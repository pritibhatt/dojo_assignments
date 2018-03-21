using System;

namespace puzzles
{
    class Program
    {
        // public static int[] RandomArray(){
        //     int[] newArray = new int[10];
        //     int min = 0;
        //     int max = 0;
        //     int sum = 0;
        //     Random rand = new Random();
        //     for(int i = 5; i<newArray.Length; i++){
        //       newArray[i]= rand.Next(5,26); 
        //       if(min<newArray[i]){
        //           min=newArray[i];
        //       }               
        //       if(max<newArray[i]){
        //           max = newArray[i];
        //       }
        //       sum+=newArray[i];
        //     }
        //     System.Console.WriteLine(min);
        //     System.Console.WriteLine(max);
        //     System.Console.WriteLine(sum);
        //     return newArray;
            
        // }
        // public static string TossCoin(){
        //     System.Console.WriteLine("tossing a coin!");
        //     int toss = 0;
        //     string headsortails = "";
        //     Random rand = new Random();
        //     toss = rand.Next(1,3);
        //     if(toss == 1){
        //         headsortails = "heads";
        //         System.Console.WriteLine("heads");
        //     }
        //     if(toss==2) {
        //         headsortails = "tails";
        //         System.Console.WriteLine(headsortails);
        //     }
        //     return headsortails;
        // }

        // public static Double TossCoin(int num)
        // {
        //    double result; 
        //     int heads = 0;
        //     int coin;
        //     Random rand = new Random();
        //     for(int i = 1; i < num; i++)
        //     {
        //         coin = rand.Next(1,3);
        //         System.Console.WriteLine(coin);
        //         if(coin == 2)
        //         {
        //             heads++;
        //         }
        //     }
        //     result = (double)heads/(double)num;
        //     System.Console.WriteLine("result is {0}", result);
        //     return result;
        // }
        public static string[] Names(){
            // int countChar = 0;
            string[] newArray = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random rand = new Random();
            for(int i =0; i<newArray.Length; i++){
                // newArray.ToString();
                i = rand.Next(0,newArray.Length);
                if(newArray[i].Length>5){
                    System.Console.WriteLine(newArray[i]);

                }

            }
            
           return newArray;
        }
        static void Main(string[] args)
        {
        //  RandomArray();
        //  TossCoin();  
        //  Names();
            }
        }
    }

