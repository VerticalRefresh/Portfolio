namespace Barham_WGUD969_Assessment.Windows
{
    partial class CustomerForm
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
            this.PostCodeLabel = new System.Windows.Forms.Label();
            this.CustPostCodeBox = new System.Windows.Forms.TextBox();
            this.Address2Label = new System.Windows.Forms.Label();
            this.CustAddr2Box = new System.Windows.Forms.TextBox();
            this.CustomerFormLabel = new System.Windows.Forms.Label();
            this.ActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.CountryLabel = new System.Windows.Forms.Label();
            this.CityLabel = new System.Windows.Forms.Label();
            this.CustAddressLabel = new System.Windows.Forms.Label();
            this.CustNameLabel = new System.Windows.Forms.Label();
            this.CustIDLabel = new System.Windows.Forms.Label();
            this.CustCountryBox = new System.Windows.Forms.TextBox();
            this.CustCityBox = new System.Windows.Forms.TextBox();
            this.CustAddrBox = new System.Windows.Forms.TextBox();
            this.CustNameBox = new System.Windows.Forms.TextBox();
            this.CustIDBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CustPhoneBox = new System.Windows.Forms.MaskedTextBox();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.CreatedDateBox = new System.Windows.Forms.TextBox();
            this.CreatedByBox = new System.Windows.Forms.TextBox();
            this.CreatedDateLabel = new System.Windows.Forms.Label();
            this.CreatedByLabel = new System.Windows.Forms.Label();
            this.LastModLabel = new System.Windows.Forms.Label();
            this.ModDateBox = new System.Windows.Forms.TextBox();
            this.ModByLabel = new System.Windows.Forms.Label();
            this.ModByBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PostCodeLabel
            // 
            this.PostCodeLabel.AutoSize = true;
            this.PostCodeLabel.Location = new System.Drawing.Point(175, 211);
            this.PostCodeLabel.Name = "PostCodeLabel";
            this.PostCodeLabel.Size = new System.Drawing.Size(64, 13);
            this.PostCodeLabel.TabIndex = 55;
            this.PostCodeLabel.Text = "Postal Code";
            // 
            // CustPostCodeBox
            // 
            this.CustPostCodeBox.Location = new System.Drawing.Point(245, 208);
            this.CustPostCodeBox.Name = "CustPostCodeBox";
            this.CustPostCodeBox.Size = new System.Drawing.Size(124, 20);
            this.CustPostCodeBox.TabIndex = 54;
            this.CustPostCodeBox.TextChanged += new System.EventHandler(this.EditBox_TextChanged);
            // 
            // Address2Label
            // 
            this.Address2Label.AutoSize = true;
            this.Address2Label.Location = new System.Drawing.Point(6, 141);
            this.Address2Label.Name = "Address2Label";
            this.Address2Label.Size = new System.Drawing.Size(54, 13);
            this.Address2Label.TabIndex = 53;
            this.Address2Label.Text = "Address 2";
            // 
            // CustAddr2Box
            // 
            this.CustAddr2Box.Location = new System.Drawing.Point(66, 138);
            this.CustAddr2Box.Name = "CustAddr2Box";
            this.CustAddr2Box.Size = new System.Drawing.Size(303, 20);
            this.CustAddr2Box.TabIndex = 52;
            // 
            // CustomerFormLabel
            // 
            this.CustomerFormLabel.AutoSize = true;
            this.CustomerFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerFormLabel.Location = new System.Drawing.Point(191, 22);
            this.CustomerFormLabel.Name = "CustomerFormLabel";
            this.CustomerFormLabel.Size = new System.Drawing.Size(166, 33);
            this.CustomerFormLabel.TabIndex = 51;
            this.CustomerFormLabel.Text = "Customers";
            // 
            // ActiveCheckBox
            // 
            this.ActiveCheckBox.AutoSize = true;
            this.ActiveCheckBox.Checked = true;
            this.ActiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ActiveCheckBox.Location = new System.Drawing.Point(28, 243);
            this.ActiveCheckBox.Name = "ActiveCheckBox";
            this.ActiveCheckBox.Size = new System.Drawing.Size(56, 17);
            this.ActiveCheckBox.TabIndex = 46;
            this.ActiveCheckBox.Text = "Active";
            this.ActiveCheckBox.UseVisualStyleBackColor = true;
            this.ActiveCheckBox.CheckedChanged += new System.EventHandler(this.ActiveCheckBox_CheckedChanged);
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Location = new System.Drawing.Point(23, 211);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(38, 13);
            this.PhoneLabel.TabIndex = 43;
            this.PhoneLabel.Text = "Phone";
            // 
            // CountryLabel
            // 
            this.CountryLabel.AutoSize = true;
            this.CountryLabel.Location = new System.Drawing.Point(196, 176);
            this.CountryLabel.Name = "CountryLabel";
            this.CountryLabel.Size = new System.Drawing.Size(43, 13);
            this.CountryLabel.TabIndex = 42;
            this.CountryLabel.Text = "Country";
            // 
            // CityLabel
            // 
            this.CityLabel.AutoSize = true;
            this.CityLabel.Location = new System.Drawing.Point(36, 176);
            this.CityLabel.Name = "CityLabel";
            this.CityLabel.Size = new System.Drawing.Size(24, 13);
            this.CityLabel.TabIndex = 41;
            this.CityLabel.Text = "City";
            // 
            // CustAddressLabel
            // 
            this.CustAddressLabel.AutoSize = true;
            this.CustAddressLabel.Location = new System.Drawing.Point(15, 107);
            this.CustAddressLabel.Name = "CustAddressLabel";
            this.CustAddressLabel.Size = new System.Drawing.Size(45, 13);
            this.CustAddressLabel.TabIndex = 40;
            this.CustAddressLabel.Text = "Address";
            // 
            // CustNameLabel
            // 
            this.CustNameLabel.AutoSize = true;
            this.CustNameLabel.Location = new System.Drawing.Point(25, 74);
            this.CustNameLabel.Name = "CustNameLabel";
            this.CustNameLabel.Size = new System.Drawing.Size(35, 13);
            this.CustNameLabel.TabIndex = 39;
            this.CustNameLabel.Text = "Name";
            // 
            // CustIDLabel
            // 
            this.CustIDLabel.AutoSize = true;
            this.CustIDLabel.Location = new System.Drawing.Point(11, 19);
            this.CustIDLabel.Name = "CustIDLabel";
            this.CustIDLabel.Size = new System.Drawing.Size(65, 13);
            this.CustIDLabel.TabIndex = 38;
            this.CustIDLabel.Text = "Customer ID";
            // 
            // CustCountryBox
            // 
            this.CustCountryBox.Location = new System.Drawing.Point(245, 173);
            this.CustCountryBox.Name = "CustCountryBox";
            this.CustCountryBox.Size = new System.Drawing.Size(124, 20);
            this.CustCountryBox.TabIndex = 34;
            this.CustCountryBox.TextChanged += new System.EventHandler(this.EditBox_TextChanged);
            // 
            // CustCityBox
            // 
            this.CustCityBox.Location = new System.Drawing.Point(66, 173);
            this.CustCityBox.Name = "CustCityBox";
            this.CustCityBox.Size = new System.Drawing.Size(124, 20);
            this.CustCityBox.TabIndex = 33;
            this.CustCityBox.TextChanged += new System.EventHandler(this.EditBox_TextChanged);
            // 
            // CustAddrBox
            // 
            this.CustAddrBox.Location = new System.Drawing.Point(66, 104);
            this.CustAddrBox.Name = "CustAddrBox";
            this.CustAddrBox.Size = new System.Drawing.Size(303, 20);
            this.CustAddrBox.TabIndex = 32;
            this.CustAddrBox.TextChanged += new System.EventHandler(this.EditBox_TextChanged);
            // 
            // CustNameBox
            // 
            this.CustNameBox.Location = new System.Drawing.Point(66, 71);
            this.CustNameBox.Name = "CustNameBox";
            this.CustNameBox.Size = new System.Drawing.Size(303, 20);
            this.CustNameBox.TabIndex = 31;
            this.CustNameBox.TextChanged += new System.EventHandler(this.EditBox_TextChanged);
            // 
            // CustIDBox
            // 
            this.CustIDBox.Enabled = false;
            this.CustIDBox.Location = new System.Drawing.Point(13, 35);
            this.CustIDBox.Name = "CustIDBox";
            this.CustIDBox.ReadOnly = true;
            this.CustIDBox.Size = new System.Drawing.Size(100, 20);
            this.CustIDBox.TabIndex = 30;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(339, 419);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 29;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(258, 419);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 28;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CustPhoneBox
            // 
            this.CustPhoneBox.Location = new System.Drawing.Point(67, 208);
            this.CustPhoneBox.Mask = "(000)000-0000";
            this.CustPhoneBox.Name = "CustPhoneBox";
            this.CustPhoneBox.Size = new System.Drawing.Size(100, 20);
            this.CustPhoneBox.TabIndex = 56;
            this.CustPhoneBox.TextChanged += new System.EventHandler(this.EditBox_TextChanged);
            // 
            // WarningLabel
            // 
            this.WarningLabel.AutoSize = true;
            this.WarningLabel.ForeColor = System.Drawing.Color.Red;
            this.WarningLabel.Location = new System.Drawing.Point(119, 381);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(174, 13);
            this.WarningLabel.TabIndex = 57;
            this.WarningLabel.Text = "Please correct the highlighted fields";
            this.WarningLabel.Visible = false;
            // 
            // CreatedDateBox
            // 
            this.CreatedDateBox.Location = new System.Drawing.Point(95, 289);
            this.CreatedDateBox.Name = "CreatedDateBox";
            this.CreatedDateBox.ReadOnly = true;
            this.CreatedDateBox.Size = new System.Drawing.Size(100, 20);
            this.CreatedDateBox.TabIndex = 36;
            // 
            // CreatedByBox
            // 
            this.CreatedByBox.Enabled = false;
            this.CreatedByBox.Location = new System.Drawing.Point(229, 289);
            this.CreatedByBox.Name = "CreatedByBox";
            this.CreatedByBox.ReadOnly = true;
            this.CreatedByBox.Size = new System.Drawing.Size(145, 20);
            this.CreatedByBox.TabIndex = 37;
            // 
            // CreatedDateLabel
            // 
            this.CreatedDateLabel.AutoSize = true;
            this.CreatedDateLabel.Location = new System.Drawing.Point(44, 292);
            this.CreatedDateLabel.Name = "CreatedDateLabel";
            this.CreatedDateLabel.Size = new System.Drawing.Size(47, 13);
            this.CreatedDateLabel.TabIndex = 44;
            this.CreatedDateLabel.Text = "Created:";
            // 
            // CreatedByLabel
            // 
            this.CreatedByLabel.AutoSize = true;
            this.CreatedByLabel.Location = new System.Drawing.Point(201, 292);
            this.CreatedByLabel.Name = "CreatedByLabel";
            this.CreatedByLabel.Size = new System.Drawing.Size(22, 13);
            this.CreatedByLabel.TabIndex = 45;
            this.CreatedByLabel.Text = "By:";
            // 
            // LastModLabel
            // 
            this.LastModLabel.AutoSize = true;
            this.LastModLabel.Location = new System.Drawing.Point(18, 333);
            this.LastModLabel.Name = "LastModLabel";
            this.LastModLabel.Size = new System.Drawing.Size(73, 13);
            this.LastModLabel.TabIndex = 47;
            this.LastModLabel.Text = "Last Modified:";
            // 
            // ModDateBox
            // 
            this.ModDateBox.Enabled = false;
            this.ModDateBox.Location = new System.Drawing.Point(95, 330);
            this.ModDateBox.Name = "ModDateBox";
            this.ModDateBox.ReadOnly = true;
            this.ModDateBox.Size = new System.Drawing.Size(100, 20);
            this.ModDateBox.TabIndex = 48;
            // 
            // ModByLabel
            // 
            this.ModByLabel.AutoSize = true;
            this.ModByLabel.Location = new System.Drawing.Point(201, 333);
            this.ModByLabel.Name = "ModByLabel";
            this.ModByLabel.Size = new System.Drawing.Size(22, 13);
            this.ModByLabel.TabIndex = 49;
            this.ModByLabel.Text = "By:";
            // 
            // ModByBox
            // 
            this.ModByBox.Enabled = false;
            this.ModByBox.Location = new System.Drawing.Point(229, 330);
            this.ModByBox.Name = "ModByBox";
            this.ModByBox.ReadOnly = true;
            this.ModByBox.Size = new System.Drawing.Size(145, 20);
            this.ModByBox.TabIndex = 50;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 459);
            this.Controls.Add(this.WarningLabel);
            this.Controls.Add(this.CustPhoneBox);
            this.Controls.Add(this.PostCodeLabel);
            this.Controls.Add(this.CustPostCodeBox);
            this.Controls.Add(this.Address2Label);
            this.Controls.Add(this.CustAddr2Box);
            this.Controls.Add(this.CustomerFormLabel);
            this.Controls.Add(this.ModByBox);
            this.Controls.Add(this.ModByLabel);
            this.Controls.Add(this.ModDateBox);
            this.Controls.Add(this.LastModLabel);
            this.Controls.Add(this.ActiveCheckBox);
            this.Controls.Add(this.CreatedByLabel);
            this.Controls.Add(this.CreatedDateLabel);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.CountryLabel);
            this.Controls.Add(this.CityLabel);
            this.Controls.Add(this.CustAddressLabel);
            this.Controls.Add(this.CustNameLabel);
            this.Controls.Add(this.CustIDLabel);
            this.Controls.Add(this.CreatedByBox);
            this.Controls.Add(this.CreatedDateBox);
            this.Controls.Add(this.CustCountryBox);
            this.Controls.Add(this.CustCityBox);
            this.Controls.Add(this.CustAddrBox);
            this.Controls.Add(this.CustNameBox);
            this.Controls.Add(this.CustIDBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Name = "CustomerForm";
            this.Text = "Customer Editor";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PostCodeLabel;
        private System.Windows.Forms.TextBox CustPostCodeBox;
        private System.Windows.Forms.Label Address2Label;
        private System.Windows.Forms.TextBox CustAddr2Box;
        private System.Windows.Forms.Label CustomerFormLabel;
        private System.Windows.Forms.CheckBox ActiveCheckBox;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label CountryLabel;
        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.Label CustAddressLabel;
        private System.Windows.Forms.Label CustNameLabel;
        private System.Windows.Forms.Label CustIDLabel;
        private System.Windows.Forms.TextBox CustCountryBox;
        private System.Windows.Forms.TextBox CustCityBox;
        private System.Windows.Forms.TextBox CustAddrBox;
        private System.Windows.Forms.TextBox CustNameBox;
        private System.Windows.Forms.TextBox CustIDBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.MaskedTextBox CustPhoneBox;
        private System.Windows.Forms.Label WarningLabel;
        private System.Windows.Forms.TextBox CreatedDateBox;
        private System.Windows.Forms.TextBox CreatedByBox;
        private System.Windows.Forms.Label CreatedDateLabel;
        private System.Windows.Forms.Label CreatedByLabel;
        private System.Windows.Forms.Label LastModLabel;
        private System.Windows.Forms.TextBox ModDateBox;
        private System.Windows.Forms.Label ModByLabel;
        private System.Windows.Forms.TextBox ModByBox;
    }
}