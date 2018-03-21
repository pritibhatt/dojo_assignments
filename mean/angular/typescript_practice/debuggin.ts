//1.
var myString: string;
// I can assign myString like this:
myString = "Bee stinger";

// Why is there a problem with this? What can I do to fix this? myString is string so needs "".
myString = "9";

//2.
function sayHello(name: string) { 
    return `Hello, ${name}!`;
}
// This is working great:
console.log(sayHello("Kermit"));
// Why isn't this working? I want it to return "Hello, 9!" name is a string so needs ""

console.log(sayHello("9"));

//3.
function fullName(firstName: string, lastName: string, middleName?: string) {
    let fullName = `${firstName} ${middleName} ${lastName}`;
    return fullName;
}
// This works:
console.log(fullName("Mary", "Moore", "Tyler"));
// What do I do if someone doesn't have a middle name? input value of "" without any numbers in it.
console.log(fullName("Jimbo", "Jones"));

//4.
interface Student {
    firstName: string;
    lastName: string;
    belts: number;
}
function graduate(ninja: Student) {
    return `Congratulations, ${ninja.firstName} ${ninja.lastName}, you earned ${ninja.belts} belts!`;
}
const christine = {
    firstName: "Christine",
    lastName: "Yang",
    belts: 2
}

const jay = {
    firstName: "Jay",
    lastName: "Patel",
    belts: 4
}
// This seems to work fine:
console.log(graduate(christine));
// This one has problems: Belts was mispelled
console.log(graduate(jay));

//5.
class Ninja {
    fullName: string;
    constructor(
        public firstName: string,
        public lastName?: string) {
        this.fullName = `${firstName} ${lastName}`;
    }
    debug() {
        console.log("Console.log() is my friend.")
    }
}
// This is not making an instance of Ninja, for some reason: last name is missing so you can make last name nullable with ?
const shane = new Ninja("Shane");
// Since I'm having trouble making an instance of Ninja, I decided to do this: can create ninja using proper constructor
const turing = new Ninja("Alan", "Turing")
// Now I'll make a study function, which is a lot like our graduate function from above:
function study(programmer: Ninja) {
    return `Ready to whiteboard an algorithm, ${programmer.fullName}?`
}
// Now this has problems: not following new Class model. 
console.log(study(turing));

//6.
var increment = x => x + 1;
// This works great:
console.log(increment(3));
var square = x =>  x * x ;
// This is not showing me what I want: does not need curley braces: var square = x => x * x ;
console.log(square(4));
// This is not working: needs to have parenthesis around multiple parameters
var multiply = (x, y) => (x * y);
// Nor is this working: requires curly brackets
var math = (x, y) => {
    let sum = x + y;
    let product = {x * y};
    let difference = Math.abs(x - y);
    return [sum, product, difference];
};

//7.
class Elephant {
    constructor(public age: number) { }
    birthday = function () {
        this.age++;
    }
}
const babar = new Elephant(8);
//actually called the function
setTimeout(babar.birthday(), 1000)
setTimeout(function () {
    console.log(`Babar's age is ${babar.age}.`)
}, 2000)