using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarhamD968PracticalAssessment.Classes
{
    internal class Outsourced : Part
    {
        public string CompanyName { get; set; }
        public Outsourced(int partID, string name = "", decimal price = (decimal)0.00, 
            int instock = 0, int min = 0, int max = 0, string companyName = "") : base(partID, name, price, instock, min, max)
        {
            CompanyName = companyName;
        }
    }
}
