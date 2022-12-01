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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SQl_Get_Data getData = new SQl_Get_Data();
        DataTable tbl = new DataTable();

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_usename.Text==""&&txt_password.Text=="")//seeing if whether password and username is empty
            {
                MessageBox.Show("Please Enter Username and Password to Login");
            }
            else
            {
                //checking if the login details are correct
                tbl = getData.DataTable("select * from users where Username='" + txt_usename.Text + "' and User_Password='" + txt_password.Text + "'");
                if (tbl.Rows.Count > 0)
                {
                    UserInstance.uname = txt_usename.Text;
                    if (tbl.Rows[0]["User_type"].ToString() == "Administrator")//login as admin
                    {
                        this.Hide();
                        AdminMain am = new AdminMain();
                        am.Show();

                    }
                    else//login as normal user
                    {
                        this.Hide();
                        UserMain um = new UserMain();
                        um.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Login Failed: Incorrect Username or Password");
                }
            }

            
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register r = new Register();
            r.Show();
        }
    }
}
