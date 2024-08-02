namespace EldenRingQuickPasswd
{
    internal class ResetNewModIni
    {
        static Boolean passwdFlag = false, gameplayFlag = false, scalingFlag = false;
        
        public static void ResetCoopPasswd(string newPasswd)
        {
            string iniFilePath = Path.Combine(GeneralFunctions.FindGamePath(), "GAME", "SeamlessCoop", "ersc_settings.ini");
            string section = "PASSWORD";
            string key = "cooppassword";

            try
            {
                // 读取原始INI文件内容
                string[] lines = File.ReadAllLines(iniFilePath);

                // 准备修改后的INI内容
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();
                    if (line.StartsWith($"[{section}]"))
                    {
                        // 找到密码所在行
                        for (int j = i + 1; j < lines.Length; j++)
                        {
                            string innerLine = lines[j].Trim();
                            if (innerLine.StartsWith($"{key}"))
                            {
                                // 替换密码值
                                lines[j] = $"{key} = {newPasswd}";
                                break;
                            }
                        }
                        break;
                    }
                }

                // 将修改后的内容写回文件
                File.WriteAllLines(iniFilePath, lines);
                passwdFlag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"更新INI文件时出现错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ResetGameplay(int[] newGameplay)
        {
            string iniFilePath = Path.Combine(GeneralFunctions.FindGamePath(), "GAME", "SeamlessCoop", "ersc_settings.ini");
            string section = "GAMEPLAY";
            string[] keys = { "allow_invaders", "death_debuffs", "allow_summons", "overhead_player_display" };

            try
            {
                // 读取原始INI文件内容
                string[] lines = File.ReadAllLines(iniFilePath);

                // 准备修改后的INI内容
                bool sectionFound = false;
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();
                    if (line.StartsWith($"[{section}]"))
                    {
                        sectionFound = true;
                        // 找到section所在行
                        for (int j = i + 1; j < lines.Length && !lines[j].StartsWith("["); j++)
                        {
                            string innerLine = lines[j].Trim();
                            for (int k = 0; k < keys.Length; k++)
                            {
                                if (innerLine.StartsWith($"{keys[k]}"))
                                {
                                    // 替换值
                                    lines[j] = $"{keys[k]} = {newGameplay[k]}";
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }

                if (!sectionFound)
                {
                    MessageBox.Show($"未找到节 [{section}]", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 将修改后的内容写回文件
                File.WriteAllLines(iniFilePath, lines);
                gameplayFlag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"更新INI文件时出现错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ResetScaling(int[] newScaling)
        {
            string iniFilePath = Path.Combine(GeneralFunctions.FindGamePath(), "GAME", "SeamlessCoop", "ersc_settings.ini");
            string section = "SCALING";
            string[] keys = { "enemy_health_scaling", "enemy_damage_scaling", "enemy_posture_scaling", "boss_health_scaling", "boss_damage_scaling", "boss_posture_scaling" };

            try
            {
                // 读取原始INI文件内容
                string[] lines = File.ReadAllLines(iniFilePath);

                // 准备修改后的INI内容
                bool sectionFound = false;
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();
                    if (line.StartsWith($"[{section}]"))
                    {
                        sectionFound = true;
                        // 找到section所在行
                        for (int j = i + 1; j < lines.Length && !lines[j].StartsWith("["); j++)
                        {
                            string innerLine = lines[j].Trim();
                            for (int k = 0; k < keys.Length; k++)
                            {
                                if (innerLine.StartsWith($"{keys[k]}"))
                                {
                                    // 替换值
                                    lines[j] = $"{keys[k]} = {newScaling[k]}";
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }

                if (!sectionFound)
                {
                    MessageBox.Show($"未找到节 [{section}]", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 将修改后的内容写回文件
                File.WriteAllLines(iniFilePath, lines);
                scalingFlag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"更新INI文件时出现错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SuccessMassge()
        {
            if (passwdFlag && gameplayFlag && scalingFlag)
                MessageBox.Show("成功更新ini文件\n如果是在游戏运行中修改需要重启游戏后才能生效", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
