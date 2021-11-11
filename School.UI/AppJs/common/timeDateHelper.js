
var getMinutesDate = function (sp) {
    var today = new Date();
    var date = today.getFullYear() + '/' + (today.getMonth() + 1) + '/' + today.getDate();
    var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
    var fullday = date + " " + time;
    var dateObject = {
        fullDate: fullday,
        date: date,
        time: time
    };

    return dateObject;
};