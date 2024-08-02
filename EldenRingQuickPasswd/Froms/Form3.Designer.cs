namespace EldenRingQuickPasswd
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            groupBox1 = new GroupBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            groupBox2 = new GroupBox();
            label3 = new Label();
            domainUpDown1 = new DomainUpDown();
            groupBox3 = new GroupBox();
            groupBox5 = new GroupBox();
            textBox8 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            textBox7 = new TextBox();
            label9 = new Label();
            textBox6 = new TextBox();
            groupBox4 = new GroupBox();
            label4 = new Label();
            textBox3 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            button2 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 0;
            label1.Text = "原密码：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(195, 25);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.TabIndex = 1;
            label2.Text = "新密码：";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(68, 22);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(115, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(257, 22);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(115, 23);
            textBox2.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(323, 313);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "确定";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(12, 102);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(386, 62);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "联机密码";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(18, 22);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(147, 21);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "开启入侵（默认开启）";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(18, 51);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(162, 21);
            checkBox2.TabIndex = 7;
            checkBox2.Text = "死亡Debuff（默认开启）";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(171, 22);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(207, 21);
            checkBox3.TabIndex = 8;
            checkBox3.Text = "多人时允许使用骨灰（默认开启）";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(domainUpDown1);
            groupBox2.Controls.Add(checkBox2);
            groupBox2.Controls.Add(checkBox3);
            groupBox2.Controls.Add(checkBox1);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(386, 84);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "游戏设定";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(182, 51);
            label3.Name = "label3";
            label3.Size = new Size(80, 17);
            label3.TabIndex = 10;
            label3.Text = "血条显示模式";
            // 
            // domainUpDown1
            // 
            domainUpDown1.Items.Add("默认");
            domainUpDown1.Items.Add("不显示");
            domainUpDown1.Items.Add("ping");
            domainUpDown1.Items.Add("等级");
            domainUpDown1.Items.Add("死亡次数");
            domainUpDown1.Items.Add("等级和ping");
            domainUpDown1.Location = new Point(268, 49);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.ReadOnly = true;
            domainUpDown1.Size = new Size(95, 23);
            domainUpDown1.TabIndex = 9;
            domainUpDown1.Text = "默认";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(groupBox5);
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Location = new Point(12, 170);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(386, 137);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "数值设定（每加一人/%）";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(textBox8);
            groupBox5.Controls.Add(label7);
            groupBox5.Controls.Add(label8);
            groupBox5.Controls.Add(textBox7);
            groupBox5.Controls.Add(label9);
            groupBox5.Controls.Add(textBox6);
            groupBox5.Location = new Point(195, 19);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(183, 110);
            groupBox5.TabIndex = 13;
            groupBox5.TabStop = false;
            groupBox5.Text = "BOOS";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(147, 77);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(30, 23);
            textBox8.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 22);
            label7.Name = "label7";
            label7.Size = new Size(136, 17);
            label7.TabIndex = 5;
            label7.Text = "血量加成（默认100%）";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 51);
            label8.Name = "label8";
            label8.Size = new Size(122, 17);
            label8.TabIndex = 6;
            label8.Text = "伤害加成（默认0%）";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(147, 48);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(30, 23);
            textBox7.TabIndex = 10;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 80);
            label9.Name = "label9";
            label9.Size = new Size(129, 17);
            label9.TabIndex = 7;
            label9.Text = "韧性加成（默认20%）";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(147, 19);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(30, 23);
            textBox6.TabIndex = 9;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(textBox3);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(textBox4);
            groupBox4.Controls.Add(textBox5);
            groupBox4.Location = new Point(6, 22);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(183, 107);
            groupBox4.TabIndex = 12;
            groupBox4.TabStop = false;
            groupBox4.Text = "小怪";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 19);
            label4.Name = "label4";
            label4.Size = new Size(129, 17);
            label4.TabIndex = 0;
            label4.Text = "血量加成（默认35%）";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(147, 16);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(30, 23);
            textBox3.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 77);
            label6.Name = "label6";
            label6.Size = new Size(129, 17);
            label6.TabIndex = 4;
            label6.Text = "韧性加成（默认15%）";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 48);
            label5.Name = "label5";
            label5.Size = new Size(122, 17);
            label5.TabIndex = 2;
            label5.Text = "伤害加成（默认0%）";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(147, 45);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(30, 23);
            textBox4.TabIndex = 3;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(147, 74);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(30, 23);
            textBox5.TabIndex = 8;
            // 
            // button2
            // 
            button2.Location = new Point(242, 313);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 11;
            button2.Text = "恢复默认";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 342);
            Controls.Add(button2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form3";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "修改联机规则";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private GroupBox groupBox1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private DomainUpDown domainUpDown1;
        private Label label3;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox8;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Button button2;
    }
}