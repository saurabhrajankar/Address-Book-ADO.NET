using System;
using System.Data.SqlClient;

namespace ABSD5
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
    public class ABSD5
    {
        string str = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ado_AddressBook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void delete_contact(Contact cnct)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query = "Select FirstName,LastName,Address,City,State,Zip,MobNo,Email from AddressBookTable";
            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlCommand cmd=new SqlCommand("DeleteContact", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", cnct.FirstName);
            cmd.ExecuteNonQuery();
            SqlDataReader dr=cmd1.ExecuteReader();
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
            ABSD5 obj=new ABSD5();
            Contact c=new Contact();
            c.FirstName = "UC";
            obj.delete_contact(c);
        }
    }
}
