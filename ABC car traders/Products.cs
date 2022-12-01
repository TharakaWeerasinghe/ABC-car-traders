using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ABC_car_traders
{
    public partial class Products : Form
    {
        SqlDataManipulator sdm = new SqlDataManipulator();
        public Products()
        {
            InitializeComponent();
        }
        // method for loading all the products to the datagridview
        public void loadProducts()
        {
            DataTable dt = sdm.dispalyData("Select * from Products");
            dgv_products.DataSource = dt;
        }

        private void Products_Load(object sender, EventArgs e)
        {
            loadProducts();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                //searching for a paticular product according to the input text
                DataTable dt = sdm.dispalyData("select * from Products where Product_name like '" + txt_search.Text + "'+'%'");
                dgv_products.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
          
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                int stock;
                bool parseSucess = int.TryParse(txt_pstock.Text, out stock);
                float price;
                bool floatparsesuccess = float.TryParse(txt_pprice.Text, out price);

                if (parseSucess == false)//validating stock is an integer
                {
                    MessageBox.Show("Please enter an integer as stock!");
                    return;
                }

                if (floatparsesuccess==false)//validating price is a float
                {
                    MessageBox.Show("Please enter an valid number as price!");
                    return;
                }
                
                else
                {
                    //inserting a new product to the table
                    sdm.modifyData("insert into Products(Product_ID,Product_name,Product_color,Product_quantity,Product_price,Product_manufacturer,Product_description,Product_type) values('" + txt_PID.Text + "','" + txt_pname.Text + "','" +txt_pcolor.Text + "','" +int.Parse( txt_pstock.Text) + "','" +float.Parse( txt_pprice.Text) + "','" + txt_pmanufacturer.Text + "','" + txt_pdescription.Text + "','"+cmb_ptype.Text+"')");
                    MessageBox.Show("Product Added Succesful!");
                    loadProducts();
                }
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                {
                    MessageBox.Show("Product ID taken please enter another username");
                }
                else
                {
                    MessageBox.Show(ex.Message.ToString());
                }
               
            }
            
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                int stock;
                bool parseSucess = int.TryParse(txt_pstock.Text, out stock);
                float price;
                bool floatparsesuccess = float.TryParse(txt_pprice.Text, out price);

                if (parseSucess == false)
                {
                    MessageBox.Show("Please enter an integer as stock!");//validating stock is an integer
                    return;
                }

                if (floatparsesuccess == false)//validating price is a float
                {
                    MessageBox.Show("Please enter an valid number as price!");
                    return;
                }

                else
                {
                    //update an existing product
                    sdm.modifyData("Update Products set Product_name='" + txt_pname.Text + "',Product_color='" + txt_pcolor.Text + "',Product_quantity='" + int.Parse(txt_pstock.Text) + "',Product_price='" + float.Parse(txt_pprice.Text) + "',Product_manufacturer='" + txt_pmanufacturer.Text + "',Product_description='" + txt_pdescription.Text + "',Product_type='" + cmb_ptype.Text + "' where Product_ID='" + txt_PID.Text + "'");
                    MessageBox.Show("Product updated Succesful!");
                    loadProducts();
                }
            }
            catch(Exception ex)
            {
               
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            //delete a product
            try
            {
                sdm.modifyData("delete from Products where Product_ID='" + txt_PID.Text + "'");
                MessageBox.Show("Product Deleted Succesfully!");
                loadProducts();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dgv_products_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_products.CurrentRow.Index != -1)
            {
                txt_PID.Text = dgv_products.CurrentRow.Cells[0].Value.ToString();
                txt_pname.Text = dgv_products.CurrentRow.Cells[1].Value.ToString();
                txt_pcolor.Text = dgv_products.CurrentRow.Cells[2].Value.ToString();
                txt_pstock.Text = dgv_products.CurrentRow.Cells[3].Value.ToString();
                txt_pprice.Text = dgv_products.CurrentRow.Cells[4].Value.ToString();
                txt_pmanufacturer.Text = dgv_products.CurrentRow.Cells[5].Value.ToString();
                txt_pdescription.Text = dgv_products.CurrentRow.Cells[6].Value.ToString();
                cmb_ptype.Text = dgv_products.CurrentRow.Cells[7].Value.ToString();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMain am = new AdminMain();
            am.Show();
        }

        private void dgv_products_Click(object sender, EventArgs e)
        {
            if (dgv_products.CurrentRow.Index != -1)
            {
                txt_PID.Text = dgv_products.CurrentRow.Cells[0].Value.ToString();
                txt_pname.Text = dgv_products.CurrentRow.Cells[1].Value.ToString();
                txt_pcolor.Text = dgv_products.CurrentRow.Cells[2].Value.ToString();
                txt_pstock.Text = dgv_products.CurrentRow.Cells[3].Value.ToString();
                txt_pprice.Text = dgv_products.CurrentRow.Cells[4].Value.ToString();
                txt_pmanufacturer.Text = dgv_products.CurrentRow.Cells[5].Value.ToString();
                txt_pdescription.Text = dgv_products.CurrentRow.Cells[6].Value.ToString();
                cmb_ptype.Text = dgv_products.CurrentRow.Cells[7].Value.ToString();
            }
        }
    }
}
