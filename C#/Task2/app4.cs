using System;

namespace ConsoleApp4
{
    class Program
    {
        class Point 
        {
            int x, y;
            string name;
            public int X 
                { get { return x; }  }
            public int Y
                { get { return y; } }
            public string Name
            { get { return name; } }

            public Point(int x, int y, string name)
            {
                this.x = x;
                this.y = y;
                this.name = name;
            }
        }

        class Figure
        {
            Point a, b, c, d, e;
            public string figName;
            public Figure(Point a, Point b, Point c) 
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            public Figure(Point a, Point b, Point c, Point d)
            {
                this.a = a;
                this.b = b;
                this.c = c;
                this.d = d;
            }
            public Figure(Point a, Point b, Point c, Point d, Point e)
            {
                this.a = a;
                this.b = b;
                this.c = c;
                this.d = d;
                this.e = e;
            }

            double LengthSide(Point A, Point B) 
            {
                return Math.Sqrt(Math.Pow((A.X - B.X), 2) + Math.Pow((A.Y - B.Y), 2));
            }

            public double PerimeterCalculator()
            {
                double result = 0;
                if (d == null & e == null)
                    { result = LengthSide(a, b) + LengthSide(b, c) + LengthSide(c, a);
                    figName = a.Name + b.Name + c.Name;
                    }
                if (e == null & d != null)
                    { result = LengthSide(a, b) + LengthSide(b, c) + LengthSide(c, d) + LengthSide(d, a);
                    figName = a.Name + b.Name + c.Name + d.Name;
                }
                if (e != null & d != null)
                    { result = LengthSide(a, b) + LengthSide(b, c) + LengthSide(c, d) + LengthSide(d, e) + LengthSide(e, a);
                    figName = a.Name + b.Name + c.Name + d.Name + e.Name;
                }
                
                return result;

            }
        }


        static void Main(string[] args)
        {
            Point A = new Point(2, 2, "A");
            Point B = new Point(10, 6, "B");
            Point C = new Point(10, 2, "C");
            Point D = new Point(9, 0, "D");
            Point E = new Point(2, 0, "E");

            Figure abc = new Figure(A, B, C);
            double abcPerimeter = abc.PerimeterCalculator();
            Figure abcd = new Figure(A, B, C, D);
            double abcdPerimeter = abcd.PerimeterCalculator();
            Figure abcde = new Figure(A, B, C, D, E);
            double abcdePerimeter = abcde.PerimeterCalculator();

            Console.WriteLine($"Периметр {abc.figName} составляет {abcPerimeter}");
            Console.WriteLine($"Периметр {abcd.figName} составляет {abcdPerimeter}");
            Console.WriteLine($"Периметр {abcde.figName} составляет {abcdePerimeter}");
            
            Console.Read();

        }
    }
}
