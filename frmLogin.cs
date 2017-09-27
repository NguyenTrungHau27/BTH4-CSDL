using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BaiTH4
{
    public partial class frmLogin : Form
    {
        private SqlConnection nv = null;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            nv = new SqlConnection();
        }
        public void connect(string cnstr)
        {
            try
            {
                if (nv != null)
                {
                    nv.ConnectionString = cnstr;
                    nv.Open();
                    MessageBox.Show("Ket noi thanh cong");

                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Cung cap co so du lieu", ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Loi cap do", ex.Message);
            }
        }
        public void disconnect()
        {
            nv.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string server, database;
            server = txtServerName.Text;
            database = txtDatabase.Text;
            string cnstr = "Server =";
            cnstr += server.Trim() + "; Database = " + database+"; ";
            if (rd1.Checked)
            {
                cnstr += "Integrated Security = true;";
            }
            else
            {
                cnstr += "User = " + txtUserName.Text + "; Password = " + txtPassword.Text + ";";
            }
           
            connect(cnstr);
        }

        private void rd1_CheckedChanged(object sender, EventArgs e)
        {
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
        }

        private void rd2_CheckedChanged(object sender, EventArgs e)
        {
            txtUserName.Enabled = true;
            txtPassword.Enabled = true;
        }

        

      
    }
}
