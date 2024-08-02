namespace EldenRingQuickPasswd
{
    public partial class Form3 : Form
    {
        private CheckBox[] checkBoxArray;
        private TextBox[] textBoxArray;
        static bool flag = true;

        public Form3()
        {
            InitializeComponent();

            string gamePath = GeneralFunctions.FindGamePath();
            string iniFilePath = Path.Combine(gamePath, "GAME", "SeamlessCoop", "ersc_settings.ini");

            // 检查文件路径是否存在
            if (!File.Exists(iniFilePath))
            {
                flag = false;
                MessageBox.Show("找到ini文件，请检查Mod是否安装正确", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            checkBoxArray = [checkBox1, checkBox2, checkBox3];
            textBoxArray = [textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8];
            if (flag) InitializeWindow();

            bool steamFlag = Directory.Exists(gamePath), iniFlag = flag;
            //MessageBox.Show($"Steam {steamFlag} 位置：\n{gamePath}\nini {iniFlag} 位置：\n{iniFilePath}");
        }

        private void InitializeWindow()
        {
            textBox1.Text = ReadModIni.GetCoopPasswd();
            textBox2.Text = ReadModIni.GetCoopPasswd();

            string[] gamePlayVars = ReadModIni.GetGamePlayVar();
            if (gamePlayVars.Length > 0)
            {
                // 遍历所有变量并设置对应的 CheckBox
                foreach (string gamePlayVar in gamePlayVars)
                {
                    string[] parts = gamePlayVar.Split(':');
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();

                        switch (key)
                        {
                            case "allow_invaders":
                                checkBox1.Checked = (value == "1"); break;
                            case "death_debuffs":
                                checkBox2.Checked = (value == "1"); break;
                            case "allow_summons":
                                checkBox3.Checked = (value == "1"); break;
                            case "overhead_player_display":
                                domainUpDown1.SelectedIndex = Convert.ToInt32(value); break;
                        }
                    }
                }
            }

            string[] gameCalingVars = ReadModIni.GetGameScalingVar();
            if (gameCalingVars.Length > 0)
            {
                foreach (string gameCalingVar in gameCalingVars)
                {
                    string[] parts = gameCalingVar.Split(':');
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();

                        switch (key)
                        {
                            case "enemy_health_scaling":
                                textBox3.Text = value; break;
                            case "enemy_damage_scaling":
                                textBox4.Text = value; break;
                            case "enemy_posture_scaling":
                                textBox5.Text = value; break;
                            case "boss_health_scaling":
                                textBox6.Text = value; break;
                            case "boss_damage_scaling":
                                textBox7.Text = value; break;
                            case "boss_posture_scaling":
                                textBox8.Text = value; break;
                        }
                    }
                }
            }
        }

        private int[] ReadGameplayComponent()
        {
            int[] gameplay = new int[4];

            // 读取设定部分
            for (int i = 0; i < gameplay.Length - 1; i++)
            {
                gameplay[i] = (checkBoxArray[i].Checked) ? 1 : 0;
            }
            gameplay[gameplay.Length - 1] = domainUpDown1.SelectedIndex;

            return gameplay;
        }

        private int[] ReadScalingComponet()
        {
            int[] scaling = new int[6];

            // 读取数值部分
            for (int i = 0, j = 2; i < scaling.Length; i++, j++)
            {
                int temp = Convert.ToInt32(textBoxArray[j].Text);
                if (temp >= 0 && temp <= 100) scaling[i] = temp;
                else 
                { 
                    MessageBox.Show("数值设定部分请输入0~100的值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            return scaling;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                string newPasswd = textBox2.Text;
                int[] newScaling = ReadScalingComponet();
                int[] newGameplay = ReadGameplayComponent();

                ResetNewModIni.ResetCoopPasswd(newPasswd);
                ResetNewModIni.ResetScaling(newScaling);
                ResetNewModIni.ResetGameplay(newGameplay);

                ResetNewModIni.SuccessMassge();

                InitializeWindow();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                DialogResult dialogResult = MessageBox.Show("确定恢复默认设定？", "恢复默认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {

                    string newPasswd = null;
                    int[] newScaling = {35, 0, 15, 100, 0, 20};
                    int[] newGameplay = {1, 1, 1, 0};

                    ResetNewModIni.ResetCoopPasswd(newPasswd);
                    ResetNewModIni.ResetScaling(newScaling);
                    ResetNewModIni.ResetGameplay(newGameplay);

                    ResetNewModIni.SuccessMassge();

                    InitializeWindow();
                }
            }
        }
    }
}
