// Task 1
var array: (string | number)[] = ["AK", 1, "EK", 2];
console.log(array[0]);
/*------------------------------------------------------------------*/

// Task 2
type tps = number | string;
function fun(x: tps[]) {
    if (checkNumbers(x)) {
        let sum = 0;
        for (let i = 0; i < x.length; i++) {
            sum += x[i] as number;
        }
        return sum;
    }
    else if (checkString(x)) {
        let result = "";
        for (let i = 0; i < x.length; i++) {
            result += x[i] as string;
        }
        return result;
    }
    else {
        var numbers: number[] = [];
        for (let i = 0; i < x.length; i++) {
            if (typeof (x[i]) == "number") {
                numbers.push(x[i] as number);
            }
        }
        return numbers.sort((a, b) => a - b);
    }
}

function checkNumbers(x: tps[]): boolean {
    let result = false;
    for (let i = 0; i < x.length; i++) {
        if (typeof (x[i]) == "number")
            result = true;
        else return false;
    }
    return result;
}

function checkString(x: tps[]): boolean {
    let result = false;
    for (let i = 0; i < x.length; i++) {
        if (typeof (x[i]) == "string")
            result = true;
        else return false;
    }
    return result;
}

let arr1: tps[] = [1, 2, 3];
let arr2: tps[] = ["A", "B", "C"];
let arr3: tps[] = [1, "A", 2, "B", 3, "C"];
console.log(fun(arr1)); // 6
console.log(fun(arr2)); // ABC
console.log(fun(arr3)); // [1, 2, 3]
/*------------------------------------------------------------------*/

// Task 3
abstract class Shape {
    constructor(public name: string) { }
    abstract area(): number;
}

class Circle extends Shape {
    constructor(public radius: number) {
        super("Circle");
    }
    area(): number {
        return Math.PI * this.radius * this.radius;
    }
}

class Rectangle extends Shape {
    constructor(public width: number, public height: number) {
        super("Rectangle");
    }
    area(): number {
        return this.width * this.height;
    }
}

class Square extends Rectangle {
    constructor(public side: number) {
        super(side, side);
        this.name = "Square";
    }
}

let circle = new Circle(5);
let rectangle = new Rectangle(4, 6);
let square = new Square(4);
console.log(`${circle.name} Area: ${circle.area()}`); // Circle Area: 78.53981633974483
console.log(`${rectangle.name} Area: ${rectangle.area()}`); // Rectangle Area:
console.log(`${square.name} Area: ${square.area()}`); // Square Area: 16
/*------------------------------------------------------------------*/

// Task 4
interface IEmployee {
    id: number;
    name: string;
    salary: number;
    department: string;
    address: string
}
let employee: IEmployee = {
    id: 1,
    name: "John Doe",
    salary: 50000,
    department: "IT",
    address: "123 Main St, City, Country"
};

class Employee implements IEmployee {
    constructor(
        public id: number,
        public name: string,
        public salary: number,
        public department: string,
        public address: string
    ) {
        this.id = id;
        this.name = name;
        this.salary = salary;
        this.department = department;
        this.address = address;
    }
    get getSalary(): number {
        return this.salary;
    }
    display(): void {
        console.log(`ID: ${this.id}`);
        console.log(`Name: ${this.name}`);
        console.log(`Salary: ${this.getSalary}`);
        console.log(`Department: ${this.department}`);
        console.log(`Address: ${this.address}`);
    }
    GetById(id: number): Employee | null {
        if (this.id == id) {
            return this;
        }
        else return null;
    }
}

let emp = new Employee(1, "AK", 1000, "IT", "123 Main St, City, Country");
// emp.display();

class Manager extends Employee {
    constructor(
        public id: number,
        public name: string,
        public salary: number,
        public department: string,
        public address: string,
        public managerId: number,
        public managerName: string
    ) {
        super(id, name, salary, department, address);
        this.managerId = managerId;
        this.managerName = managerName;
    }

}

let manager = new Manager(1, "AK", 2000, "IT", "456 Main St, City, Country", 2, "Manager Name");
let foundEmployee = manager.GetById(1);
if (foundEmployee) {
    console.log("Employee found:");
    foundEmployee.display();
}
/*------------------------------------------------------------------*/

// Task 5
enum WeekDays {
    Saturday,
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday
}

let day = WeekDays.Saturday;
console.log(`Today is: ${WeekDays[day]}`); // Today is: Saturday
function CheckDay (d:WeekDays):string | null {
    if (d == WeekDays.Saturday || d == WeekDays.Sunday) {
        return "Weekend";
    }
    else {
        return null
    }
}
console.log(CheckDay(day)); // Weekend