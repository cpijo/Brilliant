
var classPageSize = {

    pageSizeGallery: function () {

        var colHeight = 0,
            className = 0,
            columWidth = 0,
            average = 0,
            menuSize = 250,
            _average = 0,
            avg = 0,
            device = deviceSize,
            width = device.width,
            height = device.height,
            pageHeight = device.pageHeight;   //height - 110,//total is 130 of 90+20

        //REMOVE THIS
        //width = 760;= 620;= 359;
        if (width > 768) {

            className = "col-xs-3";
            colHeight = 235;

            average = width / 4;
            columWidth = average;
            _average = "" + average;
            if (_average.indexOf('.') !== -1) {
                avg = _average.split(".");
                columWidth = avg[0];
            }

        }
        else {
            //Close Menu
            classMenuHelper.closeMenu(width);
            menuSize = 0;
            if (width === 620 || width > 620) {

                className = "col-xs-3";
                width = width - 24;
                average = width / 4;
                innerPage = width - 250;

                if (pageHeight > 606) {
                    colHeight = 200;
                }
                else {
                    colHeight = 145;
                }
            }
            else if (width < 620) {

                if (width === 360 || width > 360) {

                    className = "col-xs-4";
                    className = "col-xs-6";
                    width = width - 24;
                    average = width / 3;
                    if (pageHeight > 516) {
                        colHeight = 160;
                    }
                    else {
                        colHeight = 135;
                    }
                }
                else if (width < 360) {

                    if (width === 300 || width > 300) {

                        className = "col-xs-4";
                        className = "col-xs-6";
                        width = width - 24;
                        average = width / 2;

                        innerPage = width - 0;
                        if (pageHeight > 516) {
                            colHeight = 135;
                        }
                        else {
                            colHeight = 135;
                            className = "col-xs-6";
                        }
                    }
                    else {
                        className = "col-xs-6";
                        width = width - 24;
                        average = width / 2;
                        innerPage = width - 0;
                        colHeight = 100;
                    }
                }
            }

            columWidth = average;
            colHeight = average;
            _average = "" + average;
            if (_average.indexOf('.') !== -1) {
                avg = _average.split(".");
                columWidth = avg[0];
                colHeight = columWidth;
            }
        }

        var pageSizeObject = {
            pageHeight: pageHeight,
            pageWidth: width,
            className: className,
            columHeight: colHeight,
            columWidth: columWidth,
            menuSize: menuSize
        };

        return pageSizeObject;
    }
    ,
    pageSize: function () {

        var colHeight = 0,
            className = 0,
            columWidth = 0,
            average = 0,
            _average = 0,
            avg = 0,
            device = deviceSize,
            width = device.width,
            height = device.height,
            pageHeight = device.pageHeight;   //height - 110,//total is 130 of 90+20    
        //width = 760;= 620;= 359;
        if (width > 768) {

            if (width > 920) {
                width = 900;
            }
            else {
                width = width - 24;
            }
            className = "col-xs-8 , col-xs-4";
            colHeight = 235;
            average = width / 3; // = col-xs-4
            columWidth = average;
            _average = "" + average;
            //removing dot after number
            if (_average.indexOf('.') !== -1) {
                avg = _average.split(".");
                columWidth = avg[0];
                //to get size of col-xs-8
                columWidth = columWidth * 2;
            }
        }
        else {
            //Close Menu
            classMenuHelper.closeMenu(width);

            if (width === 620 || width > 620) {

                className = "col-xs-12";
                width = width - 24;
                average = width / 1;

                if (pageHeight > 606) {
                    colHeight = 200;
                }
                else {
                    colHeight = 145;
                }
            }
            else if (width < 620) {

                if (width === 360 || width > 360) {

                    className = "col-xs-12";
                    width = width - 24;
                    average = width / 1;

                    innerPage = width - 0;

                    if (pageHeight > 516) {
                        colHeight = 160;
                    }
                    else {
                        colHeight = 135;
                    }
                }
                if (width < 360) {

                    if (width === 300 || width > 300) {

                        className = "col-xs-12";
                        width = width - 24;
                        average = width / 1;

                        if (pageHeight > 516) {
                            colHeight = 135;
                        }
                        else {
                            colHeight = 135;
                        }
                    }
                    else {
                        className = "col-xs-12";
                        width = width - 24;
                        average = width / 1;
                        colHeight = 100;
                    }
                }
            }

            columWidth = average;
            colHeight = average;
            _average = "" + average;
            if (_average.indexOf('.') !== -1) {
                avg = _average.split(".");
                columWidth = avg[0];
                colHeight = columWidth;
            }

        }

        var pageSizeObject = {
            pageHeight: pageHeight,
            pageWidth: width,
            className: className,
            columHeight: colHeight,
            columWidth: columWidth,
            openMenu: "no"
        };
        return pageSizeObject;
    }
    ,
    pageSizeInfor: function () {
        var colHeight = 0,
            className = 0,
            columWidth = 0,
            average = 0,
            _average = 0,
            avg = 0,
            device = deviceSize,
            width = device.width,
            pageHeight = device.pageHeight;

        if (width > 768) {

            if (width > 920) {
                width = 900;
            }
            else {
                width = width - 30;
            }
            className = "col-xs-6";
            colHeight = 235;

            average = width / 2; // = col-xs-4
            columWidth = average;
            _average = "" + average;
            //removing dot after number
            if (_average.indexOf('.') !== -1) {
                avg = _average.split(".");
                columWidth = avg[0];
            }
        }
        else {

            //Close Menu
            classMenuHelper.closeMenu(width);

            if (width === 620 || width > 620) {

                className = "col-xs-12";
                width = width - 30;
                average = width / 1;

                if (pageHeight > 606) {
                    colHeight = 200;
                }
                else {
                    colHeight = 145;
                }
            }
            else if (width < 620) {

                if (width === 360 || width > 360) {

                    className = "col-xs-12";
                    width = width - 30;
                    average = width / 1;

                    if (pageHeight > 516) {
                        colHeight = 160;
                    }
                    else {
                        colHeight = 135;
                    }
                }
                else if (width < 360) {

                    if (width === 300 || width > 300) {

                        className = "col-xs-12";
                        width = width - 30;
                        average = width / 1;

                        if (pageHeight > 516) {
                            colHeight = 135;
                        }
                        else {
                            colHeight = 135;
                        }
                    }
                    else {
                        className = "col-xs-12";
                        width = width - 30;
                        average = width / 1;

                        colHeight = 100;
                    }
                }
            }

            columWidth = average;
            _average = "" + average;
            if (_average.indexOf('.') !== -1) {
                avg = _average.split(".");
                columWidth = avg[0];
                colHeight = columWidth;
            }

        }

        var pageSizeObject = {
            pageHeight: pageHeight,
            pageWidth: width,
            className: className,
            columHeight: colHeight,
            columWidth: columWidth,
            openMenu: "no",
            menuSize: 250
        };
        return pageSizeObject;
    }
    ,
    pageSizeCommon: function () {

        var columHeight = 0,
            className = 0,
            columWidth = 0,
            device = deviceSize,
            width = device.width,
            height = device.height,
            pageHeight = device.pageHeight;

        //if (width > 768) {} else {}

        if (width > 920) {
            width = 900;
        }
        else {
            width = width - 24;
        }
        className = "col-xs-12";
        columWidth = width;
        columHeight = pageHeight - 84 - 24;

        var pageSizeObject = {
            pageHeight: pageHeight,
            pageWidth: width,
            className: className,
            columHeight: columHeight,
            columWidth: columWidth,
            openMenu: "no",
            menuSize: 0
        };
        return pageSizeObject;
    }
    ,
    pageSizeImageSlider: function () {
        var pageSizeObject = classPageSize.pageSizeCommon();
        return pageSizeObject;
    }
    ,
    pageSizeUserService: function () {
        var pageSizeObject = classPageSize.pageSizeCommon();
        return pageSizeObject;
    }
    ,
    pageSizeRegister: function () {
        var pageSizeObject = classPageSize.pageSizeCommon();
        return pageSizeObject;
    }
    ,
    getPageSize: function () {
        //var pageSize = JSON.stringify(classPageSize.pageSize());
        var bigImage = JSON.stringify(classImageResizer.bigImageSize());
        var smallImage = JSON.stringify(classImageResizer.smallImageSize());

        var formdata = new FormData();
        //formdata.append('jsonStringPageSize', pageSize);
        formdata.append('jsonStringBigImageSize', bigImage);
        formdata.append('jsonStringSmallImageSize', smallImage);

        var pageObj = {
            pageSize: pageSize,
            bigImage: bigImage,
            smallImage: smallImage,
            formdata: formdata
        };
        return pageObj;
    }
    ,
    pageSizeGallery_Scope: function () {

        var page = {
            name: "gallery",

            colHeight768small: 235,
            divideBy768: 4,
            className768: "col-xs-3",
            className768small: "col-xs-3",

            colHeight620: 200,
            colHeight620small: 145,
            divideBy620: 4,
            className620: "col-xs-3",
            className620small: "col-xs-3",

            colHeight360: 160,
            colHeight360small: 135,
            divideBy360: 3,
            className360: "col-xs-4",
            className360small: "col-xs-4",

            colHeight300: 135,
            colHeight300small: 135,
            divideBy300: 2,
            className300: "col-xs-4",
            className300small: "col-xs-6",

            colHeight100: 100,
            divideBy100: 1,
            className100: "col-xs-6",
            className100small: "col-xs-6"
        };

        var pageSizeObject = classPageSize.setPageSizer(page);
        return pageSizeObject;
    }
};
