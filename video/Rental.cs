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
{
    public partial class Rental : Form
    {
        SqlDataAdapter SqlAdapter = new SqlDataAdapter();
        SqlConnection SqlConnect = new SqlConnection();
        SqlCommand SqlCommands = new SqlCommand();
        DataSet dataSet = new DataSet();
        public Rental()
        {
            InitializeComponent();
        }

        private void RentAMovie(object sender, EventArgs e)
        {
            MajorClass SomeFunc = new MajorClass();
            SqlConnect.Close();
            SqlConnect.ConnectionString = SomeFunc.connectionstring();
            SqlCommands.CommandType = CommandType.Text;

            SqlCommands.CommandText = "insert into RentedMovies (MovieIDFK,CustIDFK,DateRented)values(" + textBox15.Text + "," + textBox16.Text + ",'" + textBox17.Text + "')";

            SqlAdapter.InsertCommand = SqlCommands;
            SqlCommands.Connection = SqlConnect;
            SqlConnect.Open();
            SqlCommands.ExecuteNonQuery();
            
            
            
                MessageBox.Show("Movie Issued and Added to your Account");
            
        }

        private void Rental_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet5.RentedMovies' table. You can move, or remove it, as needed.
            this.rentedMoviesTableAdapter.Fill(this.database1DataSet5.RentedMovies);

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];

                textBox14.Text = row.Cells[0].Value.ToString();

                textBox15.Text = row.Cells[1].Value.ToString();
                textBox16.Text = row.Cells[2].Value.ToString();
                textBox17.Text = row.Cells[3].Value.ToString();
                textBox18.Text = row.Cells[4].Value.ToString();


            }
        }

        private void ReturnAMovie(object sender, EventArgs e)
        {
            MajorClass SomeFunc = new MajorClass();
            SqlConnect.Close();



            SqlConnect.ConnectionString = SomeFunc.connectionstring();
            SqlCommands.CommandType = CommandType.Text;
            SqlCommands.CommandText = "update RentedMovies set DateReturned='" + textBox18.Text + "' where RMID=" + textBox14.Text;

            SqlAdapter.UpdateCommand = SqlCommands;
            SqlCommands.Connection = SqlConnect;
            SqlConnect.Open();
            SqlCommands.ExecuteNonQuery();
            
                MessageBox.Show("Thanks for Returning Movies. Hope you like it. Rent out other popular Movies");
            
                }
      private void CurrentMovies(object sender, EventArgs e)
        {
            MajorClass SomeFunc = new MajorClass();
            DataSet Current = SomeFunc.showcurrent();
            dataGridView4.DataSource = Current.Tables[0];
        }

        private void PopularMovies(object sender, EventArgs e)
        {
            MajorClass SomeFunc = new MajorClass();
            DataSet Popular = SomeFunc.mostpopular();
            dataGridView4.DataSource = Popular.Tables[0];
        }
    }
}
