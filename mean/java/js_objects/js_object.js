// challenge 1
// let students = [
//     {name: 'Remy', cohort: 'Jan'},
//     {name: 'Genevieve', cohort: 'March'},
//     {name: 'Chuck', cohort: 'Jan'},
//     {name: 'Osmund', cohort: 'June'},
//     {name: 'Nikki', cohort: 'June'},
//     {name: 'Boris', cohort: 'June'}
// ];
// for(let student in students){
//     console.log("Name: " + students[student].name + ", " + "Cohort: " + students[student].cohort);
// }

// challenge 2
let users = {
    employees: [
        {'first_name':  'Miguel', 'last_name' : 'Jones'},
        {'first_name' : 'Ernie', 'last_name' : 'Bertson'},
        {'first_name' : 'Nora', 'last_name' : 'Lu'},
        {'first_name' : 'Sally', 'last_name' : 'Barkyoumb'}
    ],
    managers: [
       {'first_name' : 'Lillian', 'last_name' : 'Chambers'},
       {'first_name' : 'Gordon', 'last_name' : 'Poe'}
    ]
 };
//  var count = 0;
console.log("EMPLOYEES");
for(let employee in users.employees){
    
    // if(employee = true){
    //     count += 1
    //     console.log(count)
    //  }
    
    console.log(users.employees[employee].last_name + ", " + users.employees[employee].first_name);
};
// console.log("MANAGERS");
// for(let manager in users.managers){
//     console.log(users.managers[manager].last_name + ", " + users.managers[manager].first_name);
    
// }
