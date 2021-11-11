
var classBusyIconHelper = {

    setPageSize: function () {
        var page = deviceSize;
        if (page.width < 400) {
            var width = page.pageWidth - 20;
            var avg = page.pageWidth / 2;
            // width: 360px;
            //$('#Home-Container #PartialContainer #PopupBodyBusyIcon').css({
            //    'width': width + 'px',
            //    'margin': '10px',
            //    'left': 'calc(50% - ' + avg + 'px)'
            //});
        }
    }
    ,
    showBusyIcon: function () {
        $("#layoutBodyId #PopupOverlayBusyIcon").show();
        $("#Home-Container #PopupBodyBusyIcon").show();
    },
    hideBusyIcon: function () {
        $("#layoutBodyId #PopupOverlayBusyIcon").hide();
        $("#Home-Container #PopupBodyBusyIcon").hide();
    }
};

