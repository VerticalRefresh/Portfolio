//V0.2 01/13/24 Begin code refactor from BarhamFinalProjectD968 in order to implement UML classes accurately
//Copied in forms and initiated events for exit/cancel buttons, add button, and implemented indexing for parts
//Copied data binding parameters for data grid view and established test data
//Add function implemented for parts using ID indexing, radio buttons function to change view from parts to products
//Next step is to implement delete function for parts
//V0.3 01/14/24 Implemented delete and modify function for parts.  Began Implementation of product methods
//Methods implemented in Inventory class for product lookup, add, remove, and update.  Next step is to implement product form
//V0.6 Skipped a few there.  Product form functioning with parts list and available parts list.
//All save, modify and delete functions work properly. Data integrity checks for parts form functional
//Next step is data integrity for product form



using System.Diagnostics;
using System.Security.AccessControl;
using BarhamD968PracticalAssessment.Classes;

namespace BarhamD968PracticalAssessment
{
    public partial class MainPage : Form
    {
        private BindingSource displayViewSource;
        public Inventory inventory;
        private int selectedID = -1;

        public MainPage()
        {
            inventory = new Inventory();
            LoadData();
            InitializeComponent();

            InitializeDataGridView();
            AddPartColumns();

            DisplayView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DisplayView.ReadOnly = true;
            DisplayView.MultiSelect = false;
            DisplayView.AllowUserToAddRows = false;
            DisplayView.DataBindingComplete += DisplayView_DataBindingComplete;
            DisplayView.SelectionChanged += DisplayView_SelectionChanged;



            displayViewSource = new BindingSource { DataSource = inventory.AllParts };
            DisplayView.DataSource = displayViewSource;
        }
        private void LoadData()  //Loading test data
        {
            Outsourced part1 = new Outsourced(inventory.GetPartIndex(), "Part 1", (decimal)5.25, 5, 4, 10, "Company 1");
            inventory.AddPart(part1);
            Inhouse part2 = new Inhouse(inventory.GetPartIndex(), "Part 2", (decimal)6.55, 7, 2, 10, 1);
            inventory.AddPart(part2);
            Product product1 = new Product(1, "Product 1", 10, 10, 1, 100);
            inventory.AddProduct(product1);
            product1.AssociatedParts.Add(part1);
        }

        private void DisplayView_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)  //Sets the display index for columns
        {
            Debug.WriteLine("DataBindingComplete");
            if (DisplayView.Columns != null)
            {
                if (DisplayView.Columns.Contains("PartID"))
                {
                    DisplayView.Columns["PartID"].DisplayIndex = 0;
                }
                if (DisplayView.Columns.Contains("ProductID"))
                {
                    DisplayView.Columns["ProductID"].DisplayIndex = 0;
                }
                if (DisplayView.Columns.Contains("Name"))
                {
                    DisplayView.Columns["Name"].DisplayIndex = 1;
                }
                if (DisplayView.Columns.Contains("Inventory"))
                {
                    DisplayView.Columns["Inventory"].DisplayIndex = 2;
                }
                if (DisplayView.Columns.Contains("Price"))
                {
                    DisplayView.Columns["Price"].DisplayIndex = 3;
                }
                if (DisplayView.Columns.Contains("Minimum"))
                {
                    DisplayView.Columns["Minimum"].DisplayIndex = 4;
                }
                if (DisplayView.Columns.Contains("Maximum"))
                {
                    DisplayView.Columns["Maximum"].DisplayIndex = 5;
                }
                DisplayView.ClearSelection();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e) //Exits program
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e) //Opens blank Part or Product with new ID form
        {

            if (PartsRadio.Checked)
            {
                PartsForm partsForm = new PartsForm(this);
                partsForm.Show();
                this.Hide();
            }
            else if (ProductRadio.Checked)
            {
                ProductsForm productsForm = new ProductsForm(this);
                productsForm.Show();
                this.Hide();
            }
        }
        public void RefreshData() //Refreshes data grid
        {
            displayViewSource.ResetBindings(false);
        }

