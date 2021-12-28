using DentalOffice.Enum;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace DentalOffice.Models.DataAccesslayer
{
    public class UserDAL
    {
        public static User GetUserPr(string Username, string Password)
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getUserPr",con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter OutputPar = new SqlParameter("@output",SqlDbType.Int);
                OutputPar.Direction = ParameterDirection.Output;
                SqlParameter UsernamePar = new SqlParameter("@Username",Username);
                SqlParameter PasswordPar = new SqlParameter("@Password",Password);

                cmd.Parameters.Add(OutputPar);
                cmd.Parameters.Add(UsernamePar);
                cmd.Parameters.Add(PasswordPar);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                User user = new User();
                while(reader.Read())
                {
                    user.ID = (int)(reader[0]);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.FirstName = reader.GetString(3);
                    user.LastName = reader.GetString(4);
                    user.Role = Util.RoleToString(reader.GetString(5));
                    user.Deleted = Util.DeletedToString(reader.GetString(6));
                }
                user.FullName = user.FirstName + " " + user.LastName;
                reader.Close();

                if(OutputPar.Value as int? == 1)
                {
                    user = null;
                }
                return user;
            }
        }
        
        public static ObservableCollection<User> GetDoctorsPr()
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getDoctorsPr",con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                ObservableCollection<User> result = new ObservableCollection<User>();

                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    User doctor = new User();
                    doctor.ID = (int)(reader[0]);
                    doctor.Username = reader.GetString(1);
                    doctor.Password = reader.GetString(2);
                    doctor.FirstName = reader.GetString(3);
                    doctor.LastName = reader.GetString(4);
                    doctor.Role = Util.RoleToString(reader.GetString(5));
                    doctor.Deleted = Util.DeletedToString(reader.GetString(6));
                    doctor.FullName = doctor.FirstName + " " + doctor.LastName;
                    result.Add(doctor);
                }
                reader.Close();
                return result;

            }
            
        }
        
        public static ObservableCollection<User> GetUsersPr()
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getUsersPr", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                ObservableCollection<User> result = new ObservableCollection<User>();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    User user = new User();
                    user.ID = (int)(reader[0]);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.FirstName = reader.GetString(3);
                    user.LastName = reader.GetString(4);
                    user.Role = Util.RoleToString(reader.GetString(5));
                    user.Deleted = Util.DeletedToString(reader.GetString(6));
                    user.FullName = user.FirstName + " " + user.LastName;
                    result.Add(user);
                }
                reader.Close();
                return result;

            }
        }
        
        public static void AddDoctorPr(User doctor)
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("addDoctorPr", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter OutputPar = new SqlParameter("@output", SqlDbType.Int);
                OutputPar.Direction = ParameterDirection.Output;
                SqlParameter UsernamePar = new SqlParameter("@Username", doctor.Username);
                SqlParameter PasswordPar = new SqlParameter("@Password", doctor.Password);
                SqlParameter FirstNamePar = new SqlParameter("@FirstName", doctor.FirstName);
                SqlParameter LastNamePar = new SqlParameter("@LastName", doctor.LastName);
                
                cmd.Parameters.Add(OutputPar);
                cmd.Parameters.Add(UsernamePar);
                cmd.Parameters.Add(PasswordPar);
                cmd.Parameters.Add(FirstNamePar);
                cmd.Parameters.Add(LastNamePar);
                con.Open();
                cmd.ExecuteNonQuery();

                if (OutputPar.Value as int? == 1)
                {
                    MessageBox.Show("Doctor already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Operation successfully completed!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        
        public static void DeleteDoctorPr(User doctor)
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("deleteDoctorPr", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                SqlParameter id = new SqlParameter("@id", doctor.ID);
                
                cmd.Parameters.Add(id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        public static void UpdateDoctorPr(User doctor)
        {
            using (SqlConnection con = Helper.Connection)
            {
              
                SqlCommand cmd = new SqlCommand("updateDoctorPr", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter OutputPar = new SqlParameter("@output", SqlDbType.Int);
                OutputPar.Direction = ParameterDirection.Output;
                SqlParameter ID = new SqlParameter("@ID", doctor.ID);
                SqlParameter Username = new SqlParameter("@Username", doctor.Username);
                SqlParameter Password = new SqlParameter("@Password", doctor.Password);
                SqlParameter FirstName = new SqlParameter("@FirstName", doctor.FirstName);
                SqlParameter LastName = new SqlParameter("@LastName", doctor.LastName);

                cmd.Parameters.Add(OutputPar);
                cmd.Parameters.Add(ID);
                cmd.Parameters.Add(Username);
                cmd.Parameters.Add(Password);
                cmd.Parameters.Add(FirstName);
                cmd.Parameters.Add(LastName);

                con.Open();
                cmd.ExecuteNonQuery();

                if(OutputPar.Value as int? == 1)
                {
                    MessageBox.Show("The username already exists in database!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        
        public static double GetOccupancy(User doctor, DateTime start, DateTime end)
        {
            double totalHours = (end - start).TotalDays * 8 * 2;
            int nrAppointments = 0;
            foreach(Patient patient in PatientDAL.GetPatientsFromADoctorPr(doctor))
            {
                foreach(Appointment appointment in AppointmentDAL.GetAppointmentsFromAPatientPr(patient))
                {
                    if(DateTime.Compare(start,appointment.Date) <= 0 && DateTime.Compare(appointment.Date,end)<=0)
                    {
                        nrAppointments++;
                    }
                }
            }
            return (nrAppointments * 100) / totalHours;
        }
        
        public static decimal GetMonthGains(User doctor, int month, int year)
        {
            decimal cost = 0;
            foreach(Patient patient in PatientDAL.GetPatientsFromADoctorPr(doctor))
            {
                foreach(Appointment appointment in AppointmentDAL.GetAppointmentsFromAPatientPr(patient))
                {
                    if(appointment.Date.Month == month && appointment.Date.Year == year)
                    {
                        cost += appointment.Cost;
                    }
                }
            }
            return cost;
        }
    }
}
