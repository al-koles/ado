using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado
{
    class Program
    {
        static void Main(string[] args)
        {
            //string c = Properties.Settings.Default.
            string connStr = "Data Source=DESKTOP-ST1VBIU;Initial Catalog=test;Integrated Security=True";
            using(SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select * from a", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        string columnName1 = reader.GetName(0);

                        Console.WriteLine($"{columnName1}");

                        while (reader.Read())
                        {
                            object id = reader.GetValue(0);

                            Console.WriteLine($"{id}");
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.Read();
        }
    }
}
