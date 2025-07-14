using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarhamD968PracticalAssessment.Classes
{
    public abstract class Part
    {
        public int PartID { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }


        public Part(int partID, string name = "", decimal price = (decimal)0.00, int instock = 0, int min = 0,
            int max = 0)
        {
            PartID = partID;
            Name = name;
            Price = price;
            InStock = instock;
            Min = min;
            Max = max;
        }
    }
}
