namespace EldenRingQuickPasswd
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            LoadCoopPassword();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newPasswd = textBox2.Text;
            ResetNewCoopPasswd.ResetCoopPasswd(newPasswd);
            LoadCoopPassword();
        }

        private void LoadCoopPassword()
        {
            textBox1.Text = ReadCoopPasswd.GetCoopPasswd();
        }
    }
}
