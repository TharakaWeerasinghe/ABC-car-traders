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
    public partial class Manage_Orders : Form
    {
        SqlDataManipulator sdm = new SqlDataManipulator();
        public Manage_Orders()
        {
            InitializeComponent();
        }
        //method for loading all orders to the gridview
        public void loadOrders()
        {
            DataTable dt = sdm.dispalyData("Select * from Orders");
            dgv_orders.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_PID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_pprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Manage_Orders_Load(object sender, EventArgs e)
        {
            //loading usernames to the combobox
            try
            {
                DataTable dt = sdm.dispalyData("Select Username from Users order by Username asc");
                foreach (DataRow dr in dt.Rows)
                {
                    cmb_customer.Items.Add(dr["Username"].ToString());
                }
                loadOrders();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            //searching for a order according to the user input text
            try
            {
                DataTable dt = sdm.dispalyData("Select * from Orders where  Username like'" + txt_search.Text + "'+'%' ");
                dgv_orders.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_Click_1(object sender, EventArgs e)
        {

            try
            {
                float total;
                bool floatparsesuccess = float.TryParse(txt_total.Text, out total);

                

                if (floatparsesuccess == false)//validating total
                {
                    MessageBox.Show("Please enter an Valid number as Order total");
                    return;
                }
                else
                {
                    // adding a new order
                    sdm.modifyData("insert into Orders(Order_date,Order_products,order_total,Order_status,Username) values('" + dtp_odate.Text + "','" + txt_products.Text + "','" + total + "','" + cmb_status.Text + "','" + cmb_customer.Text + "')");
                    MessageBox.Show("Order added succesfully!");
                    
                    loadOrders();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                {
                    MessageBox.Show("Order ID taken please enter another Order ID");
                }
                else
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                
            }
        }

        private void btn_update_Click_1(object sender, EventArgs e)
        {
            try
            {
                float total;
                bool floatparsesuccess = float.TryParse(txt_total.Text, out total);



                if (floatparsesuccess == false)//validating order total
                {
                    MessageBox.Show("Please enter an Valid number as Order total");
                }
                else
                {
                    //updating a order
                    sdm.modifyData("update Orders set Order_date='"+dtp_odate.Text+ "',Order_products='"+txt_products.Text+ "',order_total='"+total+ "',Order_status='"+cmb_status.Text+ "',Username='"+cmb_customer.Text+ "' where Order_ID='"+int.Parse(txt_OID.Text)+"'");
                    MessageBox.Show("Order Updated succesfully!");
                    loadOrders();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                //delting an order and emptying textboxes
                sdm.modifyData("delete from Orders where Order_ID='" + int.Parse(txt_OID.Text) + "'");
                MessageBox.Show("Order Deleted Succesfully!");
                txt_OID.Text = "";
                dtp_odate.Text = "";
                txt_products.Text = "";
                txt_total.Text = "";
                cmb_status.Text = "";
                cmb_customer.Text = "";
                loadOrders();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dgv_orders_Click(object sender, EventArgs e)
        {
            if (dgv_orders.CurrentRow.Index != -1)
            {
                txt_OID.Text = dgv_orders.CurrentRow.Cells[0].Value.ToString();
                dtp_odate.Text = dgv_orders.CurrentRow.Cells[1].Value.ToString();
                txt_products.Text = dgv_orders.CurrentRow.Cells[2].Value.ToString();
                txt_total.Text = dgv_orders.CurrentRow.Cells[3].Value.ToString();
                cmb_status.Text = dgv_orders.CurrentRow.Cells[4].Value.ToString();
                cmb_customer.Text = dgv_orders.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminMain am = new AdminMain();
            am.Show();
        }

        private void txt_search_Click(object sender, EventArgs e)
        {
            txt_search.Text = "";
        }
    }
}
