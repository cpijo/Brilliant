
var classTimerGeneric = {

    myTimer: 0,
    c: 5,
    obj: "",
    deg:0
    ,

    startTimer: function (myObj, sec) {
        me = this;
        this.c = sec;
        this.obj = myObj;

        if (me.obj.page === "menu") {
            $(me.obj.element).css({ "color": "Red" });
            $(me.obj.element).parent().css({ "background-color": "Orange" })
                                            .parent().css({ "display": "block" });
        }
        else if (me.obj.page === "ovalay") {
            $(me.obj.element).css({ "background-color": "Orange" });
            $(me.obj.element)
                    .css({ "-webkit-transform": "rotate(2160deg)" })
                    .css({ "-moz-transform": "rotate(2160deg)" })
                    .css({ "-ms-transform": "rotate(2160deg)" })
                    .css({ "-o-transform": "rotate(2160deg)" })
                    .css({ "transition-duration": "1.9s" });
        }      
        this.myTimer = setInterval(this.stopCountSeconds, 100);
    }
    ,
    stopCountSeconds: function () {
        var _myTimer = me.myTimer;
        var co = me.c;

        if (me.obj.page === "ovalay") {
            //$(classTimerGeneric.obj.element).addClass("rotatedCloseBtn360");
        }
    
        if (co === 0) {

            if (me.obj.page === "menu") {
                //$(classTimerGeneric.obj.element).css({ "color": "white" });
                //$(classTimerGeneric.obj.element).parent().css({ "background-color": "rgb(59, 90, 108)" });
            }
            else if (me.obj.page === "ovalay") {
               
                $(me.obj.element).css({ "background-color": "Red" });
                //$(classTimerGeneric.obj.element).remove("rotatedCloseBtn360");
                //$(classTimerGeneric.obj.element).addClass("rotatedCloseBtn0");

                $(me.obj.element)
                    .css({ "-webkit-transform": "rotate(0deg)" })
                    .css({ "-moz-transform": "rotate(0deg)" })
                    .css({ "-ms-transform": "rotate(0deg)" })
                    .css({ "-o-transform": "rotate(0deg)" })
                    .css({ "transition-duration": ".1s" });
            }
            else {
                ;
            }
            clearInterval(_myTimer);
        }
        --me.c;
    }
};

