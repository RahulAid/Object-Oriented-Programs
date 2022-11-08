using Newtonsoft.Json;
using ObjectOrientedPrograms.Model;

namespace ObjectOrientedPrograms.Repository
{
    public class CommercialDataProcessing
    {
        public string FilePath = @"D:\BridgeLabzz\Object-Oriented-Programs\JsonFile\CustomerData.json";
        public static string filePath = @"D:\BridgeLabzz\Object-Oriented-Programs\JsonFile\StockData.json";

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
        
        string? customerName;
        string companyStockName = " ";
        int balanceLeft = 0;
        int currentSharePrice = 0;
        bool existingCustomer = false;

        public void BuyStocks() 
        {
            int boughtShareValue = 0;
            Console.Write("\nEnter Customer Name: ");
            customerName = Console.ReadLine();
            Console.Write("\nEnter the Name of Stock to be Bought: ");
            string? stockName = Console.ReadLine();
            Console.Write("\nEnter Number of Shares to be Bought: ");
            int numOfShares = Convert.ToInt32(Console.ReadLine());

            CompanyStockAccount();
            CustomerStockAccount();

            //Check condition to Buy

            foreach (var item in objstockData.Stocks) 
            {
                if (item.StockName == stockName)
                {
                    Console.WriteLine($"{stockName} Share is available in the Database");
                    foreach (var item2 in objstockAccounts)
                    {
                        if (item2.CustomerInfo.CustomerName == customerName)
                        {
                            Console.WriteLine($"{customerName} is eligible to Buy Stocks");
                            if (item.NumOfShares >= numOfShares)
                            {
                                Console.WriteLine($"{numOfShares} shares can be bought from {stockName}");
                                item.NumOfShares -= numOfShares;
                                boughtShareValue = numOfShares * item.SharePrice;
                                currentSharePrice = item.SharePrice;
                                companyStockName = item.StockName;
                            }
                            else
                            {
                                Console.WriteLine("\nDesired no. Stocks exceeds the Available Limit");
                            }
                        }
                        else if(item2.CustomerInfo.CustomerName != customerName)
                        {
                            Console.WriteLine($"{customerName} is not eligible to Buy Stocks");

                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine($"{stockName} Share is not available in the Database");
                }
            }
            saveCompanyData();

           
            foreach (var item in objstockAccounts) 
            {
                if (item.CustomerInfo.CustomerName == customerName)
                {
                    existingCustomer = true;
                    if (item.CustomerInfo.CustomerAccountBalance >= boughtShareValue)
                    {
                        item.CustomerInfo.CustomerAccountBalance -= boughtShareValue;
                        balanceLeft = item.CustomerInfo.CustomerAccountBalance;
                        if (stockName == companyStockName)
                        {

                            foreach (ShareDetails item2 in item.ShareDetails)
                            {
                                if (item2.CompanyName == stockName)
                                {

                                    item2.NoOfShares += numOfShares;
                                    break;
                                }
                            }

                            Console.WriteLine($"\n{numOfShares} Numbers of {stockName} Shares are Bought");

                        }
                        else
                        {
                            Console.WriteLine("\nShare Details not found");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\n{companyStockName} Shares can not be Bought due to Insufficient Balance");
                    }
                }
            }
            
            saveCustomerData();
        }

        public void SellStocks() 
        {
            int soldShareValue = 0;
            Console.Write("\nEnter Customer Name: ");
            customerName = Console.ReadLine();
            Console.Write("\nEnter the Name of Stock to be Sold: ");
            string? stockName = Console.ReadLine();
            Console.Write("\nEnter Number of Shares to be Sold: ");
            int numOfShares = Convert.ToInt32(Console.ReadLine());

            CompanyStockAccount();
            CustomerStockAccount();

            //Check Condition to Sell

            foreach (var item in objstockAccounts) 
            {
                if (item.CustomerInfo.CustomerName == customerName)
                {
                    Console.WriteLine($"{customerName} is eligible to Sell Stocks");
                    existingCustomer = true;
                    foreach (ShareDetails item2 in item.ShareDetails)
                    {
                        if (item2.CompanyName == stockName)
                        {
                            Console.WriteLine($"{stockName} share is available in the Database");
                            if (item2.NoOfShares >= numOfShares)
                            {
                                item2.NoOfShares -= numOfShares;
                                currentSharePrice = item2.PricePerShare;

                            }
                            else
                            {
                                Console.WriteLine("Stock cannot be Sold");
                            }
                            break;
                        }
                    }
                    item.CustomerInfo.CustomerAccountBalance += numOfShares * currentSharePrice;
                    balanceLeft = item.CustomerInfo.CustomerAccountBalance;
                    soldShareValue = numOfShares * currentSharePrice;
                    break;
                }
                else
                {
                    Console.WriteLine($"{customerName} is not eligible to Sell Stocks");
                }
            }
            

            CompanyStockAccount();
            foreach (var item in objstockData.Stocks) 
            {
                if (item.StockName == stockName)
                {
                    foreach (var item2 in objstockAccounts)
                    {
                        if (item2.CustomerInfo.CustomerName == customerName)
                        {
                            item.NumOfShares += numOfShares;
                            break;
                        }
                    }
                }
            }
            saveCompanyData();
            Console.WriteLine($"\nDesired Shares are Sold");

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

        public void valueOf() 
        {
            CustomerStockAccount();
            int totalValue = 0;
            Console.Write("\nEnter Customer Name: ");
            string? customerName = Console.ReadLine();

            foreach (var item in objstockAccounts)
            {
                if (item.CustomerInfo.CustomerName == customerName)
                {
                    foreach (var data in item.ShareDetails)
                    {
                        totalValue += data.NoOfShares * data.PricePerShare;
                    }
                }
            }
            Console.WriteLine($"\n{customerName} has a Total Value of : {totalValue}");
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
                "Number of infos  : " + data.CustomerInfo.CustomerPhoneNo + "\n" +
                "Price per info   : " + data.CustomerInfo.CustomerEmail + "\n" +
                "Price per info   : " + data.CustomerInfo.CustomerAddress + "\n" +
                "Price per info   : " + data.CustomerInfo.CustomerAccountBalance
                );

                foreach (var shares in data.ShareDetails)
                {
                    Console.WriteLine(
                    "\nStock Name        : " + shares.CompanyName + "\n" +
                    "Number of infos  : " + shares.NoOfShares + "\n" +
                    "Price per info   : " + shares.PricePerShare
                    );
                }
            }
        }
    }
}
