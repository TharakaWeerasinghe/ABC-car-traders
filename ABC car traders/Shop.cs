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
    public partial class Shop : Form
    {
        SqlDataManipulator sdm = new SqlDataManipulator();
        Cartview cart;
        public Shop(Cartview cv)
        {
            InitializeComponent();
            this.cart = cv;
        }
        //method to load all the products
        public void loadProducts()
        {
            DataTable dt = sdm.dispalyData("Select * from Products where Product_type='"+cmb_ptype.Text+"'");
            dgv_products.DataSource = dt;
        }

        private void Shop_Load(object sender, EventArgs e)
        {
            loadProducts();
        }

        private void btn_addtocart_Click(object sender, EventArgs e)
        {
            //adding a an item to the cart
            string PID= dgv_products.CurrentRow.Cells[0].Value.ToString();
            string Pname= dgv_products.CurrentRow.Cells[1].Value.ToString();
            string price= dgv_products.CurrentRow.Cells[4].Value.ToString();
            float total = float.Parse(dgv_products.CurrentRow.Cells[4].Value.ToString()) * 1;
            cart.dgv_cart.Rows.Add(PID,Pname,price,1,total);
            MessageBox.Show("Succesfully Added to Cart!");
        }

        private void btn_viewcart_Click(object sender, EventArgs e)
        {
            this.cart.Show();
        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            //searching for a paticular product by category
            DataTable dt = sdm.dispalyData("select * from Products where Product_name like '" + txt_search.Text + "'+'%' and Product_type='"+cmb_ptype.Text+"'");
            dgv_products.DataSource = dt;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
            UserMain um = new UserMain();
            um.Show();
        }
    }
}
