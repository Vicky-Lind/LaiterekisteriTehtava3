using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Create connection to SQL Server using Windows authentication
            using (SqlConnection conn = new SqlConnection("Data Source=LS99-NOTEBOOK-2\\SQLEXPRESS;Initial Catalog=Henkilosto;Integrated Security=True"))
            {
                // Open the connection and see status
                conn.Open();
                Console.WriteLine(conn.State);
                Console.WriteLine("Yhteyteen vastaa SQL Server versio " + conn.ServerVersion);

                // Create a sql command to insert a new employee to Työntekija table
                string insertEmployee = "INSERT INTO dbo.Tyontekija (Etunimi, Sukunimi) VALUES ('Assi', 'Kalma');";

                SqlCommand cmd = new SqlCommand(insertEmployee, conn);

                cmd.ExecuteNonQuery();

                conn.Close();
            };

            // Create another connection to the Db
            using (SqlConnection conn2 = new SqlConnection("Data Source=LS99-NOTEBOOK-2\\SQLEXPRESS;Initial Catalog=Henkilosto;Integrated Security=True"))
            {
                conn2.Open();

                // Create a sql command to update x city in Tyontekija table
                string updateEmployee = "UPDATE dbo.tyontekija SET Postitoimipaikka = 'Turku' WHERE TyontekijaID = 6;";

                SqlCommand cmd2 = new SqlCommand(updateEmployee, conn2);
                cmd2.ExecuteNonQuery();

                conn2.Close();
            };

            // Create 3rd connection to the Db
            using (SqlConnection conn3 = new SqlConnection("Data Source=LS99-NOTEBOOK-2\\SQLEXPRESS;Initial Catalog=Henkilosto;Integrated Security=True"))
            {
                conn3.Open();

                string queryAllEmployees = "SELECT * FROM dbo.Tyontekija;";

                SqlCommand cmd3 = new SqlCommand(queryAllEmployees, conn3);

                // To avoid eternal loop use timeout
                cmd3.CommandTimeout = 10;

                SqlDataReader reader = cmd3.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}", reader.GetString(0), reader.GetString(1));
                }
                conn3.Close();
            };

            Console.ReadLine();
        }
    }
}