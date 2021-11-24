using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalOffice.Enum;

namespace DentalOffice.Models
{
    public class Intervention
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Deleted Deleted { get; set; }


        public Intervention() { }

        public Intervention(int ID, string Name, Deleted Deleted)
        {
            this.ID = ID;
            this.Name = Name;
            this.Deleted = Deleted;
        }
        
        public override string ToString()
        {
            return "( ID: " + this.ID + ", name: " + this.Name + ", deleted: " + this.Deleted + " )"; 
        }
    }
}