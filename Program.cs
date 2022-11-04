using ObjectOrientedPrograms.Repository;

namespace Object_Oriented_Programs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Object Oriented Program\n");

            InventoryManager inventoryManager = new InventoryManager();
            inventoryManager.CalcInventoryValue();
        }
    }
}