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
    public partial class Income_Report : Form
    {
        SqlDataManipulator sdm = new SqlDataManipulator();
        public Income_Report()
        {
            InitializeComponent();
        }

        private void Income_Report_Activated(object sender, EventArgs e)
        {
            //loading the total of all orders
            DataTable dt = sdm.dispalyData("SELECT SUM(order_total) as Total_Income FROM Orders");
            dgv_Income.DataSource = dt;

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminMain am = new AdminMain();
            am.Show();
        }
    }
}
