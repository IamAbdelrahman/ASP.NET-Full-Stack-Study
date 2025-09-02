var myElement = document.getElementById("el2");
myElement.innerHTML = "<h1>ElZero</h1>";
myElement.style.color = "blue";
myElement.style.fontSize = "80px";
myElement.style.fontWeight = "bold";
myElement.style.textAlign = "center";
myElement.style.fontFamily = "Arial";

console.log("%cElzero %cWeb %cSchool", 
    "color:red; font-size:40px", 
    "color: green; font-size:40px; font-weight:bold", 
    "color: white; background-color: blue; font-size:40px");

console.group("Group 1");
console.log("Message One");
console.log("Message Two");
console.group("Child Group");
console.log("Message One");
console.log("Message Two");
console.group("Grand Child Group");
console.log("Message One");
console.log("Message Two");
console.groupEnd();
console.groupEnd();
console.groupEnd();

console.group("Group 2");
console.log("Message One");
console.log("Message Two");
console.groupEnd();

console.table(["Elzero", "Ahmed", "Sameh", "Gamal", "Aya"]);

// console.log("Iam In Console");
// document.write("Iam In Page");

if(0)
{
    console.log("Iam In Console");
    document.writeln("Iam In Page");
}