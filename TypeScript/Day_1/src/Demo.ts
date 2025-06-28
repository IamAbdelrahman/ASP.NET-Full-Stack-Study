console.log("Hello Typescript")
console.log("Hello, World")
/*-----------------------------------------------------------------*/

// ARRAY | TUBLES
let arr: [number]
arr = [1]
console.log(arr[0]) // 1
arr.push(5)
console.log(arr.pop()) // 5
var mixedArr:any[] = [1, true, "Ahmed"]
var StringOrNumber:(number |string)[] = ["Ahmed", 10, "Ibrahim", 11]
type types = string | number | boolean
var StringOrNumberOrBoolean: types[] = [1, "Ahmed", true]
var y: Array<types> = [true, 10, "Hossam"] // Define an array using generic
console.log(StringOrNumberOrBoolean[2]) // true

var numbers:number[] = [1,2,3]
for (var i = 0; i < numbers.length; i++)
    console.log(numbers[i])
/*-----------------------------------------------------------------*/

// BOOLEAN
let result: boolean = true
result = false
console.log(typeof(result))
/*-----------------------------------------------------------------*/

// STRING
let person: string = "AK"
console.log(person)

let animal: "dog"
animal = "dog"
// animal = "cat"
console.log(typeof(animal), `animal is ${animal}`) // string - dog


/*-----------------------------------------------------------------*/

// ANY - UNKNOWN
var fname:any
fname = 10
var lname;
lname = 20
fname = "ahmed"
var myname:string = "abdo"
console.log(myname.toUpperCase())
console.log(myname) // NO EFFECT HERE
lname = "alaa"
console.log(fname +" "+lname);

var z:unknown
z = "hello"
if (typeof(z) == "string")
{
    console.log(z.toUpperCase())
}
console.log(z)
// z.toUpperCaser(); ERROR
/*-----------------------------------------------------------------*/

// UNION DATA TYPES
var x: string | number;
x = "ali"
x = 10
console.log("x = ", x)
/*-----------------------------------------------------------------*/

// OBJECT
var obj:{fname:string, age:number} = {fname:"AK", age:25}
console.log(obj.fname +":"+ obj.age);

var arrOfObjs:[{fname:string, age:number}] = [obj]
console.log(arrOfObjs[0])
let product:{id:number, price:number} = {id:1, price:1000}
var products:{id:number, name:string, price:number}[] = 
[
    {
        id:1,
        name:"pepsi",
        price:100
    }
]
/*-----------------------------------------------------------------*/

// FUNCTION
function sum(x: number, y: number){
return x + y;
}
console.log(sum(1, 2))

function sub(x:number = 0, y:number = 0) {
    return x - y
}
sub(1,1); // sub(1) // sub() // ALL 
// sum("ali", "kamal")
type Species = "dog" | "cat" | "donkey" | "bird";

function buyPet(pet:Species, name:string): Species { return pet; }
let pet = buyPet("dog", "putty")
// let pet = buyPet("lion", "King") // ERROR: lion is not assignable to parameter of type 'Species'
console.log(pet) // dog
/*-----------------------------------------------------------------*/

// CLASS
abstract class Person 
{
    constructor(public name:string, public age:number){
        this.name = name;
        this.age = age;
    }
    display():void {console.log(this.age)}
}
class User extends Person 
{
    constructor(name:string, age:number, public password:string) {
        super(name, age)
    }
    GeneratePassword():string 
    {
        return this.password.toUpperCase() + "#$@"
    }
    override display(): void {
        console.log(this.age + ":" + this.GeneratePassword())
    }
}

// let p1 = new Person("AK",20)
// console.log(p1)
let user = new User("AK", 25, "aljfeer#r3")
console.log(user)
user.display()
class Pet 
{
    constructor(public name:string, public num:number){}
    set setNum(value:number) {
        this.num = value
    }
    get getNum() {
        return this.num
    }
}
let p2 = new Pet("putty", 1)
p2.name = "catty" // set
console.log(p2)
p2.setNum = 11
console.log(p2.getNum)
/*-----------------------------------------------------------------*/

// INTERFACE
interface pet {
species: Species;
eat:() => void;
sleep():void;
}

class Dog implements pet
{
    constructor(public species:Species) {
        this.species = "dog"
    }
    eat() {console.log("I eat")}
    sleep() {console.log("I sleep")}
}

let d = new Dog("dog")
d.eat(); d.sleep()
interface shape {
    id:number,
    name:string,
    Area:(x:number, y:number) => number;
}

// class circle implements shape {
//     constructor (public id:number, public name:string)
//     {
//         this.id = id
//         this.name = name
//     }
//     Area(x:number, y:number) {
//         return x * y
//     }
// }

interface IPerson {
    id:number
    name:string
}
let persons:IPerson[] = [{id:1, name:"AK"}, {id:2, name:"SK"}]
console.log(persons[0]) // {id:1, name:"AK"}
console.log(typeof(persons[0]))

interface IPets {
    species:Species
    eat():void
    sleep():void
}

interface ICat extends IPets {
    species:"cat"
}

interface IDonkey extends IPets {
    species:"donkey"
}

interface IBird extends IPets {
    species:"bird"
    sing():void
}


function sellPet (pet:Species, name:string):IPets {
    if (pet == "cat") {
        return {
            species:"cat",
            eat():void {console.log("cat eats")},
            sleep():void {console.log("cat sleeps")},
        } as ICat;
    }
    else if (pet == "bird") {
        return {
            species:"bird",
            eat():void {console.log("bird eats")},
            sleep():void {console.log("bird sleeps")},
            sing():void {console.log("bird sings")}
        } as IBird
    }
    else throw console.error("ERROR");
}

let iCat = sellPet("cat", "Tom")
let iBird = sellPet("bird", "Owl")
iCat.eat()
iBird.eat()
/*-----------------------------------------------------------------*/

// GENERICS
// function Gen<T1,T2>(x:T1, y:T2):T1{
//     return x
// }
// console.log(Gen(1, 2)) // 1
// console.log(Gen("AK", "SK")) // AK
// console.log(Gen(true,"We")) // true