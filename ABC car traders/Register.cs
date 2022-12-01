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
    public partial class Register : Form
    {
        SqlDataManipulator sdm = new SqlDataManipulator();
        public Register()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            try
            {
                //validating email,first name and lastname
                string patternmail = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                string patternfname = "^.*[a-zA-Z]";
                string patternlname= "^.*[a-zA-Z]";
                if (!Regex.IsMatch(txt_email.Text, patternmail))
                {
                    MessageBox.Show("Please  enter the email in a correct format");
                    return;
                }
                if (!Regex.IsMatch(txt_fname.Text,patternfname))
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
                    //registering a new user
                    sdm.modifyData("insert into Users(Username,User_Password,User_Fname,User_Lname,User_email,User_address,User_contact,User_type) values('" + txt_uname.Text + "','" + txt_password.Text + "','" + txt_fname.Text + "','" + txt_lname.Text + "','" + txt_email.Text + "','" + txt_address.Text + "','" + txt_cno.Text + "','User')");
                    MessageBox.Show("Registration Succesful!");
                }
            }
                
            catch(Exception ex)
            {
                if(ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                {
                    MessageBox.Show("Username taken please enter another username");
                }
            }

            
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void txt_email_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
