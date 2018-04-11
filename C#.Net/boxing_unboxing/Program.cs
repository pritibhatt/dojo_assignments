using System;
using System.Collections.Generic;
namespace boxing_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> boxedList = new List<object>();
            boxedList.Add(7);
            boxedList.Add(28);
            boxedList.Add(-1);
            boxedList.Add(true);
            boxedList.Add("chair");    
            int total = 0;       
            for(var i = 0; i<boxedList.Count; i++){
                // System.Console.WriteLine(boxedList[i]);
                if(boxedList[i] is int){
                    total+= (int)boxedList[i]  ;
                }                
            }
                System.Console.WriteLine(total);
            
        }
    }
}
