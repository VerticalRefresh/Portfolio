using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarhamD968PracticalAssessment.Classes;

namespace BarhamD968PracticalAssessment
{
    public partial class PartsForm : Form
    {
        private MainPage mainPage;
        private Part internalPart;
        public PartsForm(MainPage mainPage, Part part = null)
        {

            this.mainPage = mainPage;
            if (part == null)
            {
                int newID = mainPage.inventory.GetPartIndex();
                part = new Outsourced(newID);
            }
            internalPart = part;
            InitializeComponent();
            PartsForm_New();
        }


        private void PartsForm_New() //Initialize the form with the part data
        {
            if (internalPart is Inhouse)
            {
                Inhouse inhouse = (Inhouse)internalPart;
                InHouseCheck.Checked = true;
                NameMachineLabel.Text = "Machine ID";
                NameMachineBox.Text = inhouse.MachineID.ToString();
            }
            else
            {
                Outsourced outsourced = (Outsourced)internalPart;
                InHouseCheck.Checked = false;
                NameMachineLabel.Text = "Company Name";
                NameMachineBox.Text = outsourced.CompanyName;
            }
            IDBox.Text = internalPart.PartID.ToString();
            NameBox.Text = internalPart.Name;
            InventoryBox.Text = internalPart.InStock.ToString();
            PriceBox.Text = internalPart.Price.ToString();
            MaxBox.Text = internalPart.Max.ToString();
            MinBox.Text = internalPart.Min.ToString();
            SaveButtonCheck();
        }

        private void InHouseCheck_CheckedChanged(object sender, EventArgs e)  //Swap between in-house and outsourced
        {
            if (InHouseCheck.Checked == false)
            {
                NameMachineLabel.Text = "Company Name";
            }
            else if (InHouseCheck.Checked == true)
            {
                NameMachineLabel.Text = "Machine ID";
            }
            SaveButtonCheck();
        }

        //Cancel button
        private void CancelButton_Click(object sender, EventArgs e)
        {
            mainPage.Show();
            this.Close();
        }

        //Saves part to inventory
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (InHouseCheck.Checked == true)
            {
                internalPart = new Inhouse(int.Parse(IDBox.Text), NameBox.Text, decimal.Parse(PriceBox.Text),
                    int.Parse(InventoryBox.Text), int.Parse(MinBox.Text), int.Parse(MaxBox.Text), int.Parse(NameMachineBox.Text));
            }
            else
            {
                internalPart = new Outsourced(int.Parse(IDBox.Text), NameBox.Text, decimal.Parse(PriceBox.Text),
                    int.Parse(InventoryBox.Text), int.Parse(MinBox.Text), int.Parse(MaxBox.Text), NameMachineBox.Text);
            }

            Part foundPart = mainPage.inventory.LookupPart(int.Parse(IDBox.Text));

            if (foundPart != null)
            {
                mainPage.inventory.UpdatePart(internalPart.PartID, internalPart);
            }
            else
            {
                mainPage.inventory.AddPart(internalPart);
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

        private void NameMachineBox_TextChanged(object sender, EventArgs e)
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
            if (InHouseCheck.Checked)
            {
                if (string.IsNullOrWhiteSpace(NameMachineBox.Text) || !int.TryParse(NameMachineBox.Text, out _))
                {
                    NameMachineBox.BackColor = Color.LightSalmon;
                    ErrorLabel.Text = "Machine ID must be a number";
                    ErrorLabel.Visible = true;
                    isValid = false;
                }
                else
                {
                    NameMachineBox.BackColor = Color.White;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(NameMachineBox.Text))
                {
                    NameMachineBox.BackColor = Color.LightSalmon;
                    ErrorLabel.Text = "Company Name cannot be empty";
                    ErrorLabel.Visible = true;
                    isValid = false;
                }
                else
                {
                    NameMachineBox.BackColor = Color.White;
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
    }
}
