using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPrograms.Model
{
    public class StockModel
    {
        public List<StockProp> Stocks { get; set; }
    }

    public class StockProp
    {
        public string StockName { get; set; }
        public int NumOfShares { get; set; }
        public int SharePrice { get; set; }
    }
}