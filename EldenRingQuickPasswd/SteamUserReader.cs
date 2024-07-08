using System.Text;
using System.Text.RegularExpressions;

namespace EldenRingQuickPasswd
{
    public class SteamUser
    {
        public string SteamId { get; set; }
        public string AccountName { get; set; }
        public string PersonaName { get; set; }

        public override string ToString()
        {
            return $"Steam ID: {SteamId}"+ Environment.NewLine + $"账号: {AccountName}"+ Environment.NewLine + $"用户名: {PersonaName}"+ Environment.NewLine;
        }
    }

    public class SteamUserReader
    {
        public List<SteamUser> GetSteamUsersAllInfo()
        {
            try
            {
                string steamInstallPath = GeneralFunctions.GetSteamInstallPath();
                string filePath = Path.Combine(steamInstallPath, @"config\loginusers.vdf");

                // 检查文件是否存在
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("Steam loginusers.vdf 文件不存在", filePath);
                }

                // 读取文件内容
                string fileContent = File.ReadAllText(filePath);

                // 解析文件内容
                return ParseVdf(fileContent);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        private List<SteamUser> ParseVdf(string vdfContent)
        {
            var users = new List<SteamUser>();

            // 匹配每个用户的正则表达式
            var userRegex = new Regex(@"""(\d+)""\s*{\s*""AccountName""\s*""([^""]+)""\s*""PersonaName""\s*""([^""]+)""", RegexOptions.Compiled);

            var matches = userRegex.Matches(vdfContent);
            foreach (Match match in matches)
            {
                var user = new SteamUser
                {
                    SteamId = match.Groups[1].Value,
                    AccountName = match.Groups[2].Value,
                    PersonaName = match.Groups[3].Value
                };

                users.Add(user);
            }

            return users;
        }
    }
}