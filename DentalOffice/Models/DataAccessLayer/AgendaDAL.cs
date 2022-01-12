using DentalOffice.Enum;
using DentalOffice.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace DentalOffice.Models.DataAccesslayer
{
    public class AgendaDAL
    {
        public static void AddAgendaPr(Agenda agenda)
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("addAgendaPr", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idAppointmentPar = new SqlParameter("@idAppointment", agenda.IDappointment);
                SqlParameter idInterventionPar = new SqlParameter("@idIntervention", agenda.IDintervention);

                cmd.Parameters.Add(idAppointmentPar);
                cmd.Parameters.Add(idInterventionPar);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static Agenda generateAgenda(int ID, int IDappointment, int IDintervention, Deleted Deleted)
        {
            Agenda agenda = new Agenda();
            agenda.ID = ID;
            agenda.IDappointment = IDappointment;
            agenda.IDintervention = IDintervention;
            agenda.Deleted = Deleted;
            return agenda;
        }
        public static ObservableCollection<Agenda> GetAgendasPr()
        {
            using (SqlConnection con = Helper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getAgendasPr", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                ObservableCollection<Agenda> result = new ObservableCollection<Agenda>();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add
                    (
                        new Agenda()
                        {
                            ID = (int)(reader[0]),
                            IDappointment = (int)(reader[1]),
                            IDintervention = (int)(reader[2]),
                            Deleted = Util.DeletedToString(reader.GetString(3))
                        }
                    );
                }
                reader.Close();
                return result;
            }
        }
    }
}