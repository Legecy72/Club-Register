using System;
using System.Data;
using System.Data.SqlClient;


namespace Club_Register
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\querc\source\repos\Club Register\Club Register\Database1.mdf"";Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from club", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into club "
                + "values('" + txtName.Text + "' , " + txtNo.Text + "," + txtNum.Text + " , '" + txtAddress.Text + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE club SET [Name] = '" + txtName.Text + "', [Address] = '"+ txtAddress.Text+"',  [Phone Number] =  " + txtNum.Text + " WHERE [Membership No] = " + txtNo.Text, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM club WHERE [Membership No] = " + txtNo.Text, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}