        private void ModifyButton_Click(object sender, EventArgs e) //Opens ModifyPart form
        {
            if (DisplayView.SelectedRows.Count > 0)
            {
                if (selectedID > 0)
                {
                    if (PartsRadio.Checked)
                    {
                        Part part = inventory.LookupPart(selectedID);
                        if (part != null)
                        {
                            PartsForm partsForm = new PartsForm(this, part);
                            partsForm.Show();
                            this.Hide();
                        }
                    }
                    else if (ProductRadio.Checked)
                    {
                        Product product = inventory.LookupProduct(selectedID);
                        if (product != null)
                        {
                            ProductsForm productsForm = new ProductsForm(this, product);
                            productsForm.Show();
                            this.Hide();
                        }
                    }

                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e) //Deletes selected part/product
        {
            if (PartsRadio.Checked)
            {
                bool partFound = false;
                foreach (Product product in inventory.Products)
                {
                    foreach (Part part in product.AssociatedParts)
                    {
                        if (part.PartID == selectedID)
                        {
                            partFound = true;
                            break;
                        }
                    }
                }
                if (partFound)
                {
                    MessageBox.Show("Part is associated with a product and cannot be deleted.");
                }
                else
                {
                    if (selectedID > 0)
                    {
                        var confirmDelete = MessageBox.Show($"Delete part {selectedID}?", "Confirm Delete:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (confirmDelete == DialogResult.Yes)
                        {
                            Part part = inventory.LookupPart(selectedID);
                            if (part != null)
                            {
                                bool success = inventory.DeletePart(part);
                                if (success)
                                {
                                    MessageBox.Show("Part deleted successfully.");
                                    RefreshData();
                                }
                                else
                                {
                                    MessageBox.Show("Part could not be deleted.");
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No part selected.");
                    }
                }
            }
            else if (ProductRadio.Checked)
            {
                var confirmDelete = MessageBox.Show($"Delete product {selectedID}?", "Confirm Delete:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmDelete == DialogResult.Yes)
                {
                    if (selectedID > 0)
                    {
                        bool success = inventory.RemoveProduct(selectedID);
                        if (success)
                        {
                            MessageBox.Show("Product deleted successfully.");
                            RefreshData();
                        }
                        else
                        {
                            MessageBox.Show("Product could not be deleted.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No product selected.");
                    }
                }

            }
        }

        



        //Data Grid View Manipulation for Parts/Products Switching

        private void InitializeDataGridView() // Common Columns for Parts and Products
        {
            DisplayView.AutoGenerateColumns = false;

            DisplayView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Name",
                Name = "Name"
            });
            DisplayView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "InStock",
                HeaderText = "Inventory",
                Name = "Inventory"
            });
            DisplayView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Price",
                Name = "Price"
            });
            DisplayView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Min",
                HeaderText = "Minimum",
                Name = "Minimum"
            });
            DisplayView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Max",
                HeaderText = "Maximum",
                Name = "Maximum"
            });
        }

        //Add/Remove Unique Columns for Parts/Products
        private void AddPartColumns()
        {
            DisplayView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PartID",
                HeaderText = "PartID",
                Name = "PartID"
            });
        }

        private void RemovePartColumns()
        {

            if (DisplayView.Columns.Contains("PartID"))
            {
                DisplayView.Columns.Remove("PartID");
            }
        }
        private void AddProductColumns()
        {
            DisplayView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductID",
                HeaderText = "ProductID",
                Name = "ProductID"
            });
        }
        private void RemoveProductColumns()
        {
            if (DisplayView.Columns.Contains("ProductID"))
            {
                DisplayView.Columns.Remove("ProductID");
            }
        }
        private void PartsRadio_CheckedChanged(object sender, EventArgs e) //Swap data grid for parts/products
        {
            DisplayView.SelectionChanged -= DisplayView_SelectionChanged;
            DisplayView.ClearSelection();
            Debug.WriteLine("Parts Radio CheckChanged");
            if (PartsRadio.Checked)
            {
                RemoveProductColumns();
                AddPartColumns();
                displayViewSource.DataSource = inventory.AllParts;
            }
            else if (ProductRadio.Checked)
            {
                RemovePartColumns();
                AddProductColumns();
                displayViewSource.DataSource = inventory.Products;
            }
            RefreshData();
            DisplayView.SelectionChanged += DisplayView_SelectionChanged;
        }
        private void DisplayView_SelectionChanged(object sender, EventArgs e) //Store the value from the ID column for the selected row
        {
            {
                Debug.WriteLine("DisplayView Selection Changed");
                if (PartsRadio.Checked)
                {
                    if (DisplayView.Columns.Contains("PartID"))
                    {
                        if (DisplayView.SelectedRows.Count > 0)
                        {
                            selectedID = Convert.ToInt32(DisplayView.SelectedRows[0].Cells["PartID"].Value);
                            Debug.WriteLine($"Selected ID: {selectedID}");
                        }
                        else
                        {
                            selectedID = -1;
                            Debug.WriteLine($"Selected ID: {selectedID}");
                        }
                    }
                }
                else if (ProductRadio.Checked)
                {
                    if (DisplayView.Columns.Contains("ProductID"))
                    {
                        if (DisplayView.SelectedRows.Count > 0)
                        {
                            selectedID = Convert.ToInt32(DisplayView.SelectedRows[0].Cells["ProductID"].Value);
                            Debug.WriteLine($"Selected ID: {selectedID}");
                        }
                        else
                        {
                            selectedID = -1;
                            Debug.WriteLine($"Selected ID: {selectedID}");
                        }
                    }
                }
            }
        }

        //Search Function
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            FilterDataGridView();
        }

        private void FilterDataGridView()
        {
            string searchText = SearchBox.Text.ToLower();
            if (PartsRadio.Checked)
            {
                var filteredParts = inventory.AllParts.Where(part => part.Name.ToLower().Contains(searchText)).ToList();
                displayViewSource.DataSource = filteredParts;
                RefreshData();
            }
            else if (ProductRadio.Checked)
            {
                var filteredProducts = inventory.Products.Where(product => product.Name.ToLower().Contains(searchText)).ToList();
                displayViewSource.DataSource = filteredProducts;
                RefreshData();
            }
        }
    }
}
