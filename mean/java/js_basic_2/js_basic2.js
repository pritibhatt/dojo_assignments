function magic_multiply(x, y){
    // --- your code here ---
    // for(let i = 0; i<x.length; i++)
    // {
        // z = x*y
        // z = x[i]*y
        // x = z
       x = x.repeat(y);
        console.log(x);
        if(x.constructor === Array){
            console.log('Yes x is an array!');
        }else{
            console.log('No x is not an array!');
        }; 
    // }
    return x;
   

}
// test 1
// magic_multiply(5,2)

// test 2
// magic_multiply(0,0)

// test 3
// magic_multiply([1, 2, 3], 2);

// test 4
// magic_multiply(7, "three");

// test 5
magic_multiply("Brendo", 4);
