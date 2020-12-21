using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricalIdentify
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int difficulty { get; set; }
        public float math_exp { get; set; }
        public float dispersion { get; set; }
        public float avg_speed { get; set; }
        public string avg_vector { get; set; }

        private DBContext context;

        //////// Constructors
        public User() {
            id = 0;
            login = "";
            password = "";
            difficulty = 0;
            math_exp = 0F;
            dispersion = 0F;
            avg_speed = 0F;
            avg_vector = "";
            context = new DBContext();
        }

        public User(string login)
        {
            id = 0;
            this.login = login;
            password = "";
            difficulty = 0;
            math_exp = 0F;
            dispersion = 0F;
            avg_speed = 0F;
            avg_vector = "";
            context = new DBContext();

        }

        public User(string login, string password)
        {
            id = 0;
            this.login = login;
            this.password = password;
            difficulty = 0;
            math_exp = 0F;
            dispersion = 0F;
            avg_speed = 0F;
            avg_vector = "";
            context = new DBContext();
            context.closeConnection();
        }


        //////// Common DB actions
        public bool registrateUser()
        {
            if (checkForUnique())
            {
                difficulty = DifficultyChecker.difficultyCheck(password);
                string query = "INSERT INTO `users`(`login`, `password`, `difficulty`) VALUES(@login, @password, @difficulty)";
                MySqlCommand command = new MySqlCommand(query, context.getConnection());
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                command.Parameters.Add("@difficulty", MySqlDbType.Int16).Value = difficulty;
                context.openConnection();
                command.ExecuteNonQuery();
                context.closeConnection();
                authenticateUser();
                return true; //success
            }
            else
            {
                return false; //unsuccess
            }
        }

        public bool registrateUser(string login, string password)
        {
            if (checkForUnique())
            {
                difficulty = DifficultyChecker.difficultyCheck(password);
                string query = "INSERT INTO `users`(`login`, `password`, `difficulty`) VALUES(@login, @password, @difficulty)";
                MySqlCommand command = new MySqlCommand(query, context.getConnection());
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                command.Parameters.Add("@difficulty", MySqlDbType.Int16).Value = difficulty;
                context.openConnection();
                command.ExecuteNonQuery();
                context.closeConnection();
                this.login = login;
                this.password = password;
                authenticateUser();
                return true; //success
            }
            else
            {
                return false; //unsuccess
            }
        }
        
        public bool authenticateUser()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command =
                new MySqlCommand("SELECT * FROM `users` WHERE `login` = @login AND `password` = @password",
                context.getConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            context.openConnection();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            context.closeConnection();
            if (table.Rows.Count > 0)
            { 
                object[] item = table.Rows[0].ItemArray;
                this.id = Convert.ToInt32(item[0]);
                this.login = item[1].ToString();
                this.password = item[2].ToString();
                this.difficulty = Convert.ToInt32(item[3]);
                if (item[4] != System.DBNull.Value)
                {
                    this.math_exp = Convert.ToSingle(item[4]);
                }
                if (item[5] != System.DBNull.Value)
                {
                    this.dispersion = Convert.ToSingle(item[5]);
                }
                if (item[6] != System.DBNull.Value)
                {
                    this.avg_speed = Convert.ToSingle(item[6]);
                }
                if (item[7] != System.DBNull.Value)
                {
                    this.avg_vector = Convert.ToString(item[7]);
                }
                return true; //success
            }
            else
            {
                return false; //unsuccess
            }
        }

        public bool authenticateUser(string login, string password) 
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command =
                new MySqlCommand("SELECT * FROM `users` WHERE `login` = @login AND `password` = @password",
                context.getConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password; 
            context.openConnection();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            context.closeConnection();
            if (table.Rows.Count > 0)
            {
                object[] item = table.Rows[0].ItemArray;
                this.id = Convert.ToInt32(item[0]);
                this.login = item[1].ToString();
                this.password = item[2].ToString();
                this.difficulty = Convert.ToInt32(item[3]);
                if (item[4] != System.DBNull.Value)
                {
                    this.math_exp = Convert.ToSingle(item[4]);
                }
                if (item[5] != System.DBNull.Value)
                {
                    this.dispersion = Convert.ToSingle(item[5]);
                }
                if (item[6] != System.DBNull.Value)
                {
                    this.avg_speed = Convert.ToSingle(item[6]);
                }
                if (item[7] != System.DBNull.Value)
                {
                    this.avg_vector = Convert.ToString(item[7]);
                }
                return true; //success
            }
            else
            {
                return false; //unsuccess
            }
        }

        public void verifyUser(double[] vector) 
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command =
                new MySqlCommand("SELECT * FROM `users` WHERE `login` = @login AND `password` = @password",
                context.getConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            context.openConnection();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            context.closeConnection();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                object[] item = table.Rows[i].ItemArray;
                double delta = 0.0;

                string[] canonVector = (Convert.ToString(item[7])).Split(';');
                for (int j = 0; j < vector.Length; j++)
                {
                    double canonEl = Convert.ToDouble(canonVector[j]);
                    if (Math.Abs(canonEl) > 10E-3)
                    {
                        delta += Math.Abs(1 - (vector[j] / canonEl));
                    }
                    else if (Math.Abs(canonEl - vector[j]) > 10E-2)
                    {
                        delta += 1;
                    }
                }

                if (delta < 0.25 * vector.Length)
                {
                    this.id = Convert.ToInt32(item[0]);
                    this.login = item[1].ToString();
                    this.password = item[2].ToString();
                    this.difficulty = Convert.ToInt32(item[3]);
                    if (item[4] != System.DBNull.Value)
                    {
                        this.math_exp = Convert.ToSingle(item[4]);
                    }
                    if (item[5] != System.DBNull.Value)
                    {
                        this.dispersion = Convert.ToSingle(item[5]);
                    }
                    if (item[6] != System.DBNull.Value)
                    {
                        this.avg_speed = Convert.ToSingle(item[6]);
                    }
                    if (item[7] != System.DBNull.Value)
                    {
                        this.avg_vector = Convert.ToString(item[7]);
                    }
                }
            }
        }

        public void identifyUser(double[] vector) 
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command =
                new MySqlCommand("SELECT * FROM `users` WHERE `password` = @password",
                context.getConnection());
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            context.openConnection();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            context.closeConnection();

            double minDelta = vector.Length;
            int bestIdx = -1;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                object[] item = table.Rows[i].ItemArray;
                double delta = 0.0;

                string[] canonVector = (Convert.ToString(item[7])).Split(';');
                for (int j = 0; j < vector.Length; j++)
                {
                    double canonEl = Convert.ToDouble(canonVector[j]);
                    if (Math.Abs(canonEl) > 10E-3)
                    {
                        delta += Math.Abs(1 - (vector[j] / canonEl));
                    }
                    else if (Math.Abs(canonEl - vector[j]) > 10E-2) {
                        delta += 1;
                    }
                }
                if (delta < minDelta)
                {
                    minDelta = delta;
                    bestIdx = i;
                }
            }
            if (bestIdx != -1) 
            {
                object[] item = table.Rows[bestIdx].ItemArray;
                this.id = Convert.ToInt32(item[0]);
                this.login = item[1].ToString();
                this.password = item[2].ToString();
                this.difficulty = Convert.ToInt32(item[3]);
                if (item[4] != System.DBNull.Value)
                {
                    this.math_exp = Convert.ToSingle(item[4]);
                }
                if (item[5] != System.DBNull.Value)
                {
                    this.dispersion = Convert.ToSingle(item[5]);
                }
                if (item[6] != System.DBNull.Value)
                {
                    this.avg_speed = Convert.ToSingle(item[6]);
                }
                if (item[7] != System.DBNull.Value)
                {
                    this.avg_vector = Convert.ToString(item[7]);
                }
            }
        }

        public bool changePassword(string oldPassword, string newPassword)
        {
            if (checkForPasswordValid(oldPassword))
            {
                difficulty = DifficultyChecker.difficultyCheck(password);
                string query = "UPDATE `users` SET `password` = @newPassword ,`difficulty` = @difficulty WHERE `login` = @login";
                MySqlCommand command = new MySqlCommand(query, context.getConnection());
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@newPassword", MySqlDbType.VarChar).Value = newPassword;
                command.Parameters.Add("@difficulty", MySqlDbType.Int16).Value = difficulty;
                context.openConnection();
                command.ExecuteNonQuery();
                context.closeConnection();
                this.password = newPassword;
                return true; //success
            }
            else
            {
                return false; //unsuccess
            }
        }

        ////////Statics update
        public void updateCommonStatistics(float math_exp, float dispersion, List<double> speeds, List<double[]> vectors) 
        {
            this.math_exp = math_exp;
            this.dispersion = dispersion;
            List<double> avg_vector_double = new List<double>();
            this.avg_vector = "";
            for (int i = 0; i < vectors[1].Length; i++) {
                avg_vector_double.Add(0.0);
                for (int j = 1; j < vectors.Count; j++) {
                    avg_vector_double[i] += vectors[j][i];
                }
                avg_vector_double[i] = avg_vector_double[i] / vectors.Count;
                this.avg_vector += avg_vector_double[i].ToString() + ";";
            }
            this.avg_speed = 0.0F;
            for (int i = 0; i < speeds.Count; i++) {
                this.avg_speed += Convert.ToSingle(speeds[i]);
            }
            this.avg_speed = this.avg_speed / speeds.Count;
            string query = "UPDATE `users` SET `math_exp` = @math_exp ,`dispersion` = @dispersion , `avg_speed` = @avg_speed , `avg_vector` = @avg_vector WHERE `id` = @id";
            MySqlCommand command = new MySqlCommand(query, context.getConnection());
            command.Parameters.Add("@math_exp", MySqlDbType.Float).Value = this.math_exp;
            command.Parameters.Add("@dispersion", MySqlDbType.Float).Value = this.dispersion;
            command.Parameters.Add("@avg_speed", MySqlDbType.Float).Value = this.avg_speed;
            command.Parameters.Add("@avg_vector", MySqlDbType.VarChar).Value = this.avg_vector;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            context.openConnection();
            command.ExecuteNonQuery();
            context.closeConnection();

        }

        ////////Boolean checks
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
        
    }
}
