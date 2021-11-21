var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
// Class Inheritance in JavaScript
var Mammal = /** @class */ (function () {
    function Mammal(name) {
        this.name = name;
    }
    Mammal.prototype.eats = function () {
        return this.name + " eats Food";
    };
    return Mammal;
}());
var Dog = /** @class */ (function (_super) {
    __extends(Dog, _super);
    function Dog(name, owner) {
        var _this = _super.call(this, name) || this;
        _this.owner = owner;
        return _this;
    }
    Dog.prototype.eats = function () {
        return this.name + " eats Chicken";
    };
    return Dog;
}(Mammal));
var myDog = new Dog("Spot", "John");
console.log(myDog.eats()); // Spot eats chicken
//# sourceMappingURL=override_exp_1_class.js.map