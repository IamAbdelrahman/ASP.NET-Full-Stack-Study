"use strict";
console.log("Hello Typescript");
console.log("Hello, World");
/*-----------------------------------------------------------------*/
// ARRAY | TUBLES
let arr;
arr = [1];
console.log(arr[0]); // 1
arr.push(5);
console.log(arr.pop()); // 5
var mixedArr = [1, true, "Ahmed"];
var StringOrNumber = ["Ahmed", 10, "Ibrahim", 11];
var StringOrNumberOrBoolean = [1, "Ahmed", true];
var y = [true, 10, "Hossam"]; // Define an array using generic
console.log(StringOrNumberOrBoolean[2]); // true
var numbers = [1, 2, 3];
for (var i = 0; i < numbers.length; i++)
    console.log(numbers[i]);
/*-----------------------------------------------------------------*/
// BOOLEAN
let result = true;
result = false;
console.log(typeof (result));
/*-----------------------------------------------------------------*/
// STRING
let person = "AK";
console.log(person);
let animal;
animal = "dog";
// animal = "cat"
console.log(typeof (animal), `animal is ${animal}`); // string - dog
/*-----------------------------------------------------------------*/
// ANY - UNKNOWN
var fname;
fname = 10;
var lname;
lname = 20;
fname = "ahmed";
var myname = "abdo";
console.log(myname.toUpperCase());
console.log(myname); // NO EFFECT HERE
lname = "alaa";
console.log(fname + " " + lname);
var z;
z = "hello";
if (typeof (z) == "string") {
    console.log(z.toUpperCase());
}
console.log(z);
// z.toUpperCaser(); ERROR
/*-----------------------------------------------------------------*/
// UNION DATA TYPES
var x;
x = "ali";
x = 10;
console.log("x = ", x);
/*-----------------------------------------------------------------*/
// OBJECT
var obj = { fname: "AK", age: 25 };
console.log(obj.fname + ":" + obj.age);
var arrOfObjs = [obj];
console.log(arrOfObjs[0]);
let product = { id: 1, price: 1000 };
var products = [
    {
        id: 1,
        name: "pepsi",
        price: 100
    }
];
/*-----------------------------------------------------------------*/
// FUNCTION
function sum(x, y) {
    return x + y;
}
console.log(sum(1, 2));
function sub(x = 0, y = 0) {
    return x - y;
}
sub(1, 1); // sub(1) // sub() // ALL 
function buyPet(pet, name) { return pet; }
let pet = buyPet("dog", "putty");
// let pet = buyPet("lion", "King") // ERROR: lion is not assignable to parameter of type 'Species'
console.log(pet); // dog
/*-----------------------------------------------------------------*/
// CLASS
class Person {
    constructor(name, age) {
        this.name = name;
        this.age = age;
        this.name = name;
        this.age = age;
    }
    display() { console.log(this.age); }
}
class User extends Person {
    constructor(name, age, password) {
        super(name, age);
        this.password = password;
    }
    GeneratePassword() {
        return this.password.toUpperCase() + "#$@";
    }
    display() {
        console.log(this.age + ":" + this.GeneratePassword());
    }
}
// let p1 = new Person("AK",20)
// console.log(p1)
let user = new User("AK", 25, "aljfeer#r3");
console.log(user);
user.display();
class Pet {
    constructor(name, num) {
        this.name = name;
        this.num = num;
    }
    set setNum(value) {
        this.num = value;
    }
    get getNum() {
        return this.num;
    }
}
let p2 = new Pet("putty", 1);
p2.name = "catty"; // set
console.log(p2);
p2.setNum = 11;
console.log(p2.getNum);
class Dog {
    constructor(species) {
        this.species = species;
        this.species = "dog";
    }
    eat() { console.log("I eat"); }
    sleep() { console.log("I sleep"); }
}
let d = new Dog("dog");
d.eat();
d.sleep();
let persons = [{ id: 1, name: "AK" }, { id: 2, name: "SK" }];
console.log(persons[0]); // {id:1, name:"AK"}
console.log(typeof (persons[0]));
function sellPet(pet, name) {
    if (pet == "cat") {
        return {
            species: "cat",
            eat() { console.log("cat eats"); },
            sleep() { console.log("cat sleeps"); },
        };
    }
    else if (pet == "bird") {
        return {
            species: "bird",
            eat() { console.log("bird eats"); },
            sleep() { console.log("bird sleeps"); },
            sing() { console.log("bird sings"); }
        };
    }
    else
        throw console.error("ERROR");
}
let iCat = sellPet("cat", "Tom");
let iBird = sellPet("bird", "Owl");
iCat.eat();
iBird.eat();
/*-----------------------------------------------------------------*/
// GENERICS
// function Gen<T1,T2>(x:T1, y:T2):T1{
//     return x
// }
// console.log(Gen(1, 2)) // 1
// console.log(Gen("AK", "SK")) // AK
// console.log(Gen(true,"We")) // true
