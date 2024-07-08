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
                MessageBox.Show($"��ȡ Steam �û���Ϣʱ��������{ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckSelentAndBak()
        {
            //string[] filesName = GetFilesNameInDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EldenRing", comboBox1.SelectedItem.ToString()));

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("��ѡ����ȷ�û�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"δ�ҵ���Ϸ·��{gamePath}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return $"δ�ҵ���Ϸ·��{gamePath}";
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

                // ����Ƿ������Ҫ���޸ĵ��ļ���
                foreach (string filePath in files)
                {
                    if (File.Exists(filePath))
                    {
                        filesToModifyExist = true;
                        break;
                    }
                }

                // �����������Ҫ�޸ĵ��ļ���������ʾ��
                if (!filesToModifyExist)
                {
                    DialogResult result = MessageBox.Show($"δ�ҵ���Ҫ�޸ĵ��ļ����Ƿ�Ҫǰ���ļ��н��м�飿", "δ�ҵ��ļ�", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // ���ļ���
                        System.Diagnostics.Process.Start("explorer.exe", directoryPath);
                    }
                    return;
                }

                // �����ļ���ת��
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
                MessageBox.Show($"�����ļ��Ѵ� {oldExt} �޸�Ϊ {newExt}", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("δ�ҵ������ļ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (string bakFile in bakFiles)
                {
                    // ��ȡԭʼ�ļ�����ȥ�� .htbak ��׺��
                    string originalFileName = bakFile.Substring(0, bakFile.Length - 6);
                    string newFilePath = Path.Combine(directoryPath, originalFileName);

                    // ���Ŀ���ļ��Ƿ��Ѿ�����
                    if (File.Exists(newFilePath))
                    {
                        DialogResult result = MessageBox.Show($"�ļ� {originalFileName} �Ѿ����ڣ��Ƿ�Ҫǰ���ļ��н��м�飿", "�ļ�����", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            // ���ļ���
                            System.Diagnostics.Process.Start("explorer.exe", directoryPath);
                        }
                        return;
                    }

                    // �������ļ��ָ���ԭʼ��չ��
                    File.Move(bakFile, newFilePath);
                }

                MessageBox.Show("���б����ļ��ѻָ���ԭʼ��չ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckSelentAndBak())
            {
                ModifyExtensions(false); // �� .co2 �޸�Ϊ .sl2
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
                ModifyExtensions(true); // �� .sl2 �޸�Ϊ .co2
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