using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarhamD968PracticalAssessment.Classes
{
    internal class Inhouse : Part
    {
        public int MachineID { get; set; }
        public Inhouse(int partID, string name = "", decimal price = (decimal)0.00, int instock = 0, int min = 0, int max = 0, int machineID = 0) : base(partID, name, price, instock, min, max)
        {
            MachineID = machineID;
        }
    }
}
