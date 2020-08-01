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

namespace Visitor_Diary
{
    public partial class visitor : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=visitor;Integrated Security=True;Pooling=False");
        public visitor()
        {
            InitializeComponent();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Visitor_Load(object sender, EventArgs e)
        {
            Show();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand command = new SqlCommand(@"INSERT INTO contacts 
                    (firstName , lastName, contact, email, purpose) 
                    VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "' , '" + textBox3.Text + "', '" + textBox4.Text + "','" + comboBox1.Text + "')", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Entered Successfull!!");
            Show();
        }

        void Show()
        {
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from contacts", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int number = dataGridView1.Rows.Add();
                dataGridView1.Rows[number].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[number].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[number].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[number].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[number].Cells[4].Value = item[4].ToString();

            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand command = new SqlCommand(@"DELETE FROM contacts WHERE (contact = '"+textBox3.Text+"')", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Successfull!!");
            Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand command = new SqlCommand(@"UPDATE contacts SET firstName='" + textBox1.Text + "', lastName='" + textBox2.Text + "' , contact='" + textBox3.Text + "', email='" + textBox4.Text + "', purpose='" + comboBox1.Text + "' WHERE (contact='"+textBox3.Text+"')", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update Successfull!!");
            Show();
        }
    }
}
