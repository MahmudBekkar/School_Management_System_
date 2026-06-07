using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SchoolM
{
    public partial class Attendance : Form
    {
        private readonly string connectionString = @"Data Source=DESKTOP-2IL0NSV\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False";

        public Attendance()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cnn = new SqlCommand("INSERT INTO attentab (AId, StudentName, Status) VALUES (@AId, @StudentName, @Status)", con);

            cnn.Parameters.AddWithValue("@AId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Status", textBox3.Text);

            cnn.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnDisplay_Click(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT * FROM attentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cnn = new SqlCommand("UPDATE attentab SET StudentName=@StudentName, Status=@Status WHERE AId=@AId", con); cnn.Parameters.AddWithValue("@AId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Status", textBox3.Text);

            cnn.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnDisplay_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cnn = new SqlCommand("DELETE FROM attentab WHERE AId=@AId", con); cnn.Parameters.AddWithValue("@AId", int.Parse(textBox1.Text));
            
            cnn.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnDisplay_Click(sender, e);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
         
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT * FROM attentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }
    }
}
