using Newtonsoft.Json;
using Object;
using ObjectOrientedPrograms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObjectOrientedPrograms.Repository
{
    public class InventoryManager
    {
        public string FilePath = @"D:\BridgeLabzz\Object-Oriented-Programs\JsonFile\InventoryData.jsonInventoryData.json";

        public void CalcInventoryValue()
        {
            var jsonData = File.ReadAllText(FilePath);
            var inventoryData = JsonConvert.DeserializeObject<InventoryModel>(jsonData);

            Console.WriteLine(
               "Rice Name :" + inventoryData.Rice.Name + "\n" +
               "Rice Weight :" + inventoryData.Rice.Weight + "\n" +
               "Rice Price Per Kg :" + inventoryData.Rice.PricePerKG + "\n" +

                "Pulse Name :" + inventoryData.Pulses.Name + "\n" +
                "Pulse Weight :" + inventoryData.Pulses.Weight + "\n" +
                "Pulse Price Per Kg :" + inventoryData.Pulses.PricePerKG + "\n" +

                "Wheat Name :" + inventoryData.Wheats.Name + "\n" +
                "Wheat Weight :" + inventoryData.Wheats.Weight + "\n" +
                "Wheat Price Per Kg :" + inventoryData.Wheats.PricePerKG + "\n" 
                );

            int riceTotalValue = inventoryData.Rice.PricePerKG * inventoryData.Rice.Weight;
            int pulsesTotalValue = inventoryData.Pulses.PricePerKG * inventoryData.Pulses.Weight;
            int wheatsTotalValue = inventoryData.Wheats.PricePerKG * inventoryData.Wheats.Weight;

            Console.WriteLine($"\nRice has a Total Value of Rs. : {riceTotalValue}");
            Console.WriteLine($"Pulses has a Total Value of Rs : {pulsesTotalValue}");
            Console.WriteLine($"Wheats has a Total Value of Rs. ::{wheatsTotalValue}");

            Console.WriteLine("\nInventory" + jsonData);
            Console.ReadLine();
        }
    }
}