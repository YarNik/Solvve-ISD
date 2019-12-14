using System;

namespace ConsoleApp3
{
    class Program
    {
        class Vehicle 
        {
            int price;
            int speed;
            int productionYear;
            public int Price { get { return price; } }
            public int Speed { get { return speed; } }
            public int ProductionYear { get { return productionYear; } }
            public Vehicle(int price, int speed, int productionYear) 
            {
                this.price = price;
                this.speed = speed;
                this.productionYear = productionYear;
            }
        }

        class Plane : Vehicle
        {
            int altitude;
            int capacity;
            public Plane(int price, int speed, int productionYear, int altitude, int capacity) : base(price, speed, productionYear)
            {
                this.altitude = altitude;
                this.capacity = capacity;
            }
            public void Show() 
            {
                Console.WriteLine($"Plane - price: {Price}, speed: {Speed}, year of production: {ProductionYear}, flight altitude: {altitude}, capacity: {capacity}.");
            }
        }

        class Car : Vehicle
        {            
            public Car(int price, int speed, int productionYear) : base(price, speed, productionYear) { }
            public void Show()
            {
                Console.WriteLine($"Car - price: {Price}, speed: {Speed}, year of production: {ProductionYear}.");
            }
        }

        class Ship : Vehicle
        {            
            int capacity;
            string homePort;
            public Ship(int price, int speed, int productionYear, int capacity, string homePort) : base(price, speed, productionYear)
            {               
                this.capacity = capacity;
                this.homePort = homePort;
            }
            public void Show()
            {
                Console.WriteLine($"Ship - price: {Price}, speed: {Speed}, year of production: {ProductionYear}, capacity: {capacity}, home port: {homePort}.");
            }
        }
        static void Main(string[] args)
        {
            Plane plane = new Plane(1500000, 1200, 2015, 10000, 250);
            Car car = new Car(15000, 220, 2019);
            Ship ship = new Ship(150000, 110, 2015, 15, "Odessa");
            plane.Show();
            car.Show();
            ship.Show();
            Console.ReadLine();
        }
    }
}
