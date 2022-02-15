
function Person(firstName, lastName) {
    this.FirstName = firstName || "unknown";
    this.LastName = lastName || "unknown";
}

Person.prototype.getFullName = function () {
    return this.FirstName + " " + this.LastName;
}
function Student(firstName, lastName, schoolName, grade) {
    Person.call(this, firstName, lastName);

    this.SchoolName = schoolName || "unknown";
    this.Grade = grade || 0;
}
//Student.prototype = Person.prototype;
Student.prototype = new Person();
Student.prototype.constructor = Student;

var std = new Student("James", "Bond", "XYZ", 10);

alert(std.getFullName()); // James Bond
alert(std instanceof Student); // true
alert(std instanceof Person); // true





function myfunction() {
    try {
        // code that may throw an error
    }
    catch (ex) {
        // code to be executed if an error occurs
    }
    finally {
        // code to be executed regardless of an error occurs or not
    }
}