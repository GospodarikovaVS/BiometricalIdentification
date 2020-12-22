using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Data;
using MySql.Data.MySqlClient;

namespace BiometricalIdentify
{
    public partial class LogInForm : Form
    {
        private PassChecker passChecker;
        private PushingKeyQueue pushingKeyQueue;
        private Stopwatch commonStopwatch;
        private User user;
        Series inputSpeedsSeries;
        Series inputDinamicsSeries;
        private List<double> speeds = new List<double>();
        private List<double> timesWithoutPressing = new List<double>();
        public List<double[]> vectors;
        public bool writeStatsMode;

        public LogInForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComStatBox.ScrollBars = ScrollBars.Vertical;
            HoldTimeBox.ScrollBars = ScrollBars.Vertical;
            KeyOverlayBox.ScrollBars = ScrollBars.Vertical;
            passChecker = new PassChecker();
            pushingKeyQueue = new PushingKeyQueue();
            commonStopwatch = new Stopwatch();
            InputSpeedChart.Series.Clear();
            InputSpeedChart.Titles.Add("InputSpeeds");
            InputSpeedChart.Palette = ChartColorPalette.Berry;
            InputSpeedChart.Series.Clear();
            inputSpeedsSeries = InputSpeedChart.Series.Add("symbols\nper sec");
            inputSpeedsSeries.Points.Clear();
            InputDynamicsChart.Titles.Add("Dispersion of InputSpeeds");
            InputDynamicsChart.Palette = ChartColorPalette.Berry;
            InputDynamicsChart.Series.Clear();
            inputDinamicsSeries = InputDynamicsChart.Series.Add("dispersion");
            inputDinamicsSeries.ChartType = SeriesChartType.Spline;
            user = new User();
            ChangePasswordButton.Enabled = false;
            vectors = new List<double[]>();
            writeStatsMode = false;

            inputDinamicsSeries.Points.Clear();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            if (commonStopwatch.IsRunning)
            {
                commonStopwatch.Stop();
                passChecker.addFullTime(commonStopwatch.ElapsedMilliseconds);
                commonStopwatch.Reset();
            }

            passChecker.addKeyOverlays(pushingKeyQueue.getKeyOverlays());
            speeds = pushingKeyQueue.holdingTimes;
            timesWithoutPressing = pushingKeyQueue.overlaysTimes;
            pushingKeyQueue = new PushingKeyQueue();


            if (PasswordInputBox.TextLength == 0) MessageBox.Show("Вы не ввели пароль");
            else
            {
                byte difficulty = 0;
                bool success;
                var vector = UserVector.GetUserVector(speeds.Count, speeds, timesWithoutPressing);
                if (user.id == null || user.id == 0)
                {
                    user.password = PasswordInputBox.Text;
                    user.login = LoginInputBox.Text;
                    success = passChecker.passCheckWithDB(PasswordInputBox.Text, ref difficulty, user, vector);
                    if (user.id == null || user.id == 0) {
                        MessageBox.Show("Вы не смогли войти в систему");
                        PasswordInputBox.Clear();
                        ComStatBox.Clear();
                        KeyOverlayBox.Clear();
                        return;
                    }
                    else 
                    { 
                        MessageBox.Show("Вы вошли в систему как " + user.id + " - " + user.login);
                        LoginInputBox.Text = user.login;
                        ChangePasswordButton.Enabled = true;
                    }
                }
                else
                {
                    success = passChecker.passCheck(PasswordInputBox.Text, ref difficulty, user);
                }

                if (success)
                {
                    LoginInputBox.Enabled = false;
                    if (vectors.Count == 10)
                    {
                        writeStatsMode = false;
                        user.updateCommonStatistics(Convert.ToSingle(passChecker.getMathExp()),
                                                    Convert.ToSingle(passChecker.getDispersion()),
                                                    passChecker.getInputSpeeds(), vectors);
                    }
                    String comStatisticsText = "";
                    comStatisticsText += "Difficulty of inputed password is " + difficulty.ToString() + Environment.NewLine +
                                    "Input speed is " + passChecker.getLastInputSpeed().ToString("N2") + Environment.NewLine +
                                    "Mathematical expectation is " + passChecker.getMathExp().ToString("N2") + Environment.NewLine +
                                    "Dispersion is " + passChecker.getDispersion().ToString("N2") + Environment.NewLine;
                    if (writeStatsMode)
                    {
                        comStatisticsText += "Now we write your statistics. Write password " + (10 - vectors.Count) + " times" + Environment.NewLine;
                    }
                    String keyOverlaysText = "Amount of keys` overlays:" + Environment.NewLine +
                                                "    1st type - " + passChecker.getLastKeyOverlaysFstType() + Environment.NewLine +
                                                "    2nd type - " + passChecker.getLastKeyOverlaysSndType() + Environment.NewLine +
                                                "    3rd type - " + passChecker.getLastKeyOverlaysThrdType();
                    vectors.Add(vector);

                    PasswordInputBox.Clear();
                    ComStatBox.Clear();
                    KeyOverlayBox.Clear();
                    ComStatBox.AppendText(comStatisticsText);
                    KeyOverlayBox.AppendText(keyOverlaysText);
                    inputSpeedsSeries.Points.Add(passChecker.getLastInputSpeed());
                    inputDinamicsSeries.Points.Add(passChecker.getDispersion());
                }
                else
                {
                    MessageBox.Show("Ошибка входа в систему");
                    PasswordInputBox.Clear();
                    ComStatBox.Clear();
                    KeyOverlayBox.Clear();
                }
            }
        }

