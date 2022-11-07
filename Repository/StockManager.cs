using Newtonsoft.Json;
using ObjectOrientedPrograms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObjectOrientedPrograms.Repository
{
    public class StockManager
    {
        public string FilePath = @"D:\BridgeLabzz\Object-Oriented-Programs\JsonFile\StockData.json";
        public void CalcStockValue()
        {
            var jsonData = File.ReadAllText(FilePath);
            var inventoryData = JsonConvert.DeserializeObject<StockModel>(jsonData);
            int valueOfEachStock = 0;
            long combinedValueOfStocks = 0;

            foreach (var stock in StockData.Stocks)
            {
                Console.WriteLine(
                   "Stock Name :" + stock.StockName + "\n" +
                    "Number of Shares Available :" + stock.NumOfShares + "\n" +
                    "Stock Price Per Share :" + stock.SharePrice 
                    );

                valueOfEachStock = stock.NumOfShares * stock.SharePrice;
                Console.WriteLine($"Total Price of {stock.StockName} in $s is : {valueOfEachStock}\n");

                combinedValueOfStocks += valueOfEachStock ;

               
            }

            Console.WriteLine($"The value of All the Stocks Combined is {combinedValueOfStocks} $");
                        
            Console.ReadLine();
        }
    }
}
