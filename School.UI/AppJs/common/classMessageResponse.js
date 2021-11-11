
var classMessageResponse = {
    me: this
    ,
    setPageSize: function () {
        var page = deviceSize;
        if (page.width < 400) {
            var width = page.pageWidth - 20;
            var avg = page.pageWidth / 2;
            // width: 360px;
            $('#Home-Container #PartialContainer #PopupBodyMessageResponse').css({
                'width': width + 'px',
                'margin': '10px',
                'left': 'calc(50% - ' + avg + 'px)'
            });

            $('#Home-Container #PartialContainer #PopupBodyConfirmMessageResponse').css({
                'width': width + 'px',
                'margin': '10px',
                'left': 'calc(50% - ' + avg + 'px)'
            });

            $('#Home-Container #PartialContainer #PopupBodyMessageAppend').css({
                'width': width + 'px',
                'margin': '10px',
                'left': 'calc(50% - ' + avg + 'px)'
            });
        }
    }
    ,
    showMessage: function (pageObj) {

        switch (pageObj.type) {

            case "success":
                pageObj.buttnType = "btn-success"; pageObj.border = "green";
                break;
            case "warning":
                pageObj.buttnType = "btn-warning"; pageObj.border = "orange";
                break;
            case "error":
                pageObj.buttnType = "btn-danger"; pageObj.border = "red";
                break;
            default:
                pageObj.buttnType = "btn-success"; pageObj.border = "green";
                break;
        }

        var hideTypes = "#PopupBodyMessageResponse #parentIcons span";
        $(hideTypes).css("display", "none").hide();

        var type = "#PopupBodyMessageResponse #parentIcons span#" + pageObj.type;
        $(type).css("display", "block").css("border-color", pageObj.border).show();

        var buttons = "#PopupBodyMessageResponse #btnOk button.btnOk";
        $(buttons).removeClass("btn-success btn-warning btn-danger").addClass(pageObj.buttnType);


        var popupOverlay = "#PopupOverlayMessage";
        var basePartialHolder = "#Home-Container #PopupBodyMessageResponse";

        var myTitle = "#Home-Container #PopupBodyMessageResponse #msgTitleId p.title";
        $(myTitle).empty().text(pageObj.title);

        var myMessage = "#Home-Container #PopupBodyMessageResponse #msgContextId p.message";
        $(myMessage).empty().text(pageObj.message);

        $(popupOverlay).css("display", "block").show();
        $(basePartialHolder).css("display", "block").show();

        if (pageObj.autoClose !== undefined) {
            if (pageObj.autoClose === true) {
                autoClickEvent.startTimer("#PopupBodyMessageResponse #btnOk button.btnOk", pageObj.timer, pageObj);
            }
        }

    }
    ,


    showMessageAppend: function (pageObj) {

        switch (pageObj.type) {

            case "success":
                pageObj.buttnType = "btn-success"; pageObj.border = "green";
                break;
            case "warning":
                pageObj.buttnType = "btn-warning"; pageObj.border = "orange";
                break;
            case "error":
                pageObj.buttnType = "btn-danger"; pageObj.border = "red";
                break;
            default:
                pageObj.buttnType = "btn-success"; pageObj.border = "green";
                break;
        }

        var hideTypes = "#PopupBodyMessageAppend #parentIcons span";
        $(hideTypes).css("display", "none").hide();

        var type = "#PopupBodyMessageAppend #parentIcons span#" + pageObj.type;
        $(type).css("display", "block").css("border-color", pageObj.border).show();

        var buttons = "#PopupBodyMessageAppend #btnOk button.btnOk";
        $(buttons).removeClass("btn-success btn-warning btn-danger").addClass(pageObj.buttnType);


        var popupOverlay = "#PopupOverlayMessage";
        var basePartialHolder = "#Home-Container #PopupBodyMessageAppend";

        var myTitle = "#Home-Container #PopupBodyMessageAppend #msgTitleId p.title";
        $(myTitle).empty().text(pageObj.title);

        var myMessage = "#Home-Container #PopupBodyMessageAppend #msgContextId";
        $(myMessage).empty().append(pageObj.message);

        $(popupOverlay).css("display", "block").show();
        $(basePartialHolder).css("display", "block").show();

        if (pageObj.autoClose !== undefined) {
            if (pageObj.autoClose === true) {
                autoClickEvent.startTimer("#PopupBodyMessageAppend #btnOk button.btnOk", pageObj.timer, pageObj);
            }
        }

    }
    ,


    messageConfirmation: function (pageObj) {

        //classMessageResponse.pageObj = Object.create(classMessageResponse.objPage);
        classMessageResponse.pageObj = pageObj;

        switch (pageObj.type) {

            case "success":
                pageObj.buttnType = "btn-success"; pageObj.border = "green";
                break;
            case "warning":
                pageObj.buttnType = "btn-warning"; pageObj.border = "orange";
                break;
            case "error":
                pageObj.buttnType = "btn-danger"; pageObj.border = "red";
                break;
            default:
                pageObj.buttnType = "btn-success"; pageObj.border = "green";
                break;
        }

        var hideTypes = "#PopupBodyConfirmMessageResponse #parentIcons span";
        $(hideTypes).css("display", "none").hide();

        var type = "#PopupBodyConfirmMessageResponse #parentIcons span#" + pageObj.type;
        $(type).css("display", "block").css("border-color", pageObj.border).show();

        var buttons = "#PopupBodyConfirmMessageResponse #btnConfirm button.btnOk";
        $(buttons).removeClass("btn-success btn-warning btn-danger").addClass(pageObj.buttnType).text(pageObj.buttonContinue);

        var btnCancel = "#PopupBodyConfirmMessageResponse #btnConfirm button.btnCancel";
        $(btnCancel).text(pageObj.buttonCancel);

        var popupOverlay = "#PopupOverlayMessage";
        var basePartialHolder = "#Home-Container #PopupBodyConfirmMessageResponse";

        var myTitle = "#Home-Container #PopupBodyConfirmMessageResponse #msgTitleId p.title";
        $(myTitle).empty().text(pageObj.title);

        var myMessage = "#Home-Container #PopupBodyConfirmMessageResponse #msgContextId p.message";
        $(myMessage).empty().text(pageObj.message);

        $(popupOverlay).css("display", "block").show();
        $(basePartialHolder).css("display", "block").show();

    }
    ,
    hideMessage: function () {
        var popupOverlay = "#PopupOverlayMessage";
        var basePartialHolder = "#Home-Container #PopupBodyMessageResponse";
        $(popupOverlay).css("display", "none").hide();
        $(basePartialHolder).css("display", "none").hide();
    }
    ,
    hideMessageConfirm: function () {
        var popupOverlay = "#PopupOverlayMessage";
        var basePartialHolder = "#Home-Container #PopupBodyConfirmMessageResponse";
        $(popupOverlay).css("display", "none").hide();
        $(basePartialHolder).css("display", "noe").hide();
    }
    ,
    hideMessageAppend: function () {
        var popupOverlay = "#PopupOverlayMessage";
        var basePartialHolder = "#Home-Container #PopupBodyMessageAppend";
        $(popupOverlay).css("display", "none").hide();
        $(basePartialHolder).css("display", "noe").hide();
    }
    ,
    objPage: {
        title: "Unsave Data",
        message: "Your Data Is not saved do you want to close",
        type: "warning",
        buttnType: "btn-success",
        border: "green",
        pageId: "popupBodyID"
    }
    ,
    autoClose: {
        button: "",
        time:""
    }
    ,
    pageObj: {}
    ,
    isCancel: function (isConfirm, msgObj, element) { }
    ,
    isContinue: function (isConfirm, msgObj, element) { }
    ,

    closeMessageResponse: function (_this) {

        var $thisButton = $(_this);
        var classList = $thisButton[0].className;
        var classNames = classList.split(" ");
        var hasOk = false;
        for (var i = 0; i < classNames.length; i++) {

            if (classNames[i] === "btnOk") {
                hasOk = true;
                break;
            }
        }

        if (hasOk === true) {
    
            var pageObj = classMessageResponse.pageObj;
            var popupBodyID = pageObj.pageId;

            $('#' + popupBodyID).css("display", "none");

            if (popupBodyID === "none") {
                $("#PopupOverlayMessage").hide();
                $("#Home-Container #PopupBodyMessageResponse").hide();
            }
            else {
          
            if (popupBodyID === "PopupBodyUserLogin") {
                $('#PopupOverlayLogIn').css("display", "none");
            }
            else if (popupBodyID === "PopupBodyChildOne") {
                $('#PopupOverlayChildOne').css("display", "none");
            }
            else if (popupBodyID === "PopupBodyChildTwo") {
                $('#PopupOverlayChildTwo').css("display", "none");
            }
            else if (popupBodyID === "PopupBodyChildThree") {
                $('#PopupOverlayChildThree').css("display", "none");
            }
            else if (popupBodyID === "PopupBodyChildChat") {
                $('#PopupOverlayChildChat').css("display", "none");
            }
            else {
                ;
            }

            $("#PopupOverlayMessage").hide();
                $("#Home-Container #PopupBodyConfirmMessageResponse").hide();
            }
        }
        else {
            $("#PopupOverlayMessage").hide();
            $("#Home-Container #PopupBodyConfirmMessageResponse").hide();
        }
    }
};

//var overrideClassMessageResponse = Object.create(classMessageResponse);

