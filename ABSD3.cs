using System;
using System.Data.SqlClient;

namespace ABSD3
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
    public class ABSD3
    {
        string str = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ado_AddressBook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void insert_contact(Contact cnct)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query="Select FirstName,LastName,Address,City,State,Zip,MobNo,Email from AddressBookTable";
            SqlCommand cmd1=new SqlCommand(query, con);
            SqlCommand cmd = new SqlCommand("InsertContact", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", cnct.FirstName);
            cmd.Parameters.AddWithValue("@LastName", cnct.LastName);
            cmd.Parameters.AddWithValue("@Address", cnct.Address);
            cmd.Parameters.AddWithValue("@City", cnct.City);
            cmd.Parameters.AddWithValue("@State", cnct.State);
            cmd.Parameters.AddWithValue("@Zip", cnct.Zip);
            cmd.Parameters.AddWithValue("@MobNo",cnct.MobNo);
            cmd.Parameters.AddWithValue("@Email", cnct.Email);
            cmd.ExecuteNonQuery();
            SqlDataReader dr=cmd1.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    cnct.FirstName=dr.GetString(0);
                    cnct.LastName=dr.GetString(1);
                    cnct.Address=dr.GetString(2);
                    cnct.City=dr.GetString(3);
                    cnct.State=dr.GetString(4);
                    cnct.Zip = dr.GetInt32(5);
                    cnct.MobNo = dr.GetInt32(6);
                    cnct.Email=dr.GetString(7);

                    Console.WriteLine("FirstName:"+cnct.FirstName);
                    Console.WriteLine("LastName:"+cnct.LastName);
                    Console.WriteLine("Address:"+cnct.Address);
                    Console.WriteLine("City:"+cnct.City);
                    Console.WriteLine("State:"+cnct.State);
                    Console.WriteLine("Zip:"+cnct.Zip);
                    Console.WriteLine("MobNo:"+cnct.MobNo);
                    Console.WriteLine("Email:"+cnct.Email);
                }
            }
            con.Close();
        }
        static void Main(string[] args)
        {
            ABSD3 obj=new ABSD3();
            Contact c=new Contact();
            c.FirstName = "Vaibhav";
            c.LastName = "Jadhav";
            c.Address = "Somatane";
            c.City = "Pune";
            c.State = "Maharashtra";
            c.Zip = 410506;
            c.MobNo =987654321;
            c.Email = "vaibhav123@gmail.com";

            obj.insert_contact(c);
        }
    }
}
