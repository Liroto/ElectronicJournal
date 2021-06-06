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

namespace ElectronicJournal
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userData = textBox1.Text + "," + textBox2.Text;
            string path = @""+textBox1.Text + ".csv";
            if (File.Exists(path) == true)
            {
                MessageBox.Show("Такой пользователь уже существует.");
            }
            else
            {
                File.WriteAllText(path, userData);
                MessageBox.Show(textBox1.Text+", Вы успешно зарегистрированы!");
                Close();
            }
        }
    }
}
