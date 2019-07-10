using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace video
{       
    class operationclass
    {
        SqlDataAdapter SqlAdapter = new SqlDataAdapter();
        SqlConnection SqlConnect = new SqlConnection();
        SqlCommand SqlCommands = new SqlCommand();
        DataSet dataSet = new DataSet();
        public string connectionstring()
        {
            return(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anilm\source\repos\video\video\Database2.mdf;Integrated Security=True");
        }

        
        public int getmaxmovieid()
        {
         
            SqlConnect.Close();
            SqlConnect.ConnectionString = connectionstring(); 
            SqlCommands.CommandType = CommandType.Text;
            SqlCommands.CommandText = "select max(MovieID) from Movies";
            SqlAdapter.SelectCommand = SqlCommands;
            SqlCommands.Connection = SqlConnect;
            SqlConnect.Open();
            SqlAdapter.Fill(dataSet);
            int id = Convert.ToInt16(dataSet.Tables[0].Rows[0][0]);
            return (id);
        }
       
        public DataSet moviedata(string movieid)
        {
      
            SqlConnect.Close();
            SqlConnect.ConnectionString = connectionstring();
            SqlCommands.CommandType = CommandType.Text;
            SqlCommands.CommandText = "select * from Movies where movieid=" + movieid;
            SqlAdapter.SelectCommand = SqlCommands;
            SqlCommands.Connection = SqlConnect;
            SqlConnect.Open();
            SqlAdapter.Fill(dataSet);
            return (dataSet);
        }
   

       
      
      
        
         
        public DataSet showcurrent()
        {
  
            SqlConnect.Close();
            SqlConnect.ConnectionString = connectionstring();
            SqlCommands.CommandType = CommandType.Text;
            SqlCommands.CommandText = "select * from Movies where year='2019'";
            SqlAdapter.SelectCommand = SqlCommands;
            SqlCommands.Connection = SqlConnect;
            SqlConnect.Open();
            SqlAdapter.Fill(dataSet);
            return (dataSet);
        }
        public DataSet mostpopular()
        {
            
            SqlConnect.Close();
            SqlConnect.ConnectionString = connectionstring(); 
            SqlCommands.CommandType = CommandType.Text;
            SqlCommands.CommandText = "select * from Movies where  MovieID in (select MovieIDFK from RentedMovies)";
            SqlAdapter.SelectCommand = SqlCommands;
            SqlCommands.Connection = SqlConnect;
            SqlConnect.Open();
            SqlAdapter.Fill(dataSet);
            return (dataSet);
        }
    }
}
