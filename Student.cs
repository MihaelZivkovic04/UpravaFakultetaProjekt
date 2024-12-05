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

namespace UpravaFakulteta
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Korisnik\Documents\FakultetBazaPodataka.mdf;Integrated Security=True;Connect Timeout=30");

        private void Student_Load(object sender, EventArgs e)
        {
            Ispis();
        }

        private void Ispis()
        {
            conn.Open();
            string query = "SELECT ime, prezime, telefon, kolegij FROM student";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            StudentList.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Stime.Text == "" || Stprez.Text == "" || Stoib.Text == "" || Sttel.Text == "" || Stkol.Text == "")
                {
                    MessageBox.Show("Nedovoljno informacija!");
                }
                else
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO student(ime, prezime, oib, telefon, kolegij) VALUES ('"+ Stime.Text +"','"+ Stprez.Text +"','"+ Stoib.Text +"','" +Sttel.Text + "','" + Stkol.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Student/ica uspješno dodan!");
                    Ispis();
                    DeleteText();
                }
            }
            catch
            {
                MessageBox.Show("Error.");
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand delete = new SqlCommand("DELETE FROM student WHERE student_id = (SELECT MAX(student_id) FROM student)", conn);
                delete.ExecuteNonQuery();
                conn.Close();
                Ispis();
            } catch
            {
                MessageBox.Show("Error.");
            }
        }
        
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DeleteText()
        {
            Stime.Text = "";
            Stprez.Text = "";
            Stoib.Text = "";
            Sttel.Text = "";
            Stkol.Text = "";
        }

        private void Stime_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
