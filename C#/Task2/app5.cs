using System;

namespace ConsoleApp5
{
    class Program
    {
        class User 
        {
            public string login, name, lastName;
            public int age;
            public readonly string date;
            public User(string login, string name, string lastName, int age, string date) 
            {
                this.login = login;
                this.name = name;
                this.lastName = lastName;
                this.age = age;
                this.date = date;
            }
            public void Show() 
            {
                Console.WriteLine($"Login: {login}, Name: {name}, Last Name: {lastName}, Age: {age}, Date: {date}");
            }
        }


        static void Main(string[] args)
        {
            User Vasya = new User("Vas", "Vasiliy", "Ivanov", 45, "December 12 2019");
            Vasya.login = "admin";
            Vasya.Show();

            Console.Read();
           
        }
    }
}
