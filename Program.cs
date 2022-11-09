using ObjectOrientedPrograms.Repository;

namespace ObjectOrientedPrograms
{
    internal class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("Welcome to Object Oriented Program");
           
                CommercialDataProcessing objDataProcessing = new CommercialDataProcessing();
                Console.WriteLine("\nChoose the operation to be performed on Stocks : \n1.Add Shares \n2.Remove Shares ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            objDataProcessing.CompanyStockList();
                            objDataProcessing.AddShares();
                            break;
                        }
                    case 2:
                        {
                            objDataProcessing.CompanyStockList();
                            objDataProcessing.RemoveShares();
                            break;
                        }
                    
                }
                Console.ReadLine();
                
        }
    }
}