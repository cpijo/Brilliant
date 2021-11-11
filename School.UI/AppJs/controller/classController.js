
var classController = {

    controllerByFormdata: function (pageObj) {
       
        var url = classControllerHelper.urlHelper(pageObj.url);
        //classBusyIconHelper.showBusyIcon();
        url = '/StudentAttendance/Save';
        $.ajax({
            url: url,
            type: "POST",
            contentType: false,
            processData: false,
            data: pageObj.data,
            datatype: 'application/json',
            cache: false,






            //url: url,
            //type: pageObj.type,
            //contentType: 'application/json',
            //datatype: 'application/json',
            //processData: false,
            //data: pageObj.data,
            //cache: false,
            //async: true,
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
                        classControllerHelper.appendPartial(response, pageObj.partialHolder);
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
    controllerByParameter: function (pageObj) {

        var parent = { "parent": [{ "Name": "User1", "Number": "101" }, { "Name": "User2", "Number": "102" }, { "Name": "User3", "Number": "103" }] }
        var teacher = {
            DateOfAttendance: '5555',
            attandance: '7899',
            Grade: '55',
            SubjectName: '4567'
        }; 

        var url = '/StudentAttendance/Save';
        url = url + "?teacher=" + JSON.stringify(teacher) + "&parent=" + JSON.stringify(parent),


         url = classControllerHelper.urlHelper(pageObj.url);
        classBusyIconHelper.showBusyIcon();
        //url: url + "?portfolioId=" + pfid + "&data=" + JSON.stringify(Extension),
        //{link}?value1&field2=value2&field3=value3...
        var dictionary = pageObj.data;
        for (var i = 0; i < dictionary.length; i++) {

            if (i===0) {
                url = url + "?" + dictionary[i].key +"="+ dictionary[i].value;
                //pageObj.dictionary[i].key = dictionary[i].value;
            }
            else {
                //url = url + "&" + dictionary[i].key + "=" + dictionary[i].value;
            }
        }
        var _newurl = url;

        $.ajax({
            url: url,
            type: pageObj.type,
            contentType: 'application/json',
            datatype: 'application/json',
            processData: false,
            //data: pageObj.data,
            data: JSON.stringify({ s1: "000", s2: "111" }),
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
                        classControllerHelper.appendPartial(response, pageObj.partialHolder);
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
    controllerByFromBody: function (pageObj) {

        var url = classControllerHelper.urlHelper(pageObj.url);
        classBusyIconHelper.showBusyIcon();
        //url: url + "?portfolioId=" + pfid + "&data=" + JSON.stringify(Extension),
        //{link}?value1&field2=value2&field3=value3...
        var dictionary = pageObj.data;
        for (var i = 0; i < dictionary.lenght; i++) {

            if (i === 0) {
                url = url + "?" + dictionary[i].key + "=" + dictionary[i].value;
                //pageObj.dictionary[i].key = pageObj.dictionary[i].value;
            }
            else {
                url = url + "&" + dictionary[i].key + "=" + dictionary[i].value;
            }
        }
        var _newurl = url;
        var request = { name: "John", age: 31, city: "New York" };
        $.ajax({
            url: url,
            type: pageObj.type,
            contentType: 'application/json',
            datatype: 'application/json',
            processData: false,
            data: JSON.stringify(request),
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
                        classControllerHelper.appendPartial(response, pageObj.partialHolder);
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
};

