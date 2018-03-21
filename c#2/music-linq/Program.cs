using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

             //There is only one artist in this collection from Mount Vernon, what is their name and age?
            var artist1 = Artists.Where(a => a.Hometown == "Mount Vernon").ToList();
            foreach (var art1 in artist1)
            {
                System.Console.WriteLine($"The artist whose hometown is Mount Vernon is: {art1.ArtistName}");
            }
            System.Console.WriteLine("================================================================");
            //Who is the youngest artist in our collection of artists?

            var artist2 = Artists.OrderBy(a => a.Age).ToList();
            System.Console.WriteLine($"The youngest artist is: {artist2[0].ArtistName}");


            //Display all artists with 'William' somewhere in their real name
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine(" all artists with 'William' somewhere in their real name: ");
            System.Console.WriteLine("================================================================");

            var artist3 = Artists.Where(a => a.RealName.Contains("William")).ToList();
            foreach (var myart in artist3)
            {
                System.Console.WriteLine(myart.RealName);
            }
            System.Console.WriteLine("================================================================");

            //Display the 3 oldest artist from Atlanta
            var artist4 = Artists.OrderByDescending(a=>a.Age).Where(a => a.Hometown == "Atlanta").ToList();
                        
            System.Console.WriteLine(" the 3 oldest artist from Atlanta: ");
            System.Console.WriteLine("================================================================");

            for (int i=0; i<3;i++){
                System.Console.WriteLine($"{artist4[i].ArtistName}, age = {artist4[i].Age}");
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            // var group=Groups.ToList();
            var artist=Artists.Where(a=>a.Hometown != "New York").ToList();
            // var restult=artist.Join( group, ,).ToList();
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}
