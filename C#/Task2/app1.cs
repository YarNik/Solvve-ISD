using System;

namespace ConsoleApp1
{
    class Addres
    {
        public string Index
        { get; set; }
        public string Country
        { get; set; }
        public string City
        { get; set; }
        public string Street
        { get; set; }
        public string House
        { get; set; }
        public string Apartment
        { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Addres build = new Addres();
            build.Index = "49000";
            build.Country = "Ukraine";
            build.City = "Dnepr";
            build.Street = "Victory street";
            build.House = "12";
            build.Apartment = "123";

            Console.WriteLine($"My adress is {build.Index}, {build.Country}, {build.City}, {build.Street}, #{build.House}, ap.{build.Apartment}");
            Console.Read();

           
        }

   
    }
}
