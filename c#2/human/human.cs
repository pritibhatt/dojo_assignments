namespace human
{
 public class Human
{
    public string name;
    public int strength=3;
    public int intelligence=3;
    public int dextertiy=3;
    public int health=100;
   public int damage;
    public Human (string n)
    {
        name = n;
    }
    public Human(string n, int str, int intell, int dex, int h)
    {
        name = n;
        strength = str;
        intelligence = intell;
        dextertiy= dex;
        health=h;     
    }
    public void Attack(Human enemy)
    {
        if(enemy is Human)
        {
            damage =strength*5;
            enemy.health-=damage;
            System.Console.WriteLine($"{name} attacked {enemy.name}. Health for {enemy.name} is now {enemy.health}");
        }
        else
        {
            System.Console.WriteLine("Cannot attack, not a human");            
        }
        
    }
}   
}
