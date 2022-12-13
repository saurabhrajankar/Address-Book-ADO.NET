using System;
using System.Data.SqlClient;

namespace ABSD2
{
    public class ABSD2
    {
        string str = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ado_AddressBook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void create_table()
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("CREATE TABLE AddressBookTable(FirstName VARCHAR(15) NOT NULL,LastName VARCHAR(20) NOT NULL,Address VARCHAR(50) NOT NULL,City VARCHAR(15) NOT NULL,State VARCHAR(15) NOT NULL,Zip Int NOT NULL,MobNo Int NOT NULL,Email VARCHAR(30) NOT NULL)", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        static void Main(string[] args)
        {
            ABSD2 obj= new ABSD2();
            obj.create_table();
        }
    }
}
