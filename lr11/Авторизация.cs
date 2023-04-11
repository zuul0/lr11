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

namespace lr11
{
    public partial class Авторизация : Form
    {
        public Авторизация()
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
        private void Form1_Load(object sender, EventArgs e)
        {

     
     }



        private void Авторизация_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
             
                if (db.Users.Count() > 0)
                {
                    foreach (User user in db.Users)
                    {
                        if (textBoxLog.Text == user.Login &&
                            this.GetHashString(textBoxPass.Text) == user.Password)
                        { 
                            ФормаПользователя userForm = new ФормаПользователя();
                            userForm.label1.Text = ("Логин: ") + user.Login;
                            userForm.label2.Text = ("Имя: ") + user.Name;
                            userForm.label3.Text = ("Фамилия: ") + user.LastName;
                            userForm.label4.Text = ("Дата рождения: ") + user.Birthday;
                            userForm.label5.Text = ("Email: ") + user.Email;
                            userForm.label6.Text = ("Телефон: ") + user.Phone;
                            userForm.label9.Text = ("Количество изданий: ") + user.Amount;
                            userForm.label7.Text = ("Направление_творчества: ") + user.Napravleniye;
                            userForm.label8.Text = ("Дата_первой_публикации: ") + user.Data_vpk;
                            MessageBox.Show("Вы вошли под учетной записью: " + user.Login);
                           
                            this.Hide();
                            userForm.Show();
                            break;
                        }
                    }
                    
                        MessageBox.Show("Логин или пароль указан неверно!");
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Регистрация reg = new Регистрация();
            reg.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        /* private void label5_Click(object sender, EventArgs e)
         {
             ВосстановлениеПароля recover = new ВосстановлениеПароля();
             recover.Show();
             this.Hide();
         }*/
    }
}
