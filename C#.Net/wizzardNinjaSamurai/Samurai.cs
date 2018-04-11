using System;
using System.Collections.Generic;

namespace wizzardNinjaSamurai
{
    public class Samurai : Human
    {
        
        public Samurai(string person) : base(person)
        {
            health=200;
        }
        public int death_Blow(Human enemy)
        {
            enemy.health-=50;
            if(enemy.health<50)
            {
                enemy.health=0;
            }
            System.Console.WriteLine($"{name} attacked {enemy.name}. Health for {enemy.name} decreased and is now {enemy.health}");            
            return enemy.health;
        }
        public int meditate()
        {
            health=200;
            System.Console.WriteLine($"Health is now restored for {name} to {health}");            
            return health;
        }
    }
}