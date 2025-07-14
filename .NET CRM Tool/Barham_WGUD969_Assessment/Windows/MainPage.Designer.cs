namespace Barham_WGUD969_Assessment.Windows
{
    partial class MainPage
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
            this.LogoffButton = new System.Windows.Forms.Button();
            this.AppointmentsLabel = new System.Windows.Forms.Label();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.ApptDelButton = new System.Windows.Forms.Button();
            this.ApptModButton = new System.Windows.Forms.Button();
            this.ApptAddButton = new System.Windows.Forms.Button();
            this.CustDelButton = new System.Windows.Forms.Button();
            this.CustModButton = new System.Windows.Forms.Button();
            this.CalendarView = new System.Windows.Forms.MonthCalendar();
            this.CustWApptsRdoButton = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AllCustRdoButton = new System.Windows.Forms.RadioButton();
            this.CustRdoButton = new System.Windows.Forms.RadioButton();
            this.MonthRdoButton = new System.Windows.Forms.RadioButton();
            this.WeekRdoButton = new System.Windows.Forms.RadioButton();
            this.DayRdoButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AllApptsRdoButton = new System.Windows.Forms.RadioButton();
            this.AppointmentView = new System.Windows.Forms.DataGridView();
            this.CustomerView = new System.Windows.Forms.DataGridView();
            this.CustAddButton = new System.Windows.Forms.Button();
            this.ReportsButton = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerView)).BeginInit();
            this.SuspendLayout();
            // 
            // LogoffButton
            // 
            this.LogoffButton.Location = new System.Drawing.Point(710, 415);
            this.LogoffButton.Name = "LogoffButton";
            this.LogoffButton.Size = new System.Drawing.Size(75, 23);
            this.LogoffButton.TabIndex = 29;
            this.LogoffButton.Text = "Log Off";
            this.LogoffButton.UseVisualStyleBackColor = true;
            this.LogoffButton.Click += new System.EventHandler(this.LogoffButton_Click);
            // 
            // AppointmentsLabel
            // 
            this.AppointmentsLabel.AutoSize = true;
            this.AppointmentsLabel.Location = new System.Drawing.Point(16, 244);
            this.AppointmentsLabel.Name = "AppointmentsLabel";
            this.AppointmentsLabel.Size = new System.Drawing.Size(71, 13);
            this.AppointmentsLabel.TabIndex = 27;
            this.AppointmentsLabel.Text = "Appointments";
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Location = new System.Drawing.Point(15, 69);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(56, 13);
            this.CustomerLabel.TabIndex = 26;
            this.CustomerLabel.Text = "Customers";
            // 
            // ApptDelButton
            // 
            this.ApptDelButton.Location = new System.Drawing.Point(177, 387);
            this.ApptDelButton.Name = "ApptDelButton";
            this.ApptDelButton.Size = new System.Drawing.Size(75, 23);
            this.ApptDelButton.TabIndex = 25;
            this.ApptDelButton.Text = "Delete";
            this.ApptDelButton.UseVisualStyleBackColor = true;
            this.ApptDelButton.Click += new System.EventHandler(this.ApptDelButton_Click);
            // 
            // ApptModButton
            // 
            this.ApptModButton.Location = new System.Drawing.Point(96, 387);
            this.ApptModButton.Name = "ApptModButton";
            this.ApptModButton.Size = new System.Drawing.Size(75, 23);
            this.ApptModButton.TabIndex = 24;
            this.ApptModButton.Text = "Modify";
            this.ApptModButton.UseVisualStyleBackColor = true;
            this.ApptModButton.Click += new System.EventHandler(this.ApptModButton_Click);
            // 
            // ApptAddButton
            // 
            this.ApptAddButton.Location = new System.Drawing.Point(15, 387);
            this.ApptAddButton.Name = "ApptAddButton";
            this.ApptAddButton.Size = new System.Drawing.Size(75, 23);
            this.ApptAddButton.TabIndex = 23;
            this.ApptAddButton.Text = "Add";
            this.ApptAddButton.UseVisualStyleBackColor = true;
            this.ApptAddButton.Click += new System.EventHandler(this.ApptAddButton_Click);
            // 
            // CustDelButton
            // 
            this.CustDelButton.Location = new System.Drawing.Point(177, 218);
            this.CustDelButton.Name = "CustDelButton";
            this.CustDelButton.Size = new System.Drawing.Size(75, 23);
            this.CustDelButton.TabIndex = 22;
            this.CustDelButton.Text = "Delete";
            this.CustDelButton.UseVisualStyleBackColor = true;
            this.CustDelButton.Click += new System.EventHandler(this.CustDelButton_Click);
            // 
            // CustModButton
            // 
            this.CustModButton.Location = new System.Drawing.Point(96, 218);
            this.CustModButton.Name = "CustModButton";
            this.CustModButton.Size = new System.Drawing.Size(75, 23);
            this.CustModButton.TabIndex = 21;
            this.CustModButton.Text = "Modify";
            this.CustModButton.UseVisualStyleBackColor = true;
            this.CustModButton.Click += new System.EventHandler(this.CustModButton_Click);
            // 
            // CalendarView
            // 
            this.CalendarView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalendarView.Location = new System.Drawing.Point(558, 218);
            this.CalendarView.Name = "CalendarView";
            this.CalendarView.TabIndex = 20;
            this.CalendarView.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.CalendarView_DateSelected);
            // 
            // CustWApptsRdoButton
            // 
            this.CustWApptsRdoButton.AutoSize = true;
            this.CustWApptsRdoButton.Location = new System.Drawing.Point(4, 27);
            this.CustWApptsRdoButton.Name = "CustWApptsRdoButton";
            this.CustWApptsRdoButton.Size = new System.Drawing.Size(166, 17);
            this.CustWApptsRdoButton.TabIndex = 1;
            this.CustWApptsRdoButton.Text = "Customers With Appointments";
            this.CustWApptsRdoButton.UseVisualStyleBackColor = true;
            this.CustWApptsRdoButton.CheckedChanged += new System.EventHandler(this.CustRdoButton_CheckChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AllCustRdoButton);
            this.panel2.Controls.Add(this.CustWApptsRdoButton);
            this.panel2.Location = new System.Drawing.Point(15, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 53);
            this.panel2.TabIndex = 19;
            // 
            // AllCustRdoButton
            // 
            this.AllCustRdoButton.AutoSize = true;
            this.AllCustRdoButton.Checked = true;
            this.AllCustRdoButton.Location = new System.Drawing.Point(4, 4);
            this.AllCustRdoButton.Name = "AllCustRdoButton";
            this.AllCustRdoButton.Size = new System.Drawing.Size(88, 17);
            this.AllCustRdoButton.TabIndex = 2;
            this.AllCustRdoButton.TabStop = true;
            this.AllCustRdoButton.Text = "All Customers";
            this.AllCustRdoButton.UseVisualStyleBackColor = true;
            this.AllCustRdoButton.CheckedChanged += new System.EventHandler(this.AllCustRdoButton_CheckedChanged);
            // 
            // CustRdoButton
            // 
            this.CustRdoButton.AutoSize = true;
            this.CustRdoButton.Location = new System.Drawing.Point(4, 76);
            this.CustRdoButton.Name = "CustRdoButton";
            this.CustRdoButton.Size = new System.Drawing.Size(84, 17);
            this.CustRdoButton.TabIndex = 3;
            this.CustRdoButton.Text = "By Customer";
            this.CustRdoButton.UseVisualStyleBackColor = true;
            this.CustRdoButton.CheckedChanged += new System.EventHandler(this.ApptView_CheckChanged);
            // 
            // MonthRdoButton
            // 
            this.MonthRdoButton.AutoSize = true;
            this.MonthRdoButton.Location = new System.Drawing.Point(4, 52);
            this.MonthRdoButton.Name = "MonthRdoButton";
            this.MonthRdoButton.Size = new System.Drawing.Size(55, 17);
            this.MonthRdoButton.TabIndex = 2;
            this.MonthRdoButton.Text = "Month";
            this.MonthRdoButton.UseVisualStyleBackColor = true;
            this.MonthRdoButton.CheckedChanged += new System.EventHandler(this.ApptView_CheckChanged);
            // 
            // WeekRdoButton
            // 
            this.WeekRdoButton.AutoSize = true;
            this.WeekRdoButton.Location = new System.Drawing.Point(4, 28);
            this.WeekRdoButton.Name = "WeekRdoButton";
            this.WeekRdoButton.Size = new System.Drawing.Size(54, 17);
            this.WeekRdoButton.TabIndex = 1;
            this.WeekRdoButton.Text = "Week";
            this.WeekRdoButton.UseVisualStyleBackColor = true;
            this.WeekRdoButton.CheckedChanged += new System.EventHandler(this.ApptView_CheckChanged);
            // 
            // DayRdoButton
            // 
            this.DayRdoButton.AutoSize = true;
            this.DayRdoButton.Checked = true;
            this.DayRdoButton.Location = new System.Drawing.Point(4, 4);
            this.DayRdoButton.Name = "DayRdoButton";
            this.DayRdoButton.Size = new System.Drawing.Size(44, 17);
            this.DayRdoButton.TabIndex = 0;
            this.DayRdoButton.TabStop = true;
            this.DayRdoButton.Text = "Day";
            this.DayRdoButton.UseVisualStyleBackColor = true;
            this.DayRdoButton.CheckedChanged += new System.EventHandler(this.ApptView_CheckChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(429, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 33);
            this.label3.TabIndex = 28;
            this.label3.Text = "Appointments";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AllApptsRdoButton);
            this.panel1.Controls.Add(this.CustRdoButton);
            this.panel1.Controls.Add(this.MonthRdoButton);
            this.panel1.Controls.Add(this.WeekRdoButton);
            this.panel1.Controls.Add(this.DayRdoButton);
            this.panel1.Location = new System.Drawing.Point(558, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 127);
            this.panel1.TabIndex = 18;
            // 
            // AllApptsRdoButton
            // 
            this.AllApptsRdoButton.AutoSize = true;
            this.AllApptsRdoButton.Location = new System.Drawing.Point(4, 100);
            this.AllApptsRdoButton.Name = "AllApptsRdoButton";
            this.AllApptsRdoButton.Size = new System.Drawing.Size(103, 17);
            this.AllApptsRdoButton.TabIndex = 4;
            this.AllApptsRdoButton.TabStop = true;
            this.AllApptsRdoButton.Text = "All Appointments";
            this.AllApptsRdoButton.UseVisualStyleBackColor = true;
            this.AllApptsRdoButton.CheckedChanged += new System.EventHandler(this.ApptView_CheckChanged);
            // 
            // AppointmentView
            // 
            this.AppointmentView.AllowUserToAddRows = false;
            this.AppointmentView.AllowUserToDeleteRows = false;
            this.AppointmentView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmentView.Location = new System.Drawing.Point(15, 260);
            this.AppointmentView.MultiSelect = false;
            this.AppointmentView.Name = "AppointmentView";
            this.AppointmentView.ReadOnly = true;
            this.AppointmentView.Size = new System.Drawing.Size(506, 120);
            this.AppointmentView.TabIndex = 17;
            this.AppointmentView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AppointmentView_CellClick);
            // 
            // CustomerView
            // 
            this.CustomerView.AllowUserToAddRows = false;
            this.CustomerView.AllowUserToDeleteRows = false;
            this.CustomerView.AllowUserToOrderColumns = true;
            this.CustomerView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.CustomerView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerView.Location = new System.Drawing.Point(15, 86);
            this.CustomerView.MultiSelect = false;
            this.CustomerView.Name = "CustomerView";
            this.CustomerView.ReadOnly = true;
            this.CustomerView.Size = new System.Drawing.Size(506, 127);
            this.CustomerView.TabIndex = 16;
            this.CustomerView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomerView_CellClick);
            // 
            // CustAddButton
            // 
            this.CustAddButton.Location = new System.Drawing.Point(15, 218);
            this.CustAddButton.Name = "CustAddButton";
            this.CustAddButton.Size = new System.Drawing.Size(75, 23);
            this.CustAddButton.TabIndex = 15;
            this.CustAddButton.Text = "Add";
            this.CustAddButton.UseVisualStyleBackColor = true;
            this.CustAddButton.Click += new System.EventHandler(this.CustAddButton_Click);
            // 
            // ReportsButton
            // 
            this.ReportsButton.Location = new System.Drawing.Point(629, 415);
            this.ReportsButton.Name = "ReportsButton";
            this.ReportsButton.Size = new System.Drawing.Size(75, 23);
            this.ReportsButton.TabIndex = 30;
            this.ReportsButton.Text = "Reports";
            this.ReportsButton.UseVisualStyleBackColor = true;
            this.ReportsButton.Click += new System.EventHandler(this.ReportsButton_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ReportsButton);
            this.Controls.Add(this.LogoffButton);
            this.Controls.Add(this.AppointmentsLabel);
            this.Controls.Add(this.CustomerLabel);
            this.Controls.Add(this.ApptDelButton);
            this.Controls.Add(this.ApptModButton);
            this.Controls.Add(this.ApptAddButton);
            this.Controls.Add(this.CustDelButton);
            this.Controls.Add(this.CustModButton);
            this.Controls.Add(this.CalendarView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AppointmentView);
            this.Controls.Add(this.CustomerView);
            this.Controls.Add(this.CustAddButton);
            this.Name = "MainPage";
            this.Text = "Main Page";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LogoffButton;
        private System.Windows.Forms.Label AppointmentsLabel;
        private System.Windows.Forms.Label CustomerLabel;
        private System.Windows.Forms.Button ApptDelButton;
        private System.Windows.Forms.Button ApptModButton;
        private System.Windows.Forms.Button ApptAddButton;
        private System.Windows.Forms.Button CustDelButton;
        private System.Windows.Forms.Button CustModButton;
        private System.Windows.Forms.MonthCalendar CalendarView;
        private System.Windows.Forms.RadioButton CustWApptsRdoButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton CustRdoButton;
        private System.Windows.Forms.RadioButton MonthRdoButton;
        private System.Windows.Forms.RadioButton WeekRdoButton;
        private System.Windows.Forms.RadioButton DayRdoButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView AppointmentView;
        private System.Windows.Forms.DataGridView CustomerView;
        private System.Windows.Forms.Button CustAddButton;
        private System.Windows.Forms.RadioButton AllCustRdoButton;
        private System.Windows.Forms.Button ReportsButton;
        private System.Windows.Forms.RadioButton AllApptsRdoButton;
    }
}