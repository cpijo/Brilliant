


// constructor function
function registerdUser() {
    this.buttonName = 'view',
        this.todo = 'view',

        this.view = function () {
            console.log('hello');
        },
        this.edit = function () {
            console.log('hello');
        }
        ,
        this.delete = function () {
            console.log('hello');
        };
}

// create objects
const _registerdUser = new registerdUser();
const person2 = new Person();

// access properties
console.log(person1.name);  // John
console.log(person2.name);  // John






function myInit() {

    document.addEventListener('DomContentLooaded', myInit);

    let btn = document.getElementById('btn');
    let lnk = document.getElementById('link');
    let txt = document.getElementById('txt');

    txt.addEventListener('input', function (event) {
        var _type = event.type;
        var _target = event.target;
        var _value = event.target.value;
    });
    txt.addEventListener('change', function (event) {
        var _type = event.type;
        var _target = event.target;
        var _value = event.target.value;
    });
    txt.addEventListener('blur', function (event) {
        var _type = event.type;
        var _target = event.target;
        var _value = event.target.value;
    });

}








$(document).ready(function () {

    $("#demoGrid").DataTable({

        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "pageLength": 5,

        "ajax": {
            "url": "/Demo/LoadData",
            "type": "POST",
            "datatype": "json"
        },

        "columnDefs":
            [{
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [7],
                "searchable": false,
                "orderable": false
            },
            {
                "targets": [8],
                "searchable": false,
                "orderable": false
            },
            {
                "targets": [9],
                "searchable": false,
                "orderable": false
            }],

        "columns": [
            { "data": "CustomerID", "name": "CustomerID", "autoWidth": true },
            { "data": "CompanyName", "name": "CompanyName", "autoWidth": true },
            { "data": "ContactName", "title": "ContactName", "name": "ContactName", "autoWidth": true },
            { "data": "ContactTitle", "name": "ContactTitle", "autoWidth": true },
            { "data": "City", "name": "City", "autoWidth": true },
            { "data": "PostalCode", "name": "PostalCode", "autoWidth": true },
            { "data": "Country", "name": "Country", "autoWidth": true },
            { "data": "Phone", "name": "Phone", "title": "Status", "autoWidth": true },
            {
                "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/Demo/Edit/' + full.CustomerID + '">Edit</a>'; }
            },
            {
                data: null, render: function (data, type, row) {
                    return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.CustomerID + "'); >Delete</a>";
                }
            },

        ]

    });
});