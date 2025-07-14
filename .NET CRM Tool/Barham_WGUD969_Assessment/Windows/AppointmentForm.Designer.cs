namespace Barham_WGUD969_Assessment.Windows
{
    partial class AppointmentForm
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CustomerNameBox = new System.Windows.Forms.TextBox();
            this.CustomerNameLabel = new System.Windows.Forms.Label();
            this.UrlBox = new System.Windows.Forms.TextBox();
            this.TypeBox = new System.Windows.Forms.TextBox();
            this.ContactBox = new System.Windows.Forms.TextBox();
            this.LocationBox = new System.Windows.Forms.TextBox();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.EndLabel = new System.Windows.Forms.Label();
            this.StartLabel = new System.Windows.Forms.Label();
            this.UrlLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.ContactLabel = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.UserIdLabel = new System.Windows.Forms.Label();
            this.CustIdLabel = new System.Windows.Forms.Label();
            this.AppointmentIdLabel = new System.Windows.Forms.Label();
            this.EndPicker = new System.Windows.Forms.DateTimePicker();
            this.StartPicker = new System.Windows.Forms.DateTimePicker();
            this.CustIdBox = new System.Windows.Forms.TextBox();
            this.ApptIdBox = new System.Windows.Forms.TextBox();
            this.AppointmentFormLabel = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UserNameBox = new System.Windows.Forms.TextBox();
            this.UserIdBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(673, 407);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 57;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(591, 408);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 56;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CustomerNameBox
            // 
            this.CustomerNameBox.Location = new System.Drawing.Point(313, 36);
            this.CustomerNameBox.Name = "CustomerNameBox";
            this.CustomerNameBox.ReadOnly = true;
            this.CustomerNameBox.Size = new System.Drawing.Size(215, 20);
            this.CustomerNameBox.TabIndex = 53;
            // 
            // CustomerNameLabel
            // 
            this.CustomerNameLabel.AutoSize = true;
            this.CustomerNameLabel.Location = new System.Drawing.Point(224, 38);
            this.CustomerNameLabel.Name = "CustomerNameLabel";
            this.CustomerNameLabel.Size = new System.Drawing.Size(82, 13);
            this.CustomerNameLabel.TabIndex = 52;
            this.CustomerNameLabel.Text = "Customer Name";
            // 
            // UrlBox
            // 
            this.UrlBox.Location = new System.Drawing.Point(98, 332);
            this.UrlBox.Name = "UrlBox";
            this.UrlBox.Size = new System.Drawing.Size(208, 20);
            this.UrlBox.TabIndex = 51;
            this.UrlBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // TypeBox
            // 
            this.TypeBox.Location = new System.Drawing.Point(98, 306);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(208, 20);
            this.TypeBox.TabIndex = 50;
            this.TypeBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // ContactBox
            // 
            this.ContactBox.Location = new System.Drawing.Point(98, 280);
            this.ContactBox.Name = "ContactBox";
            this.ContactBox.Size = new System.Drawing.Size(208, 20);
            this.ContactBox.TabIndex = 49;
            this.ContactBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // LocationBox
            // 
            this.LocationBox.Location = new System.Drawing.Point(98, 254);
            this.LocationBox.Name = "LocationBox";
            this.LocationBox.Size = new System.Drawing.Size(208, 20);
            this.LocationBox.TabIndex = 48;
            this.LocationBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(98, 143);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescriptionBox.Size = new System.Drawing.Size(208, 105);
            this.DescriptionBox.TabIndex = 47;
            this.DescriptionBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // TitleBox
            // 
            this.TitleBox.Location = new System.Drawing.Point(98, 89);
            this.TitleBox.Multiline = true;
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TitleBox.Size = new System.Drawing.Size(208, 48);
            this.TitleBox.TabIndex = 46;
            this.TitleBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // EndLabel
            // 
            this.EndLabel.AutoSize = true;
            this.EndLabel.Location = new System.Drawing.Point(559, 124);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(26, 13);
            this.EndLabel.TabIndex = 44;
            this.EndLabel.Text = "End";
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Location = new System.Drawing.Point(556, 88);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(29, 13);
            this.StartLabel.TabIndex = 43;
            this.StartLabel.Text = "Start";
            // 
            // UrlLabel
            // 
            this.UrlLabel.AutoSize = true;
            this.UrlLabel.Location = new System.Drawing.Point(61, 335);
            this.UrlLabel.Name = "UrlLabel";
            this.UrlLabel.Size = new System.Drawing.Size(29, 13);
            this.UrlLabel.TabIndex = 42;
            this.UrlLabel.Text = "URL";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(61, 313);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(31, 13);
            this.TypeLabel.TabIndex = 41;
            this.TypeLabel.Text = "Type";
            // 
            // ContactLabel
            // 
            this.ContactLabel.AutoSize = true;
            this.ContactLabel.Location = new System.Drawing.Point(48, 285);
            this.ContactLabel.Name = "ContactLabel";
            this.ContactLabel.Size = new System.Drawing.Size(44, 13);
            this.ContactLabel.TabIndex = 40;
            this.ContactLabel.Text = "Contact";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(44, 257);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(48, 13);
            this.LocationLabel.TabIndex = 39;
            this.LocationLabel.Text = "Location";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(32, 146);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLabel.TabIndex = 38;
            this.DescriptionLabel.Text = "Description";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(61, 92);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(27, 13);
            this.TitleLabel.TabIndex = 37;
            this.TitleLabel.Text = "Title";
            // 
            // UserIdLabel
            // 
            this.UserIdLabel.AutoSize = true;
            this.UserIdLabel.Location = new System.Drawing.Point(133, 62);
            this.UserIdLabel.Name = "UserIdLabel";
            this.UserIdLabel.Size = new System.Drawing.Size(40, 13);
            this.UserIdLabel.TabIndex = 36;
            this.UserIdLabel.Text = "UserID";
            // 
            // CustIdLabel
            // 
            this.CustIdLabel.AutoSize = true;
            this.CustIdLabel.Location = new System.Drawing.Point(30, 62);
            this.CustIdLabel.Name = "CustIdLabel";
            this.CustIdLabel.Size = new System.Drawing.Size(65, 13);
            this.CustIdLabel.TabIndex = 35;
            this.CustIdLabel.Text = "Customer ID";
            // 
            // AppointmentIdLabel
            // 
            this.AppointmentIdLabel.AutoSize = true;
            this.AppointmentIdLabel.Location = new System.Drawing.Point(10, 36);
            this.AppointmentIdLabel.Name = "AppointmentIdLabel";
            this.AppointmentIdLabel.Size = new System.Drawing.Size(80, 13);
            this.AppointmentIdLabel.TabIndex = 34;
            this.AppointmentIdLabel.Text = "Appointment ID";
            // 
            // EndPicker
            // 
            this.EndPicker.Location = new System.Drawing.Point(591, 118);
            this.EndPicker.Name = "EndPicker";
            this.EndPicker.Size = new System.Drawing.Size(157, 20);
            this.EndPicker.TabIndex = 33;
            this.EndPicker.ValueChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // StartPicker
            // 
            this.StartPicker.Location = new System.Drawing.Point(591, 85);
            this.StartPicker.Name = "StartPicker";
            this.StartPicker.Size = new System.Drawing.Size(157, 20);
            this.StartPicker.TabIndex = 32;
            this.StartPicker.ValueChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // CustIdBox
            // 
            this.CustIdBox.Location = new System.Drawing.Point(98, 59);
            this.CustIdBox.Name = "CustIdBox";
            this.CustIdBox.ReadOnly = true;
            this.CustIdBox.Size = new System.Drawing.Size(29, 20);
            this.CustIdBox.TabIndex = 31;
            // 
            // ApptIdBox
            // 
            this.ApptIdBox.Location = new System.Drawing.Point(98, 33);
            this.ApptIdBox.Name = "ApptIdBox";
            this.ApptIdBox.ReadOnly = true;
            this.ApptIdBox.Size = new System.Drawing.Size(110, 20);
            this.ApptIdBox.TabIndex = 30;
            // 
            // AppointmentFormLabel
            // 
            this.AppointmentFormLabel.AutoSize = true;
            this.AppointmentFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppointmentFormLabel.Location = new System.Drawing.Point(586, 20);
            this.AppointmentFormLabel.Name = "AppointmentFormLabel";
            this.AppointmentFormLabel.Size = new System.Drawing.Size(205, 33);
            this.AppointmentFormLabel.TabIndex = 29;
            this.AppointmentFormLabel.Text = "Appointments";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(377, 235);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(151, 13);
            this.ErrorLabel.TabIndex = 58;
            this.ErrorLabel.Text = "Please fix the highlighted fields";
            this.ErrorLabel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "User";
            // 
            // UserNameBox
            // 
            this.UserNameBox.Location = new System.Drawing.Point(313, 63);
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.ReadOnly = true;
            this.UserNameBox.Size = new System.Drawing.Size(215, 20);
            this.UserNameBox.TabIndex = 55;
            // 
            // UserIdBox
            // 
            this.UserIdBox.Location = new System.Drawing.Point(179, 59);
            this.UserIdBox.Name = "UserIdBox";
            this.UserIdBox.ReadOnly = true;
            this.UserIdBox.Size = new System.Drawing.Size(29, 20);
            this.UserIdBox.TabIndex = 45;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.UserNameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CustomerNameBox);
            this.Controls.Add(this.CustomerNameLabel);
            this.Controls.Add(this.UrlBox);
            this.Controls.Add(this.TypeBox);
            this.Controls.Add(this.ContactBox);
            this.Controls.Add(this.LocationBox);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.UserIdBox);
            this.Controls.Add(this.EndLabel);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.UrlLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.ContactLabel);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.UserIdLabel);
            this.Controls.Add(this.CustIdLabel);
            this.Controls.Add(this.AppointmentIdLabel);
            this.Controls.Add(this.EndPicker);
            this.Controls.Add(this.StartPicker);
            this.Controls.Add(this.CustIdBox);
            this.Controls.Add(this.ApptIdBox);
            this.Controls.Add(this.AppointmentFormLabel);
            this.Name = "AppointmentForm";
            this.Text = "Appointment Editor";
            this.Load += new System.EventHandler(this.AppointmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox CustomerNameBox;
        private System.Windows.Forms.Label CustomerNameLabel;
        private System.Windows.Forms.TextBox UrlBox;
        private System.Windows.Forms.TextBox TypeBox;
        private System.Windows.Forms.TextBox ContactBox;
        private System.Windows.Forms.TextBox LocationBox;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label UrlLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label ContactLabel;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label UserIdLabel;
        private System.Windows.Forms.Label CustIdLabel;
        private System.Windows.Forms.Label AppointmentIdLabel;
        private System.Windows.Forms.DateTimePicker EndPicker;
        private System.Windows.Forms.DateTimePicker StartPicker;
        private System.Windows.Forms.TextBox CustIdBox;
        private System.Windows.Forms.TextBox ApptIdBox;
        private System.Windows.Forms.Label AppointmentFormLabel;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UserNameBox;
        private System.Windows.Forms.TextBox UserIdBox;
    }
}