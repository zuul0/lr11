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

namespace lr11
{
    public partial class ВосстановлениеПароля : Form
    {
        public ВосстановлениеПароля()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailAddress from = new MailAddress("z.davl@yandwx.ru", "Zu");
                MailAddress to = new MailAddress(textBoxEmail.Text);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Тест";
                using (UserContext db = new UserContext())
                {
                    foreach (User user in db.Users)
                    {
                        if (textBoxEmail.Text == user.Email)
                        {
                            m.Body = "<h1>Пароль: " + user.Password + "</h1>";
                        }
                    }
                }
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                smtp.Credentials = new NetworkCredential("z.davl@yandwx.ru", "hkDMFks9PX");
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
