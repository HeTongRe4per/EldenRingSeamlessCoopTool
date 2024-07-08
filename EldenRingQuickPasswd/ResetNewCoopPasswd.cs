namespace EldenRingQuickPasswd
{
    internal class ResetNewCoopPasswd
    {
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
                Console.WriteLine($"成功更新 {key} 到 {newPasswd}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"更新INI文件时出现错误: {ex.Message}");
            }
        }
    }
}
