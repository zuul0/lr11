using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lr11
{
    public partial class Регистрация : Form
    {
        public Регистрация()
        {
            InitializeComponent();
        }
        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                User user = new User(textBoxLog.Text, this.GetHashString(textBoxPass.Text), textBox4.Text, textBox3.Text, textBoxEmail.Text, textBox9.Text, textBox8.Text, textBox7.Text, textBox1.Text, textBox1.Text);
                db.Users.Add(user);
                db.SaveChanges();
                MessageBox.Show("Регистрация успешна!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Авторизация auto = new Авторизация();
            auto.Show();
            this.Hide();
        }

        private void Регистрация_Load(object sender, EventArgs e)
        {

        }
    }
}
