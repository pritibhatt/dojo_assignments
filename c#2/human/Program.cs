using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
           Human john = new Human("John", 10, 10,10,10);
        //    System.Console.WriteLine(john.health);
        //    System.Console.WriteLine(john.dextertiy);
        //    System.Console.WriteLine(john.intelligence);
        //    System.Console.WriteLine(john.strength);
        //    System.Console.WriteLine(john.name);
           Human steve = new Human("Steve");
           john.Attack(steve);
           
        }
    }
}
