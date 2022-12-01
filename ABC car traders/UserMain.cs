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
    public partial class UserMain : Form
    {
        SqlDataManipulator sdm = new SqlDataManipulator();
        public UserMain()
        {
            InitializeComponent();
        }

        private void UserMain_Load(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btn_shop_Click(object sender, EventArgs e)
        {
            this.Hide();
            Shop s = new Shop(new Cartview());
            s.Show();
        }

        private void btn_myorders_Click(object sender, EventArgs e)
        {
            this.Close();
            My_Orders mo = new My_Orders();
            mo.Show();
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            this.Close();
            Account_Settings ac = new Account_Settings();
            ac.Show();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login l = new Login();
            l.Show();
        }

        private void UserMain_Activated(object sender, EventArgs e)
        {
            //loading data to the user dashboard from the database
            label1.Text = "Welcome " + UserInstance.uname + "!";
            current_date.Text = DateTime.Now.ToShortDateString();
            string user = UserInstance.uname;
            DataTable dt = sdm.dispalyData("select count (Order_ID) from Orders where Username='"+user+ "' and Order_status='Delivered'");
            delivered_orders.Text = dt.Rows[0][0].ToString();
            DataTable dt2 = sdm.dispalyData("select count (Order_ID) from Orders where Username='" + user + "' and Order_status='Pending'");
            Pendin_oders.Text = dt2.Rows[0][0].ToString();
            DataTable dt3 = sdm.dispalyData("select count (Order_ID) from Orders where Username='" + user + "'");
            Total_orders.Text = dt3.Rows[0][0].ToString();
        }
    }
}
