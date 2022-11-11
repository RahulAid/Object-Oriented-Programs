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

        string? customerName;
        int totalBalance = 0;
        int currentSharePrice = 0;
        string marketCompanyName = " ";
        bool existingCustomer = false;

        public void CompanyStockAccount() //Company Stock Data
        {
            var companyAccountData = File.ReadAllText(filePath);
            objstockData = JsonConvert.DeserializeObject<StockModel>(companyAccountData);
        }

        public void StockAccount() //Customer Stock Data
        {
            var customerAccountData = File.ReadAllText(FilePath);
            objstockAccounts = JsonConvert.DeserializeObject<List<StockAccount>>(customerAccountData);
        }

        public void BuyShares() // To Buy the stocks
        {
            int valueOfSharesBought = 0;
            Console.Write("\nEnter Customer Name: ");
            customerName = Console.ReadLine();
            Console.Write("\nEnter the Name of Stock you want to Buy from the Company Stock list: ");
            string stockName = Console.ReadLine();
            Console.Write("\nEnter Number of Shares you want to Buy: ");
            int numOfShares = Convert.ToInt32(Console.ReadLine());

            CompanyStockAccount();
            StockAccount();
            foreach (var item in objstockData.Stocks) //Stock Data debited from company account
            {
                if (item.StockName == stockName)
                {
                    foreach (var item2 in objstockAccounts)
                    {
                        if (item2.CustomerInfo.CustomerName == customerName)
                        {
                            if (item.NumOfShares >= numOfShares)
                            {
                                item.NumOfShares -= numOfShares;
                                valueOfSharesBought = numOfShares * item.SharePrice;
                                currentSharePrice = item.SharePrice;
                                marketCompanyName = item.StockName;
                            }
                            else
                            {
                                Console.WriteLine("\nCannot buy anymore Stocks");
                            }
                        }
                    }
                    break;
                }
            }
            saveCompany();

            StockAccount();
            foreach (var item in objstockAccounts) //Stock Data credited to Customer Account
            {
                if (item.CustomerInfo.CustomerName == customerName)
                {
                    existingCustomer = true;
                    if (item.CustomerInfo.CustomerAccountBalance >= valueOfSharesBought)
                    {
                        item.CustomerInfo.CustomerAccountBalance -= valueOfSharesBought;
                        totalBalance = item.CustomerInfo.CustomerAccountBalance;
                        if (stockName == marketCompanyName)
                        {
                            bool flag = false;
                            foreach (ShareDetails item2 in item.ShareDetails)
                            {
                                if (item2.CompanyName == stockName)
                                {
                                    flag = true;
                                    item2.NoOfShares += numOfShares;
                                    break;
                                }
                            }
                            if (flag != true)
                            {
                                item.ShareDetails.Add(new ShareDetails() { CompanyName = stockName, NoOfShares = numOfShares, PricePerShare = currentSharePrice });
                            }
                            Console.WriteLine($"\n{numOfShares} no. of {stockName} shares are bought at a price of {valueOfSharesBought}");
                            Console.WriteLine("\nTransaction Completed");
                        }
                        else
                        {
                            Console.WriteLine($"\n{stockName} Share is not available ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nCannot buy Stocks due to Insufficient Balance");
                    }
                }
            }
            if (!existingCustomer)
            {
                Console.WriteLine($"\n{customerName} is not found");
            }
            saveCustomer();
        }

        public void SellShares() // To Sell The Stocks
        {
            int valueOfSharesSold = 0;
            Console.Write("\nEnter Customer Name: ");
            customerName = Console.ReadLine();
            Console.Write("\nEnter the Name of Stock you want to Sell from the Customer Stock list: ");
            string? stockName = Console.ReadLine();
            Console.Write("\nEnter Number of Shares you want to sell: ");
            int numOfShares = Convert.ToInt32(Console.ReadLine());

            StockAccount();
            foreach (var item in objstockAccounts) //Debiting Stock Data from Customer's Account
            {
                if (item.CustomerInfo.CustomerName == customerName)
                {
                    existingCustomer = true;
                    foreach (ShareDetails item2 in item.ShareDetails)
                    {
                        if (item2.CompanyName == stockName)
                        {
                            if (item2.NoOfShares >= numOfShares)
                            {
                                item2.NoOfShares -= numOfShares;
                                currentSharePrice = item2.PricePerShare;
                                if (item2.NoOfShares == 0)
                                {
                                    item.ShareDetails.Remove(item2);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cannot Alter the Stock Data anymore");
                            }
                            break;
                        }
                    }
                    item.CustomerInfo.CustomerAccountBalance += numOfShares * currentSharePrice;
                    totalBalance = item.CustomerInfo.CustomerAccountBalance;
                    valueOfSharesSold = numOfShares * currentSharePrice;
                    break;
                }
            }
            if (!existingCustomer)
            {
                Console.WriteLine($"\n{customerName} is not found");
            }
            saveCustomer();

            CompanyStockAccount();
            foreach (var item in objstockData.Stocks) // New Stocks credited into Customer's Account
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
            saveCompany();
            Console.WriteLine($"\n{numOfShares} no. of {stockName} shares are sold for a price of {valueOfSharesSold}");
            Console.WriteLine("Transaction Successfully Completed");
        }

        public void saveCompany()
        {
            string stockDebited = JsonConvert.SerializeObject(objstockData);
            File.WriteAllText(filePath, stockDebited);
        }

        public void saveCustomer()
        {
            string newStockAdded = JsonConvert.SerializeObject(objstockAccounts);
            File.WriteAllText(FilePath, newStockAdded);
        }

        public void valueOf() //Calculate the total value of all the stocks combined in Customer's Account
        {
            StockAccount();
            int totalValue = 0;
            Console.Write("\nEnter Customer Name: ");
            string? customerName = Console.ReadLine();

            foreach (var item in objstockAccounts)
            {
                if (item.CustomerInfo.CustomerName == customerName)
                {
                    foreach (var shares in item.ShareDetails)
                    {
                        totalValue += shares.NoOfShares * shares.PricePerShare;
                    }
                }
            }
            Console.WriteLine($"\n{customerName} has a total value of : {totalValue}");
        }

        public void CompanyStockList()
        {
            CompanyStockAccount();
            Console.WriteLine("\nCompany Stock List");

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
            StockAccount();
            Console.WriteLine("\nCustomer Stock List");

            foreach (var data in objstockAccounts)
            {
                Console.WriteLine(
                "\nStock Name  : " + data.CustomerInfo.CustomerName + "\n" +
                "Customer phone no.  : " + data.CustomerInfo.CustomerPhoneNo + "\n" +
                "CustomerEmail  : " + data.CustomerInfo.CustomerEmail + "\n" +
                "CustomerAddress  : " + data.CustomerInfo.CustomerAddress + "\n" +
                "CustomerAddress  : " + data.CustomerInfo.CustomerAddress
                );

                foreach (var shares in data.ShareDetails)
                {
                    Console.WriteLine(
                    "\nStock Name        : " + shares.CompanyName + "\n" +
                    "No Of Shares  : " + shares.NoOfShares + "\n" +
                    "Price Per Share   : " + shares.PricePerShare
                    );
                }
            }
        }
    }
}