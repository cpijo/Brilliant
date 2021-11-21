// Class Inheritance in JavaScript
class Mammal {
    [x: string]: any;
    constructor(name) {
        this.name = name;
    }
    eats() {
        return `${this.name} eats Food`;
    }
}

class Dog extends Mammal {
    constructor(name, owner) {
        super(name);
        this.owner = owner;
    }
    eats() {
        return `${this.name} eats Chicken`;
    }
}

let myDog = new Dog("Spot", "John");
console.log(myDog.eats()); // Spot eats chicken