namespace EldenRingQuickPasswd
{
    internal class ReadCoopPasswd
    {
        public static string GetCoopPasswd()
        {
            string gamePath = GeneralFunctions.FindGamePath();
            if (gamePath == null)
            {
                return $"未找到游戏路径{gamePath}";
            }

            string iniFilePath = Path.Combine(gamePath, "GAME", "SeamlessCoop", "ersc_settings.ini");
            string section = "PASSWORD";
            string key = "cooppassword";

            string coopPassword = GeneralFunctions.ReadIniValue(iniFilePath, section, key);

            if (coopPassword != null)
            {
                return coopPassword;
            }
            else
            {
                return "密码为空";
            }
        }
    }
}
