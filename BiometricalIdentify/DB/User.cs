using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricalIdentify
{
    class User
    {
        public string login { get; set; }
        public string password { get; set; }
        public double math_exp { get; set; }
        public double dispersion { get; set; }
        public double avg_input_speed { get; set; }
        public int trying_amount { get; set; }
        private DBContext context;

        public User() {
            login = "";
            password = "";
            math_exp = 0;
            dispersion = 0;
            avg_input_speed = 0;
            trying_amount = 0;
            context = new DBContext();
        }

        public User(string login)
        {
            this.login = login;
            password = "";
            math_exp = 0;
            dispersion = 0;
            avg_input_speed = 0;
            trying_amount = 0;
            context = new DBContext();

        }

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
            math_exp = 0;
            dispersion = 0;
            avg_input_speed = 0;
            trying_amount = 0;
            context = new DBContext();
            context.closeConnection();
        }

        public bool checkForExistence() 
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = 
                new MySqlCommand("SELECT * FROM `users` WHERE `password` IS NOT NULL AND `login` = '@login'", 
                context.getConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            context.openConnection();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            context.closeConnection();
            return table.Rows.Count > 0;
        }

        public bool checkForUnique()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @login", context.getConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            context.openConnection();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            context.closeConnection();
            return table.Rows.Count == 0;
        }

        public bool checkForPasswordValid(string userPass)
        {
            if (checkForExistence()) {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = 
                    new MySqlCommand("SELECT * FROM `users` WHERE `login` = '@login' AND `password` = '@password'", 
                    context.getConnection());
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = userPass;
                context.openConnection();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                context.closeConnection();
                return table.Rows.Count > 0;
            }
            return false;
        }
        
        public void registrateUser() 
        {
            if (checkForUnique())
            {
                string query = "INSERT INTO `users`(`login`, `password`) VALUES(@login,@password)";
                MySqlCommand command = new MySqlCommand(query,context.getConnection());
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                context.openConnection();
                command.ExecuteNonQuery();
                context.closeConnection();
            }
        }
    }
}
