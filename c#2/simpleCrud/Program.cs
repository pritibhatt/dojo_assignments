using System;
using System.Collections.Generic;
using DbConnection;
namespace simpleCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            // System.Console.WriteLine("First Name");
            // string Fn = Console.ReadLine();
            // System.Console.WriteLine("Last Name");
            // string Ln = Console.ReadLine();
            // System.Console.WriteLine("Favorite Number");
            // string FavN = Console.ReadLine();
            
            // // MySQL query to INSERT data into my Users table
            // string insertToDB =  $"INSERT INTO Users (FirstName, LastName,  FavoriteNumber) VALUES ('{Fn}', '{Ln}', '{FavN}' )";
            // DbConnector.Execute(insertToDB);
            //to read from MySQL db
            string query = $"SELECT * FROM Users";
            List<Dictionary<string, object>> users = DbConnector.Query(query);
            // var users = DbConnector.Query(query);
            
            foreach(var user in users)
            {
                System.Console.WriteLine(user["FirstName"]);
                System.Console.WriteLine(user["LastName"]);  
                System.Console.WriteLine(user["FavoriteNumber"]);
                
            }
            // System.Console.WriteLine(users);
        }
    }
}
