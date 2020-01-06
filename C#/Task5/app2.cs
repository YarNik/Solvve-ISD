using System;

namespace ConsoleApp2
{
    class Program
    {
        struct Train
        {
            public string destination;
            public int trainNumber;
            public string departureTime;  
            public void DisplayInfo()
            {
                Console.WriteLine($"Train number: {trainNumber}, destination: {destination}, departure time: {departureTime}.");
            }
        }
        static void Main(string[] args)
        {            
            Train[] trains = new Train[8];
            // Input data
            for (int i = 0; i < trains.Length; i++)
            {
                Train one = new Train();
                int num;
                bool isNum = false;
                do
                {
                    Console.Write("Enter number of train: ");
                    string input = Console.ReadLine();
                    isNum = int.TryParse(input, out num);
                    if (isNum) { one.trainNumber = int.Parse(input); }
                } while (isNum == false);
                Console.Write("Enter destination: ");
                one.destination = Console.ReadLine();
                Console.Write("Enter departure time: ");
                one.departureTime = Console.ReadLine();
                trains[i] = one;
            }
            // Sorting trains by trainNumber
            Train temp; 
            for (int i = 0; i < trains.Length - 1; i++)
            {
                for (int j = i + 1; j < trains.Length; j++)
                {
                    if (trains[i].trainNumber > trains[j].trainNumber)
                    {
                        temp = trains[i];
                        trains[i] = trains[j];
                        trains[j] = temp;
                    }
                }
            }
            // Input your number of train
            int no;
            int yourTrainNumber = 0;
            bool isNumber = false;
            do
            {
                Console.Write("Enter your number of train: ");
                string input = Console.ReadLine();
                isNumber = int.TryParse(input, out no);
                if (isNumber) { yourTrainNumber = int.Parse(input); }
            } while (isNumber == false);
            // Search your train
            Train found = Array.Find(trains, item => item.trainNumber == yourTrainNumber);
            if (found.trainNumber == yourTrainNumber)
            {
                found.DisplayInfo();
            } else { Console.WriteLine("No such train number!"); }
           
            Console.ReadLine();

        }
    }
}
