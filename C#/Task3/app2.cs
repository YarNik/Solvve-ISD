using System;

namespace ConsoleApp2
{
    class Program
    {
        class ClassRoom 
        {
            Pupil[] pupils;
            public ClassRoom(params Pupil[] pupils) 
            {
                this.pupils = pupils;
            }
            public void ClassRoomShow() 
            {
                for (int i = 0; i < pupils.Length; i++) 
                {
                    pupils[i].Study();
                    pupils[i].Read();
                    pupils[i].Write();
                    pupils[i].Relax();
                }
                Console.ReadLine();
            }
        }

        class Pupil 
        {
            public string Name { get; set; }
            public Pupil(string name) {Name = name; }
            public virtual void Study() { Console.WriteLine($"{Name} stydies."); }
            public virtual void Read() { Console.WriteLine($"{Name} reads."); }
            public virtual void Write() { Console.WriteLine($"{Name} writes."); }
            public virtual void Relax() { Console.WriteLine($"{Name} relaxes."); }
        }

        class ExcelentPupil : Pupil
        {
            public ExcelentPupil(string name) : base(name) {  }
            public override void Study() { Console.WriteLine($"{Name} stydies excelent."); }
            public override void Read() { Console.WriteLine($"{Name} reads excelent."); }           
            public override void Write() { Console.WriteLine($"{Name} writes excelent."); }            
            public override void Relax() { Console.WriteLine($"{Name} relaxes excelent."); }           
        }

        class GoodPupil : Pupil
        {
            public GoodPupil(string name) : base(name) { }
            public override void Study() { Console.WriteLine($"{Name} stydies good."); }
            public override void Read() { Console.WriteLine($"{Name} reads good."); }
            public override void Write() { Console.WriteLine($"{Name} writes good."); }
            public override void Relax() { Console.WriteLine($"{Name} relaxes good."); }
        }

        class BadPupil : Pupil
        {
            public BadPupil(string name) : base(name) { }
            public override void Study() { Console.WriteLine($"{Name} stydies bad."); }
            public override void Read() { Console.WriteLine($"{Name} reads bad."); }
            public override void Write() { Console.WriteLine($"{Name} writes bad."); }
            public override void Relax() { Console.WriteLine($"{Name} relaxes bad."); }
        }
        static void Main(string[] args)
        {
            Pupil semen = new ExcelentPupil("Semen");
            Pupil ivan = new BadPupil("Ivan");
            Pupil elena = new GoodPupil("Elena");
            Pupil vasya = new GoodPupil("Vasiliy");

            ClassRoom class1 = new ClassRoom(semen, ivan, elena, vasya);
            class1.ClassRoomShow();
        }
    }
}
