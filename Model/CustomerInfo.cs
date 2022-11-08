using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPrograms.Model
{
    public class CustomerInfo
    {
        public string CustomerName { get; set; }
        public long CustomerPhoneNo { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public int CustomerAccountBalance { get; set; }
    }

    public class ShareDetails
    {
        public string CompanyName { get; set; }
        public int NoOfShares { get; set; }
        public int PricePerShare { get; set; }
    }

    public class StockAccount
    {
        public CustomerInfo CustomerInfo { get; set; }
        public List<ShareDetails> ShareDetails { get; set; }
    }
}
