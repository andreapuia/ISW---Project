using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalOffice.Enum;

namespace DentalOffice.Models
{
    public class Patient
    {
        public int ID { get; set; }

        public int IDdoctor { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CNP { get; set; }

        public string City { get; set; }

        public Deleted Deleted { get; set; }
        
        public string FullName { get; set; }


        public decimal Cost { get; set; }


        public Patient() { }

        public Patient(int ID, int IDdoctor, string FirstName, string LastName, string CNP, string City, Deleted Deleted)
        {
            this.ID = ID;
            this.IDdoctor = IDdoctor;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.CNP = CNP;
            this.City = City;
            this.Deleted = Deleted;
        }

    

        public override string ToString()
        {
            return "( ID: " + this.ID + ", doctor: " + this.IDdoctor + ", name: " + this.FirstName + " " + this.LastName + ", CNP: " + this.CNP + ", city: " + this.City + ", deleted: " + this.Deleted + " )";
        }
    }
}