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
    public partial class Subject : Form
    {
        public Subject()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        
       
            private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2IL0NSV\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("INSERT INTO subtab (SubjectId, SubjectName) VALUES (@SubjectId, @SubjectName)", con);

            int subjectId;
            if (!int.TryParse(textBox1.Text, out subjectId))
            {
                MessageBox.Show("Please enter a valid number in the SubjectId field.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                con.Close();
                return;
            }

            cnn.Parameters.AddWithValue("@SubjectId", subjectId);
            cnn.Parameters.AddWithValue("@SubjectName", textBox2.Text);

            cnn.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Record Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }
            


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2IL0NSV\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from subtab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2IL0NSV\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cnn = new SqlCommand("UPDATE subtab SET SubjectName=@SubjectName WHERE SubjectId=@SubjectId", con);
            int subjectId;
            if (!int.TryParse(textBox1.Text, out subjectId))
            {
                MessageBox.Show("Please enter a valid Subject ID to update.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cnn.Parameters.AddWithValue("@SubjectId", subjectId);
            cnn.Parameters.AddWithValue("@SubjectName", textBox2.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2IL0NSV\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("DELETE FROM subtab WHERE SubjectId=@SubjectId", con); int subjectId;
            if (!int.TryParse(textBox1.Text, out subjectId))
            {
                MessageBox.Show("Please enter a valid Subject ID to delete.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cnn.Parameters.AddWithValue("@SubjectId", subjectId);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2IL0NSV\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from subtab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void Subject_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2IL0NSV\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from subtab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
