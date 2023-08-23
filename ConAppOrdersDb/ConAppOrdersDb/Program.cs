using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppOrdersDb
{
    internal class Program
    {
        static SqlCommand cmd;
        static SqlConnection con;
        static string conString = "server=DESKTOP-CHNJ5UD;database=OrderDb;trusted_connection=true;";
        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(conString);
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "PlaceOrder";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                Console.WriteLine("Enter Customer id ");
                cmd.Parameters.AddWithValue("@customerid", int.Parse(Console.ReadLine()));
                Console.WriteLine("Enter order Amount ");
                cmd.Parameters.AddWithValue("@totalamount", Console.ReadLine());
                int nor = cmd.ExecuteNonQuery();
                Console.WriteLine("Order Placed Successfull!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            { 
                con.Close();
                Console.ReadKey();
            }
            
        }
    }
}
