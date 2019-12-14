using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
	class Program
	{
		static void Main(string[] args)
		{
			string animal;
			do
			{
				Console.Write("Введите `мяу` или `гав`: ");
				animal = Console.ReadLine();
				if (animal == "мяу") break;
				if (animal == "гав") break;
			} while (true);

			if (animal == "мяу") { Console.WriteLine("Покорми кота"); }
			if (animal == "гав") { Console.WriteLine("Погуляй с собакой"); }
			
			Console.ReadLine();

		}
	}
}
