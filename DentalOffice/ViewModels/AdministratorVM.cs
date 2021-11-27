using DentalOffice.Models;
using DentalOffice.Models.DataAccesslayer;
using System.Collections.ObjectModel;

namespace DentalOffice.ViewModels
{
    public class AdministratorVM : BaseVM
    {
        #region private members

        private User selectedDoctor;
        private User currentAdmin;
        private string currentAdminText;
        private Intervention currentIntervention;
        private ObservableCollection<User> doctorsList;
        private ObservableCollection<Intervention> interventionsList;

        #endregion
        
        #region public properties

        public User CurrentAdmin
        {
            get { return this.currentAdmin; }
            set { this.currentAdmin = value; CurrentAdminText = "Welcome back, " + this.currentAdmin.FullName + "!"; }
        }

        public string CurrentAdminText
        {
            get { return this.currentAdminText; }
            set { this.currentAdminText = value; OnPropertyChanged("CurrentAdminText"); }
        }

        public ObservableCollection<User> DoctorsList
        {
            get { return this.doctorsList; }
            set { this.doctorsList = value; OnPropertyChanged("DoctorsList"); }
        }

        public User SelectedDoctor
        {
            get { return this.selectedDoctor; }
            set { this.selectedDoctor = value; OnPropertyChanged("SelectedDoctor"); }

        }

        public ObservableCollection<Intervention> InterventionsList
        {
            get { return this.interventionsList; }
            set { this.interventionsList = value; OnPropertyChanged("InterventionsList"); }
        }

        public Intervention CurrentIntervention
        {
            get { return this.currentIntervention; }
            set { this.currentIntervention = value; OnPropertyChanged("CurrentIntervention"); }
        }

        #endregion
        
        public AdministratorVM()
        {
            this.DoctorsList = UserDAL.GetDoctorsPr();
            this.InterventionsList = InterventionDAL.GetInterventionsPr();
        }
    }
}