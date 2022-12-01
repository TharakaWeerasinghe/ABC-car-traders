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
    public partial class Account_Settings : Form
    {
        SqlDataManipulator sdm = new SqlDataManipulator();
        public Account_Settings()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Account_Settings_Load(object sender, EventArgs e)
        {
            //load account data to the text boxes in the form from the database users table
            string user = UserInstance.uname;
            DataTable dt = sdm.dispalyData("Select * from Users where Username='"+user+"'");
            txt_password.Text = dt.Rows[0]["User_Password"].ToString();
            txt_fname.Text= dt.Rows[0]["User_Fname"].ToString();
            txt_lname.Text= dt.Rows[0]["User_Lname"].ToString();
            txt_email.Text= dt.Rows[0]["User_email"].ToString();
            txt_address.Text= dt.Rows[0]["User_address"].ToString();
            txt_cno.Text= dt.Rows[0]["User_contact"].ToString();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

            try
            {
                //validating email and first and last names
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
                    //midify User data and then load the new data to the form
                    string user = UserInstance.uname;
                    sdm.modifyData("Update Users set User_Password='" + txt_password.Text + "',User_Fname='" + txt_fname.Text + "',User_Lname='" + txt_lname.Text + "',User_email='" + txt_email.Text + "',User_address='" + txt_address.Text + "',User_contact='" + txt_cno.Text + "',User_type='User' where Username='" + user + "'");
                    MessageBox.Show("Account Edited Succesfully!");
                    DataTable dt = sdm.dispalyData("Select * from Users where Username='" + user + "'");
                    txt_password.Text = dt.Rows[0]["User_Password"].ToString();
                    txt_fname.Text = dt.Rows[0]["User_Fname"].ToString();
                    txt_lname.Text = dt.Rows[0]["User_Lname"].ToString();
                    txt_email.Text = dt.Rows[0]["User_email"].ToString();
                    txt_address.Text = dt.Rows[0]["User_address"].ToString();
                    txt_cno.Text = dt.Rows[0]["User_contact"].ToString();

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
