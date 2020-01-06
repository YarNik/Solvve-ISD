using System;

namespace ConsoleApp6
{
    enum Post
    {
        handyman = 50,
        foreman = 45,
        manager = 45,
        engineer = 40
    }    
    class Program
    {
        class Accauntant
        {
            public bool AskForBonus(Post worker, int hours)
            {
                if ((int)worker < hours) { return true; }
                else return false;
            }
        }
        static void Main(string[] args)
        {
            Accauntant accaunt = new Accauntant();            
            bool TomBonus = accaunt.AskForBonus(Post.handyman, 55);            
            bool BorisBonus = accaunt.AskForBonus(Post.manager, 42);
            Console.WriteLine($"Bonus for Tom? {TomBonus}");
            Console.WriteLine($"Bonus for Boris? {BorisBonus}");

            Console.ReadLine();
        }
    }
}
