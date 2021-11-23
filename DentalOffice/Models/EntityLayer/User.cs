using DentalOffice.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.Models
{
    public class User
    {
        public int ID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Role Role { get; set; }

        public Deleted Deleted { get; set; }
        
        public string FullName { get;set; }


        public User() { }

        public User(int ID, string Username, string Password, string FirstName, string LastName, Role Role, Deleted Status)
        {
            this.ID = ID;
            this.Username = Username;
            this.Password = Password;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Role = Role;
            this.Deleted = Deleted;
        }

    
        public override string ToString()
        {
            return "( ID: " + this.ID + ", username: " + this.Username + ", password: " + this.Password + ", name: " + this.FirstName + " " + this.LastName + ", role: " + this.Role + ", deleted: " + this.Deleted + " )" ;
        }
    }
}