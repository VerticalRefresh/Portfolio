namespace BarhamD968PracticalAssessment
{
    partial class ProductsForm
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
            PartsLabel = new Label();
            PartList = new DataGridView();
            PriceBox = new TextBox();
            MaxBox = new TextBox();
            MinBox = new TextBox();
            InventoryBox = new TextBox();
            NameBox = new TextBox();
            ProductLabel = new Label();
            IDBox = new TextBox();
            MaxLabel = new Label();
            MinLabel = new Label();
            PriceLabel = new Label();
            InventoryLabel = new Label();
            NameLabel = new Label();
            IDLabel = new Label();
            AvailableParts = new DataGridView();
            AvailablePartsLabel = new Label();
            AddPartButton = new Button();
            RemovePartButton = new Button();
            SaveButton = new Button();
            Cancel = new Button();
            ErrorLabel = new Label();
            AvailableSearch = new TextBox();
            AssociatedSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)PartList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AvailableParts).BeginInit();
            SuspendLayout();
            // 
            // PartsLabel
            // 
            PartsLabel.AutoSize = true;
            PartsLabel.Location = new Point(320, 178);
            PartsLabel.Name = "PartsLabel";
            PartsLabel.Size = new Size(33, 15);
            PartsLabel.TabIndex = 50;
            PartsLabel.Text = "Parts";
            // 
            // PartList
            // 
            PartList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PartList.Location = new Point(359, 178);
            PartList.MultiSelect = false;
            PartList.Name = "PartList";
            PartList.ReadOnly = true;
            PartList.Size = new Size(273, 124);
            PartList.TabIndex = 49;
            PartList.DataBindingComplete += PartList_DataBindingComplete;
            PartList.SelectionChanged += PartList_SelectionChanged;
            // 
            // PriceBox
            // 
            PriceBox.Location = new Point(155, 228);
            PriceBox.Name = "PriceBox";
            PriceBox.Size = new Size(100, 23);
            PriceBox.TabIndex = 48;
            PriceBox.TextChanged += PriceBox_TextChanged;
            // 
            // MaxBox
            // 
            MaxBox.Location = new Point(155, 199);
            MaxBox.Name = "MaxBox";
            MaxBox.Size = new Size(100, 23);
            MaxBox.TabIndex = 47;
            MaxBox.TextChanged += MaxBox_TextChanged;
            // 
            // MinBox
            // 
            MinBox.Location = new Point(155, 170);
            MinBox.Name = "MinBox";
            MinBox.Size = new Size(100, 23);
            MinBox.TabIndex = 46;
            MinBox.TextChanged += MinBox_TextChanged;
            // 
            // InventoryBox
            // 
            InventoryBox.Location = new Point(155, 141);
            InventoryBox.Name = "InventoryBox";
            InventoryBox.Size = new Size(100, 23);
            InventoryBox.TabIndex = 45;
            InventoryBox.TextChanged += InventoryBox_TextChanged;
            // 
            // NameBox
            // 
            NameBox.Location = new Point(155, 111);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(100, 23);
            NameBox.TabIndex = 44;
            NameBox.TextChanged += NameBox_TextChanged;
            // 
            // ProductLabel
            // 
            ProductLabel.AutoSize = true;
            ProductLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductLabel.Location = new Point(18, 23);
            ProductLabel.Name = "ProductLabel";
            ProductLabel.Size = new Size(78, 25);
            ProductLabel.TabIndex = 43;
            ProductLabel.Text = "Product";
            // 
            // IDBox
            // 
            IDBox.BackColor = SystemColors.ControlDark;
            IDBox.Enabled = false;
            IDBox.Location = new Point(155, 82);
            IDBox.Name = "IDBox";
            IDBox.Size = new Size(100, 23);
            IDBox.TabIndex = 42;
            // 
            // MaxLabel
            // 
            MaxLabel.AutoSize = true;
            MaxLabel.Location = new Point(35, 202);
            MaxLabel.Name = "MaxLabel";
            MaxLabel.Size = new Size(114, 15);
            MaxLabel.TabIndex = 41;
            MaxLabel.Text = "Maximum Inventory";
            // 
            // MinLabel
            // 
            MinLabel.AutoSize = true;
            MinLabel.Location = new Point(36, 173);
            MinLabel.Name = "MinLabel";
            MinLabel.Size = new Size(113, 15);
            MinLabel.TabIndex = 40;
            MinLabel.Text = "Minimum Inventory";
            // 
            // PriceLabel
            // 
            PriceLabel.AutoSize = true;
            PriceLabel.Location = new Point(116, 231);
            PriceLabel.Name = "PriceLabel";
            PriceLabel.Size = new Size(33, 15);
            PriceLabel.TabIndex = 39;
            PriceLabel.Text = "Price";
            // 
            // InventoryLabel
            // 
            InventoryLabel.AutoSize = true;
            InventoryLabel.Location = new Point(92, 144);
            InventoryLabel.Name = "InventoryLabel";
            InventoryLabel.Size = new Size(57, 15);
            InventoryLabel.TabIndex = 38;
            InventoryLabel.Text = "Inventory";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(110, 114);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(39, 15);
            NameLabel.TabIndex = 37;
            NameLabel.Text = "Name";
            // 
            // IDLabel
            // 
            IDLabel.AutoSize = true;
            IDLabel.Location = new Point(131, 85);
            IDLabel.Name = "IDLabel";
            IDLabel.Size = new Size(18, 15);
            IDLabel.TabIndex = 36;
            IDLabel.Text = "ID";
            // 
            // AvailableParts
            // 
            AvailableParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AvailableParts.Location = new Point(359, 23);
            AvailableParts.Name = "AvailableParts";
            AvailableParts.Size = new Size(273, 120);
            AvailableParts.TabIndex = 51;
            AvailableParts.DataBindingComplete += AvailableParts_DataBindingComplete;
            AvailableParts.SelectionChanged += AvailableParts_SelectionChanged;
            // 
            // AvailablePartsLabel
            // 
            AvailablePartsLabel.AutoSize = true;
            AvailablePartsLabel.Location = new Point(269, 23);
            AvailablePartsLabel.Name = "AvailablePartsLabel";
            AvailablePartsLabel.Size = new Size(84, 15);
            AvailablePartsLabel.TabIndex = 52;
            AvailablePartsLabel.Text = "Available Parts";
            // 
            // AddPartButton
            // 
            AddPartButton.Location = new Point(526, 149);
            AddPartButton.Name = "AddPartButton";
            AddPartButton.Size = new Size(106, 23);
            AddPartButton.TabIndex = 53;
            AddPartButton.Text = "Add Part";
            AddPartButton.UseVisualStyleBackColor = true;
            AddPartButton.Click += AddPartButton_Click;
            // 
            // RemovePartButton
            // 
            RemovePartButton.Location = new Point(526, 308);
            RemovePartButton.Name = "RemovePartButton";
            RemovePartButton.Size = new Size(106, 23);
            RemovePartButton.TabIndex = 54;
            RemovePartButton.Text = "Remove Part";
            RemovePartButton.UseVisualStyleBackColor = true;
            RemovePartButton.Click += RemovePartButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(35, 308);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 55;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // Cancel
            // 
            Cancel.Location = new Point(116, 308);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(75, 23);
            Cancel.TabIndex = 56;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = true;
            ErrorLabel.ForeColor = Color.Red;
            ErrorLabel.Location = new Point(116, 339);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(0, 15);
            ErrorLabel.TabIndex = 57;
            ErrorLabel.Visible = false;
            // 
            // AvailableSearch
            // 
            AvailableSearch.Location = new Point(359, 149);
            AvailableSearch.Name = "AvailableSearch";
            AvailableSearch.Size = new Size(150, 23);
            AvailableSearch.TabIndex = 58;
            AvailableSearch.Text = "Search";
            AvailableSearch.TextChanged += AvailableSearch_TextChanged;
            // 
            // AssociatedSearch
            // 
            AssociatedSearch.Location = new Point(359, 308);
            AssociatedSearch.Name = "AssociatedSearch";
            AssociatedSearch.Size = new Size(150, 23);
            AssociatedSearch.TabIndex = 59;
            AssociatedSearch.Text = "Search";
            AssociatedSearch.TextChanged += AssociatedSearch_TextChanged;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(687, 363);
            Controls.Add(AssociatedSearch);
            Controls.Add(AvailableSearch);
            Controls.Add(ErrorLabel);
            Controls.Add(Cancel);
            Controls.Add(SaveButton);
            Controls.Add(RemovePartButton);
            Controls.Add(AddPartButton);
            Controls.Add(AvailablePartsLabel);
            Controls.Add(AvailableParts);
            Controls.Add(PartsLabel);
            Controls.Add(PartList);
            Controls.Add(PriceBox);
            Controls.Add(MaxBox);
            Controls.Add(MinBox);
            Controls.Add(InventoryBox);
            Controls.Add(NameBox);
            Controls.Add(ProductLabel);
            Controls.Add(IDBox);
            Controls.Add(MaxLabel);
            Controls.Add(MinLabel);
            Controls.Add(PriceLabel);
            Controls.Add(InventoryLabel);
            Controls.Add(NameLabel);
            Controls.Add(IDLabel);
            Name = "ProductsForm";
            Text = "Products";
            ((System.ComponentModel.ISupportInitialize)PartList).EndInit();
            ((System.ComponentModel.ISupportInitialize)AvailableParts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PartsLabel;
        private DataGridView PartList;
        private TextBox PriceBox;
        private TextBox MaxBox;
        private TextBox MinBox;
        private TextBox InventoryBox;
        private TextBox NameBox;
        private Label ProductLabel;
        private TextBox IDBox;
        private Label MaxLabel;
        private Label MinLabel;
        private Label PriceLabel;
        private Label InventoryLabel;
        private Label NameLabel;
        private Label IDLabel;
        private DataGridView AvailableParts;
        private Label AvailablePartsLabel;
        private Button AddPartButton;
        private Button RemovePartButton;
        private Button SaveButton;
        private Button Cancel;
        private Label ErrorLabel;
        private TextBox AvailableSearch;
        private TextBox AssociatedSearch;
    }
}