
var deviceSize = (function () {
    var deviceWidth = window.innerWidth
        || document.documentElement.clientWidth
        || document.body.clientWidth
        ;
    var deviceHeight = window.innerHeight
        || document.documentElement.clientHeight
        || document.body.clientHeight
        ;
    /*phone 360 width*/
    //deviceWidth = 360;
    //deviceHeight = 640;
    //deviceTestSize(360, 640);

    return deviceSize = {
        width: deviceWidth,
        height: deviceHeight,
        pageWidth: deviceWidth,
        pageHeight: deviceHeight - 110 //deviceHeight - 110,//total is 130 of 90+20
    };
})();
