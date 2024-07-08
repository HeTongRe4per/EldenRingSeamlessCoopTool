namespace EldenRingQuickPasswd
{
    internal class GeneralFunctions
    {
        public static string FindGamePath()
        {
            string gamePath = null;
            string steamInstallPath = GetSteamInstallPath();
            string gameId = "1245620";
            string steamAppsPath = Path.Combine(steamInstallPath, "steamapps");

            // 搜索appmanifest文件
            string[] manifestFiles = Directory.GetFiles(steamAppsPath, $"appmanifest_{gameId}.acf");
            if (manifestFiles.Length > 0)
            {
                string manifestContent = File.ReadAllText(manifestFiles[0]);
                var match = System.Text.RegularExpressions.Regex.Match(manifestContent, "\"installdir\"\\s+\"([^\"\r\n]+)\"");
                if (match.Success)
                {
                    gamePath = Path.Combine(steamAppsPath, "common", match.Groups[1].Value);
                }
            }
            return gamePath;
        }

        public static string GetSteamInstallPath()
        {
            const string steamRegistryKey = @"SOFTWARE\WOW6432Node\Valve\Steam";
            const string steamRegistryValue = "InstallPath";

            try
            {
                using (var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(steamRegistryKey))
                {
                    if (key != null)
                    {
                        var o = key.GetValue(steamRegistryValue);
                        if (o != null)
                        {
                            return o as string;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法找到 Steam 安装路径：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
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