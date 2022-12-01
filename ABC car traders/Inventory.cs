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
    public partial class Inventory : Form
    {
        SqlDataManipulator sdm = new SqlDataManipulator();
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Activated(object sender, EventArgs e)
        {
            //load the product details and stock form product into a table
            DataTable dt = sdm.dispalyData("Select Product_ID,Product_name,Product_quantity,Product_type from Products");
            dgv_Inventory.DataSource = dt;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminMain am = new AdminMain();
            am.Show();
        }
    }
}
