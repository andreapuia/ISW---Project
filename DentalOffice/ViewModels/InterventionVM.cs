using DentalOffice.Models;
using DentalOffice.Models.DataAccesslayer;
using System.Collections.ObjectModel;

namespace DentalOffice.ViewModels
{
    public class InterventionVM : BaseVM
    {

        public class Obj
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Price { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
        }

        private ObservableCollection<Obj> objects;
        public ObservableCollection<Obj> Objects
        {
            get { return this.objects; }
            set { this.objects = value; OnPropertyChanged("Objects"); }
        }


        public InterventionVM()
        {
            Objects = new ObservableCollection<Obj>();

            foreach(Intervention intervention in InterventionDAL.GetInterventionsPr())
            {
                Price price = PriceDAL.GetCurrentPricePr(intervention);
                if(price != null)
                {
                    Objects.Add(
                        new Obj()
                        {
                            ID = intervention.ID,
                            Name = intervention.Name,
                            Price = price.Value.ToString() + " €",
                            StartDate = price.StartDateStr,
                            EndDate = price.EndDateStr
                });
                   
                }
            }
            

        }
    }
}