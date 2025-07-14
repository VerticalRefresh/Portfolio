namespace BarhamD968PracticalAssessment
{
    partial class MainPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            PartsRadio = new RadioButton();
            ProductRadio = new RadioButton();
            ExitButton = new Button();
            DisplayView = new DataGridView();
            SearchBox = new TextBox();
            PartsLabel = new Label();
            label1 = new Label();
            DeleteButton = new Button();
            ModifyButton = new Button();
            AddButton = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DisplayView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(PartsRadio);
            panel1.Controls.Add(ProductRadio);
            panel1.Location = new Point(690, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(96, 83);
            panel1.TabIndex = 21;
            // 
            // PartsRadio
            // 
            PartsRadio.AutoSize = true;
            PartsRadio.Checked = true;
            PartsRadio.Location = new Point(16, 16);
            PartsRadio.Name = "PartsRadio";
            PartsRadio.Size = new Size(51, 19);
            PartsRadio.TabIndex = 6;
            PartsRadio.TabStop = true;
            PartsRadio.Text = "Parts";
            PartsRadio.UseVisualStyleBackColor = true;
            PartsRadio.CheckedChanged += PartsRadio_CheckedChanged;
            // 
            // ProductRadio
            // 
            ProductRadio.AutoSize = true;
            ProductRadio.Location = new Point(16, 41);
            ProductRadio.Name = "ProductRadio";
            ProductRadio.Size = new Size(72, 19);
            ProductRadio.TabIndex = 7;
            ProductRadio.Text = "Products";
            ProductRadio.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(694, 402);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(75, 23);
            ExitButton.TabIndex = 20;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // DisplayView
            // 
            DisplayView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DisplayView.Location = new Point(15, 169);
            DisplayView.Name = "DisplayView";
            DisplayView.Size = new Size(771, 186);
            DisplayView.TabIndex = 19;
            DisplayView.SelectionChanged += DisplayView_SelectionChanged;
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(195, 127);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(221, 23);
            SearchBox.TabIndex = 18;
            SearchBox.Text = "Search";
            SearchBox.TextChanged += SearchBox_TextChanged;
            // 
            // PartsLabel
            // 
            PartsLabel.AutoSize = true;
            PartsLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PartsLabel.Location = new Point(15, 122);
            PartsLabel.Name = "PartsLabel";
            PartsLabel.Size = new Size(53, 25);
            PartsLabel.TabIndex = 17;
            PartsLabel.Text = "Parts";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 26);
            label1.Name = "label1";
            label1.Size = new Size(212, 32);
            label1.TabIndex = 16;
            label1.Text = "Inventory Program";
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(448, 379);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 15;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // ModifyButton
            // 
            ModifyButton.Location = new Point(367, 379);
            ModifyButton.Name = "ModifyButton";
            ModifyButton.Size = new Size(75, 23);
            ModifyButton.TabIndex = 14;
            ModifyButton.Text = "Modify";
            ModifyButton.UseVisualStyleBackColor = true;
            ModifyButton.Click += ModifyButton_Click;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(286, 379);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 13;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(ExitButton);
            Controls.Add(DisplayView);
            Controls.Add(SearchBox);
            Controls.Add(PartsLabel);
            Controls.Add(label1);
            Controls.Add(DeleteButton);
            Controls.Add(ModifyButton);
            Controls.Add(AddButton);
            Name = "MainPage";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DisplayView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private RadioButton PartsRadio;
        private RadioButton ProductRadio;
        private Button ExitButton;
        private DataGridView DisplayView;
        private TextBox SearchBox;
        private Label PartsLabel;
        private Label label1;
        private Button DeleteButton;
        private Button ModifyButton;
        private Button AddButton;
    }
}
