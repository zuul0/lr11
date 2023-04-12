using lr11;
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
                User user1 = new User(textBoxLog.Text, this.GetHashString(textBoxPass.Text), textBoxName.Text, textBoxSur.Text, textBoxBirthday.Text, textBoxEmail.Text, textBoxPhone.Text, textBoxNapr.Text, textBoxAmount.Text, textBoxData.Text);

                if (db.Users.Count() > 0)
                {
                    foreach (User user in db.Users)
                    {
                        if ( user1.Email != user.Email)
                        {
                            db.Users.Add(user1);
                           
                            MessageBox.Show("Аккаунт " + textBoxLog.Text + " успешно добавлен");                  

                }
                        else
                        {
                            MessageBox.Show("Пользователь с таким логином или email уже существует");
                            textBoxEmail.Clear();
                           
                            continue;
                        }
                    }  Авторизация auto = new Авторизация();
                    this.Hide();
                    auto.Show();
                    db.SaveChanges();
            }
               
                
            }  
                

                    /* using (UserContext db = new UserContext())
                     {
                         User user = new User(textBoxLog.Text, this.GetHashString(textBoxPass.Text), textBoxName.Text, textBoxSur.Text, textBoxBirthday.Text,  textBoxEmail.Text, textBoxPhone.Text, textBoxNapr.Text, textBoxAmount.Text, textBoxData.Text);
                         db.Users.Add(user);
                         db.SaveChanges();
                         MessageBox.Show("Регистрация успешна!");
                     
 Авторизация auto = new Авторизация();
            auto.Show();
            this.Hide();
                }

    
        private void Регистрация_Load(object sender, EventArgs e)
        {

        }}*/
                }
            }
        }

        
 