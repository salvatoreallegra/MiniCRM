//typescript practice

let age: number = 30;
let name: string = "Simon Barkoftka";
let isDeveloper: boolean = true;
const title: string = "TypeScript Practice";

console.log(age);

function add(a: number, b:number) : number {
  return a + b;
}

console.log(add(5, 10));
console.log(name);
console.log(isDeveloper);
console.log(title);

function introduce(name:string) : void {
  console.log(`Hello, my name is ${name}`);
}
introduce("Simon");

//Objects
const FighterJet = {
    id: 1,
    Model: "F-22 Raptor",
    Manufacturer: "Lockheed Martin",
    MaxSpeed: 1500,
    isStealth: true 
}
console.log(FighterJet.Model);

//Types
type Car = {
    id: number;
    Model: string;
    Manufacturer: string;
    MaxSpeed: number;
    isElectric: boolean;
    isSuperCar: boolean;
}

const myCar: Car = {
    id: 1,
    Model: "Ferrari SF90 Stradale",
    Manufacturer: "Ferrari",
    MaxSpeed: 217,
    isElectric: true,
    isSuperCar: true
};
console.log(myCar.Model);