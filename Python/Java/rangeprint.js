function printRange(rangestart, rangestop, skipamount){
    
    for(var i = rangestart; i<rangestop; i += skipamount){
        console.log(i);
        rangestart=i;
    }
    
  
}
printRange(2, 10, 2);