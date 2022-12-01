using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace ABC_car_traders
{
    class SQl_Get_Data
    {
        SqlConnection con = new SqlConnection(@"Data Source=MSI;Initial Catalog=ABC_Auto;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public DataTable DataTable (string query)
        {
            if (con.State == ConnectionState.Closed)
            {
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                con.Close();


            }
            return dt;
        }
    }
}
