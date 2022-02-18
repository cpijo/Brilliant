





function register(elementId, eventType, ...callbacks) {
    const element = document.getElementById(elementId);
    for (const callback of callbacks) {
        element.addEventListener(eventType, callback, false);
    }
}

register("myButton", "click", sayHello, cleanup);





function myToDO(callback) {
    alert("I hope it helps");
}

function registerElement(callback) {
    var element = document.getElementById("pxgridID");
    if (element === undefined || element === null) {
        element = document.getElementById("pxgridClass")
    }

    element.addEventListener("click", function (e) {
        myToDO();
    }, false);
}


function registerElement_Simple() {
    var element = document.getElementById("pxgridID");
    element.addEventListener("click", function (e) {
        alert("I hope it helps");
    }, false);
}



let button = document.querySelector('#button');
let msg = document.querySelector('#message');

button.addEventListener('click', () => {
    msg.classList.toggle('reveal');
})







const outer = document.querySelector('.outer');
const middle = document.querySelector('.middle');
const inner1 = document.querySelector('.inner1');
const inner2 = document.querySelector('.inner2');

const capture = {
    capture: true
};
const noneCapture = {
    capture: false
};
const once = {
    once: true
};
const noneOnce = {
    once: false
};
const passive = {
    passive: true
};
const nonePassive = {
    passive: false
};

outer.addEventListener('click', onceHandler, once);
outer.addEventListener('click', noneOnceHandler, noneOnce);
middle.addEventListener('click', captureHandler, capture);
middle.addEventListener('click', noneCaptureHandler, noneCapture);
inner1.addEventListener('click', passiveHandler, passive);
inner2.addEventListener('click', nonePassiveHandler, nonePassive);

function onceHandler(event) {
    alert('outer, once');
}
function noneOnceHandler(event) {
    alert('outer, none-once, default');
}
function captureHandler(event) {
    //event.stopImmediatePropagation();
    alert('middle, capture');
}
function noneCaptureHandler(event) {
    alert('middle, none-capture, default');
}
function passiveHandler(event) {
    // Unable to preventDefault inside passive event listener invocation.
    event.preventDefault();
    alert('inner1, passive, open new page');
}
function nonePassiveHandler(event) {
    event.preventDefault();
    //event.stopPropagation();
    alert('inner2, none-passive, default, not open new page');
}



const Something = function (element) {
    // |this| is a newly created object
    this.name = 'Something Good';
    this.onclick1 = function (event) {
        console.log(this.name); // undefined, as |this| is the element
    };

    this.onclick2 = function (event) {
        console.log(this.name); // 'Something Good', as |this| is bound to newly created object
    };

    // bind causes a fixed `this` context to be assigned to onclick2
    this.onclick2 = this.onclick2.bind(this);

    element.addEventListener('click', this.onclick1, false);
    element.addEventListener('click', this.onclick2, false); // Trick
}
var s = new Something(document.body);



var Something1 = function (element) {
    // |this| is a newly created object
    this.name = 'Something Good';
    this.handleEvent = function (event) {
        console.log(this.name); // 'Something Good', as this is bound to newly created object
        switch (event.type) {
            case 'click':
                // some code here...
                break;
            case 'dblclick':
                // some code here...
                break;
        }
    };

    // Note that the listeners in this case are |this|, not this.handleEvent
    element.addEventListener('click', this, false);
    element.addEventListener('dblclick', this, false);

    // You can properly remove the listeners
    element.removeEventListener('click', this, false);
    element.removeEventListener('dblclick', this, false);
}




class SomeClass {

    constructor() {
        this.name = 'Something Good';
    }

    register() {
        const that = this;
        window.addEventListener('keydown', function (e) { that.someMethod(e); });
    }

    someMethod(e) {
        console.log(this.name);
        switch (e.keyCode) {
            case 5:
                // some code here...
                break;
            case 6:
                // some code here...
                break;
        }
    }

}

const myObject = new SomeClass();
myObject.register();





const myButton = document.getElementById('my-button-id');
const someObject = { aProperty: 'Data' };

myButton.addEventListener('click', function () {
    console.log(someObject.aProperty);  // Expected Value: 'Data'

    someObject.aProperty = 'Data Again';  // Change the value
});

window.setInterval(function () {
    if (someObject.aProperty === 'Data Again') {
        console.log('Data Again: True');
        someObject.aProperty = 'Data';  // Reset value to wait for next event execution
    }
}, 5000);



const els = document.getElementsByTagName('*');

// Case 1
for (let i = 0; i < els.length; i++) {
    els[i].addEventListener("click", function (e) {/*do something*/ }, false);
}

// Case 2
function processEvent(e) {
    /* do something */
}

for (let i = 0; i < els.length; i++) {
    els[i].addEventListener("click", processEvent, false);
}




//var els = document.getElementsByTagName('*');

//function processEvent(e) {
//    /* do something */
//}

//// For illustration only: Note the mistake of [j] for [i]. We are registering all event listeners to the first element

//// Case 3
//for (let i = 0, j = 0; i < els.length; i++) {
//    els[j].addEventListener("click", processEvent = function (e) {/* do something */ }, false);
//}

//// Case 4
//for (let i = 0, j = 0; i < els.length; i++) {
//    function processEvent(e) {/* do something */ };
//    els[j].addEventListener("click", processEvent, false);
//}





