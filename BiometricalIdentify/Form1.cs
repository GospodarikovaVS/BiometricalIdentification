using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace BiometricalIdentify
{
    public partial class LogInForm : Form
    {
        private PassChecker passChecker;
        private PushingKeyQueue pushingKeyQueue;
        private Stopwatch commonStopwatch;
        Series inputSpeedsSeries;
        Series inputDinamicsSeries;

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

            if (PasswordInputBox.TextLength == 0) MessageBox.Show("Вы не ввели пароль");
            else {
                byte difficulty = 0;
                bool success = passChecker.passCheck(PasswordInputBox.Text, ref difficulty);

                if (success)
                {
                    String comStatisticsText = "Difficulty of inputed password is " + difficulty.ToString() + Environment.NewLine +
                                            "Input speed is " + passChecker.getLastInputSpeed().ToString("N2") + Environment.NewLine +
                                            "Mathematical expectation is " + passChecker.getMathExp().ToString("N2") + Environment.NewLine +
                                            "Dispersion is " + passChecker.getDispersion().ToString("N2") + Environment.NewLine;
                    String keyOverlaysText = "Amount of keys` overlays:" + Environment.NewLine + 
                                                "    1st type - " + passChecker.getLastKeyOverlaysFstType() + Environment.NewLine +
                                                "    2nd type - " + passChecker.getLastKeyOverlaysSndType() + Environment.NewLine +
                                                "    3rd type - " + passChecker.getLastKeyOverlaysThrdType();

                    PasswordInputBox.Clear();
                    ComStatBox.Clear();
                    KeyOverlayBox.Clear();
                    ComStatBox.AppendText(comStatisticsText);
                    KeyOverlayBox.AppendText(keyOverlaysText);
                    inputSpeedsSeries.Points.Add(passChecker.getLastInputSpeed());
                    inputDinamicsSeries.Points.Add(passChecker.getDispersion());
                }
                else {
                    MessageBox.Show("Пароль введён неверно");
                    PasswordInputBox.Clear();
                    ComStatBox.Clear();
                    KeyOverlayBox.Clear();
                }
            }

            pushingKeyQueue = new PushingKeyQueue();
        }

        private void RestartStatButton_Click(object sender, EventArgs e)
        {
            ComStatBox.ScrollBars = ScrollBars.Vertical;
            HoldTimeBox.ScrollBars = ScrollBars.Vertical;
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
            inputDinamicsSeries = InputDynamicsChart.Series.Add("symbols\nper sec");
            inputDinamicsSeries.ChartType = SeriesChartType.Spline;

            inputDinamicsSeries.Points.Clear();
        }

        private void SaveStatButton_Click(object sender, EventArgs e)
        {

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

    }
}
