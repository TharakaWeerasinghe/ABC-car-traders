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
    public partial class My_Orders : Form
    {
        SqlDataManipulator sdm = new SqlDataManipulator();
    
        public My_Orders()
        {
            InitializeComponent();
        }
        // method for loading all the order made by the user currently logged in
        public void loadOrders()
        {
            string user = UserInstance.uname;
            DataTable dt = sdm.dispalyData("Select * from Orders where Username='"+user+"'");
            dgv_orders.DataSource = dt;
        }
        private void My_Orders_Load(object sender, EventArgs e)
        {
            loadOrders();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            //canceling an order and returning an error if the order is already delivered
            try
            {
                string status = dgv_orders.CurrentRow.Cells[4].Value.ToString();
                if (status == "Delivered")
                {
                    MessageBox.Show("Can't cancel Order. Order already delivered");
                }
                else
                {
                    sdm.modifyData("delete from Orders where Order_ID='" + int.Parse(dgv_orders.CurrentRow.Cells[0].Value.ToString()) + "'");
                    MessageBox.Show("Order Canceled Succesfully!");
                    loadOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
            UserMain um = new UserMain();
            um.Show();
        }
    }
}
