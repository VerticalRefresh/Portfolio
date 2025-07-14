using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarhamD968PracticalAssessment.Classes;

namespace BarhamD968PracticalAssessment
{
    public partial class ProductsForm : Form
    {
        private MainPage mainPage;
        private Product internalProduct;
        private BindingSource partsBinding = new BindingSource();
        private BindingSource associatedPartsBinding = new BindingSource();
        private int partListSelection = -1;
        private int availablePartsSelection = -1;
        public ProductsForm(MainPage mainPage, Product product = null)
        {
            this.mainPage = mainPage;
            if (product == null)
            {
                int newID = mainPage.inventory.GetProductIndex();
                product = new Product(newID);
            }
            internalProduct = product;
            InitializeComponent();
            ProductForm_New();
        }

        private void ProductForm_New() //Set Data Grid View Format and textbox data, populate data grid view
        {
            IDBox.Text = internalProduct.ProductID.ToString();
            NameBox.Text = internalProduct.Name;
            InventoryBox.Text = internalProduct.InStock.ToString();
            PriceBox.Text = internalProduct.Price.ToString();
            MaxBox.Text = internalProduct.Max.ToString();
            MinBox.Text = internalProduct.Min.ToString();
            AvailableParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PartList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AvailableParts.ReadOnly = true;
            PartList.ReadOnly = true;
            AvailableParts.MultiSelect = false;
            PartList.MultiSelect = false;
            AvailableParts.AllowUserToAddRows = false;
            PartList.AllowUserToAddRows = false;
            AvailableParts.DataBindingComplete += AvailableParts_DataBindingComplete;
            PartList.DataBindingComplete += PartList_DataBindingComplete;
            AvailableParts.SelectionChanged += AvailableParts_SelectionChanged;
            PartList.SelectionChanged += PartList_SelectionChanged;
            partsBinding.DataSource = mainPage.inventory.AllParts;
            associatedPartsBinding.DataSource = internalProduct.AssociatedParts;
            AvailableParts.DataSource = partsBinding;
            PartList.DataSource = associatedPartsBinding;
            SaveButtonCheck();
        }

        //Sets columns for available parts and prepares selection for add
        private void AvailableParts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (AvailableParts.Columns.Contains("Min"))
            {
                AvailableParts.Columns["Min"].Visible = false;
            }
            if (AvailableParts.Columns.Contains("Max"))
            {
                AvailableParts.Columns["Max"].Visible = false;
            }
            if (AvailableParts.Columns.Contains("Price"))
            {
                AvailableParts.Columns["Price"].Visible = false;
            }
            if (AvailableParts.Columns.Contains("PartID"))
            {
                AvailableParts.Columns["PartID"].Width = 75;
            }
            if (AvailableParts.Columns.Contains("Name"))
            {
                AvailableParts.Columns["Name"].Width = 75;
            }
            if (AvailableParts.Columns.Contains("InStock"))
            {
                AvailableParts.Columns["InStock"].Width = 75;
            }
            AvailableParts.ClearSelection();
        }

        private void AvailableParts_SelectionChanged(object sender, EventArgs e)
        {
            if (AvailableParts.SelectedRows.Count > 0)
            {
                availablePartsSelection = Convert.ToInt32(AvailableParts.SelectedRows[0].Cells["PartID"].Value);
            }
            else
            {
                availablePartsSelection = -1;
            }
        }

