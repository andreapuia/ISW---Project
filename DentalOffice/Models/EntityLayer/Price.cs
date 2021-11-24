using DentalOffice.Enum;
using System;

namespace DentalOffice.Models
{
    public class Price
    {
        public int ID { get; set; }

        public int IDintervention { get; set; }

        public decimal Value { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Deleted Deleted { get; set; }


        public string StartDateStr { get; set; }

        public string EndDateStr { get; set; }


        public Price() { }

        public Price(int ID, int IDintervention, decimal Value, DateTime StartDate, DateTime EndDate, Deleted Deleted)
        {
            this.ID = ID;
            this.IDintervention = IDintervention;
            this.Value = Value;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Deleted = Deleted;
        }

       

        
        public override string ToString()
        {
            return "( ID: " + this.ID +", IDintervention: " + this.IDintervention + ", value: " + this.Value + " €, start date: " + this.StartDate.ToString("yyyy-MM-dd") + ", end date: " + this.EndDate.ToString("yyyy-MM-dd")  + " )";
        }
    }
}