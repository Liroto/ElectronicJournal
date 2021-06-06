using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace ElectronicJournal
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            reg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string logPath = @"" + textBox1.Text + ".csv";
            FileInfo presentUser = new FileInfo(logPath);

            if (textBox1.Text == "dekanat" && textBox2.Text == "dekanat")
            {
                DekanatForm dekanat = new DekanatForm();
                dekanat.Show();
            }
            else if(presentUser.Exists)
            {
                string currentPassword;
                using (TextFieldParser tfp = new TextFieldParser(logPath))
                {
                    tfp.TextFieldType = FieldType.Delimited;
                    tfp.SetDelimiters(",");
                    string[] password = tfp.ReadFields();
                    currentPassword = password[1];
                }
                if (textBox2.Text == currentPassword)
                {
                    MainForm main = new MainForm();
                    main.label1.Text += textBox1.Text;
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Вероятно, вы ввели неправильный пароль.");
                }
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует!");
            }
        }
    }
}
