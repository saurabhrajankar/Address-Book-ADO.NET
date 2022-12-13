using System;
using System.Data.SqlClient;

namespace ABSD1
{
    public class ABSD1
    {
        public static string str = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void connect_database()
        {
            try
            {
                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand("Create Database Ado_AddressBook", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            ABSD1 obj= new ABSD1();
            obj.connect_database();
        }
    }
}
