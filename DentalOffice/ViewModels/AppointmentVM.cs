using DentalOffice.Models;
using DentalOffice.Models.DataAccesslayer;
using System;
using System.Collections.ObjectModel;

namespace DentalOffice.ViewModels
{
    public class AppointmentVM : BaseVM
    {
        #region private members

        private Patient currentPatient;
        private string currentPatientText;

        private ObservableCollection<Intervention> interventionsList;
        private ObservableCollection<Intervention> selectedInterventionsList;

        private Intervention currentIntervention;
        private Intervention currentSelectedIntervention;

        private DateTime currentDate;
        #endregion


        #region public properties

        public ObservableCollection<Intervention> InterventionsList
        {
            get { return this.interventionsList; }
            set { this.interventionsList = value; OnPropertyChanged("InterventionsList"); }
        }

        public ObservableCollection<Intervention> SelectedInterventionsList
        {
            get { return this.selectedInterventionsList; }
            set { this.selectedInterventionsList = value; OnPropertyChanged("SelectedInterventionsList"); }
        }

        public Patient CurrentPatient
        {
            get { return this.currentPatient; }
            set { this.currentPatient = value; OnPropertyChanged("CurrentPatient"); CurrentPatientText = "Patient: " + this.currentPatient.FullName; }
        }

        public string CurrentPatientText
        {
            get { return this.currentPatientText; }
            set { this.currentPatientText = value; OnPropertyChanged("CurrentPatientText"); }
        }

        public Intervention CurrentIntervention
        {
            get { return this.currentIntervention; }
            set { this.currentIntervention = value; OnPropertyChanged("CurrentIntervention"); }
        }
        public Intervention CurrentSelectedIntervention
        {
            get { return this.currentSelectedIntervention; }
            set { this.currentSelectedIntervention = value; OnPropertyChanged("CurrentSelectedIntervention"); }
        }

    
         
        public DateTime CurrentDate
        {
            get { return this.currentDate; }
            set { this.currentDate = value; OnPropertyChanged("CurrentDate"); }
        }

        #endregion 

        public AppointmentVM()
        {
            InterventionsList = new ObservableCollection<Intervention>();
            foreach (Intervention intervention in InterventionDAL.GetInterventionsPr())
            {
                Price price = PriceDAL.GetCurrentPricePr(intervention);
                if (price != null)
                {
                    interventionsList.Add(intervention);
                }
            }

            SelectedInterventionsList = new ObservableCollection<Intervention>();
        }

       

    }
}
