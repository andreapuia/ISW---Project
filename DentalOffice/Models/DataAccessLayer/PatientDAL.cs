using DentalOffice.Enum;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace DentalOffice.Models.DataAccesslayer
{
    public class PatientDAL
    {
        public static ObservableCollection<Patient> GetPatientsPr()
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getPatientsPr", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                ObservableCollection<Patient> result = new ObservableCollection<Patient>();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Patient patient = new Patient();
                    patient.ID = (int)(reader[0]);
                    patient.IDdoctor = (int)(reader[1]);
                    patient.FirstName = reader.GetString(2);
                    patient.LastName = reader.GetString(3);
                    patient.CNP = reader.GetString(4);
                    patient.City = reader.GetString(5);
                    patient.Deleted = Util.DeletedToString(reader.GetString(6));
                    patient.Cost = PatientDAL.GetCostPacient(patient);
                    result.Add(patient);
                }
                reader.Close();
                return result;
            }
        }
        public static ObservableCollection<Patient> GetPatientsFromADoctorPr(User doctor)
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getPatientsFromADoctorPr", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter IdPar = new SqlParameter("@id", doctor.ID);
                cmd.Parameters.Add(IdPar);

                con.Open();

                ObservableCollection<Patient> result = new ObservableCollection<Patient>();

                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Patient patient = new Patient();
                    patient.ID = (int)(reader[0]);
                    patient.IDdoctor = (int)(reader[1]);
                    patient.FirstName = reader.GetString(2);
                    patient.LastName = reader.GetString(3);
                    patient.CNP = reader.GetString(4);
                    patient.City = reader.GetString(5);
                    patient.Deleted = Util.DeletedToString(reader.GetString(6));
                    patient.Cost = PatientDAL.GetCostPacient(patient);
                    result.Add(patient);
                }
                reader.Close();
                return result;
            }
        }
        public static void UpdatePatientPr(Patient patient)
        {
            using (SqlConnection con = Helper.Connection)
            {

                SqlCommand cmd = new SqlCommand("updatePatientPr", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter CNP = new SqlParameter("@CNP", patient.CNP);
                SqlParameter FirstName = new SqlParameter("@FirstName", patient.FirstName);
                SqlParameter LastName = new SqlParameter("@LastName", patient.LastName);
                SqlParameter City = new SqlParameter("@City", patient.City);

                cmd.Parameters.Add(CNP);
                cmd.Parameters.Add(FirstName);
                cmd.Parameters.Add(LastName);
                cmd.Parameters.Add(City);

                con.Open();
                cmd.ExecuteNonQuery();
                
            }
        }
        
        public static void DeletePatientPr(Patient patient)
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("deletePatientPr", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter CNP = new SqlParameter("@CNP", patient.CNP);

                cmd.Parameters.Add(CNP);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void AddPatientPr(Patient patient)
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("addPatientPr", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter OutputPar = new SqlParameter("@output", SqlDbType.Int);
                OutputPar.Direction = ParameterDirection.Output;
                SqlParameter IDdoctorPar = new SqlParameter("@IDdoctor", patient.IDdoctor);
                SqlParameter FirstNamePar = new SqlParameter("@FirstName", patient.FirstName);
                SqlParameter LastNamePar = new SqlParameter("@LastName", patient.LastName);
                SqlParameter CNPPar = new SqlParameter("@CNP", patient.CNP);
                SqlParameter CityPar = new SqlParameter("@City", patient.City);

                cmd.Parameters.Add(OutputPar);
                cmd.Parameters.Add(IDdoctorPar);
                cmd.Parameters.Add(FirstNamePar);
                cmd.Parameters.Add(LastNamePar);
                cmd.Parameters.Add(CNPPar);
                cmd.Parameters.Add(CityPar);

                con.Open();
                cmd.ExecuteNonQuery();

                switch(OutputPar.Value as int?)
                {
                    case 0:
                        MessageBox.Show("Operation successfully completed!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case 1:
                        MessageBox.Show("The patient is already registered in the database!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case 2:
                        MessageBox.Show("The patient was successfully transferred!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                }
            }
        }

        public static decimal GetCostPacient(Patient patient)
        {
            decimal cost = 0;

            foreach (Appointment appointment in AppointmentDAL.GetAppointmentsFromAPatientPr(patient))
            {
                cost += AppointmentDAL.GetCostAppointment(appointment);
            }
            return cost;
        }
    }
}