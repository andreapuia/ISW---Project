using DentalOffice.Enum;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace DentalOffice.Models.DataAccesslayer
{
    public class InterventionDAL
    {
        public static void AddInterventionPr(string name, decimal price, DateTime startDate)
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("addInterventionPr", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter OutputPar = new SqlParameter("@output", SqlDbType.Int);
                OutputPar.Direction = ParameterDirection.Output;
                SqlParameter Namepar = new SqlParameter("@Name", name);
                SqlParameter PricePar = new SqlParameter("@Price", price);
                SqlParameter StartDatePar = new SqlParameter("@StartDate", startDate);
                SqlParameter EndDatePar = new SqlParameter("@EndDate", startDate);
                cmd.Parameters.Add(OutputPar);
                cmd.Parameters.Add(Namepar);
                cmd.Parameters.Add(PricePar);
                cmd.Parameters.Add(StartDatePar);
                cmd.Parameters.Add(EndDatePar);
                con.Open();
                cmd.ExecuteNonQuery();
                
                if ((OutputPar.Value as int?) == 1)
                {
                    MessageBox.Show("Error at start date!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if ((OutputPar.Value as int?) == 2)
                {
                    MessageBox.Show("Intervention already exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Operation successfully completed!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
        }

        public static ObservableCollection<Intervention> GetInterventionsPr()
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getInterventionsPr", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                ObservableCollection<Intervention> result = new ObservableCollection<Intervention>();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add
                    (
                        new Intervention()
                        {
                            ID = (int)(reader[0]),
                            Name = reader.GetString(1),
                            Deleted = Util.DeletedToString(reader.GetString(2))
                        }
                    );
                }
                reader.Close();
                return result;

            }
        }
        
        public static void DeleteInterventionPr(Intervention intervention)
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("deleteInterventionPr", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter id = new SqlParameter("@id", intervention.ID);

                cmd.Parameters.Add(id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateInterventionPr(Intervention intervention, decimal price, DateTime startDate)
        {
            using (SqlConnection con = Helper.Connection)
            {
              
                SqlCommand cmd = new SqlCommand("updateInterventionPr", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter OutputPar = new SqlParameter("@output", SqlDbType.Int);
                OutputPar.Direction = ParameterDirection.Output;

                SqlParameter LimitPar = new SqlParameter("@limit", SqlDbType.Date);
                LimitPar.Direction = ParameterDirection.Output;

                SqlParameter IDPar = new SqlParameter("@id", intervention.ID);
                SqlParameter PricePar = new SqlParameter("@Price", price);
                SqlParameter StartDatePar = new SqlParameter("@StartDate", startDate);

                cmd.Parameters.Add(OutputPar);
                cmd.Parameters.Add(LimitPar);
                cmd.Parameters.Add(IDPar);
                cmd.Parameters.Add(PricePar);
                cmd.Parameters.Add(StartDatePar);

                con.Open();
                cmd.ExecuteNonQuery();

                if (OutputPar.Value as int? == 1)
                {
                    DateTime? _date = LimitPar.Value as DateTime?;
                    DateTime date = default(DateTime);
                    if (_date.HasValue)
                    {
                        date = _date.Value;
                    }

                    MessageBox.Show("Error! The intervention has the price defined until: " + date.ToString("yyyy-MM-dd"), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Operation successfully completed!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        
        public static ObservableCollection<Intervention> GetInterventionsFromAnAppPr(Appointment appointment)
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getInterventionsFromAnAppPr", con);
                cmd.CommandType = CommandType.StoredProcedure;
                

                SqlParameter IDPar = new SqlParameter("@idAppointment", appointment.ID);
                cmd.Parameters.Add(IDPar);

                
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ObservableCollection<Intervention> result = new ObservableCollection<Intervention>();
                while (reader.Read())
                {
                    result.Add
                    (
                        new Intervention()
                        {
                            ID = (int)(reader[0]),
                            Name = reader.GetString(1),
                            Deleted = Util.DeletedToString(reader.GetString(2))
                        }
                    );
                }
                reader.Close();
                return result;

            }
        }


      

    }
}
