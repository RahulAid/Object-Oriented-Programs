using ObjectOrientedPrograms.Repository;

namespace ObjectOrientedPrograms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Object Oriented Program\n");

            StockManager stockManager = new StockManager();
            stockManager.CalcStockValue();
        }
    }
}