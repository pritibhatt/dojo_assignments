using System;
using System.Collections.Generic;
namespace wizzardNinjaSamurai
{
    public class Wizzard: Human
    {

        public Wizzard(string person) : base(person)
        {
            health = 50;
            intelligence =25;
        }
        public int Heal()
        {
            health+=10*intelligence;
            return health;
        }
        public int Fireball(Human enemy)
        {
            Random rand = new Random();
            enemy.health-=rand.Next(20,50);
            System.Console.WriteLine($"{name} attacked {enemy.name}. Health for {enemy.name} is now {enemy.health}");
            return enemy.health;
        }
    }
}