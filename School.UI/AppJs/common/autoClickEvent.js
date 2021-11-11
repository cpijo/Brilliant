
var autoClickEvent = {

    myTimer: 0,
    sec: 0,
    element: "",
    obj: {},
    startTimer: function (element, timer, obj) {
        st = this;
        this.element = element;
        this.obj = obj;
        today = new Date();
        this.sec = today.getSeconds();
        count = 0;

        var intervalId = setInterval(function () {
            autoClickEvent.checkTime(timer);
        }, 1000);

        this.turnOff = function () {
            clearInterval(intervalId);
        };
    }
    ,
    checkTime: function (timer) {
        var _today = new Date();
        var _sec = _today.getSeconds();

        var total_sec = _sec - st.sec;
        if (total_sec > timer) {//timer
            if (st.obj.doWork === undefined) {
                $(st.element).trigger('click');
            }
            else {
                st.obj.doWork(st.element);
                //clearInterval(st.intervalId);
            }
            st.turnOff();
        }
    }
    ,
    doWork: function (element) {
        $(element).trigger('click');
    }

};

