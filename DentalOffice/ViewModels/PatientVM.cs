using DentalOffice.Models;
using DentalOffice.Models.DataAccesslayer;
using DentalOffice.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Linq;

namespace DentalOffice.ViewModels
{
    public class PatientVM : BaseVM
    {

        public class Obj
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string CNP { get; set; }
            public string City { get; set; }
            public int Interventions { get; set; }
        }


        private User currentDoctor;
        private ObservableCollection<Obj> objects;

        public ObservableCollection<Obj> Objects
        {
            get { return this.objects; }
            set { this.objects = value; OnPropertyChanged("Objects"); }
        }

        public User CurrentDoctor
        {
            get { return this.currentDoctor; }
            set { this.currentDoctor = value; UpdateObjects(); OnPropertyChanged("CurrentDoctor"); }
        }

        public PatientVM()
        {
            
        }

        public void UpdateObjects()
        {
            Objects = new ObservableCollection<Obj>();

            foreach (Patient patient in PatientDAL.GetPatientsFromADoctorPr(CurrentDoctor))
            {
                int count = 0;
                foreach (Appointment appointment in AppointmentDAL.GetAppointmentsFromAPatientPr(patient))
                {
                    foreach (Agenda agenda in AgendaDAL.GetAgendasPr())
                    {
                        if (agenda.IDappointment == appointment.ID)
                        {
                            count++;
                        }
                    }
                }

                Objects.Add(new Obj()
                {
                    ID = patient.ID,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    CNP = patient.CNP,
                    City = patient.City,
                    Interventions = count

                });
            }

            var enumerable = Objects.OrderBy(obj => obj.Interventions); // sortarea listei de pacienti in functie de interventie
            Objects = new ObservableCollection<Obj>(enumerable);

        }
    }
}