        //Sets columns for associated parts and prepares selection for delete
        private void PartList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (PartList.Columns.Contains("Min"))
            {
                PartList.Columns["Min"].Visible = false;
            }
            if (PartList.Columns.Contains("Max"))
            {
                PartList.Columns["Max"].Visible = false;
            }
            if (PartList.Columns.Contains("Price"))
            {
                PartList.Columns["Price"].Visible = false;
            }
            if (PartList.Columns.Contains("PartID"))
            {
                PartList.Columns["PartID"].Width = 75;
            }
            if (PartList.Columns.Contains("Name"))
            {
                PartList.Columns["Name"].Width = 75;
            }
            if (PartList.Columns.Contains("InStock"))
            {
                PartList.Columns["InStock"].Width = 75;
            }
            PartList.ClearSelection();
        }

        private void PartList_SelectionChanged(object sender, EventArgs e)
        {
            if (PartList.SelectedRows.Count > 0)
            {
                partListSelection = Convert.ToInt32(PartList.SelectedRows[0].Cells["PartID"].Value);
            }
            else
            {
                partListSelection = -1;
            }
        }

        //Cancel Button
        private void Cancel_Click(object sender, EventArgs e)
        {
            mainPage.Show();
            this.Close();
        }

        //Add part
        private void AddPartButton_Click(object sender, EventArgs e)
        {
            internalProduct.AddAssociatedPart(mainPage.inventory.LookupPart(availablePartsSelection));
            partsBinding.ResetBindings(false);
        }

        //Remove associated part
        private void RemovePartButton_Click(object sender, EventArgs e)
        {
            if (internalProduct.RemoveAssociatedPart(partListSelection))
            {
                partsBinding.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Part not found in associated parts list.");
            }

        }

        //Saves to inventory
        private void SaveButton_Click(object sender, EventArgs e)
        {
            internalProduct = new Product(int.Parse(IDBox.Text), NameBox.Text, decimal.Parse(PriceBox.Text),
                int.Parse(InventoryBox.Text), int.Parse(MinBox.Text), int.Parse(MaxBox.Text), internalProduct.AssociatedParts);
            Product foundProduct = mainPage.inventory.LookupProduct(int.Parse(IDBox.Text));
            if (foundProduct != null)
            {
                mainPage.inventory.UpdateProduct(internalProduct.ProductID, internalProduct);
            }
            else
            {
                mainPage.inventory.AddProduct(internalProduct);
            }
            mainPage.Show();
            mainPage.RefreshData();
            this.Close();
        }

        //Data integrity checks

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            SaveButtonCheck();
        }

        private void InventoryBox_TextChanged(object sender, EventArgs e)
        {
            SaveButtonCheck();
        }

        private void MinBox_TextChanged(object sender, EventArgs e)
        {
            SaveButtonCheck();
        }

        private void MaxBox_TextChanged(object sender, EventArgs e)
        {
            SaveButtonCheck();
        }

        private void PriceBox_TextChanged(object sender, EventArgs e)
        {
            SaveButtonCheck();
        }
        private void SaveButtonCheck()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(NameBox.Text))//If Name not null
            {
                NameBox.BackColor = Color.LightSalmon;
                ErrorLabel.Text = "Name cannot be empty";
                ErrorLabel.Visible = true;
                isValid = false;
            }
            else
            {
                NameBox.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(InventoryBox.Text) || !int.TryParse(InventoryBox.Text, out _))//If Inventory has a number
            {
                InventoryBox.BackColor = Color.LightSalmon;
                ErrorLabel.Text = "Inventory must be a number";
                ErrorLabel.Visible = true;
                isValid = false;
            }
            else
            {
                InventoryBox.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(MinBox.Text) || !int.TryParse(MinBox.Text, out _)) //If Min has a number
            {
                MinBox.BackColor = Color.LightSalmon;
                ErrorLabel.Text = "Min must be a number";
                ErrorLabel.Visible = true;
                isValid = false;
            }
            else if (int.Parse(MinBox.Text) < 0)
            {
                MinBox.BackColor = Color.LightSalmon;
                ErrorLabel.Text = "Min cannot be less than 0";
                ErrorLabel.Visible = true;
                isValid = false;
            }
            else
            {
                MinBox.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(MaxBox.Text) || !int.TryParse(MaxBox.Text, out _))//If Max has a number
            {
                MaxBox.BackColor = Color.LightSalmon;
                ErrorLabel.Text = "Max must be a number";
                ErrorLabel.Visible = true;
                isValid = false;
            }
            else
            {
                MaxBox.BackColor = Color.White;
            }
            if (string.IsNullOrWhiteSpace(PriceBox.Text) || !decimal.TryParse(PriceBox.Text, out _))//If Price has a number
            {
                PriceBox.BackColor = Color.LightSalmon;
                ErrorLabel.Text = "Price must be a number";
                ErrorLabel.Visible = true;
                isValid = false;
            }
            else
            {
                PriceBox.BackColor = Color.White;
            }

            if (int.TryParse(InventoryBox.Text, out _) && int.TryParse(MinBox.Text, out _) && int.TryParse(MaxBox.Text, out _))
            {
                if (int.Parse(InventoryBox.Text) < int.Parse(MinBox.Text) || int.Parse(InventoryBox.Text) > int.Parse(MaxBox.Text)
                    || int.Parse(MinBox.Text) > int.Parse(MaxBox.Text))
                {
                    InventoryBox.BackColor = Color.LightSalmon;
                    MinBox.BackColor = Color.LightSalmon;
                    MaxBox.BackColor = Color.LightSalmon;
                    ErrorLabel.Text = "Inventory must be between Min and Max, Min must be less than Max";
                    ErrorLabel.Visible = true;
                    isValid = false;
                }
                else
                {
                    InventoryBox.BackColor = Color.White;
                    if (int.Parse(MinBox.Text) > 0)
                    {
                        MinBox.BackColor = Color.White;
                    }
                    MaxBox.BackColor = Color.White;
                }
            }
            if (isValid)
            {
                ErrorLabel.Visible = false;
                SaveButton.Enabled = true;
            }
            else
            {
                SaveButton.Enabled = false;
            }
        }

        //Search Boxes

        private void AvailablePartsSearch()
        {
            string searchText = AvailableSearch.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                partsBinding.DataSource = mainPage.inventory.AllParts;
            }
            else
            {
                partsBinding.DataSource = mainPage.inventory.AllParts.Where(part => part.Name.ToLower().Contains(searchText)).ToList();
            }
        }

        private void AssociatedPartsSearch()
        {
            string searchText = AssociatedSearch.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                associatedPartsBinding.DataSource = internalProduct.AssociatedParts;
            }
            else
            {
                associatedPartsBinding.DataSource = internalProduct.AssociatedParts.Where(part => part.Name.ToLower().Contains(searchText)).ToList();
            }
        }

        private void AvailableSearch_TextChanged(object sender, EventArgs e)
        {
            AvailablePartsSearch();
        }

        private void AssociatedSearch_TextChanged(object sender, EventArgs e)
        {
            AssociatedPartsSearch();
        }
    }
}
