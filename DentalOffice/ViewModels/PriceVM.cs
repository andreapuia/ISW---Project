using DentalOffice.Models;
using DentalOffice.Models.DataAccesslayer;
using System.Collections.ObjectModel;


namespace DentalOffice.ViewModels
{
    public class PriceVM : BaseVM
    {

        #region private members

        private ObservableCollection<Price> pricesList;
        private Intervention currentIntervention;

        #endregion

        public ObservableCollection<Price> PricesList
        {
            get { return this.pricesList; }
            set { this.pricesList = value; OnPropertyChanged("PricesList"); }
        }

        public Intervention CurrentIntervention
        {
            get { return this.currentIntervention; }
            set { this.currentIntervention = value ; OnPropertyChanged("CurrentIntervention"); PricesList = SortPricesList(); }
        }

        public PriceVM()
        {
          
        }

        public ObservableCollection<Price> SortPricesList()
        {
            ObservableCollection<Price> auxList = new ObservableCollection<Price>();
            
            foreach (Price price in PriceDAL.GetPricesPr())
            {
                if(price.IDintervention == this.CurrentIntervention.ID)
                {
                    auxList.Add(price);
                }
            }

            return auxList;
        }
    }
}