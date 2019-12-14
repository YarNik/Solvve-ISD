using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			double num;
			bool isNum = false;
			double first = 0;
			do
			{
				Console.Write("Enter first number: ");
				string first_str = Console.ReadLine();
				isNum = double.TryParse(first_str, out num);
				if (isNum) { first = double.Parse(first_str); }
			} while (isNum == false);

			isNum = false;
			double second = 0;
			do
			{
				Console.Write("Enter second number: ");
				string second_str = Console.ReadLine();
				isNum = double.TryParse(second_str, out num);
				if (isNum) { second = double.Parse(second_str); }
			} while (isNum == false);
						
			if (first > second) { Console.WriteLine($"{first} is bigger"); }
			else { if (first < second) { Console.WriteLine($"{second} is bigger"); } 
				 else { Console.WriteLine($"{first} is equal to {second}"); }
			} 

			Console.ReadLine();
		}
	}
}
