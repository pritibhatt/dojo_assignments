using System;
using System.Collections.Generic;
namespace collectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
        //     int [] newArr = new int[] {0,1,2,3,4,5,6,7,8,9};
        //    for(int i=0; i<newArr.Length; i++){
        //        System.Console.WriteLine(newArr[i]);
        //    }
           string[] stringArr = new string[] {"Tim", "Martin", "Nikki", "Sara"};
        //    for(int i=0; i<stringArr.Length; i++){
        //        System.Console.WriteLine(stringArr[i]);
        //     }
            
            //  bool[] boolArray = new bool[10];
            //     for(int i = 0; i < 10; i ++){
            //         if(i % 2 == 0){
                    
            //             boolArray[i] = true;
            //             System.Console.WriteLine(boolArray[i]);
            //         }
            //         else{
            //             boolArray[i] = false;
            //             System.Console.WriteLine(boolArray[i]);
            //         }
            // }

            //multiplication
            // int[,] multiArr = new int[10,10] ;
            // for(int i=1; i<11; i++){
            //     for(int j = 1; j<11; j++ ){
            //         // multiArr[i-1,j-1] = i*j;
            //         // System.Console.WriteLine(multiArr[i-1,j-1]);
            //             Console.Write(i * j + "\t");
            //     }
            //     Console.Write("\n");
            // }
               
             //flavors
            List<string> flavors = new List<string>();
            flavors.Add("chocalate");
            flavors.Add("strawberry");
            flavors.Add("vanilla");
            flavors.Add("cookies and cream");
            flavors.Add("mint and chip");
            // // for(int i=0; i<flavors.Count; i++){
            // //     System.Console.WriteLine(flavors[i]);
            // // }
            //     // System.Console.WriteLine(flavors[2]);
            //     flavors.RemoveAt(2);
            // for(int i=0; i<flavors.Count; i++){
            //     System.Console.WriteLine(flavors[i]);
            // }
           

            Dictionary<string,string> profile = new Dictionary<string,string>();
                    
            Random rand = new Random();
            foreach(string name in stringArr)
            {
                profile.Add(name,null);
            }
            foreach(var name in profile)
            {
                System.Console.WriteLine(name.Key +"-"+ flavors[rand.Next(flavors.Count)]);
            }
        }
    }
                   
}
            
        


