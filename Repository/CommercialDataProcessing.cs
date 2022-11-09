using Newtonsoft.Json;
using ObjectOrientedPrograms.Model;

namespace ObjectOrientedPrograms.Repository
{
    public class CommercialDataProcessing
    {
        public string FilePath = @"D:\BridgeLabzz\Object-Oriented-Programs\JsonFile\CustomerData.json";
        public static string filePath = @"D:\BridgeLabzz\Object-Oriented-Programs\JsonFile\StockData.json";
        string companyAccountData = File.ReadAllText(filePath);

        List<StockAccount> objstockAccounts = new List<StockAccount>();
        StockModel objstockData = new StockModel();
        public void CompanyStockAccount()
        {
            var companyAccountData = File.ReadAllText(filePath);
            objstockData = JsonConvert.DeserializeObject<StockModel>(companyAccountData);
        }

        public void CustomerStockAccount()
        {
            var customerAccountData = File.ReadAllText(FilePath);
            objstockAccounts = JsonConvert.DeserializeObject<List<StockAccount>>(customerAccountData);
        }

        public void AddShares()
        {

            Console.Write("\nEnter the Name of Stock to be Added: ");
            string? stockName = Console.ReadLine();
            Console.Write("\nEnter Number of Shares to be Added: ");
            int numOfShares = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter Price of Share to be Added: ");
            int currentSharePrice = Convert.ToInt32(Console.ReadLine());


            CompanyStockAccount();

            objstockData.Stocks.Add(new StockProp() { StockName = stockName, NumOfShares = numOfShares, SharePrice = currentSharePrice });
            saveCompanyData();
            CompanyStockList();

        }

        public void RemoveShares()
        {

            Console.Write("\nEnter the Name of Stock to be Removed : ");
            string? stockName = Console.ReadLine();

            CompanyStockAccount();

            //Check Condition to Remove Share

            foreach (var item in objstockData.Stocks)
            {
                if (item.StockName == stockName)
                {


                    objstockData.Stocks.Remove(item);
                    Console.WriteLine($"{stockName} Share has been Removed");
                    break;
                }

            }

            saveCompanyData();
            CompanyStockList();

        }
        public void saveCompanyData()
        {
            string stockDeduction = JsonConvert.SerializeObject(objstockData);
            File.WriteAllText(filePath, stockDeduction);

        }

        public void saveCustomerData()
        {
            string stockAddition = JsonConvert.SerializeObject(objstockAccounts);
            File.WriteAllText(FilePath, stockAddition);
        }

        public void CompanyStockList()
        {
            CompanyStockAccount();
            Console.WriteLine("\nCompany Stock Data");

            foreach (var stocks in objstockData.Stocks)
            {
                Console.WriteLine(
                "\nStock Name        : " + stocks.StockName + "\n" +
                "Number of Shares  : " + stocks.NumOfShares + "\n" +
                "Price per Share   : " + stocks.SharePrice
                );
            }
        }

        public void CustomerStockList()
        {
            CustomerStockAccount();
            Console.WriteLine("\nCustomer Stock Data");

            foreach (var data in objstockAccounts)
            {
                Console.WriteLine(
                "\nStock Name        : " + data.CustomerInfo.CustomerName + "\n" +
                "Customer Phone No  : " + data.CustomerInfo.CustomerPhoneNo + "\n" +
                "Customer Email   : " + data.CustomerInfo.CustomerEmail + "\n" +
                "Customer Address   : " + data.CustomerInfo.CustomerAddress + "\n" +
                "Customer Account Balance   : " + data.CustomerInfo.CustomerAccountBalance
                );

                foreach (var shares in data.ShareDetails)
                {
                    Console.WriteLine(
                    "\nStock Name        : " + shares.CompanyName + "\n" +
                    "Number of Shares  : " + shares.NoOfShares + "\n" +
                    "Price per Share   : " + shares.PricePerShare
                    );
                }
            }
        }
    }
}