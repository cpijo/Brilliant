
var classChildPageSize = {

    popupChildBase: function (PopupBodyPage) {
        var page = deviceSize;
        if (page.pageWidth < 900) {
            var width = page.pageWidth - 20;
            var avg = page.pageWidth / 2;

            $('#Home-Container #PartialContainer #' + PopupBodyPage).css({
                'width': width + 'px',
                'margin': '10px',
                'left': 'calc(50% - ' + avg + 'px)'
            });
            $('#Home-Container #PartialContainer #' + PopupBodyPage+' #partialHolder').css({
                'max-height': page.pageHeight + 'px',
                'overflow-y': 'auto'
            });
        }
    }
    ,
    popupChildLogin: function () {
        var page = deviceSize;
        if (page.pageWidth < 500) {
            var width = page.pageWidth - 20;
            var avg = page.pageWidth / 2;

            $('#Home-Container #PartialContainer #PopupBodyUserLogin').css({
                'width': width + 'px',
                'margin': '10px',
                'left': 'calc(50% - ' + avg + 'px)'
            });
            $('#Home-Container #PartialContainer #PopupBodyUserLogin #partialHolder').css({
                'max-height': page.pageHeight + 'px',
                'overflow-y': 'auto'
            });
        }
    },

    popupChildOne: function () {
        this.popupChildBase("PopupBodyChildOne");
        //var page = deviceSize;
        //if (page.pageWidth < 900) {
        //    var width = page.pageWidth - 20;
        //    var avg = page.pageWidth / 2;

        //    $('#Home-Container #PartialContainer #PopupBodyChildOne').css({
        //        'width': width + 'px',
        //        'margin': '10px',
        //        'left': 'calc(50% - ' + avg + 'px)'
        //    });
        //    $('#Home-Container #PartialContainer #PopupBodyChildOne #partialHolder').css({
        //        'max-height': page.pageHeight + 'px',
        //        'overflow-y': 'auto'
        //    });
        //}
    }
    ,
    popupChildTwo: function () {
        this.popupChildBase("PopupBodyChildTwo");
        //var page = deviceSize;
        //if (page.pageWidth < 900) {
        //    var width = page.pageWidth - 20;
        //    var avg = page.pageWidth / 2;

        //    $('#Home-Container #PartialContainer #PopupBodyChildTwo').css({
        //        'width': width + 'px',
        //        'margin': '10px',
        //        'left': 'calc(50% - ' + avg + 'px)'
        //    });
        //    $('#Home-Container #PartialContainer #PopupBodyChildTwo #partialHolder').css({
        //        'max-height': page.pageHeight + 'px',
        //        'overflow-y': 'auto'
        //    });
        //}
    }
    ,
    popupChildThree: function () {
        this.popupChildBase("PopupBodyChildThree");
        //var page = deviceSize;
        //if (page.pageWidth < 900) {
        //    var width = page.pageWidth - 20;
        //    var avg = page.pageWidth / 2;

        //    $('#Home-Container #PartialContainer #PopupBodyChildThree').css({
        //        'width': width + 'px',
        //        'margin': '10px',
        //        'left': 'calc(50% - ' + avg + 'px)'
        //    });
        //    $('#Home-Container #PartialContainer #PopupBodyChildThree #partialHolder').css({
        //        'max-height': page.pageHeight + 'px',
        //        'overflow-y': 'auto'
        //    });
        //}
    }
    ,
    popupChildFour: function () {
        this.popupChildBase("PopupBodyChildFour");
        //var page = deviceSize;
        //if (page.pageWidth < 900) {
        //    var width = page.pageWidth - 20;
        //    var avg = page.pageWidth / 2;

        //    $('#Home-Container #PartialContainer #PopupBodyChildFour').css({
        //        'width': width + 'px',
        //        'margin': '10px',
        //        'left': 'calc(50% - ' + avg + 'px)'
        //    });
        //    $('#Home-Container #PartialContainer #PopupBodyChildFour #partialHolder').css({
        //        'max-height': page.pageHeight + 'px',
        //        'overflow-y': 'auto'
        //    });
        //}
    }
};
