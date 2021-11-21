
// this is constructor function  
var Employee = function (name) {
    this.Name = name;
};

Employee.prototype.getname = function () {
    return this.Name;
};

var PermanantEmployee = function (salary) {
    this.annualSalary = salary;
};

var emp = new Employee("Sagar Jaybhay");
PermanantEmployee.prototype = emp; // in this case employee object is parent of permanant employee  

var per = new PermanantEmployee(3000);
console.log(per.getname());

document.writeln(per.getname());
document.writeln(per instanceof Employee)

document.writeln("<br/>")
document.writeln("annualSalary property : " + per.hasOwnProperty("annualSalary"))

document.writeln("<br/>")
document.writeln("Name property : " + emp.hasOwnProperty("Name"))  