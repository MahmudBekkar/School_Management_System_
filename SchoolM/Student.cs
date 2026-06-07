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

namespace SchoolM
{
    public partial class Student : Form
    {
        private readonly string connectionString = @"Data Source=DESKTOP-2IL0NSV\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False";
        public Student()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cnn = new SqlCommand("INSERT INTO studentab (StudentId, StudentName, Dob, Gender, Phone, Email) VALUES (@StudentId, @StudentName, @Dob, @Gender, @Phone, @Email)", con);
                cnn.Parameters.AddWithValue("@StudentId", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
                cnn.Parameters.AddWithValue("@Dob", dateTimePicker1.Value);
                cnn.Parameters.AddWithValue("@Gender", textBox3.Text);
                cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
                cnn.Parameters.AddWithValue("@Email", textBox5.Text);

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
            btnDisplay_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cnn = new SqlCommand("UPDATE studentab SET StudentName=@StudentName, Dob=@Dob, Gender=@Gender, Phone=@Phone, Email=@Email WHERE StudentId=@StudentId", con);
                cnn.Parameters.AddWithValue("@StudentId", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
                cnn.Parameters.AddWithValue("@Dob", dateTimePicker1.Value);
                cnn.Parameters.AddWithValue("@Gender", textBox3.Text);
                cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
                cnn.Parameters.AddWithValue("@Email", textBox5.Text);

                cnn.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDisplay_Click(sender, e); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cnn = new SqlCommand("DELETE FROM studentab WHERE StudentId=@StudentId", con); cnn.Parameters.AddWithValue("@StudentId", int.Parse(textBox1.Text));

                cnn.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDisplay_Click(sender, e); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cnn = new SqlCommand("SELECT * FROM studentab", con);
                SqlDataAdapter da = new SqlDataAdapter(cnn);
                DataTable table = new DataTable();
                da.Fill(table);

                dataGridView1.DataSource = table;
                con.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Student_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}