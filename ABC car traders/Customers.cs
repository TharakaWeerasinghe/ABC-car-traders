using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ABC_car_traders
{
    public partial class Customers : Form
    {
        SqlDataManipulator sdm = new SqlDataManipulator();
        public Customers()
        {
            InitializeComponent();
        }
        //method for loading customer data to the gridview
        public void loadCustomer()
        {
            DataTable dt = sdm.dispalyData("Select * from Users");
            dgv_customers.DataSource = dt;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Customers_Load(object sender, EventArgs e)
        {
            loadCustomer();
        }

        //searching for a customer according to the input text
        private void Btn_search_Click(object sender, EventArgs e)
        {
            DataTable dt = sdm.dispalyData("select * from Users where Username like '" + txt_search.Text + "'+'%'");
            dgv_customers.DataSource = dt;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                //validating email,first name and lastname
                string patternmail = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                string patternfname = "^.*[a-zA-Z]";
                string patternlname = "^.*[a-zA-Z]";
                if (!Regex.IsMatch(txt_email.Text, patternmail))
                {
                    MessageBox.Show("Please  enter the email in a correct format");
                    return;
                }
                if (!Regex.IsMatch(txt_fname.Text, patternfname))
                {
                    MessageBox.Show("Please  enter the first name in a correct format");
                    return;
                }
                if (!Regex.IsMatch(txt_lname.Text, patternlname))
                {
                    MessageBox.Show("Please  enter the Last name in a correct format");
                    return;
                }
                else
                {
                    //creating a new customer
                    sdm.modifyData("insert into Users(Username,User_Password,User_Fname,User_Lname,User_email,User_address,User_contact,User_type) values('" + txt_uname.Text + "','" + txt_password.Text + "','" + txt_fname.Text + "','" + txt_lname.Text + "','" + txt_email.Text + "','" + txt_address.Text + "','" + txt_cno.Text + "','"+cmb_usertype.Text+"')");
                    MessageBox.Show("User Added Succesful!");
                    loadCustomer();
                }
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                {
                    MessageBox.Show("Username taken please enter another username");
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
                //validating email,first name and lastname
                string patternmail = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                string patternfname = "^.*[a-zA-Z]";
                string patternlname = "^.*[a-zA-Z]";
                if (!Regex.IsMatch(txt_email.Text, patternmail))
                {
                    MessageBox.Show("Please  enter the email in a correct format");
                    return;
                }
                if (!Regex.IsMatch(txt_fname.Text, patternfname))
                {
                    MessageBox.Show("Please  enter the first name in a correct format");
                    return;
                }
                if (!Regex.IsMatch(txt_lname.Text, patternlname))
                {
                    MessageBox.Show("Please  enter the Last name in a correct format");
                    return;
                }
                else
                {
                    //updating an existing customer
                    sdm.modifyData("Update Users set User_Password='" + txt_password.Text + "',User_Fname='" + txt_fname.Text + "',User_Lname='" + txt_lname.Text + "',User_email='" + txt_email.Text + "',User_address='" + txt_address.Text + "',User_contact='" + txt_cno.Text + "',User_type='"+cmb_usertype.Text+"' where Username='" + txt_uname.Text + "'");
                    MessageBox.Show("User Modified Succesfully!");
                    loadCustomer();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            //deleting a customer
            try
            {
            
                sdm.modifyData("delete from Users where Username='" + txt_uname.Text + "'");
                MessageBox.Show("User Deleted Succesfully!");
                loadCustomer();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void dgv_customers_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_customers.CurrentRow.Index != -1)
            {
                txt_uname.Text = dgv_customers.CurrentRow.Cells[0].Value.ToString();
                txt_password.Text = dgv_customers.CurrentRow.Cells[1].Value.ToString();
                txt_fname.Text = dgv_customers.CurrentRow.Cells[2].Value.ToString();
                txt_lname.Text = dgv_customers.CurrentRow.Cells[3].Value.ToString();
                txt_email.Text = dgv_customers.CurrentRow.Cells[4].Value.ToString();
                txt_address.Text = dgv_customers.CurrentRow.Cells[5].Value.ToString();
                txt_cno.Text = dgv_customers.CurrentRow.Cells[6].Value.ToString();
                cmb_usertype.SelectedItem = dgv_customers.CurrentRow.Cells[7].Value.ToString();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMain am = new AdminMain();
            am.Show();
        }

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            this.Close();
            AdminMain am = new AdminMain();
            am.Show();
        }

        private void dgv_customers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_customers_Click(object sender, EventArgs e)
        {
            if (dgv_customers.CurrentRow.Index != -1)
            {
                txt_uname.Text = dgv_customers.CurrentRow.Cells[0].Value.ToString();
                txt_password.Text = dgv_customers.CurrentRow.Cells[1].Value.ToString();
                txt_fname.Text = dgv_customers.CurrentRow.Cells[2].Value.ToString();
                txt_lname.Text = dgv_customers.CurrentRow.Cells[3].Value.ToString();
                txt_email.Text = dgv_customers.CurrentRow.Cells[4].Value.ToString();
                txt_address.Text = dgv_customers.CurrentRow.Cells[5].Value.ToString();
                txt_cno.Text = dgv_customers.CurrentRow.Cells[6].Value.ToString();
                cmb_usertype.SelectedItem = dgv_customers.CurrentRow.Cells[7].Value.ToString();
            }
        }
    }
}
