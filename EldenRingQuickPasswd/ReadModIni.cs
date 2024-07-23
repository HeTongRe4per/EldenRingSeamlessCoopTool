namespace EldenRingQuickPasswd
{
    internal class ReadModIni
    {
        public static string GetCoopPasswd()
        {
            string gamePath = GeneralFunctions.FindGamePath();

            string iniFilePath = Path.Combine(gamePath, "GAME", "SeamlessCoop", "ersc_settings.ini");

            string coopPassword = GeneralFunctions.ReadIniValue(iniFilePath, "PASSWORD", "cooppassword");

            if (coopPassword != null)
            {
                return coopPassword;
            }
            else
            {
                return "密码为空";
            }
        }

        public static string[] GetGamePlayVar()
        {
            string gamePath = GeneralFunctions.FindGamePath();

            string iniFilePath = Path.Combine(gamePath, "GAME", "SeamlessCoop", "ersc_settings.ini");
            string[] gamePlays = ["allow_invaders", "death_debuffs", "allow_summons", "overhead_player_display"];
            string[] gamePlayVars = new string[gamePlays.Length];

            for (int i = 0; i < gamePlays.Length; i++)
            {
                string gamePlayVar = GeneralFunctions.ReadIniValue(iniFilePath, "GAMEPLAY", gamePlays[i]);
                gamePlayVars[i] = gamePlayVar != null ? gamePlays[i] + ": " + gamePlayVar : gamePlays[i] + ": 未找到变量";
            }

            return gamePlayVars;
        }

        public static string[] GetGameScalingVar()
        {
            string gamePath = GeneralFunctions.FindGamePath();

            string iniFilePath = Path.Combine(gamePath, "GAME", "SeamlessCoop", "ersc_settings.ini");
            string[] gameScalings = {"enemy_health_scaling", "enemy_damage_scaling", "enemy_posture_scaling", "boss_health_scaling", "boss_damage_scaling", "boss_posture_scaling"};
            string[] gameScalingVars = new string[gameScalings.Length];

            for (int i = 0; i < gameScalings.Length; i++)
            {
                string gameScalingVar = GeneralFunctions.ReadIniValue(iniFilePath, "SCALING", gameScalings[i]);
                gameScalingVars[i] = gameScalingVar != null ? gameScalings[i] + ": " + gameScalingVar : gameScalings[i] + ": 未找到变量";
            }

            return gameScalingVars;
        }
    }
}
