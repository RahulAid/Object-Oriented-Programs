using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPrograms.Model
{
    public class InventoryModel
    {
        public CommonProp Rice { get; set; }
        public CommonProp Pulses { get; set; }
        public CommonProp Wheats { get; set; }
    }

    public class CommonProp
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int PricePerKG { get; set; }
    }
}