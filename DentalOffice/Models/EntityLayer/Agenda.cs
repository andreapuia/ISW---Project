using DentalOffice.Enum;

namespace DentalOffice.Models.EntityLayer
{
    public class Agenda
    {

        public int ID { get; set; }

        public int IDappointment { get; set; }

        public int IDintervention { get; set; }

        public Deleted Deleted { get; set; }

        public Agenda() { }

        public Agenda(int ID, int IDappointment, int IDintervention, Deleted Deleted)
        {
            this.ID = ID;
            this.IDappointment = IDappointment;
            this.IDintervention = IDintervention;
            this.Deleted = Deleted;
        }

        public override string ToString()
        {
            return "( ID: " + ID + ", ID appointment: " + this.IDappointment + ", ID intervention: " + this.IDintervention + ", deleted: " + this.Deleted + " )";
        }


    }
}