using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DentalOffice.Enum;

namespace DentalOffice.Models.DataAccesslayer
{
    public class AppointmentDAL
    {
        public static ObservableCollection<int> GetUnavailableHoursPr(DateTime date)
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetUnavailableHoursPr", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlParameter DatePar = new SqlParameter("@date",date);
                cmd.Parameters.Add(DatePar);

                ObservableCollection<int> result = new ObservableCollection<int>();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add((int)(reader[0]));
                }
                reader.Close();

                return result;

            }

        }
        
        public static ObservableCollection<int> GetAvailableHours(DateTime date)
        {
            ObservableCollection<int> unavailableHours = GetUnavailableHoursPr(date);

            ObservableCollection<int> availableHours = new ObservableCollection<int>();

            for(int i=8;i<=15;i++)
            {
                if(!unavailableHours.Contains(i))
                {
                    availableHours.Add(i);
                }
            }

            return availableHours;
        }

        public static int? AddAppointmentPr(Appointment appointment)
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("addAppointmentPr", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter OutputPar = new SqlParameter("@output", SqlDbType.Int);
                OutputPar.Direction = ParameterDirection.Output;
                SqlParameter IDpatientPar = new SqlParameter("@IDpatient", appointment.IDpatient);
                SqlParameter DatePar = new SqlParameter("@Date", appointment.Date);
                SqlParameter HourPar = new SqlParameter("@Hour", appointment.Hour);

                cmd.Parameters.Add(OutputPar);
                cmd.Parameters.Add(IDpatientPar);
                cmd.Parameters.Add(DatePar);
                cmd.Parameters.Add(HourPar);
                con.Open();
                cmd.ExecuteNonQuery();

                return OutputPar.Value as int?;
            }
        }
        
        public static ObservableCollection<Appointment> GetAppointmentsFromAPatientPr(Patient patient)
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getAppointmentsFromAPatientPr", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlParameter IDPar = new SqlParameter("@id", patient.ID);
                cmd.Parameters.Add(IDPar);

                ObservableCollection<Appointment> result = new ObservableCollection<Appointment>();

                SqlDataReader reader = cmd.ExecuteReader();
               
                while (reader.Read())
                {
                    Appointment appointment = new Appointment();
                    appointment.ID = (int)(reader[0]);
                    appointment.IDpatient = (int)(reader[1]);
                    appointment.Date = reader.GetDateTime(2);
                    appointment.Hour = (int)(reader[3]);
                    appointment.Deleted = Util.DeletedToString(reader.GetString(4));
                    appointment.DateStr = appointment.Date.ToString("yyyy-MM-dd");
                    appointment.Cost = AppointmentDAL.GetCostAppointment(appointment);
                    result.Add(appointment);
                }
                reader.Close();
                return result;

            }

        }

        public static ObservableCollection<Appointment> GetAppointmentsPr()
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getAppointmentsFromAPatientPr", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                
                ObservableCollection<Appointment> result = new ObservableCollection<Appointment>();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Appointment appointment = new Appointment();
                    appointment.ID = (int)(reader[0]);
                    appointment.IDpatient = (int)(reader[1]);
                    appointment.Date = reader.GetDateTime(2);
                    appointment.Hour = (int)(reader[3]);
                    appointment.Deleted = Util.DeletedToString(reader.GetString(4));
                    appointment.DateStr = appointment.Date.ToString("yyyy-MM-dd");
                    appointment.Cost = AppointmentDAL.GetCostAppointment(appointment);
                    result.Add(appointment);

                }
                reader.Close();
                return result;

            }

        }
        
        public static void DeleteAppointmentPr(Appointment appointment)
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("deleteAppointmentPr", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter id = new SqlParameter("@id", appointment.ID);

                cmd.Parameters.Add(id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        public static decimal GetCostAppointment(Appointment appointment)
        {
            decimal cost = 0;
            foreach(Intervention intervention in InterventionDAL.GetInterventionsFromAnAppPr(appointment))
            {
                Price price = PriceDAL.GetCurrentPricePr(intervention);
                if(price != null)
                {
                    cost += price.Value;
                }
            }
            return cost;

        }

        

    }
}