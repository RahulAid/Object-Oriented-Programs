using ObjectOrientedPrograms.Repository;

namespace ObjectOrientedPrograms
{
    internal class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("Welcome to Object Oriented Program");
           
                CommercialDataProcessing objDataProcessing = new CommercialDataProcessing();
                Console.WriteLine("\nChoose the operation to be performed on Stocks : \n1.Buy Stocks \n2.Sell Stocks \n3 Calculate Total Value of Account");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            objDataProcessing.CompanyStockList();
                            objDataProcessing.BuyStocks();
                            break;
                        }
                    case 2:
                        {
                            objDataProcessing.CustomerStockList();
                            objDataProcessing.SellStocks();
                            break;
                        }
                    case 3:
                        {
                            objDataProcessing.valueOf();
                            break;
                        }
                }
                Console.ReadLine();
                
        }
    }
}