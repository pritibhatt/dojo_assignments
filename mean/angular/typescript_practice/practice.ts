var mynumVar: number = 5;
var myString: string = "Hello Universe";
var myBollean: boolean = true;
var anyType: any = 10;
anyType = {};
anyType = 10;
var myNumArray: number[] = [1,2,3,4,5];
let myStrArray: string[] = ['hello', 'world'];
let myObject: [{ name: 'priti'}, {name: 'tom'}];
//function 
//returns nothing
function printToConsole(message: string): void {
    console.log(message);
}

function maxOfArray(arr: number[]):number{
    var max = arr[0];
    for(var num of arr){
        max = num;
    }
    return max;
}
class NodeBst {
    value: number;
    left: object;
    right: object;
    constructor(value){
        this.value = value;
    }
}

interface UserInterface  {
    name: string;
    age: number;
    email: string;
}

function anotherFunction(user: UserInterface){

}
anotherFunction({ name: 'priti', age: 30, email: ''});

var myArr: Array<number> = [1,2,3,4];
var myObj: object = { name:'Bill'};
var anythingVariable: any = "Hellov world";
anythingVariable = 25; 
var arrayOne: Array<Boolean> = [true, false, true, true]; 
var arrayTwo: Array<any> = [1, 'abc', true, 2];
myObj = { x: 5, y: 10 };
// object constructor
// MyNode = (function () {
//     function MyNode(val) {
//         this.val = 0;
//         this.val = val;
//     }
//     MyNode.prototype.doSomething = function () {
//         this._priv = 10;
//     };
//     return MyNode;
// }());
// myNodeInstance = new MyNode(1);
// console.log(myNodeInstance.val);
class MyNode {
    val: number

    constructor(input: number){
        this.val = input
    }

    doSomething(){
        console.log("Hello")
    }
}
let myNodeInstance = new MyNode(1);
console.log(myNodeInstance.val);
myNodeInstance.doSomething();

function myFunction(): void {
    console.log("Hello World");
}
function sendingErrors(): never {
	throw new Error('Error message');
}

myFunction();