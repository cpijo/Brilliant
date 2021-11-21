
function Employee(name) {
    this.Name = name;
}

Employee.prototype.getgreeting = function () {
    return "Hello, " + this.Name;
};

Employee.prototype.getgreeting = function () {
    return this.Name.toUpperCase();
};

var emp = new Employee("xyz");
alert(emp.getgreeting());  

