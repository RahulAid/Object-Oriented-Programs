using ObjectOrientedPrograms.Repository;

namespace ObjectOrientedPrograms
{
    internal class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("Welcome to Object Oriented Program");
           
                CommercialDataProcessing objDataProcessing = new CommercialDataProcessing();
                Console.WriteLine("\nChoose the operation to be performed on Stocks : \n1.Buy Shares \n2.Sell Shares \n3.Calculate Total Value of Account");
                int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    {
                        objDataProcessing.CompanyStockList();
                        objDataProcessing.BuyShares();
                        break;
                    }
                case 2:
                    {
                        objDataProcessing.CustomerStockList();
                        objDataProcessing.SellShares();
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