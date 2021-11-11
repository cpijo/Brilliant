
(function () {
    if (deviceSize.width < 620) {
        $.ajax({
            url: "DeviceMenu/MobileMenu/",
            type: "POST",
            datatype: 'application/json',
            data: { par1: "1", par2: "2" }, 
            processData: true,
            cache: false,
            success: function (response) {
                $("#layout-page #popupMenuId").empty().html(response);
                $("#layout-page #menuHolderId").empty().css("display", "none");
            }
            ,
            error: function (data) {
                classBusyIconHelper.hideBusyIcon();
                var msgObj = { message: "error", type: "error", title: "error", pageId: "" };
                classMessageResponse.showMessage(msgObj);
            }
        });
    }
    else {
        $.ajax({
            url: "DeviceMenu/DesktopMenu/",
            type: "POST",
            datatype: 'application/json',
            data: { par1: "1", par2: "2" },
            processData: true,
            cache: false,
            success: function (response) {
                $("#layout-page #menuHolderId").empty().html(response);
                $("#layout-page #popupMenuId").empty().css("display", "none");
            }
            ,
            error: function (response) {
                classBusyIconHelper.hideBusyIcon();
                var msgObj = { message: "error", type: "error", title: "error", pageId: "" };
                classMessageResponse.showMessage(msgObj);
            }
        });
    }

})();
