using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Drawing.Text;

namespace lr11
{
    public partial class ВосстановлениеПароля : Form
    {
        public ВосстановлениеПароля()
        {
            InitializeComponent();
        }
        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            MD5CryptoServiceProvider CSP = new
            MD5CryptoServiceProvider();
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
            try
            {
                MailAddress from = new MailAddress("z.davl@yandex.ru", "dzuu");
                MailAddress to = new MailAddress(textBoxEmail.Text);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Тест";
                using (UserContext db = new UserContext())
                {
                    foreach (User user in db.Users)
                    {
                        if (textBoxEmail.Text == user.Email)
                        {
                            string newPasword = GeneratePass();
                            m.Body = "<h1>Пароль: " + newPasword + "</h1>";
                            user.Password = GetHashString(newPasword); 
                            MessageBox.Show("Пароль отправлен на почту: " + newPasword);
                        }
                    }
                }
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                smtp.Credentials = new NetworkCredential("z.davl@yandex.ru", "hkDMFks9PX");
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
            catch
            {
                MessageBox.Show("Error");
            }
           
        }

        private string GeneratePass()
        {
 string Passw = "";
            char[] arr = { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'A', 'B', 'C', 'D', 'E', 'F', 'd', 'c', 'e', 'f', '?' };
        Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Passw = Passw + arr[rnd.Next(arr.Length)].ToString();
            }
            return Passw;
        }
    }
}
