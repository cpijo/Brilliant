using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Data
{
    class sql_Connection
    {
        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            SqlDataReader dataReader;
            string sql = null;

            connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;Integrated Security=SSPI;User ID=UserName;Password=Password";
            sql = "Your SQL Statement Here , like Select * from product";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                   // MessageBox.Show(dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2));
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Can not open connection ! ");
            }
        }
    }
}
