
function registeredUserToDo(name) {
    this.name = name;
    this.button = 'view';
    this.toDo = 'view';
}

registeredUserToDo.prototype.toDoRequest = function () {

    return {
        name: this.name,
        button: this.button,
        toDo: this.toDo
    };
};
//"view"
registeredUserToDo.prototype.toDoRequest = function () {
    return {
        name: "view",
        button: "viewButton",
        toDo: "viewUser"
    };
};
//"edit"
registeredUserToDo.prototype.toDoRequest = function () {
    return {
        name: "edit",
        button: "editButton",
        toDo: "editUser"
    };
};
//delete"
registeredUserToDo.prototype.toDoRequest = function () {
    return {
        name: "delete",
        button: "deleteButton",
        toDo: "deleteUser"
    };
};

var emp = new registeredUserToDo("viewButton");
alert(emp.toDoRequest())  