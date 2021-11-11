
function DOMTokenList(){
    ;
}
DOMTokenList.prototype.addmany = function (_classes) {
    var classes = _classes.split(' '),
        i = 0,
        ii = classes.length;

    for (i; i < ii; i++) {
        this.add(classes[i]);
    }
};
DOMTokenList.prototype.addmany2 = function (_classes) {
    var classes = _classes.split(' '),
        i = 0,
        ii = classes.length;

    for (i; i < ii; i++) {
        if (!this.contains(classes[i])) {
            this.add(classes[i]);
        }
    }
};

DOMTokenList.prototype.removemany = function (_classes) {
    var classes = _classes.split(' '),
        i = 0,
        ii = classes.length;

    for (i; i < ii; i++) {
        this.remove(classes[i]);
    }
};
DOMTokenList.prototype.removemany = function (_classes) {
    var classes = _classes.split(' '),
        i = 0,
        ii = classes.length;

    for (i; i < ii; i++) {
        if (this.contains(classes[i])) {
            this.remove(classes[i]);
        }
    }
};

//http://html5doctor.com/the-classlist-api/
//element.classList.add('one', 'two', 'three');
//element.classList.remove('one', 'two', 'three');
element.classList.replace = function (classes) {
    var i = 0,
        ii = this.length,
        old_string = this.toString(),
        old_array = old_string.split(' '),
        new_array = classes.split(' '),
        j = 0,
        jj = new_array.length;

    // remove all the existing classes
    for (i; i < ii; i++) {
        this.remove(old_array[i]);
    }

    // add the new ones
    for (j; j < jj; j++) {
        this.add(new_array[j]);
    }
};


element.classList.insert = function (insert, position) {
    // check if the class is already in classList
    if (this.contains(insert)) {
        if (this.item(position) === insert) {
            // if it is already at the right position there's no need to continue
            return;
        } else {
            // remove it, we don't want it here
            this.remove(insert);
        }
    }

    var classes = this.toString(),
        classes_array = classes.split(' ');

    classes_array.splice(position, 0, insert);

    new_list = classes_array.join(' ');

    // use the custom replace method to replace the current classList
    this.replace(new_list);
};


DOMTokenList.prototype.toggle = function (_classes) {
    let div = document.querySelector('#content');
    div.classList.toggle('visible');
};
