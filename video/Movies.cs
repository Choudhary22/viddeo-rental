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

namespace video
// video programing is start from here
{
    public partial class Movies : Form
    {
        SqlDataAdapter SqlAdapter = new SqlDataAdapter();
        SqlConnection SqlConnect = new SqlConnection();
        SqlCommand SqlCommands = new SqlCommand();
        DataSet dataSet = new DataSet();
        public Movies()
        {
            InitializeComponent();
        }
        // here i did about movie load coding
        private void Movies_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet3.Movies' table. You can move, or remove it, as needed.
            this.moviesTableAdapter.Fill(this.database1DataSet3.Movies);

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                    textBox6.Text = row.Cells[0].Value.ToString();
                    textBox7.Text = row.Cells[1].Value.ToString();
                    textBox8.Text = row.Cells[2].Value.ToString();
                    textBox9.Text = row.Cells[3].Value.ToString();
                    textBox10.Text = row.Cells[4].Value.ToString();
                    textBox11.Text = row.Cells[5].Value.ToString();
                    textBox12.Text = row.Cells[6].Value.ToString();
                    textBox13.Text = row.Cells[7].Value.ToString();


                }
            }
            catch (Exception e1)
            {
            }
        }
        // movie adding function is here
        private void AddNewMovie(object sender, EventArgs e)
        {
            MajorClass ObjectOfClass = new MajorClass();
            SqlConnect.Close();
            string str = ObjectOfClass.connectionstring();
            int year1 = Convert.ToInt16(textBox9.Text);
            string rent = "";
            if (2019 - year1 > 5)
            {
                rent = "2";
            }
            else
            {
                rent = "5";
            }

            SqlConnect.ConnectionString = str;
            SqlCommands.CommandType = CommandType.Text;
            SqlCommands.CommandText = "insert into Movies values('" + textBox7.Text + "','" + textBox8.Text + "','" + year1 + "'," + rent + ",'" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "')";

            SqlAdapter.InsertCommand = SqlCommands;
            SqlCommands.Connection = SqlConnect;
            SqlConnect.Open();
            SqlCommands.ExecuteNonQuery();
            
                MessageBox.Show("New Movie Added");
           
        }
        // here command for sql is also here
        private void UpdateMovie(object sender, EventArgs e)
        {
            MajorClass ObjectofClass = new MajorClass();
            SqlConnect.Close();
            string str = ObjectofClass.connectionstring();
            int year1 = Convert.ToInt16(textBox9.Text);
            string rent = "";
            if (2019 - year1 > 5)
            {
                rent = "2";
            }
            else
            {
                rent = "5";
            }

            SqlConnect.ConnectionString = str;
            SqlCommands.CommandType = CommandType.Text;

            SqlCommands.CommandText = "update Movies set Rating='" + textBox7.Text + "',Title='" + textBox8.Text + "',Year='" + year1 + "',Rental_Cost=" + rent + ",Copies='" + textBox11.Text + "',Genre='" + textBox13.Text + "' where MovieID=" + textBox6.Text;

            SqlAdapter.UpdateCommand = SqlCommands;
            SqlCommands.Connection = SqlConnect;
            SqlConnect.Open();
            SqlCommands.ExecuteNonQuery();
           
            MessageBox.Show("Movie Updated");
        }
       // movie delete command is here
        private void DeleteMovie(object sender, EventArgs e)
        {

            MajorClass ObjectofClass = new MajorClass();
            SqlConnect.Close();
            string str = ObjectofClass.connectionstring();


           
            SqlCommands.CommandType = CommandType.Text;
            SqlCommands.CommandText = "delete Movies where MovieID=" + textBox6.Text;

            SqlAdapter.DeleteCommand = SqlCommands;
            SqlCommands.Connection = SqlConnect;
            SqlConnect.Open();
            SqlCommands.ExecuteNonQuery();
            
          
                MessageBox.Show("Movie Deleted");
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                

                      
        }
        // data gridview coding is here s
        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                    textBox6.Text = row.Cells[0].Value.ToString();
                    textBox7.Text = row.Cells[1].Value.ToString();
                    textBox8.Text = row.Cells[2].Value.ToString();
                    textBox9.Text = row.Cells[3].Value.ToString();
                    textBox10.Text = row.Cells[4].Value.ToString();
                    textBox11.Text = row.Cells[5].Value.ToString();
                    textBox12.Text = row.Cells[6].Value.ToString();
                    textBox13.Text = row.Cells[7].Value.ToString();


                }
            }
            catch (Exception e1)
            {
            }
        }
    }
}
