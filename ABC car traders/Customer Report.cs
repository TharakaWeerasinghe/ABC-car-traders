using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_car_traders
{
    public partial class Customer_Report : Form
    {
        SqlDataManipulator sdm = new SqlDataManipulator();
        public Customer_Report()
        {
            InitializeComponent();
        }

        private void Customer_Report_Load(object sender, EventArgs e)
        {

        }

        private void Customer_Report_Activated(object sender, EventArgs e)
        {
            //load a list of customers and their frequency of orders from the order table
            DataTable dt = sdm.dispalyData("select Username, COUNT(Order_ID) as Number_of_Orders from orders group by Username order by COUNT(*) DESC");
            dgv_bestcustomers.DataSource = dt;

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminMain am = new AdminMain();
            am.Show();
        }
    }
}
