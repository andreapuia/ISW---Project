namespace DentalOffice.Enum
{
    public static class Util
    {

        public static Role RoleToString(string str)
        {
            if(str.Equals(Role.administrator.ToString()))
            {
                return Role.administrator;
            }
            else
            {
                return Role.doctor;
            }
        }


        public static Deleted DeletedToString(string str)
        {
            if (str.Equals(Deleted.yes.ToString()))
            {
                return Deleted.yes;
            }
            else
            {
                return Deleted.no;
            }
        }

    }
}