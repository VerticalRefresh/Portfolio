using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarhamD968PracticalAssessment.Classes
{
    public class Inventory
    {
        public List<Product> Products { get; set; }
        public List<Part> AllParts { get; set; }

        public Inventory()
        {
            Products = new List<Product>();
            AllParts = new List<Part>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public bool RemoveProduct(int id)
        {
            return Products.Remove(LookupProduct(id));
        }

        public Product LookupProduct(int id)
        {
            return Products.Find(product => product.ProductID == id);
        }

        public void UpdateProduct(int id, Product product)
        {
            int index = Products.FindIndex(product => product.ProductID == id);
            Products[index] = product;
        }

        public void AddPart(Part part)
        {
            AllParts.Add(part);
        }
        public bool DeletePart(Part part)
        {
            return AllParts.Remove(part);
        }

        public Part LookupPart(int id)
        {
            return AllParts.Find(part => part.PartID == id);
        }

        public void UpdatePart(int id, Part part)
        {
            int index = AllParts.FindIndex(part => part.PartID == id);
            AllParts[index] = part;
        }
        public int GetPartIndex() //Returns an ID for new products that "fills in" gaps in the product ID list.
        {
            if (AllParts.Count > 0)
            {
                AllParts.Sort((x, y) => x.PartID.CompareTo(y.PartID));
                int i = 0;
                
                foreach (Part item in AllParts)
                {
                    if (item.PartID != i + 1)
                    {
                        return i + 1;
                    }
                    i++;
                }
                
                return i + 1;
            }
            else
            {
                return 1;
            }
        }
        public int GetProductIndex() //Returns an ID for new products that "fills in" gaps in the product ID list.
        {
            if (Products.Count == 0)
            {
                return 1;
            }
            else
            {
                Products.Sort((x, y) => x.ProductID.CompareTo(y.ProductID));
                int i = 0;
                foreach (Product item in Products)
                {
                    if (item.ProductID != i + 1)
                    {
                        return i + 1;
                    }
                    i++;
                }
                return i + 1;
            }
        }
    }
}
