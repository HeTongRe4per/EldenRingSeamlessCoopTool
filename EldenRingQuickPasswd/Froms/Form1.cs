namespace EldenRingQuickPasswd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadSteamUsers();
        }

        private void LoadSteamUsers()
        {
            try
            {
                var steamUserReader = new SteamUserReader();
                var steamUsers = steamUserReader.GetSteamUsersAllInfo();

                textBox1.Clear();

                foreach (var user in steamUsers)
                {
                    textBox1.AppendText(user.ToString() + Environment.NewLine);
                    comboBox1.Items.Add(user.SteamId.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"读取 Steam 用户信息时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckSelentAndBak()
        {
            //string[] filesName = GetFilesNameInDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EldenRing", comboBox1.SelectedItem.ToString()));

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("请选择正确用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            } else
            {
                string steamId = comboBox1.SelectedItem.ToString();
                ChangeSaves.BakupSaves(steamId);
                return true;
            }
        }

        private string GetExtension()
        {
            string gamePath = GeneralFunctions.FindGamePath();
            if (gamePath == null)
            {
                MessageBox.Show($"未找到游戏路径{gamePath}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return $"未找到游戏路径{gamePath}";
            }
            string iniFilePath = Path.Combine(gamePath, "GAME", "SeamlessCoop", "ersc_settings.ini");
            string section = "SAVE";
            string key = "save_file_extension";
            string saveFileExtension = GeneralFunctions.ReadIniValue(iniFilePath, section, key);
            return saveFileExtension;
        }

        private void ModifyExtensions(bool toCo2)
        {
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EldenRing", comboBox1.SelectedItem.ToString());
            string modExt = "." + GetExtension();
            string oldExt = toCo2 ? ".sl2" : modExt;
            string newExt = toCo2 ? modExt : ".sl2";

            if (Directory.Exists(directoryPath))
            {
                string[] files = { Path.Combine(directoryPath, $"ER0000{oldExt}"), Path.Combine(directoryPath, $"ER0000{oldExt}.bak") };
                bool filesToModifyExist = false;

                // 检查是否存在需要被修改的文件名
                foreach (string filePath in files)
                {
                    if (File.Exists(filePath))
                    {
                        filesToModifyExist = true;
                        break;
                    }
                }

                // 如果不存在需要修改的文件，弹出提示框
                if (!filesToModifyExist)
                {
                    DialogResult result = MessageBox.Show($"未找到需要修改的文件，是否要前往文件夹进行检查？", "未找到文件", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // 打开文件夹
                        System.Diagnostics.Process.Start("explorer.exe", directoryPath);
                    }
                    return;
                }

                // 进行文件名转换
                foreach (string filePath in files)
                {
                    string newFilePath = filePath.Replace(oldExt, newExt);
                    string newFilePathBak = newFilePath + ".bak";

                    if (File.Exists(newFilePath))
                    {
                        string backupFilePath = newFilePath + ".htbak";
                        File.Move(newFilePath, backupFilePath);
                    }

                    if (File.Exists(newFilePathBak))
                    {
                        string backupFilePathBak = newFilePathBak + ".htbak";
                        File.Move(newFilePathBak, backupFilePathBak);
                    }

                    if (File.Exists(filePath))
                    {
                        File.Move(filePath, newFilePath);
                    }
                }
                MessageBox.Show($"所有文件已从 {oldExt} 修改为 {newExt}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    private void RecoverExtension()
        {
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EldenRing", comboBox1.SelectedItem.ToString());
            if (Directory.Exists(directoryPath))
            {
                string[] bakFiles = Directory.GetFiles(directoryPath, "*.htbak");

                if (bakFiles.Length == 0)
                {
                    MessageBox.Show("未找到备份文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (string bakFile in bakFiles)
                {
                    // 获取原始文件名（去掉 .htbak 后缀）
                    string originalFileName = bakFile.Substring(0, bakFile.Length - 6);
                    string newFilePath = Path.Combine(directoryPath, originalFileName);

                    // 检查目标文件是否已经存在
                    if (File.Exists(newFilePath))
                    {
                        DialogResult result = MessageBox.Show($"文件 {originalFileName} 已经存在，是否要前往文件夹进行检查？", "文件存在", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            // 打开文件夹
                            System.Diagnostics.Process.Start("explorer.exe", directoryPath);
                        }
                        return;
                    }

                    // 将备份文件恢复到原始扩展名
                    File.Move(bakFile, newFilePath);
                }

                MessageBox.Show("所有备份文件已恢复到原始扩展名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckSelentAndBak())
            {
                ModifyExtensions(false); // 将 .co2 修改为 .sl2
            }
            else
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckSelentAndBak())
            {
                ModifyExtensions(true); // 将 .sl2 修改为 .co2
            }
            else
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CheckSelentAndBak())
            {
                RecoverExtension();
            }
        }
    }
}