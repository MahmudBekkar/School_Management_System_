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
    public partial class Section : Form
    {
        private readonly string connectionString = @"Data Source=DESKTOP-2IL0NSV\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False";

        public Section()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cnn = new SqlCommand("INSERT INTO sectiontab (SectionId, StudentName, Section) VALUES (@SectionId, @StudentName, @Section)", con);

                cnn.Parameters.AddWithValue("@SectionId", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
                cnn.Parameters.AddWithValue("@Section", textBox3.Text);

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
            SqlCommand cnn = new SqlCommand("select * from sectiontab", con); SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cnn = new SqlCommand("UPDATE sectiontab SET StudentName=@StudentName, Section=@Section WHERE SectionId=@SectionId", con); cnn.Parameters.AddWithValue("@SectionId", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
                cnn.Parameters.AddWithValue("@Section", textBox3.Text);

                cnn.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDisplay_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cnn = new SqlCommand("DELETE FROM sectiontab WHERE SectionId=@SectionId", con); cnn.Parameters.AddWithValue("@SectionId", int.Parse(textBox1.Text));
               

                cnn.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDisplay_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
           
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cnn = new SqlCommand("SELECT * FROM sectiontab", con);
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

        private void Section_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2IL0NSV\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cnn = new SqlCommand("SELECT * FROM sectiontab", con); SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
