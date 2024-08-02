using Narod.SteamGameFinder;

namespace EldenRingQuickPasswd
{
    internal class GeneralFunctions
    {
        public static string FindGamePath()
        {
            SteamGameLocator steamGameLocator = new SteamGameLocator();
            string gamePath = steamGameLocator.getGameInfoByFolder("ELDEN RING").steamGameLocation;
            return gamePath;
        }

        public static string GetSteamInstallPath()
        {
            SteamGameLocator steamGameLocator = new SteamGameLocator();
            string steamInstallDir = steamGameLocator.getSteamInstallLocation();

            return steamInstallDir;
        }

        public static string ReadIniValue(string filePath, string section, string key)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    bool sectionFound = false;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (line.StartsWith($"[{section}]"))
                        {
                            sectionFound = true;
                            continue;
                        }

                        if (sectionFound && line.StartsWith($"{key}"))
                        {
                            string[] parts = line.Split('=');
                            if (parts.Length >= 2)
                            {
                                return parts[1].Trim();
                            }
                        }

                        // 如果已经找到了所需部分，可以提前退出循环
                        if (sectionFound && line.StartsWith("["))
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return $"读取INI文件时出现错误: {ex.Message}";
            }
            return null;
        }
    }
}