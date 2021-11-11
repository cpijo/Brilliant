
function isEmptyObject(obj) {
    return Object.getOwnPropertyNames(obj).length === 0;
}
function isNotEmptyObject(obj) {
    return Object.getOwnPropertyNames(obj).length > 0;
}

var hasChangeValue = function (oldValues, newValues) {

    var changeObj = new Object();
    var newproperty = "";
    var oldproperty = "";
    for (oldproperty in oldValues) {
        for (newproperty in newValues) {
            if (oldproperty === newproperty) {
                if (oldValues[oldproperty] !== newValues[newproperty]) {
                    changeObj[oldproperty] = { "old": oldValues[oldproperty], "new": newValues[newproperty] };
                    //changeObj[oproperty] = true;
                }
            }
        }
    }

    return changeObj;
};

function isEmpty(obj) {
    for (var prop in obj) {
        if (obj.hasOwnProperty(prop))
            return false;
    }

    return true;
}

function isEmptyObject1(obj) {
    return JSON.stringify(obj) === '{}';
}


jQuery.isEmptyObject2(obj); 


var isEmpty3 = function (obj) {
    for (var p in obj) {
        return false;
    }
    return true;
};




var mygetInputByForm = function (allInputs, allImages) {

    var modelObject = new Object();
    for (j = 0; j < allInputs.length; j++) {

        _getFieldName = allInputs[j].name;
        if (_getFieldName === "") {
            _getFieldName = "null_Name_" + j;
            modelObject[_getFieldName] = allInputs[j].value;//  var tValue0 = thisRow[j].innerHTML;
        }
        else {
            modelObject[_getFieldName] = allInputs[j].value;//  var tValue0 = thisRow[j].innerHTML;
        }
    }

    if (allImages.length > 0) {
        for (j = 0; j < allImages.length; j++) {

            _getFieldName = allImages[j].name;
            if (_getFieldName === "") {
                _getclassName = "null_Name_" + j;
                modelObject[_getFieldName] = allImages[j].src;//  var tValue0 = thisRow[j].innerHTML;
            }
            else {
                modelObject[_getFieldName] = allImages[j].src;//  var tValue0 = thisRow[j].innerHTML;
            }
        }

    }
    return modelObject;
};





var objArray = [
    { id: 0, name: 'Object 0', otherProp: '321' },
    { id: 1, name: 'O1', otherProp: '648' },
    { id: 2, name: 'Another Object', otherProp: '850' },
    { id: 3, name: 'Almost There', otherProp: '046' },
    { id: 4, name: 'Last Obj', otherProp: '984' }
];


function findObjectByKey(array, key, value) {
    for (var i = 0; i < array.length; i++) {
        if (array[i][key] === value) {
            return array[i];
        }
    }
    return null;
}

var obj = findObjectByKey(objArray, 'id', 3);
let objEs6 = objArray.find(obj => obj.id === 3);




function isEmptyObject_0(obj) {
    for (var prop in obj) {
        if (Object.prototype.hasOwnProperty.call(obj, prop)) {
            return false;
        }
    }
    return true;
}

isEmptyObject({}); // true
isEmptyObject({ foo: 'bar' });  // false




var hasDot = hidenInputs[1].value.indexOf('.');
var ext = ".jpg";
if (hasDot !== -1) {
    var str = hidenInputs[1].value;
    var _startPoint = hasDot + 1;
    ext = str.substring(_startPoint);
}


