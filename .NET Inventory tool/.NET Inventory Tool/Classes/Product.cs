using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarhamD968PracticalAssessment.Classes
{
    public class Product
    {
        public int ProductID { get; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public BindingList<Part> AssociatedParts { get; set; }
    

    public Product(int id, string name = "", decimal price = (decimal)0.00, int instock = 0, int min = 0, 
        int max = 0, BindingList<Part> associatedParts = null)
        {
            ProductID = id;
            Name = name;
            Price = price;
            InStock = instock;
            Min = min;
            Max = max;
            AssociatedParts = associatedParts ?? new BindingList<Part>();
        }
        public void AddAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);
        }
        public bool RemoveAssociatedPart(int id)
        {
            return AssociatedParts.Remove(LookupAssociatedPart(id));
        }
        public Part LookupAssociatedPart(int id)
        {
            return AssociatedParts.FirstOrDefault(part => part.PartID == id);
        }
    }
}
