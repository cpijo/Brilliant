
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
        this.popupChildBase("popupChildOne");
        //var page = deviceSize;
        //if (page.pageWidth < 900) {
        //    var width = page.pageWidth - 20;
        //    var avg = page.pageWidth / 2;

        //    $('#Home-Container #PartialContainer #popupChildOne').css({
        //        'width': width + 'px',
        //        'margin': '10px',
        //        'left': 'calc(50% - ' + avg + 'px)'
        //    });
        //    $('#Home-Container #PartialContainer #popupChildOne #partialHolder').css({
        //        'max-height': page.pageHeight + 'px',
        //        'overflow-y': 'auto'
        //    });
        //}
    }
    ,
    popupChildTwo: function () {
        this.popupChildBase("popupChildTwo");
        //var page = deviceSize;
        //if (page.pageWidth < 900) {
        //    var width = page.pageWidth - 20;
        //    var avg = page.pageWidth / 2;

        //    $('#Home-Container #PartialContainer #popupChildTwo').css({
        //        'width': width + 'px',
        //        'margin': '10px',
        //        'left': 'calc(50% - ' + avg + 'px)'
        //    });
        //    $('#Home-Container #PartialContainer #popupChildTwo #partialHolder').css({
        //        'max-height': page.pageHeight + 'px',
        //        'overflow-y': 'auto'
        //    });
        //}
    }
    ,
    popupChildThree: function () {
        this.popupChildBase("popupChildThree");
        //var page = deviceSize;
        //if (page.pageWidth < 900) {
        //    var width = page.pageWidth - 20;
        //    var avg = page.pageWidth / 2;

        //    $('#Home-Container #PartialContainer #popupChildThree').css({
        //        'width': width + 'px',
        //        'margin': '10px',
        //        'left': 'calc(50% - ' + avg + 'px)'
        //    });
        //    $('#Home-Container #PartialContainer #popupChildThree #partialHolder').css({
        //        'max-height': page.pageHeight + 'px',
        //        'overflow-y': 'auto'
        //    });
        //}
    }
    ,
    popupChildFour: function () {
        this.popupChildBase("popupChildFour");
        //var page = deviceSize;
        //if (page.pageWidth < 900) {
        //    var width = page.pageWidth - 20;
        //    var avg = page.pageWidth / 2;

        //    $('#Home-Container #PartialContainer #popupChildFour').css({
        //        'width': width + 'px',
        //        'margin': '10px',
        //        'left': 'calc(50% - ' + avg + 'px)'
        //    });
        //    $('#Home-Container #PartialContainer #popupChildFour #partialHolder').css({
        //        'max-height': page.pageHeight + 'px',
        //        'overflow-y': 'auto'
        //    });
        //}
    }
};
