
var classControllerHelper = {

    me: this,
    urlSimple: function (url) {
        //  url = '/ViewEscort/GetGalleryPage/?page=1020';
        //  url = '/ViewEscort/GetGalleryPage/?page=1020&page2=2020&page3=3030';
        //  url = '/ViewEscort/GetGalleryPage/?key1=1020&key2=2020&key3=3030';
        //http://www.youtube.com/watch?v=x3PSh13ELIk
        //http://localhost:8080/xwiki/bin/view/Sandbox/WebHome?transformations=macro
        var _url = url.split('?');
        var params = _url.split('$');
        for (var i = 0; i < params.length; i++) {
            if (params[i].indexOf(key + '=') < 0 && params[i] !== '') {
                newParams.push(params[i]);
            }
        }

        function insertParamsToURL(key, value) {
            var selectedName = value,
                url = window.location.pathname,
                params = window.location.search.replace('?', '').split('&'),
                newParams = [];

            for (var i = 0; i < params.length; i++) {
                if (params[i].indexOf(key + '=') < 0 && params[i] !== '') {
                    newParams.push(params[i]);
                }
            }

            url += '?' + key + '=' + selectedName + (newParams.length > 0 ? '&' + newParams.join('&') : '');
            window.history.replaceState(null, null, url);
        }

    }
    ,
    urlHelper: function (url) {
        var str = url.substring(1);
        var pos = str.indexOf('/');
        var hasQuestionMark = str.indexOf('?');
        var getController = '';
        var getAction = '';
        var urlScope = '';
        var newUrl = '';

        if (hasQuestionMark === -1) {
            //newUrl = "/Home/GetGallery"
            getController = str.substring(0, pos);
            getAction = str.substring(pos + 1);
            urlScope = '@Url.Action("actionHolder","controllerHolder")';//Inside View
            urlScope = '/controllerHolder/actionHolder';

            newUrl = urlScope.replace("actionHolder", getAction).replace("controllerHolder", getController);
            //newUrl = "@Url.Action(\"GetGallery\",\"Home\")"
        }
        else {
            //  url = '/ViewEscort/GetGalleryPage/?page=1020';
            var pos2 = str.indexOf('?');
            var _pos2 = pos2 - 1;
            var str_Controller = str.substring(0, _pos2);
            pos = str_Controller.indexOf('/');

            getController = str_Controller.substring(0, pos);
            getAction = str_Controller.substring(pos + 1);
            var getVariableParamenter = str.substring(pos2 + 1);
            var pos3 = getVariableParamenter.indexOf('=');
            var variableName = getVariableParamenter.substring(0, pos3);
            var variableValue = getVariableParamenter.substring(pos3 + 1);

            urlScope = '@Url.Action("actionHolder","controllerHolder", new {parameterName = "parameterValue"})';//Inside View
            urlScope = '/controllerHolder/actionHolder/?parameterName=parameterValue';

            newUrl = urlScope.replace("actionHolder", getAction)
                .replace("controllerHolder", getController)
                .replace("parameterName", variableName)
                .replace("parameterValue", variableValue);
        }
        return newUrl;
    }
    ,
    callController: function (pageObj) {
       
        var url = classControllerHelper.urlHelper(pageObj.url);
        classBusyIconHelper.showBusyIcon();

        $.ajax({
            url: url,
            type: pageObj.type,
            contentType: 'application/json',
            datatype: 'application/json',
            processData: false,
            data: JSON.stringify(pageObj.data),//JSON.stringify({ s1: "000", s2: "111" }),
            cache: false,
            async: true,
            success: function (response) {
                switch (pageObj.function) {

                    case "message":
                        classControllerHelper.getMessage(response, pageObj);
                        break;
                    case "redirectToAction":
                        classControllerHelper.redirectToAction(response);
                        break;
                    case "returnValue":
                        classControllerHelper.returnValue(response);
                        break;
                    case "menu":
                        classControllerHelper.menuPage(response);
                        break;
                    case "popup":
                        classControllerHelper.returnChildPopup(response, pageObj.objPopup, pageObj.header);
                        break;
                    case "append":
                        classControllerHelper.appendPartial(response, pageObj);
                        break;
                    case "partial":
                        classControllerHelper.getPartialHolder(url, formdata, type, PartialHolder);
                        break;
                    case "appendRefresh":
                        me.getPartialHolderAndRefresh(url, formdata, type, PartialHolder);
                        pageObj.buttnType = "btn-danger"; pageObj.border = "red";
                        break;
                    default:
                        pageObj.buttnType = "btn-success"; pageObj.border = "green";
                        break;
                }
            },
            error: function (data) {
                classBusyIconHelper.hideBusyIcon();
                var msgObj = { message: "error ajax", type: "error", title: "error ajax", pageId: "" };
                classMessageResponse.showMessage(msgObj);
                //window.location.href = '/ApplicatioSession/ReloadWebsiteWithUserHistory/?jsonString=' + rememberUser;
            }
        });
    }
    ,
    callControllerReturn: function (pageObj) {
        var url = classControllerHelper.urlHelper(pageObj.url);
        classBusyIconHelper.showBusyIcon();
        $.ajax({
            url: url,
            type: pageObj.type,
            contentType: false,
            processData: false,
            data: pageObj.data,
            datatype: 'application/json',
            cache: false,
            success: function (response) {
                if (response.result === "true") {

                    var imageCrop = new Image();
                    imageCrop.src = response.imageDataURL;
                    var c = document.getElementById("imageEmoji");
                    var ctx = c.getContext("2d");
                    //ctx.canvas.width = 300;
                    //ctx.canvas.height = 300;
                    //ctx.drawImage(imageCrop, 0, 0);

                    classBusyIconHelper.hideBusyIcon();
                }
            },
            error: function (data) {
                classBusyIconHelper.hideBusyIcon();
                var msgObj = { message: "error ajax", type: "error", title: "error ajax", pageId: "" };
                classMessageResponse.showMessage(msgObj);
            }
        });
    }
    ,
    menuPage: function (response) {

        if (response.result === "false") {

            classBusyIconHelper.hideBusyIcon();
            var msgObj = { message: response.message, type: "error", title: response.title, pageId: "" };
            classMessageResponse.showMessage(msgObj);
        }
        else {


            var objPopup = classPageConstant.galleryPage;
            var basePartialHolder = objPopup.basePartialHolder;
            var partialHolder = objPopup.partialHolder;
            var divHeader = objPopup.divHeader;
            var button = objPopup.button;
            //$(divHeader).empty().text(header);
            $(partialHolder).empty().html(response);
            $(button).css("display", "block").show();
            $(basePartialHolder).css("display", "block").show();
            classBusyIconHelper.hideBusyIcon();


            //$("#Home-Container #PopupBodyChildOne #btnCloseGeneric").trigger("click");
            //$('#PopupOverlayChildOne').css("display", "none");
            //$("#Home-Container #PopupBodyChildOne").css("display", "none");

            //debugger;
            //var pop1 = classPageConstant.popupChildOne;

            //if ($(pop1).css("display") == "block") {
            //    $('#PopupOverlayChildOne').css("display", "none");
            //    $(pop1).css("display", "none");

           // } else {
            //    $('#PopupOverlayChildOne').css("display", "none");
           //     $(pop1).css("display", "none");
            //}
        }

    }
    ,
    returnChildPopup: function (response, objPopup, header) {

        if (response.result === "false") {
            classBusyIconHelper.hideBusyIcon();
            msgObj = { message: response.message, type: "error", title: response.title, pageId: "" };
            classMessageResponse.showMessage(msgObj);

        }
        else if (response.result === "reloadApp") {
            //debugger
            // Session["requestAction"] = new { controller = controller, action = action, task = task, reload = reload, login = login };

            var obj = {
                controller: response.controller,
                action: response.action,
                task: response.task,
                reload: response.reload,
                login: response.login
            };

            var con = "\"controller\":" + "\"" + response.controller + "\"";
            var act = "\"action\":" + "\"" + response.action + "\"";
            var tsk = "\"task\":" + "\"" + response.task + "\"";
            var rel = "\"reload\":" + "\"" + response.reload + "\"";
            var myOwnjsonString = con + "," + act + "," + tsk + "," + rel;



            var con1 = "controller:" + "" + response.controller + "";
            var act1 = "action:" + "" + response.action + "";
            var tsk1 = "task:" + "" + response.task + "";
            var rel1 = "reload:" + "" + response.reload + "";
            var myOwnjsonString1 = "{" + con1 + "," + act1 + "," + tsk1 + "," + rel1 + "}";

            var jsonString = JSON.stringify(obj);
            var url = "/{0}/{1}";
            url = url.replace("{0}", response.controller).replace("{1}", response.action);
            //url = url + '/?jsonString=' + jsonString;
            //url = url + '/?jsonString=' + { "controller": "Home", "action": "Index", "task": "reloadApp", "reload": "yes" };
            //url = "/Home/Index/?jsonString={\"controller\":\"Home\",\"action\":\"Index\",\"task\":\"reloadApp\",\"reload\":\"yes\"}";
            //url = http://localhost:52278/Home/Index/?jsonString={"controller":"Home","action":"Index","task":"reloadApp","reload":"yes"}
            //window.location.href = url;
            var data = obj;
            $.get(url, data, function (result) {
                //var id = '#postedFor' + postId;
                classBusyIconHelper.hideBusyIcon();
            });
        }
        else {
            //debugger;            

            classBusyIconHelper.hideBusyIcon();

            var popupOverlayLayout = objPopup.popupOverlayLayout;
            var basePartialHolder = objPopup.basePartialHolder;
            var partialHolder = objPopup.partialHolder;
            var divHeader = objPopup.divHeader;

            $(divHeader).empty().text(header);
            $(partialHolder).empty().html(response);
            $(popupOverlayLayout).css("display", "block").show();
            $(basePartialHolder).css("display", "block").show();

        }
    }
    ,
    appendPartial: function (response, pageObj) {      

        var divHeader = pageObj.data.divHeader;
        if (divHeader!==undefined) {
             $(divHeader).empty().text(pageObj.header);
        }

        $(pageObj.partialHolder).empty().html(response);
        classBusyIconHelper.hideBusyIcon();
    }
    ,
    getMessage: function (response, pageObj) {
        //debugger;
        var msgObj = "";
        var popupBodyID = "";
        var pageIds = "";
        if (response.result === "true") {
            classBusyIconHelper.hideBusyIcon();

            msgObj = { message: response.message, type: "success", title: response.title, pageId: "" };
            classMessageResponse.showMessage(msgObj);

            if (pageObj.closePage !== undefined) {
                    popupBodyID = "";
                    pageIds = pageObj.closePage.pageId;
                for (var i = 0; i < pageIds.length; i++) {
                    popupBodyID = pageIds[i];
                    $('#' + popupBodyID + " #partialHolder").empty();
                    $('#' + popupBodyID).css("display", "none");

                    if (popupBodyID === "PopupBodyChildOne") {
                        $('#PopupOverlayChildOne').css("display", "none");
                    }
                    else if (popupBodyID === "PopupBodyChildTwo") {
                        $('#PopupOverlayChildTwo').css("display", "none");
                    }
                    else if (popupBodyID === "PopupBodyChildThree") {
                        $('#PopupOverlayChildThree').css("display", "none");
                    }
                }
            }
        }
        else if (response.result === "isTrueAppend") {
            classBusyIconHelper.hideBusyIcon();


            msgObj = { message: response.message, type: "success", title: response.title, pageId: "" };
            classMessageResponse.showMessageAppend(msgObj);


            if (pageObj.closePage !== undefined) {
                    popupBodyID = "";
                    pageIds = pageObj.closePage.pageId;
                for (var j = 0; j < pageIds.length; j++) {
                    popupBodyID = pageIds[j];
                    $('#' + popupBodyID + " #partialHolder").empty();
                    $('#' + popupBodyID).css("display", "none");

                    if (popupBodyID === "PopupBodyChildOne") {
                        $('#PopupOverlayChildOne').css("display", "none");
                    }
                    else if (popupBodyID === "PopupBodyChildTwo") {
                        $('#PopupOverlayChildTwo').css("display", "none");
                    }
                    else if (popupBodyID === "PopupBodyChildThree") {
                        $('#PopupOverlayChildThree').css("display", "none");
                    }
                }
            }
        }
        else if (response.result === "warning") {
            classBusyIconHelper.hideBusyIcon();
            msgObj = { message: response.message, type: "warning", title: response.title, pageId: "" };
            classMessageResponse.showMessage(msgObj);
        }
        else {
            classBusyIconHelper.hideBusyIcon();
            msgObj = { message: response.message, type: "error", title: response.title, pageId: "" };
            classMessageResponse.showMessage(msgObj);
        }
    }
    ,
    redirectToAction: function (response) {

        var msgObj = "";
        if (response.result === "true") {

            classBusyIconHelper.hideBusyIcon();

            msgObj = { message: response.message, type: "success", title: response.title, pageId: "" };
            classMessageResponse.showMessage(msgObj);

            var picWidth = 420;//446;
            var picHeigt = 250;
            var gridClass = "col-xs-6";
            var pageSize = classPageSize.pageSizeInfor();
            if (deviceSize.width < 700) {
                classMenuHelper.closeOn();
                picWidth = pageSize.width - 8 - 20;//-20 for scroll bar
                picHeigt = 310;
                gridClass = "col-xs-6";
            }
            var data = {
                'pageSize': pageSize,
                'jsonImageSize': JSON.stringify({ width: picWidth, height: picHeigt, gridClass: gridClass })
            };

            var url = response.url;
            var header = response.header;
            var objPopup = classPageConstant.popupChildOne;
            var pageObj = { function: "popup", url: url, data: data, header: header, pageId: "", objPopup: objPopup };
            classControllerHelper.callController(pageObj);

        }
        else {
            classBusyIconHelper.hideBusyIcon();
            msgObj = { message: response.message, type: "error", title: response.title, pageId: "" };
            classMessageResponse.showMessage(msgObj);
        }
    }
    ,
    returnValue: function (response) {

        var msgObj = "";
        if (response.result === "true") {

            classBusyIconHelper.hideBusyIcon();
            return response;

        }
        else {
            classBusyIconHelper.hideBusyIcon();
            msgObj = { message: response.message, type: "error", title: response.title, pageId: "" };
            classMessageResponse.showMessage(msgObj);
        }
    }
    ,
    appendAddRefresh: function (response, PartialHolder) {
        //NOT WORKING
        $(PartialHolder).empty().html(response);
        $.ajax({
            url: url,
            type: pageObj.type,
            contentType: false,
            processData: false,
            data: pageObj.data,
            datatype: 'application/json',
            cache: false,
            success: function (response) {

                switch (pageObj.function) {

                    case "massege":
                        classControllerHelper.getMessage(response);
                        break;
                    case "menu":
                        classControllerHelper.menuPage(response);
                        break;
                    default:
                        pageObj.buttnType = "btn-success"; pageObj.border = "green";
                        break;
                }
            },
            error: function (data) {
                classBusyIconHelper.hideBusyIcon();
                var msgObj = { message: "error", type: "error", title: "error", pageId: "" };
                classMessageResponse.showMessage(msgObj);
            }
        });
    }
    ,
    closeOpenedPopup: function (pageObj) {

        if (pageObj.closePage !== undefined) {
            var popupBodyID = "";
            var pageIds = pageObj.closePage.pageId;
            for (var i = 0; i < pageIds.length; i++) {
                popupBodyID = pageIds[i];
                $('#' + popupBodyID + " #partialHolder").empty();
                $('#' + popupBodyID).css("display", "none");

                if (popupBodyID === "PopupBodyChildOne") {
                    $('#PopupOverlayChildOne').css("display", "none");
                }
                else if (popupBodyID === "PopupBodyChildTwo") {
                    $('#PopupOverlayChildTwo').css("display", "none");
                }
                else if (popupBodyID === "PopupBodyChildThree") {
                    $('#PopupOverlayChildThree').css("display", "none");
                }
            }
        }
    }
};

