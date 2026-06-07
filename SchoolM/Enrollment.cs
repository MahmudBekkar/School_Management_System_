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
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SchoolM
{
    public partial class Enrollment : Form
    {
        private readonly string connectionString = @"Data Source=DESKTOP-2IL0NSV\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False";

        public Enrollment()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        
      

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker2.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cnn = new SqlCommand("INSERT INTO entab (EId, StudentName, Section, EnrollDate) VALUES (@EId, @StudentName, @Section, @EnrollDate)", con); cnn.Parameters.AddWithValue("@EId", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
                cnn.Parameters.AddWithValue("@Section", textBox3.Text);
                cnn.Parameters.AddWithValue("@EnrollDate", dateTimePicker2.Value);

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
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT * FROM entab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cnn = new SqlCommand("UPDATE entab SET StudentName=@StudentName, Section=@Section, EnrollDate=@EnrollDate WHERE EId=@EId", con); 
            cnn.Parameters.AddWithValue("@EId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Section", textBox3.Text);
            cnn.Parameters.AddWithValue("@EnrollDate", dateTimePicker2.Value);

            cnn.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnDisplay_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cnn = new SqlCommand("DELETE FROM entab WHERE EId=@EId", con);
            cnn.Parameters.AddWithValue("@EId", int.Parse(textBox1.Text));

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

            SqlCommand cnn = new SqlCommand("SELECT * FROM entab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void Enrollment_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT * FROM entab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }
    }
}
