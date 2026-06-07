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
    public partial class Teacher : Form
    {
        private readonly string connectionString = @"Data Source=DESKTOP-2IL0NSV\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False";

        public Teacher()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cnn = new SqlCommand("INSERT INTO teachertab (TeacherId, TeacherName, Gender, Phone) VALUES (@TeacherId, @TeacherName, @Gender, @Phone)", con); cnn.Parameters.AddWithValue("@TeacherId", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@TeacherName", textBox2.Text);
                cnn.Parameters.AddWithValue("@Gender", textBox3.Text);
                cnn.Parameters.AddWithValue("@Phone", textBox4.Text);

                cnn.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDisplay_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2IL0NSV\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from teachertab", con); SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cnn = new SqlCommand("DELETE FROM teachertab WHERE TeacherId=@TeacherId", con); cnn.Parameters.AddWithValue("@TeacherId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@TeacherName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Gender", textBox3.Text);
            cnn.Parameters.AddWithValue("@Phone", textBox4.Text);

            cnn.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnDisplay_Click(sender, e);   
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            SqlCommand cnn = new SqlCommand("DELETE FROM teachertab WHERE TeacherId=@TeacherId", con);
            cnn.Parameters.AddWithValue("@TeacherId", int.Parse(textBox1.Text));      
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
            textBox4.Text = "";
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2IL0NSV\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cnn = new SqlCommand("SELECT * FROM teachertab", con); SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2IL0NSV\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from teachertab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
