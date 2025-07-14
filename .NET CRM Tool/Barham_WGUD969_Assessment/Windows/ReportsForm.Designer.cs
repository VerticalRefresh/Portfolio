namespace Barham_WGUD969_Assessment.Windows
{
    partial class ReportsForm
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
            this.ReportView = new System.Windows.Forms.DataGridView();
            this.ApptsByMonthRdoButton = new System.Windows.Forms.RadioButton();
            this.SchedByUserRdoButton = new System.Windows.Forms.RadioButton();
            this.ScheduleByCustRdoButton = new System.Windows.Forms.RadioButton();
            this.UserCustComboBox = new System.Windows.Forms.ComboBox();
            this.ApptByMonthPicker = new System.Windows.Forms.DateTimePicker();
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ReportsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ReportView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReportView
            // 
            this.ReportView.AllowUserToAddRows = false;
            this.ReportView.AllowUserToDeleteRows = false;
            this.ReportView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ReportView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReportView.Location = new System.Drawing.Point(10, 124);
            this.ReportView.MultiSelect = false;
            this.ReportView.Name = "ReportView";
            this.ReportView.ReadOnly = true;
            this.ReportView.Size = new System.Drawing.Size(778, 285);
            this.ReportView.TabIndex = 0;
            this.ReportView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ReportView_DataBindingComplete);
            // 
            // ApptsByMonthRdoButton
            // 
            this.ApptsByMonthRdoButton.AutoSize = true;
            this.ApptsByMonthRdoButton.Location = new System.Drawing.Point(3, 3);
            this.ApptsByMonthRdoButton.Name = "ApptsByMonthRdoButton";
            this.ApptsByMonthRdoButton.Size = new System.Drawing.Size(137, 17);
            this.ApptsByMonthRdoButton.TabIndex = 1;
            this.ApptsByMonthRdoButton.Text = "Appointments By Month";
            this.ApptsByMonthRdoButton.UseVisualStyleBackColor = true;
            this.ApptsByMonthRdoButton.CheckedChanged += new System.EventHandler(this.ApptsByMonthRdoButton_CheckedChanged);
            // 
            // SchedByUserRdoButton
            // 
            this.SchedByUserRdoButton.AutoSize = true;
            this.SchedByUserRdoButton.Location = new System.Drawing.Point(3, 26);
            this.SchedByUserRdoButton.Name = "SchedByUserRdoButton";
            this.SchedByUserRdoButton.Size = new System.Drawing.Size(110, 17);
            this.SchedByUserRdoButton.TabIndex = 2;
            this.SchedByUserRdoButton.Text = "Schedule By User";
            this.SchedByUserRdoButton.UseVisualStyleBackColor = true;
            this.SchedByUserRdoButton.CheckedChanged += new System.EventHandler(this.SchedByUserRdoButton_CheckedChanged);
            // 
            // ScheduleByCustRdoButton
            // 
            this.ScheduleByCustRdoButton.AutoSize = true;
            this.ScheduleByCustRdoButton.Location = new System.Drawing.Point(3, 49);
            this.ScheduleByCustRdoButton.Name = "ScheduleByCustRdoButton";
            this.ScheduleByCustRdoButton.Size = new System.Drawing.Size(132, 17);
            this.ScheduleByCustRdoButton.TabIndex = 3;
            this.ScheduleByCustRdoButton.Text = "Schedule By Customer";
            this.ScheduleByCustRdoButton.UseVisualStyleBackColor = true;
            this.ScheduleByCustRdoButton.CheckedChanged += new System.EventHandler(this.ScheduleByCustRdoButton_CheckedChanged);
            // 
            // UserCustComboBox
            // 
            this.UserCustComboBox.FormattingEnabled = true;
            this.UserCustComboBox.Location = new System.Drawing.Point(156, 38);
            this.UserCustComboBox.Name = "UserCustComboBox";
            this.UserCustComboBox.Size = new System.Drawing.Size(121, 21);
            this.UserCustComboBox.Sorted = true;
            this.UserCustComboBox.TabIndex = 4;
            this.UserCustComboBox.Visible = false;
            this.UserCustComboBox.SelectedIndexChanged += new System.EventHandler(this.UserCustComboBox_SelectedIndexChanged);
            // 
            // ApptByMonthPicker
            // 
            this.ApptByMonthPicker.CustomFormat = "MMMM yyyy";
            this.ApptByMonthPicker.Location = new System.Drawing.Point(156, 12);
            this.ApptByMonthPicker.Name = "ApptByMonthPicker";
            this.ApptByMonthPicker.Size = new System.Drawing.Size(200, 20);
            this.ApptByMonthPicker.TabIndex = 5;
            this.ApptByMonthPicker.Visible = false;
            this.ApptByMonthPicker.ValueChanged += new System.EventHandler(this.ApptByMonthPicker_ValueChanged);
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.Location = new System.Drawing.Point(713, 415);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(75, 23);
            this.ReturnBtn.TabIndex = 6;
            this.ReturnBtn.Text = "Return";
            this.ReturnBtn.UseVisualStyleBackColor = true;
            this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ApptsByMonthRdoButton);
            this.panel1.Controls.Add(this.SchedByUserRdoButton);
            this.panel1.Controls.Add(this.ScheduleByCustRdoButton);
            this.panel1.Location = new System.Drawing.Point(7, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 98);
            this.panel1.TabIndex = 7;
            // 
            // ReportsLabel
            // 
            this.ReportsLabel.AutoSize = true;
            this.ReportsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportsLabel.Location = new System.Drawing.Point(664, 9);
            this.ReportsLabel.Name = "ReportsLabel";
            this.ReportsLabel.Size = new System.Drawing.Size(124, 33);
            this.ReportsLabel.TabIndex = 8;
            this.ReportsLabel.Text = "Reports";
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ReportsLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ReturnBtn);
            this.Controls.Add(this.ApptByMonthPicker);
            this.Controls.Add(this.UserCustComboBox);
            this.Controls.Add(this.ReportView);
            this.Name = "ReportsForm";
            this.Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)(this.ReportView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ReportView;
        private System.Windows.Forms.RadioButton ApptsByMonthRdoButton;
        private System.Windows.Forms.RadioButton SchedByUserRdoButton;
        private System.Windows.Forms.RadioButton ScheduleByCustRdoButton;
        private System.Windows.Forms.ComboBox UserCustComboBox;
        private System.Windows.Forms.DateTimePicker ApptByMonthPicker;
        private System.Windows.Forms.Button ReturnBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ReportsLabel;
    }
}