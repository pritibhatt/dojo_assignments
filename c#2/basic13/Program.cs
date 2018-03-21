using System;

namespace basic13
{
    class Program
    {
        //print 1-255
        // public static void Print1255(){
        //     for(int i= 1; i<256; i++){
        //         System.Console.WriteLine(i);
        //     }
        // }
        //print odds 1-255
        // public static void PrintOdds1255(){
        //     for(int i= 1; i<256; i++){
        //         if(i%2==1){
        //             System.Console.WriteLine(i);
        //         }
        //     }
        // }
        //print sums 1-255
        // public static void PrintOdds1255(){
        //     for(int i= 1; i<256; i++){
        //         if(i%2==1){
        //             System.Console.WriteLine(i);
        //         }
        //     }
        // }
        //print sums 1-255
        // public static void PrintSums0255(){
        // int total = 0;
        //     for(int i= 0; i<256; i++){
        //           total += i;             
        //         System.Console.WriteLine("New number: {0} Sum {1}", i, total);
                
        //     }
        // }
        //print array
        // public static void PrintArr(int[] arr){
        //    for(int i= 0; i<arr.Length; i++){           
        //         System.Console.WriteLine(arr[i]); 
        //     }
        // }
        //find max
        // public static void PrintArr(int[] arr){
        // int max = 0;
        //    for(int i= 0; i<arr.Length; i++){ 
        //        if(max<arr[i]){
        //            max = arr[i];
        //        }          
        //     }
        //     System.Console.WriteLine(max); 
            
        // }
        //get average
        // public static void PrintArr(int[] arr){
        // int avg = 0;
        // int total = 0;
        //    for(int i= 0; i<arr.Length; i++){ 
        //        total += arr[i];
        //     }
        //     System.Console.WriteLine(total);
        //     avg = total/arr.Length;
        //     System.Console.WriteLine(avg); 
            
        // }
        // arr odd numbers--ask
        // public static void PrintArr(int[] arr){
        //    for(int i= 0; i<arr.Length; i++){ 
        //        if(arr[i]%2==1){
        //            System.Console.WriteLine(arr[i]);
        //        }
        //     }
        // }
        // // arr greater than y
        // public static void greaterThanY(int[] arr,int y){
        //     int Count = 0;
        //    for(int i= 0; i<arr.Length; i++){ 
        //        if(y<arr[i]){
        //            Count++;
        //        }
        //     }
        //     System.Console.WriteLine(Count);
            
        // }
        //square values
        // public static void squareVals(int[] arr){
        //     for(int i = 0; i<arr.Length; i++){
        //         arr[i]*=arr[i];
        //         System.Console.WriteLine(arr[i]);   
        //     }
        // }

        // //eliminat negatives
        // public static void noNegatives(int[] arr){
        //     for(int i = 0; i<arr.Length; i++){
        //         if(arr[i]<0){
        //             arr[i]=0;      
        //         }
        //     System.Console.WriteLine(arr[i]);
                
        //     }
            
        // }
        // min max avg
        // public static void minMaxAvg(int[] arr){
        // int min = 0;
        // int max = 0;
        // int avg = 0;
        // int sum = 0;
        // for(int i = 0; i<arr.Length; i++){
        //     if(min>arr[i]){
        //         min=arr[i];
        //     }
        //     if(max<arr[i]){
        //         max=arr[i];
        //     }
        //     sum+=arr[i];
        // }
        // System.Console.WriteLine(min);
        // System.Console.WriteLine(max);
        // avg = sum/arr.Length;
        // System.Console.WriteLine(avg);
    // }
        //shift arrays
        // public static void shiftArr(int[] arr){
        //     for(int i = 0; i<arr.Length-1; i++)
        //     {
        //         arr[i] = arr[i+1];
        //     }
        //     arr[arr.Length-1] = 0;
        //     // now iterate through new arr and console log each item;
        //     foreach(int num in arr)
        //     {
        //         System.Console.WriteLine(num);
        //     }   
        // }
        //number to string
        public static void numToString(object[] arr){
            for(int i = 0; i<arr.Length; i++){
                if((int)arr[i]<0){
                    arr[i] = "dojo";
                } 
            System.Console.WriteLine(arr[i]);
                  
            }
            
        }
        static void Main(string[] args)
        {
        //    Print1255();
        // PrintOdds1255(); 
        // PrintSums0255();
        // int[] arr = {1,3,5,7,9,13};
        // PrintArr(arr);
        // int[] arr = {3, -5, -7};
        // PrintArr(arr);
        //  int[] arr = {2, 10, 3};
        // PrintArr(arr);
        //   int[] arr = {1,2,3,4,5,6};
        // PrintArr(arr);
        // int[] arr = {1, 3, 5, 7};
        // int y=3;
        // greaterThanY(arr,y);
        // int[] arr = {1, 5, 10, -2};
        // squareVals(arr);
        // int[] arr = {1, 5, 10, -2};
        // noNegatives(arr);
        // int[] arr = {1, 5, 10, -2};
        // minMaxAvg(arr);
        // int[] arr = {1, 5, 10, 7, -2};
        // shiftArr(arr);
        object[] arr = {-1, -3, 2};
        numToString(arr);

        }
    }
}
