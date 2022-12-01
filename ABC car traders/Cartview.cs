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
    public partial class Cartview : Form
    {
        SqlDataManipulator sdm = new SqlDataManipulator();
       
        
        public Cartview()
        {
            InitializeComponent();
        }


        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Cartview_Load(object sender, EventArgs e)
        {
            
        }

        public void dgv_cart_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void Cartview_Shown(object sender, EventArgs e)
        {
            
        }

        private void Cartview_Activated(object sender, EventArgs e)
        {
            //everytime cart loads refresh the total value of items
            try
            {
                float sum = 0;
                for (int i = 0; i < dgv_cart.Rows.Count; i++)
                {
                    sum = sum + Convert.ToInt32(dgv_cart.Rows[i].Cells[4].Value);
                }
                lbl_total.Text = sum.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
           
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            //remove an item from the cart and throw an error if cart is empty
            try
            {
                float rowtotal = float.Parse(dgv_cart.CurrentRow.Cells[4].Value.ToString());
                dgv_cart.Rows.Remove(dgv_cart.CurrentCell.OwningRow);
                if (dgv_cart.Rows.Count == 0)
                {
                    lbl_total.Text = "0";


                }
                else
                {

                    float sum = float.Parse(lbl_total.Text);
                    float Total = sum - rowtotal;
                    lbl_total.Text = Total.ToString();
                }

            }
            catch (NullReferenceException ex)
            {

                MessageBox.Show("No items in the cart to remove!");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
            
        }

        private void btn_checkout_Click(object sender, EventArgs e)
        {
            try
            {
                string products = "";
                string date = DateTime.Now.ToShortDateString();
                float total = float.Parse(lbl_total.Text);
                string user = UserInstance.uname;
                //add all the products to the order
                for (int i = 0; i < dgv_cart.Rows.Count; i++)
                {
                    products = products + " " + dgv_cart.Rows[i].Cells[0].Value.ToString() + " " + dgv_cart.Rows[i].Cells[1].Value.ToString() + " *1";
                }

                // update product stock according to order
                for (int i = 0; i < dgv_cart.Rows.Count; i++)
                {
                    int qty = int.Parse(dgv_cart.Rows[i].Cells[3].Value.ToString());
                    DataTable dt = sdm.dispalyData("Select Product_quantity from Products where Product_ID='" + dgv_cart.Rows[i].Cells[0].Value.ToString() + "'");
                    int stock = int.Parse(dt.Rows[0]["Product_quantity"].ToString());
                    int newstock = stock - qty;
                    sdm.modifyData("Update Products set Product_quantity='" + newstock + "' where Product_ID='" + dgv_cart.Rows[i].Cells[0].Value.ToString() + "'");
                }
                //creating a new order
                sdm.modifyData("insert into Orders(Order_date,Order_products,order_total,Order_status,Username) values('" + date + "','" + products + "','" + total + "','Pending','" + user + "')");
                MessageBox.Show("Order added succesfully!");
                dgv_cart.Rows.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            
            

        }
    }
}
