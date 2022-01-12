using DentalOffice.Models;
using DentalOffice.Models.DataAccesslayer;
using System.Collections.ObjectModel;

namespace DentalOffice.ViewModels
{
    public class DoctorVM : BaseVM
    {
        #region private members

        private Patient selectedPatient;
        private Appointment selectedAppointment;

        private User currentDoctor;
        private string currentDoctorText;

        private ObservableCollection<Patient> patientsList;
        private ObservableCollection<Appointment> appointmentsList;
        private ObservableCollection<Intervention> interventionsList;

        #endregion


        #region public properties

        public User CurrentDoctor
        {
            get { return this.currentDoctor; }
            set { this.currentDoctor = value; OnPropertyChanged("CurrentDoctor"); CurrentDoctorText = "Welcome back, dr. " + this.currentDoctor.FullName + "!"; InitializePatientsList(); }
        }

        public string CurrentDoctorText
        {
            get { return this.currentDoctorText; }
            set { this.currentDoctorText = value; OnPropertyChanged("currentDoctorText"); }
        }

        public ObservableCollection<Patient> PatientsList
        {
            get { return this.patientsList; }
            set { this.patientsList = value; OnPropertyChanged("PatientsList"); }
        }

        public Patient SelectedPatient
        {
            get { return this.selectedPatient; }
            set { this.selectedPatient = value; }
        }

        public ObservableCollection<Appointment> AppointmentsList
        {
            get { return this.appointmentsList; }
            set { this.appointmentsList = value; OnPropertyChanged("AppointmentsList"); }
        }

        public Appointment SelectedAppointment
        {
            get { return this.selectedAppointment; }
            set { this.selectedAppointment = value; OnPropertyChanged("SelectedAppointment"); }
        }

        public ObservableCollection<Intervention> InterventionsList
        {
            get { return this.interventionsList; }
            set { this.interventionsList = value; OnPropertyChanged("InterventionsList"); }
        }

        #endregion

        public DoctorVM()
        {
            
        }

        public void InitializePatientsList()
        {
            PatientsList = PatientDAL.GetPatientsFromADoctorPr(this.CurrentDoctor);
            InterventionsList = new ObservableCollection<Intervention>();
        }

    }
}