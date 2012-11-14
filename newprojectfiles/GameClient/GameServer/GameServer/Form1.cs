using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GameServer
{
    public partial class Form1 : Form
    {
        Login log;
        SqlConnection con = new SqlConnection();

        public Form1(Login log)
        {
            this.log = log;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login_Click(object sender, EventArgs e)
        {
            error.Text = "Connecting...";
            con.ConnectionString = "server="+t_ip.Text+"\\VOIDDATABASE;database=mmogameproject;user id=oguztecimer; password=dakmoriar4444; Connect Timeout=5;";
            try
            {
                con.Open();
                error.Text = "Authenticating...";
                login.Visible = false;
                
                
                string query = "SELECT ID from dbo.Accounts where username='" + t_username.Text + "' and password='" + t_password.Text + "';";
                SqlCommand queryCommand = new SqlCommand(query, con);
                try
                {
                    int temp = int.Parse(queryCommand.ExecuteScalar().ToString());
                }
                catch
                {
                    error.Text = "Wrong Credentials!"; ; 
                }

                //if (temp.ToString()!="")
                //    t_ip.Text = temp.ToString();
                log.accepted = true;
                con.Close();
                login.Visible = true;
                //this.Close();
            }
            catch
            {
                error.Text = "Connection Error!";
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
