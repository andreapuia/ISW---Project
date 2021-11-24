using DentalOffice.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DentalOffice.Models.DataAccesslayer
{
    public class PriceDAL
    {
        public static Price GetCurrentPricePr(Intervention intervention)
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getCurrentPricePr", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter OutputPar = new SqlParameter("@output", SqlDbType.Int);
                OutputPar.Direction = ParameterDirection.Output;
                SqlParameter IdPar = new SqlParameter("@id", intervention.ID);

                cmd.Parameters.Add(OutputPar);
                cmd.Parameters.Add(IdPar);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Price price = new Price();
                while (reader.Read())
                {
                    price.ID = (int)(reader[0]);
                    price.IDintervention = (int)(reader[1]);
                    price.Value = reader.GetDecimal(2);
                    price.StartDate = reader.GetDateTime(3);
                    price.EndDate = reader["EndDate"] != DBNull.Value ? reader.GetDateTime(4) : default(DateTime);
                    price.Deleted = Util.DeletedToString(reader.GetString(5));

                    price.StartDateStr = price.StartDate.ToString("yyyy-MM-dd");
                    if (price.EndDate == default(DateTime))
                    {
                        price.EndDateStr = "undefined";
                    }
                    else
                    {
                        price.EndDateStr = price.EndDate.ToString("yyyy-MM-dd");
                    }

                    price.Deleted = Util.DeletedToString(reader.GetString(5));
                }
                reader.Close();

                if(OutputPar.Value as int? == 1)
                {
                    return null;
                }

                return price;
            }
        }

        public static ObservableCollection<Price> GetPricesPr()
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getPricesPr", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                ObservableCollection<Price> result = new ObservableCollection<Price>();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Price price = new Price();
                    price.ID = (int)(reader[0]);
                    price.IDintervention = (int)(reader[1]);
                    price.Value = reader.GetDecimal(2);
                    price.StartDate = reader.GetDateTime(3);
                    price.EndDate = reader["EndDate"] != DBNull.Value ? reader.GetDateTime(4) : default(DateTime);
                    price.Deleted = Util.DeletedToString(reader.GetString(5));

                    price.StartDateStr = price.StartDate.ToString("yyyy-MM-dd");
                    if (price.EndDate == default(DateTime))
                    {
                        price.EndDateStr = "undefined";
                    }
                    else
                    {
                        price.EndDateStr = price.EndDate.ToString("yyyy-MM-dd");
                    }
                    
                    
                    result.Add(price);
                }
                reader.Close();
                return result;
            }
        }
    }
}