
var classIndexPage = {

    hasMedatoryScrean : function (pageId, popupBodyID) {

        var validatePageList = classConstants.validatePageList;

        for (var i = 0; i < validatePageList.length; i++) {

            var _pageId = validatePageList[i];
            if (pageId === _pageId) {

                classIndexPage.closeConfirmation(pageId, popupBodyID);
                return { pageId: pageId, hasScrean: true };
            }
        }

        return { pageId: pageId, hasScrean: false };
    }
    ,
    closeConfirmation: function (pageId, popupBodyID) {

        switch (pageId) {

            case "registerEmailVerify-page":
                classMessageResponse.messageConfirmation({ title: "Your data is not saved", message: "If you close you will loose it, do you want to close", type: "warning", pageId: popupBodyID ,sender:"popup"});
                break;
            case "register-page":
                classMessageResponse.messageConfirmation({ title: "Your data is not saved", message: "If you close you will loose it, do you want to close", type: "warning", pageId: popupBodyID, sender: "popup" });
                break;
            case "uploadImage-page":
                classMessageResponse.messageConfirmation({ title: "Your data is not saved", message: "If you close you will loose it, do you want to close", type: "warning", pageId: popupBodyID, sender: "popup" });
                break;
            case "editPicture-page":
                classMessageResponse.messageConfirmation({ title: "Your data is not saved", message: "If you close you will loose it, do you want to close", type: "warning", pageId: popupBodyID, sender: "popup" });
                break;
            default:
                classMessageResponse.messageConfirmation({ title: "Change Profile Picture", message: "Update Profile Picture", type: "warning", pageId: popupBodyID, sender: "popup" });
                break;
        }
    }
    ,
    closePopup: function (_this) {
        /*event.preventDefault();*/
        var closeThisPage = false;
        var pageId = $(_this).siblings("#partialHolder").children('div').attr("id");
        var popupBodyID = $(_this).parent('div').parent('div .childBodyPage').attr('id');
        var partialHolderId = $(_this).siblings('div .partialHolder').attr('id');

        closeThisPage = classIndexPage.hasMedatoryScrean(pageId, popupBodyID).hasScrean;

        if (closeThisPage === false) {
            //$('#' + partialHolderId).empty();
            $('#' + popupBodyID).css("display", "none");
            if (popupBodyID === "PopupBodyUserLogin") {
                $('#PopupOverlayLogIn').css("display", "none");
            }
            if (popupBodyID === "PopupBodyChildOne") {
                $('#PopupOverlayChildOne').css("display", "none");
            }
            else if (popupBodyID === "PopupBodyChildTwo") {
                $('#PopupOverlayChildTwo').css("display", "none");
                $('#PopupBodyChildTwo .divHeader').css({ "background-color": "rgb(59, 90, 108)" });
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
        }
    }
    ,
     onDocumentReady: function () {

         document.oncontextmenu = document.body.oncontextmenu = function () { return false; };

         //classEditPhoto.imgeList0 = Object.create(classEditPhoto._imgeList0);

         //classEditPhoto.imgeList0.top = 200;
         //classEditPhoto.imgeList0.left = 400;

         //classEditPhoto.imgeObjList0.push(classEditPhoto.imgeList0);
         //classEditPhoto.imgeObjList0.push(classEditPhoto.imgeList0);

         // Self-invoking functions
         (function callingGallery(url) {

             //debugger;
             var pageSizeObject = classPageSize.pageSizeGallery();
             var jsonStringPageSize = JSON.stringify(pageSizeObject);
             var formdata = new FormData();
             formdata.append('jsonStringPageSize', jsonStringPageSize);
             url = "/Home/GetGallery";

             classBusyIconHelper.showBusyIcon();

             var header = 'Gauteng Girls';
             var objPopup = classPageConstant.galleryPage;
             
             var pageObj = { function: "menu", url: url, type: "Get", data: formdata, header: header, pageId: "" };
             classControllerHelper.callController(pageObj);  

         }());
    }
};



