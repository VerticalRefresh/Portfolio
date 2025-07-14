namespace BarhamD968PracticalAssessment
{
    partial class PartsForm
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
            SaveButton = new Button();
            CancelButton = new Button();
            PriceBox = new TextBox();
            NameMachineBox = new TextBox();
            InHouseCheck = new CheckBox();
            MaxBox = new TextBox();
            MinBox = new TextBox();
            InventoryBox = new TextBox();
            NameBox = new TextBox();
            PartsLabel = new Label();
            IDBox = new TextBox();
            NameMachineLabel = new Label();
            InHouseLabel = new Label();
            MaxLabel = new Label();
            MinLabel = new Label();
            PriceLabel = new Label();
            InventoryLabel = new Label();
            NameLabel = new Label();
            IDLabel = new Label();
            ErrorLabel = new Label();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(507, 217);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 37;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(588, 217);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 36;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // PriceBox
            // 
            PriceBox.Location = new Point(149, 214);
            PriceBox.Name = "PriceBox";
            PriceBox.Size = new Size(100, 23);
            PriceBox.TabIndex = 35;
            PriceBox.TextChanged += PriceBox_TextChanged;
            // 
            // NameMachineBox
            // 
            NameMachineBox.Location = new Point(424, 97);
            NameMachineBox.Name = "NameMachineBox";
            NameMachineBox.Size = new Size(239, 23);
            NameMachineBox.TabIndex = 34;
            NameMachineBox.TextChanged += NameMachineBox_TextChanged;
            // 
            // InHouseCheck
            // 
            InHouseCheck.AutoSize = true;
            InHouseCheck.Location = new Point(424, 70);
            InHouseCheck.Name = "InHouseCheck";
            InHouseCheck.Size = new Size(15, 14);
            InHouseCheck.TabIndex = 33;
            InHouseCheck.UseVisualStyleBackColor = true;
            InHouseCheck.CheckedChanged += InHouseCheck_CheckedChanged;
            // 
            // MaxBox
            // 
            MaxBox.Location = new Point(149, 185);
            MaxBox.Name = "MaxBox";
            MaxBox.Size = new Size(100, 23);
            MaxBox.TabIndex = 32;
            MaxBox.TextChanged += MaxBox_TextChanged;
            // 
            // MinBox
            // 
            MinBox.Location = new Point(149, 156);
            MinBox.Name = "MinBox";
            MinBox.Size = new Size(100, 23);
            MinBox.TabIndex = 31;
            MinBox.TextChanged += MinBox_TextChanged;
            // 
            // InventoryBox
            // 
            InventoryBox.Location = new Point(149, 127);
            InventoryBox.Name = "InventoryBox";
            InventoryBox.Size = new Size(100, 23);
            InventoryBox.TabIndex = 30;
            InventoryBox.TextChanged += InventoryBox_TextChanged;
            // 
            // NameBox
            // 
            NameBox.Location = new Point(149, 97);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(100, 23);
            NameBox.TabIndex = 29;
            NameBox.TextChanged += NameBox_TextChanged;
            // 
            // PartsLabel
            // 
            PartsLabel.AutoSize = true;
            PartsLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PartsLabel.Location = new Point(12, 9);
            PartsLabel.Name = "PartsLabel";
            PartsLabel.Size = new Size(53, 25);
            PartsLabel.TabIndex = 28;
            PartsLabel.Text = "Parts";
            // 
            // IDBox
            // 
            IDBox.BackColor = SystemColors.ControlDark;
            IDBox.Enabled = false;
            IDBox.Location = new Point(149, 68);
            IDBox.Name = "IDBox";
            IDBox.ReadOnly = true;
            IDBox.Size = new Size(100, 23);
            IDBox.TabIndex = 27;
            // 
            // NameMachineLabel
            // 
            NameMachineLabel.AutoSize = true;
            NameMachineLabel.Location = new Point(324, 100);
            NameMachineLabel.Name = "NameMachineLabel";
            NameMachineLabel.Size = new Size(94, 15);
            NameMachineLabel.TabIndex = 26;
            NameMachineLabel.Text = "Company Name";
            // 
            // InHouseLabel
            // 
            InHouseLabel.AutoSize = true;
            InHouseLabel.Location = new Point(284, 71);
            InHouseLabel.Name = "InHouseLabel";
            InHouseLabel.Size = new Size(134, 15);
            InHouseLabel.TabIndex = 25;
            InHouseLabel.Text = "Manufactured In-House";
            // 
            // MaxLabel
            // 
            MaxLabel.AutoSize = true;
            MaxLabel.Location = new Point(29, 188);
            MaxLabel.Name = "MaxLabel";
            MaxLabel.Size = new Size(114, 15);
            MaxLabel.TabIndex = 24;
            MaxLabel.Text = "Maximum Inventory";
            // 
            // MinLabel
            // 
            MinLabel.AutoSize = true;
            MinLabel.Location = new Point(30, 159);
            MinLabel.Name = "MinLabel";
            MinLabel.Size = new Size(113, 15);
            MinLabel.TabIndex = 23;
            MinLabel.Text = "Minimum Inventory";
            // 
            // PriceLabel
            // 
            PriceLabel.AutoSize = true;
            PriceLabel.Location = new Point(110, 217);
            PriceLabel.Name = "PriceLabel";
            PriceLabel.Size = new Size(33, 15);
            PriceLabel.TabIndex = 22;
            PriceLabel.Text = "Price";
            // 
            // InventoryLabel
            // 
            InventoryLabel.AutoSize = true;
            InventoryLabel.Location = new Point(86, 130);
            InventoryLabel.Name = "InventoryLabel";
            InventoryLabel.Size = new Size(57, 15);
            InventoryLabel.TabIndex = 21;
            InventoryLabel.Text = "Inventory";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(104, 100);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(39, 15);
            NameLabel.TabIndex = 20;
            NameLabel.Text = "Name";
            // 
            // IDLabel
            // 
            IDLabel.AutoSize = true;
            IDLabel.Location = new Point(125, 71);
            IDLabel.Name = "IDLabel";
            IDLabel.Size = new Size(18, 15);
            IDLabel.TabIndex = 19;
            IDLabel.Text = "ID";
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = true;
            ErrorLabel.ForeColor = Color.Red;
            ErrorLabel.Location = new Point(95, 277);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(0, 15);
            ErrorLabel.TabIndex = 38;
            ErrorLabel.Visible = false;
            // 
            // PartsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(727, 334);
            Controls.Add(ErrorLabel);
            Controls.Add(SaveButton);
            Controls.Add(CancelButton);
            Controls.Add(PriceBox);
            Controls.Add(NameMachineBox);
            Controls.Add(InHouseCheck);
            Controls.Add(MaxBox);
            Controls.Add(MinBox);
            Controls.Add(InventoryBox);
            Controls.Add(NameBox);
            Controls.Add(PartsLabel);
            Controls.Add(IDBox);
            Controls.Add(NameMachineLabel);
            Controls.Add(InHouseLabel);
            Controls.Add(MaxLabel);
            Controls.Add(MinLabel);
            Controls.Add(PriceLabel);
            Controls.Add(InventoryLabel);
            Controls.Add(NameLabel);
            Controls.Add(IDLabel);
            Name = "PartsForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveButton;
        private Button CancelButton;
        private TextBox PriceBox;
        private TextBox NameMachineBox;
        private CheckBox InHouseCheck;
        private TextBox MaxBox;
        private TextBox MinBox;
        private TextBox InventoryBox;
        private TextBox NameBox;
        private Label PartsLabel;
        private TextBox IDBox;
        private Label NameMachineLabel;
        private Label InHouseLabel;
        private Label MaxLabel;
        private Label MinLabel;
        private Label PriceLabel;
        private Label InventoryLabel;
        private Label NameLabel;
        private Label IDLabel;
        private Label ErrorLabel;
    }
}