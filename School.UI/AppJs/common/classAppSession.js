
var classAppSession = {
    errorMsg: "",
    status: 0,//false = 0  , true =  1
    isLogin: 0,//false = 0  , true =  1
    setBasePartialHolder: 0,

    userSession : {
        isSuccess: "false",
        isClicked: "false",
        isVisible: "false",
        hasPermission: "no",
        permissions: null,
        permissionList: {}
    },
    openPage:"",

    autoReloadApp: function () {

        var _defaultPageTimeOutMinutes = 18;
        var _timeOutWarningSeconds = 19;
        var DefaultPageTimeOutMinutes = Number(_defaultPageTimeOutMinutes) * 60;
        var TimeOutWarningSeconds = Number(_timeOutWarningSeconds);

        var timeRemaining = DefaultPageTimeOutMinutes,
            timer,
            enabledEvents = true;
        timer = setInterval(function () {

            timeRemaining--;

            var _timeRemaining = timeRemaining;


            if (timeRemaining === TimeOutWarningSeconds) {

                var obj = {
                    timeRemaining: _timeRemaining,
                    DefaultPageTimeOutMinutes: DefaultPageTimeOutMinutes
                };
                var jsonString = JSON.stringify(obj);
                timeRemaining = DefaultPageTimeOutMinutes;

                var url = '/ApplicatioSession/ReloadWebsite/?jsonString=' + jsonString;
                var data = obj;
                $.get(url, data, function (result) {
                    //var id = '#postedFor' + postId;
                    classBusyIconHelper.hideBusyIcon();
                });

                //window.location.href = '/ApplicatioSession/ReloadWebsite/?jsonString=' + jsonString;
                //window.location.href = '@Url.Action("ResertSession_ReloadApp", "ApplicatioSession")' + '?jsonString=' + jsonString;
            }
        }, 1000);

        $(document).mousemove(function (event) {
            if (timeRemaining > TimeOutWarningSeconds) {
                timeRemaining = DefaultPageTimeOutMinutes;
            }

        });
        $(document).keypress(function (event) {
            if (timeRemaining > TimeOutWarningSeconds) {
                timeRemaining = DefaultPageTimeOutMinutes;
            }
        });
        $(document).mousedown(function (event) {
            if (timeRemaining > TimeOutWarningSeconds) {
                timeRemaining = DefaultPageTimeOutMinutes;
            }
        });
    }
};
