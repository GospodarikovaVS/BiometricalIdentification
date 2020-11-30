namespace BiometricalIdentify
{
    partial class LogInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            this.PasswordInputBox = new System.Windows.Forms.TextBox();
            this.PassPanel = new System.Windows.Forms.Panel();
            this.LabLogin = new System.Windows.Forms.Label();
            this.LoginInputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LogInButton = new System.Windows.Forms.Button();
            this.LabPass = new System.Windows.Forms.Label();
            this.ControlStatsPanel = new System.Windows.Forms.Panel();
            this.ComStatBox = new System.Windows.Forms.TextBox();
            this.SaveStatButton = new System.Windows.Forms.Button();
            this.RestartStatButton = new System.Windows.Forms.Button();
            this.PassGroup = new System.Windows.Forms.GroupBox();
            this.StatGroup = new System.Windows.Forms.GroupBox();
            this.ViewStatGroup = new System.Windows.Forms.GroupBox();
            this.OtherInfoBox = new System.Windows.Forms.GroupBox();
            this.HoldTimeLabel = new System.Windows.Forms.Label();
            this.HoldTimeBox = new System.Windows.Forms.TextBox();
            this.KeyOverlaysLabel = new System.Windows.Forms.Label();
            this.KeyOverlayBox = new System.Windows.Forms.TextBox();
            this.InputDynamicsStatBox = new System.Windows.Forms.GroupBox();
            this.InputDynamicsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.InputSpeedStatBox = new System.Windows.Forms.GroupBox();
            this.InputSpeedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.RegistrationButton = new System.Windows.Forms.Button();
            this.VectorOutputBox = new System.Windows.Forms.Button();
            this.PassPanel.SuspendLayout();
            this.ControlStatsPanel.SuspendLayout();
            this.PassGroup.SuspendLayout();
            this.StatGroup.SuspendLayout();
            this.ViewStatGroup.SuspendLayout();
            this.OtherInfoBox.SuspendLayout();
            this.InputDynamicsStatBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputDynamicsChart)).BeginInit();
            this.InputSpeedStatBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputSpeedChart)).BeginInit();
            this.SuspendLayout();
            // 
            // PasswordInputBox
            // 
            this.PasswordInputBox.Location = new System.Drawing.Point(15, 78);
            this.PasswordInputBox.Name = "PasswordInputBox";
            this.PasswordInputBox.Size = new System.Drawing.Size(280, 27);
            this.PasswordInputBox.TabIndex = 0;
            this.PasswordInputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordInputBox_KeyDown);
            this.PasswordInputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PasswordInputBox_KeyUp);
            // 
            // PassPanel
            // 
            this.PassPanel.Controls.Add(this.LabLogin);
            this.PassPanel.Controls.Add(this.LoginInputBox);
            this.PassPanel.Controls.Add(this.label1);
            this.PassPanel.Controls.Add(this.LogInButton);
            this.PassPanel.Controls.Add(this.LabPass);
            this.PassPanel.Controls.Add(this.PasswordInputBox);
            this.PassPanel.Location = new System.Drawing.Point(6, 23);
            this.PassPanel.Name = "PassPanel";
            this.PassPanel.Size = new System.Drawing.Size(301, 153);
            this.PassPanel.TabIndex = 1;
            // 
            // LabLogin
            // 
            this.LabLogin.AutoSize = true;
            this.LabLogin.Location = new System.Drawing.Point(12, 3);
            this.LabLogin.Name = "LabLogin";
            this.LabLogin.Size = new System.Drawing.Size(53, 20);
            this.LabLogin.TabIndex = 5;
            this.LabLogin.Text = "Login:";
            // 
            // LoginInputBox
            // 
            this.LoginInputBox.Location = new System.Drawing.Point(15, 26);
            this.LoginInputBox.Name = "LoginInputBox";
            this.LoginInputBox.Size = new System.Drawing.Size(280, 27);
            this.LoginInputBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 8.5F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(16, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "Click Enter \r\nor button ->";
            // 
            // LogInButton
            // 
            this.LogInButton.Location = new System.Drawing.Point(128, 112);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(167, 30);
            this.LogInButton.TabIndex = 2;
            this.LogInButton.Text = "LogIn";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // LabPass
            // 
            this.LabPass.AutoSize = true;
            this.LabPass.Location = new System.Drawing.Point(12, 55);
            this.LabPass.Name = "LabPass";
            this.LabPass.Size = new System.Drawing.Size(83, 20);
            this.LabPass.TabIndex = 1;
            this.LabPass.Text = "Password:";
            // 
            // ControlStatsPanel
            // 
            this.ControlStatsPanel.Controls.Add(this.ComStatBox);
            this.ControlStatsPanel.Controls.Add(this.SaveStatButton);
            this.ControlStatsPanel.Controls.Add(this.RestartStatButton);
            this.ControlStatsPanel.Location = new System.Drawing.Point(6, 26);
            this.ControlStatsPanel.Name = "ControlStatsPanel";
            this.ControlStatsPanel.Size = new System.Drawing.Size(311, 150);
            this.ControlStatsPanel.TabIndex = 2;
            // 
            // ComStatBox
            // 
            this.ComStatBox.Enabled = false;
            this.ComStatBox.Location = new System.Drawing.Point(12, 9);
            this.ComStatBox.Multiline = true;
            this.ComStatBox.Name = "ComStatBox";
            this.ComStatBox.Size = new System.Drawing.Size(287, 88);
            this.ComStatBox.TabIndex = 6;
            // 
            // SaveStatButton
            // 
            this.SaveStatButton.Location = new System.Drawing.Point(168, 108);
            this.SaveStatButton.Name = "SaveStatButton";
            this.SaveStatButton.Size = new System.Drawing.Size(131, 30);
            this.SaveStatButton.TabIndex = 5;
            this.SaveStatButton.Text = "Save";
            this.SaveStatButton.UseVisualStyleBackColor = true;
            this.SaveStatButton.Click += new System.EventHandler(this.SaveStatButton_Click);
            // 
            // RestartStatButton
            // 
            this.RestartStatButton.Location = new System.Drawing.Point(12, 108);
            this.RestartStatButton.Name = "RestartStatButton";
            this.RestartStatButton.Size = new System.Drawing.Size(131, 30);
            this.RestartStatButton.TabIndex = 4;
            this.RestartStatButton.Text = "Restart";
            this.RestartStatButton.UseVisualStyleBackColor = true;
            this.RestartStatButton.Click += new System.EventHandler(this.RestartStatButton_Click);
            // 
            // PassGroup
            // 
            this.PassGroup.Controls.Add(this.PassPanel);
            this.PassGroup.Location = new System.Drawing.Point(10, 12);
            this.PassGroup.Name = "PassGroup";
            this.PassGroup.Size = new System.Drawing.Size(313, 182);
            this.PassGroup.TabIndex = 4;
            this.PassGroup.TabStop = false;
            this.PassGroup.Text = "Pass";
            // 
            // StatGroup
            // 
            this.StatGroup.Controls.Add(this.ControlStatsPanel);
            this.StatGroup.Location = new System.Drawing.Point(329, 12);
            this.StatGroup.Name = "StatGroup";
            this.StatGroup.Size = new System.Drawing.Size(323, 182);
            this.StatGroup.TabIndex = 5;
            this.StatGroup.TabStop = false;
            this.StatGroup.Text = "Statistic";
            // 
            // ViewStatGroup
            // 
            this.ViewStatGroup.Controls.Add(this.OtherInfoBox);
            this.ViewStatGroup.Controls.Add(this.InputDynamicsStatBox);
            this.ViewStatGroup.Controls.Add(this.InputSpeedStatBox);
            this.ViewStatGroup.Location = new System.Drawing.Point(10, 200);
            this.ViewStatGroup.Name = "ViewStatGroup";
            this.ViewStatGroup.Size = new System.Drawing.Size(642, 485);
            this.ViewStatGroup.TabIndex = 6;
            this.ViewStatGroup.TabStop = false;
            this.ViewStatGroup.Text = "ViewStatistic";
            // 
            // OtherInfoBox
            // 
            this.OtherInfoBox.Controls.Add(this.HoldTimeLabel);
            this.OtherInfoBox.Controls.Add(this.HoldTimeBox);
            this.OtherInfoBox.Controls.Add(this.KeyOverlaysLabel);
            this.OtherInfoBox.Controls.Add(this.KeyOverlayBox);
            this.OtherInfoBox.Location = new System.Drawing.Point(6, 317);
            this.OtherInfoBox.Name = "OtherInfoBox";
            this.OtherInfoBox.Size = new System.Drawing.Size(629, 162);
            this.OtherInfoBox.TabIndex = 4;
            this.OtherInfoBox.TabStop = false;
            this.OtherInfoBox.Text = "OtherInfo";
            // 
            // HoldTimeLabel
            // 
            this.HoldTimeLabel.AutoSize = true;
            this.HoldTimeLabel.Location = new System.Drawing.Point(327, 23);
            this.HoldTimeLabel.Name = "HoldTimeLabel";
            this.HoldTimeLabel.Size = new System.Drawing.Size(85, 20);
            this.HoldTimeLabel.TabIndex = 5;
            this.HoldTimeLabel.Text = "HoldTime:";
            // 
            // HoldTimeBox
            // 
            this.HoldTimeBox.Location = new System.Drawing.Point(331, 51);
            this.HoldTimeBox.Multiline = true;
            this.HoldTimeBox.Name = "HoldTimeBox";
            this.HoldTimeBox.Size = new System.Drawing.Size(280, 105);
            this.HoldTimeBox.TabIndex = 4;
            // 
            // KeyOverlaysLabel
            // 
            this.KeyOverlaysLabel.AutoSize = true;
            this.KeyOverlaysLabel.Location = new System.Drawing.Point(12, 23);
            this.KeyOverlaysLabel.Name = "KeyOverlaysLabel";
            this.KeyOverlaysLabel.Size = new System.Drawing.Size(105, 20);
            this.KeyOverlaysLabel.TabIndex = 3;
            this.KeyOverlaysLabel.Text = "KeyOverlays:";
            // 
            // KeyOverlayBox
            // 
            this.KeyOverlayBox.Location = new System.Drawing.Point(16, 51);
            this.KeyOverlayBox.Multiline = true;
            this.KeyOverlayBox.Name = "KeyOverlayBox";
            this.KeyOverlayBox.Size = new System.Drawing.Size(279, 105);
            this.KeyOverlayBox.TabIndex = 2;
            // 
            // InputDynamicsStatBox
            // 
            this.InputDynamicsStatBox.Controls.Add(this.InputDynamicsChart);
            this.InputDynamicsStatBox.Location = new System.Drawing.Point(325, 26);
            this.InputDynamicsStatBox.Name = "InputDynamicsStatBox";
            this.InputDynamicsStatBox.Size = new System.Drawing.Size(311, 286);
            this.InputDynamicsStatBox.TabIndex = 3;
            this.InputDynamicsStatBox.TabStop = false;
            this.InputDynamicsStatBox.Text = "InputDynamics";
            // 
            // InputDynamicsChart
            // 
            chartArea1.Name = "ChartArea1";
            this.InputDynamicsChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.InputDynamicsChart.Legends.Add(legend1);
            this.InputDynamicsChart.Location = new System.Drawing.Point(6, 26);
            this.InputDynamicsChart.Name = "InputDynamicsChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.InputDynamicsChart.Series.Add(series1);
            this.InputDynamicsChart.Size = new System.Drawing.Size(299, 254);
            this.InputDynamicsChart.TabIndex = 0;
            this.InputDynamicsChart.Text = "InputDynamicsChart";
            // 
            // InputSpeedStatBox
            // 
            this.InputSpeedStatBox.Controls.Add(this.InputSpeedChart);
            this.InputSpeedStatBox.Location = new System.Drawing.Point(6, 26);
            this.InputSpeedStatBox.Name = "InputSpeedStatBox";
            this.InputSpeedStatBox.Size = new System.Drawing.Size(301, 286);
            this.InputSpeedStatBox.TabIndex = 2;
            this.InputSpeedStatBox.TabStop = false;
            this.InputSpeedStatBox.Text = "InputSpeed";
            // 
            // InputSpeedChart
            // 
            chartArea2.Name = "ChartArea1";
            this.InputSpeedChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.InputSpeedChart.Legends.Add(legend2);
            this.InputSpeedChart.Location = new System.Drawing.Point(6, 26);
            this.InputSpeedChart.Name = "InputSpeedChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.InputSpeedChart.Series.Add(series2);
            this.InputSpeedChart.Size = new System.Drawing.Size(289, 254);
            this.InputSpeedChart.TabIndex = 0;
            this.InputSpeedChart.Text = "InputSpeedChar";
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.Location = new System.Drawing.Point(10, 691);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(642, 30);
            this.RegistrationButton.TabIndex = 4;
            this.RegistrationButton.Text = "Registration";
            this.RegistrationButton.UseVisualStyleBackColor = true;
            this.RegistrationButton.Click += new System.EventHandler(this.RegistrationButton_Click);
            // 
            // VectorOutputBox
            // 
            this.VectorOutputBox.Location = new System.Drawing.Point(10, 727);
            this.VectorOutputBox.Name = "VectorOutputBox";
            this.VectorOutputBox.Size = new System.Drawing.Size(642, 30);
            this.VectorOutputBox.TabIndex = 7;
            this.VectorOutputBox.Text = "Show vector";
            this.VectorOutputBox.UseVisualStyleBackColor = true;
            this.VectorOutputBox.Click += new System.EventHandler(this.VectorOutputBox_Click);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(660, 766);
            this.Controls.Add(this.VectorOutputBox);
            this.Controls.Add(this.RegistrationButton);
            this.Controls.Add(this.ViewStatGroup);
            this.Controls.Add(this.StatGroup);
            this.Controls.Add(this.PassGroup);
            this.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LogInForm";
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PassPanel.ResumeLayout(false);
            this.PassPanel.PerformLayout();
            this.ControlStatsPanel.ResumeLayout(false);
            this.ControlStatsPanel.PerformLayout();
            this.PassGroup.ResumeLayout(false);
            this.StatGroup.ResumeLayout(false);
            this.ViewStatGroup.ResumeLayout(false);
            this.OtherInfoBox.ResumeLayout(false);
            this.OtherInfoBox.PerformLayout();
            this.InputDynamicsStatBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InputDynamicsChart)).EndInit();
            this.InputSpeedStatBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InputSpeedChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox PasswordInputBox;
        private System.Windows.Forms.Panel PassPanel;
        private System.Windows.Forms.Label LabPass;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.Panel ControlStatsPanel;
        private System.Windows.Forms.TextBox ComStatBox;
        private System.Windows.Forms.Button SaveStatButton;
        private System.Windows.Forms.Button RestartStatButton;
        private System.Windows.Forms.GroupBox PassGroup;
        private System.Windows.Forms.GroupBox StatGroup;
        private System.Windows.Forms.GroupBox ViewStatGroup;
        private System.Windows.Forms.DataVisualization.Charting.Chart InputSpeedChart;
        private System.Windows.Forms.GroupBox InputSpeedStatBox;
        private System.Windows.Forms.GroupBox InputDynamicsStatBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart InputDynamicsChart;
        private System.Windows.Forms.GroupBox OtherInfoBox;
        private System.Windows.Forms.Label HoldTimeLabel;
        private System.Windows.Forms.TextBox HoldTimeBox;
        private System.Windows.Forms.Label KeyOverlaysLabel;
        private System.Windows.Forms.TextBox KeyOverlayBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RegistrationButton;
        private System.Windows.Forms.Label LabLogin;
        private System.Windows.Forms.TextBox LoginInputBox;
        private System.Windows.Forms.Button VectorOutputBox;
    }
}

