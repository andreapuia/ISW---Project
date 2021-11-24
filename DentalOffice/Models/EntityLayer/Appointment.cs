using DentalOffice.Enum;
using System;

namespace DentalOffice.Models
{
    public class Appointment
    {
        public int ID { get; set; }

        public int IDpatient { get; set; }

        public DateTime Date { get; set; }

        public int Hour { get; set; }

        public Deleted Deleted { get; set; }


        public decimal Cost { get; set; }


        public string DateStr { get; set; }

        public Appointment() { }

        public Appointment(int ID, int IDpatient, DateTime Date, int Hour, Deleted Deleted)
        {
            this.ID = ID;
            this.IDpatient = IDpatient;
            this.Date = Date;
            this.Hour = Hour;
            this.Deleted = Deleted;
        }

              
        public override string ToString()
        {
            return "( ID: " + ID + ", ID patient: " + this.IDpatient + ", date: " + this.Date.ToString("yyyy-MM-dd") + ", hour: " + this.Hour + ", deleted: " + this.Deleted + " )";
        }

    }
}