//  __ sign means NOt Calling it Direct 
var __classLogin = function () {

    var userObj ={ id: null,name: null,islogin: "false"};
          
    var setUserObj = function (usrObj) {
        userObj = usrObj;
        return userObj;
    };

    var getUserObj = function () {
        return userObj;
    };

    var userInfor = function (usrObj) {
        return {
            id: usrObj.id,
            name: usrObj.name,
            islogin: usrObj.isLogin
        };
    };

    return {
        setUserObj: setUserObj,
        getUserObj: getUserObj,
        userInfor: userInfor
    };
};

var classLogin = __classLogin();
