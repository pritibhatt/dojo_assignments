using System;

namespace wizzardNinjaSamurai
{
    public class Ninja : Human
    {
        public Ninja(string person) : base(person)
        {
            dexterity=175;
        }
        public int Steal(Human enemy)
        {
            health+=10;
            System.Console.WriteLine($"{name} attacked {enemy.name}. Health increased for {name} is now {health}");            
            return health;
        }
        public int get_Away()
        {
            health-=15;
            System.Console.WriteLine($"{name} health decreased by 15 and new health is now {health}");                        
            return health;
        }
        
    }
}