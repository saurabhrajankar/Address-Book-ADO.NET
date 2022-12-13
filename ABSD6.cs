using System;
using System.Data.SqlClient;

namespace ABSD6
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public long MobNo { get; set; }
        public string Email { get; set; }
    }
    public class ABSD6
    {
        string str = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ado_AddressBook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void retrievepersonbycity(Contact cnct)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("RetrievePersonByCity", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@City", cnct.City);
            SqlDataReader dr=cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    cnct.FirstName = dr.GetString(0);
                    cnct.LastName = dr.GetString(1);
                    cnct.Address = dr.GetString(2);
                    cnct.City = dr.GetString(3);
                    cnct.State = dr.GetString(4);
                    cnct.Zip = dr.GetInt32(5);
                    cnct.MobNo = dr.GetInt32(6);
                    cnct.Email = dr.GetString(7);

                    Console.WriteLine("FirstName:" + cnct.FirstName);
                    Console.WriteLine("LastName:" + cnct.LastName);
                    Console.WriteLine("Address:" + cnct.Address);
                    Console.WriteLine("City:" + cnct.City);
                    Console.WriteLine("State:" + cnct.State);
                    Console.WriteLine("Zip:" + cnct.Zip);
                    Console.WriteLine("MobNo:" + cnct.MobNo);
                    Console.WriteLine("Email:" + cnct.Email);
                    Console.WriteLine("\n");
                }
            }
            con.Close();
        }
        static void Main(string[] args)
        {
            ABSD6 obj=new ABSD6();
            Contact c=new Contact();

            c.City = "Georgopool";
            obj.retrievepersonbycity(c);
        }
    }
}
