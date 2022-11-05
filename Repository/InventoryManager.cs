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
    public class InventoryManager
    {
        public string FilePath = @"D:\BridgeLabzz\Object-Oriented-Programs\JsonFile\InventoryData.json";

        public void CalcInventoryValue()
        {
            var jsonData = File.ReadAllText(FilePath);
            var inventoryData = JsonConvert.DeserializeObject<InventoryModel>(jsonData);

            foreach (var Rice in inventoryData.Rice)
            {
                Console.WriteLine(
                   "Rice Name :" + Rice.Name + "\n" +
                    "Rice Weight :" + Rice.Weight + "\n" +
                    "Rice Price Per Kg :" + Rice.PricePerKG 
                    );
                Console.WriteLine($"Total Price of {Rice.Name} is   : Rs. {Rice.PricePerKG * Rice.Weight}\n");
            }
            foreach (var Pulses in inventoryData.Pulses)
            {
                Console.WriteLine(
                 "Pulse Name :" + Pulses.Name + "\n" +
                 "Pulse Weight :" + Pulses.Weight + "\n" +
                 "Pulse Price Per Kg :" + Pulses.PricePerKG
                    );
                Console.WriteLine($"Total Price of {Pulses.Name} is : Rs. {Pulses.PricePerKG * Pulses.Weight}\n");
            }
            foreach (var Wheats in inventoryData.Wheats)
            {
                Console.WriteLine(
                   "Wheat Name :" + Wheats.Name + "\n" +
                   "Wheat Weight :" + Wheats.Weight + "\n" +
                   "Wheat Price Per Kg :" + Wheats.PricePerKG
                    );
                Console.WriteLine($"Total Price of {Wheats.Name} is : Rs. {Wheats.PricePerKG * Wheats.Weight}\n");
            }

            Console.WriteLine("\nInventory Data\n" + jsonData);
            Console.ReadLine();
        }
    }
}