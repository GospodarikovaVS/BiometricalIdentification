using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricalIdentify
{
    public class DBContext
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=bmip");

        public void openConnection() {
            if (connection.State == System.Data.ConnectionState.Closed) 
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection getConnection() {
            return connection;
        }

        public String getAllUsers() {
            string usersList = "";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command =
                new MySqlCommand("SELECT * FROM `users`",
                getConnection());
            openConnection();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            closeConnection();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string user = "";
                object[] item = table.Rows[i].ItemArray;
                user += "id:" + Convert.ToString(item[0]) + ";";
                user += "login:" + item[1].ToString() + ";";
                user += "password:" + item[2].ToString() + ";";
                user += "difficulty:" + Convert.ToString(item[3]) + ";";
                if (item[4] != System.DBNull.Value)
                {
                    user += "math_exp:" + Convert.ToString(item[4]) + ";";
                }
                else {
                    user += "math_exp: ;";
                }
                if (item[5] != System.DBNull.Value)
                {
                    user += "dispersion:" + Convert.ToString(item[5]) + ";";
                }
                else
                {
                    user += "dispersion: ;";
                }
                if (item[6] != System.DBNull.Value)
                {
                    user += "avg_speed:" + Convert.ToString(item[6]) + ";";
                }
                else
                {
                    user += "avg_speed: ;";
                }
                if (item[7] != System.DBNull.Value)
                {
                    user += "avg_vector:" + Convert.ToString(item[7]) + ";";
                }
                else
                {
                    user += "avg_vector: ;";
                }
            }
            return usersList;
        }
    }
}
