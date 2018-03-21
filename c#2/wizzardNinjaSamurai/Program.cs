using System;

namespace wizzardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizzard dumbledore = new Wizzard("Dumbledore");
            // System.Console.WriteLine(dumbledore.name);
            // System.Console.WriteLine(dumbledore.health);
            // System.Console.WriteLine(dumbledore.intelligence);
            // dumbledore.Heal();
            // System.Console.WriteLine(dumbledore.health);
            Wizzard voldemort = new Wizzard("Voldemort");
            // dumbledore.Fireball(voldemort);
            Ninja guru = new Ninja("Guru");
            // guru.Steal(voldemort);
            // guru.get_Away();
            Samurai george = new Samurai("George");
            System.Console.WriteLine(george.health);
            george.meditate();
        }
    }
}
