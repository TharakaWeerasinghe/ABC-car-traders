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
    public partial class AdminMain : Form
    {
        SqlDataManipulator sdm = new SqlDataManipulator();
        public AdminMain()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btn_customer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers c = new Customers();
            c.Show();
        }

        private void btn_vehicles_Click(object sender, EventArgs e)
        {
            this.Close();
            Products p = new Products();
            p.Show();
        }

        private void btn_orders_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Orders mo = new Manage_Orders();
            mo.Show();
        }

        private void AdminMain_Activated(object sender, EventArgs e)
        {
            // load the data for the admin dashboard
            DataTable dt = sdm.dispalyData("select count (Order_ID) from Orders ");
            lbl_orders.Text = dt.Rows[0][0].ToString();
            DataTable dt2 = sdm.dispalyData("select count (Product_ID) from Products where Product_type='Vehicle' ");
            lbl_vehicles.Text = dt2.Rows[0][0].ToString();
            DataTable dt3 = sdm.dispalyData("select count (Product_ID) from Products where Product_type='Part' ");
            lbl_parts.Text = dt3.Rows[0][0].ToString();
            DataTable dt4 = sdm.dispalyData("select count (Username) from Users ");
            lbl_users.Text = dt4.Rows[0][0].ToString();
        }

        private void btn_custoemrReport_Click(object sender, EventArgs e)
        {
            this.Close();
            Customer_Report cr = new Customer_Report();
            cr.Show();
        }

        private void btn_incomerpt_Click(object sender, EventArgs e)
        {
            this.Close();
            Income_Report ir = new Income_Report();
            ir.Show();
        }

        private void btn_inventoryreport_Click(object sender, EventArgs e)
        {
            this.Close();
            Inventory i = new Inventory();
            i.Show();
        }

        private void Btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login l = new Login();
            l.Show();
        }
    }
}
