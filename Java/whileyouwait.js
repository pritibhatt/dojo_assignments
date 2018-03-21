var daysuntilMyBirthday = 60;
while(daysuntilMyBirthday>=0){
    daysuntilMyBirthday--;
    if(daysuntilMyBirthday<60 && daysuntilMyBirthday>30){
        console.log("",daysuntilMyBirthday, "days until my birthday." +" "+ "So many days");
    }
    if(daysuntilMyBirthday<31 && daysuntilMyBirthday>=6){
            console.log("",daysuntilMyBirthday, "days until my birthday." +" "+ "Getting closer");
    }    
    if(daysuntilMyBirthday<3 && daysuntilMyBirthday>1){
        console.log("",daysuntilMyBirthday, +" "+ "days until my birthday!!!");
    }   
    if(daysuntilMyBirthday<2 && daysuntilMyBirthday>0){
        console.log("",daysuntilMyBirthday, +" "+ "day until my birthday!!!");
    }
    if(daysuntilMyBirthday===0){
        console.log("Happy Birthday!!!" +" "+ "Lets have a party");
    }
}