        private void RestartStatButton_Click(object sender, EventArgs e)
        {
            RestartForm();
        }

        private void RestartForm() {
            ComStatBox.ScrollBars = ScrollBars.Vertical;
            HoldTimeBox.ScrollBars = ScrollBars.Vertical;
            passChecker = new PassChecker();
            pushingKeyQueue = new PushingKeyQueue();
            commonStopwatch = new Stopwatch();
            InputSpeedChart.Series.Clear();
            inputSpeedsSeries = InputSpeedChart.Series.Add("symbols\nper sec");
            inputSpeedsSeries.Points.Clear();
            InputDynamicsChart.Series.Clear();
            inputDinamicsSeries = InputDynamicsChart.Series.Add("symbols\nper sec");
            inputDinamicsSeries.ChartType = SeriesChartType.Spline;
            inputDinamicsSeries.Points.Clear();
            vectors = new List<double[]>();
            user = new User();
            LoginInputBox.Clear();
            PasswordInputBox.Clear();
            LoginInputBox.Enabled = true;
        }

        private void SaveStatButton_Click(object sender, EventArgs e)
        {
            string newPassword = Microsoft.VisualBasic.Interaction.InputBox("Input your password:");
            string passwordConfirm = Microsoft.VisualBasic.Interaction.InputBox("Confirm your password:");
            if (newPassword == passwordConfirm)
            {
                this.user.changePassword(user.password, newPassword);
                MessageBox.Show("Succesfuly changed");
            }
            else
            {
                MessageBox.Show("Passwords is not equal");
            }
        }

        private void PasswordInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                pushingKeyQueue.addNewPushingKey(e.KeyValue);
            }
            if (!commonStopwatch.IsRunning)
            {
                commonStopwatch.Start();
            }
        }

        private void PasswordInputBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                long time = pushingKeyQueue.getPushingTimeByKeyValue(e.KeyValue);
                passChecker.addKeyStatistics(time);
                HoldTimeBox.AppendText(time + "; ");
            }
            else {
                commonStopwatch.Stop();
                passChecker.addFullTime(commonStopwatch.ElapsedMilliseconds);
                commonStopwatch.Reset();
                this.LogInButton_Click(sender, e);
            }
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            User user = new User();
            while (user.login == null || user.login == "")
            {
                string login = Microsoft.VisualBasic.Interaction.InputBox("Input your login:");
                user.login = login;
                if (!user.checkForUnique()) {
                    MessageBox.Show("This login already registered");
                    user.login = "";
                }
            }
            while (user.password == null || user.password == "")
            {
                string password = Microsoft.VisualBasic.Interaction.InputBox("Input your password:");
                string passwordConfirm = Microsoft.VisualBasic.Interaction.InputBox("Confirm your password:");
                if (password == passwordConfirm)
                {
                    user.password = password;
                    user.registrateUser();
                    MessageBox.Show("Registration successfully. Input your password several times for statistic");
                    RestartForm();
                    LoginInputBox.Text = user.login;
                    LoginInputBox.Enabled = false;
                    ChangePasswordButton.Enabled = true;
                    ComStatBox.Text = "Now we write your statistics. Write password " + (10 - vectors.Count) + " times" + Environment.NewLine;
                    writeStatsMode = true;
                    this.user = user;
                }
                else
                {
                    MessageBox.Show("Passwords is not equal");
                }
            }
        }

        private void VectorOutputBox_Click(object sender, EventArgs e)
        { 
            var vector = UserVector.GetUserVector(speeds.Count, speeds, timesWithoutPressing);
            String userVector = "";
            List<double> newVector = new List<double>(); 
            foreach (double item in vector)
            {
                newVector.Add(item);
                userVector += Math.Round(item, 2) + "; ";
            }
            MessageBox.Show(userVector);
        }

        private void ShowListOfUsers_Click(object sender, EventArgs e)
        {
            DBContext context = new DBContext();
            MessageBox.Show(context.getAllUsers(), "Users");
        }
    }
}
