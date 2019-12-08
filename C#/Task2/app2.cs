using System;

namespace ConsoleApp2
{
    class Program
    {

        class Rectangle
        {
            public double side1, side2;
            public Rectangle(double s1, double s2)
            {
                this.side1 = s1;
                this.side2 = s2;
            }
            double AreaCalculator(double side1, double side2)
            {
                return side1 * side2;
            }

            public double Area
            {
                get 
                {
                    return AreaCalculator(side1, side2);
                }
            }

            double PerimeterCalculator(double side1, double side2)
            {
                return (side1 + side2) * 2;
            }

            public double Perimeter
            {
                get
                {
                    return PerimeterCalculator(side1, side2);
                }
            }

        }

        static void Main(string[] args)
        {
            double num;
            double height = 0;
            double width = 0;
            bool isGood;
            do
            {
                Console.Write("Введите высоту прямоугольника: ");
                string input = Console.ReadLine();
                isGood = double.TryParse(input, out num);
                if (isGood)
                {
                    height = double.Parse(input);
                    if (height < 0) isGood = false;
                }
                else { isGood = false; }
            } while (!isGood);

            do
            {
                Console.Write("Введите ширину прямоугольника: ");
                string input = Console.ReadLine();
                isGood = double.TryParse(input, out num);
                if (isGood)
                {
                    width = double.Parse(input);
                    if (width < 0) isGood = false;
                }
                else { isGood = false; }
            } while (!isGood);

            Rectangle rec = new Rectangle(height, width);

            Console.WriteLine($"Площадь этого прямоугольника {rec.Area}, а периметр {rec.Perimeter}.");
            Console.Read();

        }
    }
}
