using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MS_2tier
{
    public partial class Form1 : Form
    {
       
        private const string String = "data source = DESKTOP-A8SSEO0\\SQLEXPRESS; initial catalog = User_; persist security info=True; Integrated Security = SSPI;";
        private static SqlConnection con = new SqlConnection(String);
        private static SqlCommand comd;
        private static DataTable dt;
        private static SqlDataAdapter SDA;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql;
            sql = "insert into [user_] values @ID,@username ,@Age";
            comd = new SqlCommand(sql, con);
            comd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            comd.Parameters.AddWithValue("@username", txtusername.Text);
            comd.Parameters.AddWithValue("@Age", txtage.Text);
            comd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("add the rec has been sussfully");
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            con.Open();
            comd = new SqlCommand("update [user_] set username=@username,Age=@age where ID=@ID", con);
            comd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            comd.Parameters.AddWithValue("@username", txtusername.Text);
            comd.Parameters.AddWithValue("@Age", txtage.Text);
            comd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("update the rec has been sussfully");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            con.Open();
            comd = new SqlCommand("Delete [user_] where ID=@ID", con);
            comd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            comd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete the rec has been sussfully");
        }

        private void btnserach_Click(object sender, EventArgs e)
        {
            con.Open();
            comd = new SqlCommand("select * from [user_]", con);
            SDA = new SqlDataAdapter(comd);
            dt = new DataTable();
            SDA.Fill(dt);
            dataGridView.DataSource = dt;
            con.Close();
        }
    }
}
