using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string userInput = Console.ReadLine();
            while(userInput != "End")
            {
                string[] vehicleProperties = userInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Vehicle vehicle = new Vehicle(vehicleProperties[0],
                    vehicleProperties[1], 
                    vehicleProperties[2], 
                    int.Parse(vehicleProperties[3]));
                vehicles.Add(vehicle);
                userInput = Console.ReadLine();
            }
            userInput = Console.ReadLine();
            while(userInput != "Close the Catalogue")
            {
                int index = vehicles.FindIndex(x => x.Model == userInput);
                if(index != -1)
                {
                    Console.WriteLine(vehicles[index].ToString());
                }
                userInput = Console.ReadLine();
            }
            Console.WriteLine($"Cars have average horsepower of: {Vehicle.AverageHorsePower(vehicles, "Car"):f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {Vehicle.AverageHorsePower(vehicles, "Truck"):f2}.");
        }
    }

    
    public class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            if(type == "car")
            {
                this.Type = "Car";
            }
            else if(type == "truck")
            {
                this.Type = "Truck";
            }
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; private set; }
        public string Model { get; private set; }
        public string Color { get; private set; }
        public int HorsePower { get; private set; }

        public override string ToString()
        {
            return $"Type: {this.Type}{Environment.NewLine}Model: {this.Model}{Environment.NewLine}Color: {this.Color}{Environment.NewLine}Horsepower: {this.HorsePower}";
        }
        public static double AverageHorsePower(List<Vehicle> vehicles, string vehicleType)
        {
            //double average = 0.00;
            double sum = 0.00;
            int count = 0;
            foreach(Vehicle vehicle in vehicles.Where(x=> x.Type == vehicleType))
            {
                sum += vehicle.HorsePower;
                count++;
            }
            return (count != 0 ? sum / (double)count :  0);
        }
    }
    
}
