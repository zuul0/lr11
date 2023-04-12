using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace lr11
{

  
        
public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Napravleniye { get; set; }
        public string Amount { get; set; }
        public string Data_vpk { get; set; }
        public User()
        { }

        public User(string Login, string Password, string Name, string LastName, string Birthday, string Email, string Phone, string Napravleniye, string Amount, string Data_vpk)
        {
            this.Login = Login;
            this.Password = Password;
            this.Name = Name;
            this.LastName = LastName;
            this.Birthday = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Napravleniye = Napravleniye;
            this.Amount = Amount;
            this.Data_vpk = Data_vpk;
        }


    }
    /*

    */

}
