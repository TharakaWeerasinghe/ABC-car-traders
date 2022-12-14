using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ABC_car_traders
{
    //class containing all the sql operations
    class SqlDataManipulator
    {
        //method to return connection string
        public string constring()
        {
            return @"Data Source=MSI;Initial Catalog=ABC_Auto;Integrated Security=True";
        }
        //method to modify data in the database
        public void modifyData(string query)
        {
            SqlConnection con = new SqlConnection(constring());
            con.Open();
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
        //method to retrieve data and dispaly it
        public DataTable dispalyData(string query)
        {
            SqlConnection con = new SqlConnection(constring());
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;



        }
    }
}
