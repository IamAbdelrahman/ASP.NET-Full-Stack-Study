"use strict";
// Task 1
var array = ["AK", 1, "EK", 2];
console.log(array[0]);
function fun(x) {
    if (checkNumbers(x)) {
        let sum = 0;
        for (let i = 0; i < x.length; i++) {
            sum += x[i];
        }
        return sum;
    }
    else if (checkString(x)) {
        let result = "";
        for (let i = 0; i < x.length; i++) {
            result += x[i];
        }
        return result;
    }
    else {
        var numbers = [];
        for (let i = 0; i < x.length; i++) {
            if (typeof (x[i]) == "number") {
                numbers.push(x[i]);
            }
        }
        return numbers.sort((a, b) => a - b);
    }
}
function checkNumbers(x) {
    let result = false;
    for (let i = 0; i < x.length; i++) {
        if (typeof (x[i]) == "number")
            result = true;
        else
            return false;
    }
    return result;
}
function checkString(x) {
    let result = false;
    for (let i = 0; i < x.length; i++) {
        if (typeof (x[i]) == "string")
            result = true;
        else
            return false;
    }
    return result;
}
let arr1 = [1, 2, 3];
let arr2 = ["A", "B", "C"];
let arr3 = [1, "A", 2, "B", 3, "C"];
console.log(fun(arr1)); // 6
console.log(fun(arr2)); // ABC
console.log(fun(arr3)); // [1, 2, 3]
/*------------------------------------------------------------------*/
// Task 3
class Shape {
    constructor(name) {
        this.name = name;
    }
}
class Circle extends Shape {
    constructor(radius) {
        super("Circle");
        this.radius = radius;
    }
    area() {
        return Math.PI * this.radius * this.radius;
    }
}
class Rectangle extends Shape {
    constructor(width, height) {
        super("Rectangle");
        this.width = width;
        this.height = height;
    }
    area() {
        return this.width * this.height;
    }
}
class Square extends Rectangle {
    constructor(side) {
        super(side, side);
        this.side = side;
        this.name = "Square";
    }
}
let circle = new Circle(5);
let rectangle = new Rectangle(4, 6);
let square = new Square(4);
console.log(`${circle.name} Area: ${circle.area()}`); // Circle Area: 78.53981633974483
console.log(`${rectangle.name} Area: ${rectangle.area()}`); // Rectangle Area:
console.log(`${square.name} Area: ${square.area()}`); // Square Area: 16
let employee = {
    id: 1,
    name: "John Doe",
    salary: 50000,
    department: "IT",
    address: "123 Main St, City, Country"
};
class Employee {
    constructor(id, name, salary, department, address) {
        this.id = id;
        this.name = name;
        this.salary = salary;
        this.department = department;
        this.address = address;
        this.id = id;
        this.name = name;
        this.salary = salary;
        this.department = department;
        this.address = address;
    }
    get getSalary() {
        return this.salary;
    }
    display() {
        console.log(`ID: ${this.id}`);
        console.log(`Name: ${this.name}`);
        console.log(`Salary: ${this.getSalary}`);
        console.log(`Department: ${this.department}`);
        console.log(`Address: ${this.address}`);
    }
    GetById(id) {
        if (this.id == id) {
            return this;
        }
        else
            return null;
    }
}
let emp = new Employee(1, "AK", 1000, "IT", "123 Main St, City, Country");
// emp.display();
class Manager extends Employee {
    constructor(id, name, salary, department, address, managerId, managerName) {
        super(id, name, salary, department, address);
        this.id = id;
        this.name = name;
        this.salary = salary;
        this.department = department;
        this.address = address;
        this.managerId = managerId;
        this.managerName = managerName;
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
var WeekDays;
(function (WeekDays) {
    WeekDays[WeekDays["Saturday"] = 0] = "Saturday";
    WeekDays[WeekDays["Sunday"] = 1] = "Sunday";
    WeekDays[WeekDays["Monday"] = 2] = "Monday";
    WeekDays[WeekDays["Tuesday"] = 3] = "Tuesday";
    WeekDays[WeekDays["Wednesday"] = 4] = "Wednesday";
    WeekDays[WeekDays["Thursday"] = 5] = "Thursday";
    WeekDays[WeekDays["Friday"] = 6] = "Friday";
})(WeekDays || (WeekDays = {}));
let day = WeekDays.Saturday;
console.log(`Today is: ${WeekDays[day]}`); // Today is: Saturday
function CheckDay(d) {
    if (d == WeekDays.Saturday || d == WeekDays.Sunday) {
        return "Weekend";
    }
    else {
        return null;
    }
}
console.log(CheckDay(day)); // Weekend
