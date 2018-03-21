// math 1--does not work
// function zero_negativity(arr){
//     var statement = true;
//     for(var i = 0; i < arr.lenth-1; i++){
//         if(arr[i] < 0){           
//             statement = false;
//         }   
//     }
//     console.log(statement);
// }    
// // var arr = [1, 2, -3];
// zero_negativity([1, 2, -3]);
// math 2
// function is_even(num)
//   {
//     if(num%2==0)
//        {
//         console.log("true");
//         return true;
//     }
//     else
//     {
//         console.log("false")
//         return false;
//     }
// }
// is_even(4)

// math 3-does not work
// function how_many_even(arr)""
// {
// let count = 0;
//     for(let i = 0; i<arr.lenth; i++){
//         if(arr[i]%2==0)
//             {
//                 count+=1;
//             }
//     }
//     return count;
// }
// let arr = [1, 2, 4, 5];
// let x = how_many_even(arr);
// console.log(x)

function create_dummy_array(n){
    var new_arr = [];
    for(var i=0; i<n; i++){
        var new_nums = Math.floor(Math.random() * 9); 
        new_arr.push(new_nums);
    }
    console.log(new_arr);
    return new_arr;
}
create_dummy_array(4);

