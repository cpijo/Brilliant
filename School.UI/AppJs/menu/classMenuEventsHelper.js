
var classMenuEventsHelper = function () {

    $('#menuId #SurbubsId').css({
        'max-height': deviceSize.pageHeight + 'px',
        'overflow-y': 'auto'
    });

    //000000000000000000000000000000000000000000000000000000
    //    THIS IS THE Big size LEFT MENU CLICK EVENT
    // $(this).parent().find('ul').AddClass('show-block');

    $("ul.primary .treeview > a").click(
        function (event) {
            event.stopPropagation();
            event.preventDefault();
            event.stopImmediatePropagation();

var tags ='.PartialLayoutMenu, #menuId, #menuId .sidebar, .treeview a, '+
    '#layoutLeftId, #layoutLeftId .layoutLeft-header, .layoutRight-header-bottom, '+
                    '#Home-Container #basePartialHolder .divHeader, #tableId thead';
                var divHeaderP = '#Home-Container #basePartialHolder .divHeader p';

            if ($(this).hasClass('menu-st')) {               
                $(tags).css({ "background-color": "rgb(173, 128, 73)", "color": "white" });
                $(divHeaderP).css({ "color": "white" });
                $('input[type="text"], .form-control').css(
                    {
                        "outline": "none",
                        "cursor": "pointer",
                        "font-size": "14px",
                        "border-radius": "2px",
                        "border": "thin solid rgb(173, 128, 74)",
                        "height": "27px"
                    });
            }
            else if($(this).hasClass('menu-a')) {
                $(tags).css({ "background-color": "rgb(43, 67, 81)", "color": "white" });
                $(divHeaderP).css({ "color": "white" });
                $('input[type="text"], .form-control').css(
                    {
                        "outline": "none",
                        "cursor": "pointer",
                        "font-size": "14px",
                        "border-radius": "2px",
                        "border": "thin solid rgb(43, 67, 82)",
                        "height": "27px"
                    });
            }
            else {
                ;
            }



            if (event.target === event.currentTarget) {
                var mytag = event.currentTarget;
            }

            if ($(this).hasClass('show-block')) {
                $(this).parent().children('ul').stop(true, true).delay(100).slideUp("normal");
                $(this).removeClass('show-block');
            }
            else {
                $(this).parent().children('ul').stop(true, true).delay(100).slideDown("normal");
                $(this).parent().siblings('li').find('ul').stop(true, true).delay(100).slideUp("normal");
                $(this).addClass('show-block');
                $(this).parent().siblings('li').find('a').removeClass('show-block');
            }
            return false;
        });


            //$(this).parent().find('ul').removeClass('show-none').AddClass('show-block');
            //$(this).parent().find("li").toggleClass('showSubMenu_ul_li');
           // $(this).parent().siblings('li').find('ul').removeClass('show-block').AddClass('show-none');

            //$("ul.primary li li a").removeClass("activeItem").css("background-color", "rgb(51, 122, 183)");

            //var myId = this.id;
            //if (myId === 'a-SurbubId') {

            //    if ($(this).hasClass('show-block')) {

            //        $('#txtSearchSurburb').css({
            //            'display': 'block'
            //        });
            //    }
            //    else {
            //        $('#txtSearchSurburb').css({
            //            'display': 'none'
            //        });
            //    }
            //}

            //return false;
    //    }
    ////    , function () {
    ////        $(this).parent().children('ul').stop(true, true).delay(100).slideUp("normal");           
    ////}
    //);

 /*
  
    $("ul.primary .treeview > a").click(
        function (event) {
            event.preventDefault();
            event.stopPropagation();
            $(this).parent().children('ul').stop(true, true).slideToggle("300");
            $(this).toggleClass('showSubMenu_ul');
            $(this).parent().find("li").toggleClass('showSubMenu_ul_li');
            $(this).parent().siblings('li').find('ul').hide();
            //$(this).parent().find("li").not(this).find('ul').hide();
            //Remove Active Color When Item is Clicked
            $("ul.primary li li a").removeClass("activeItem").css("background-color", "rgb(51, 122, 183)");

            //var thisElement = this;
            //var elementId = event.target.id;
            var myId = this.id;
            if (myId === 'a-SurbubId') {

                if ($(this).hasClass('showSubMenu_ul')) {

                    $('#txtSearchSurburb').css({
                        'display': 'block'
                    });
                }
                else {
                    $('#txtSearchSurburb').css({
                        'display': 'none'
                    });
                }
            }
            return false;
        }
    );

     */
    //000000000000000000000000000000000000000000000000000000
    //    THIS IS THE Small Menu Hover

    $("ul.primary > li").hover(

        function () {
            //stuff to do on mouse enter
            if ($(".treeview ul.sidebar-submenu").hasClass("sidebar-small")) {
                $(this).find("ul.sidebar-submenu").css("display", "block");
                $(this).children('ul.sidebar-submenu').addClass("showSubMenu");

                var myValue = $(this).find("span.menu-header-name").text();
                $(this).find("ul.sidebar-submenu li:eq(0)").before('<li class"list_Header00" style="padding-left:10px ;padding-top:5px ;background-color: navy ;background: navy ;border-bottom:2px solid navy ;height:35px">' + myValue + '</li>');
            }
        },
        function () {
            //stuff to do on mouse leave
            if ($(".treeview ul.sidebar-submenu").hasClass("sidebar-small")) {
                $(this).children('ul.sidebar-submenu').removeClass("showSubMenu");
                $(this).find("ul.sidebar-submenu").css("display", "none");

                //$(".list_Header00").remove();
                $(this).find("ul.sidebar-submenu li:eq(0)").remove();
            }
        });

    //$('#menuId #txtSearchSurburb').keyup(function () {
    //    $('.SurbubsId ul li').hide().filter(':containsLower("' + this.value + '")').show();
    //});

    $('#menuId #txtSearchSurburb').keyup(function () {
        var search = $(this).val().toLowerCase(); //Turns input val lowercase
        var re = new RegExp(search, 'g');

        $('.SurbubsId ul li').each(function () { //Search in all <li>
            $(this).hide(); //Hide all <li>
            var target = $(this).text().toLowerCase(); //Tuns <li> text lowercase
            if (target.match(re)) {
                $(this).show(); //Show <li> with matching letter/word
            }
        });
    });


    $('ul.primary > li').hover(function () {
        $(this).find('.erroSign').removeClass("fa-angle-right").addClass("fa-angle-down")
            .css({ "font-weight": "900", "color": "orange" });
        $(this).css("border-radius", "2px");
        $(this).find("ul li").css({ "background-color": "rgb(51, 122, 183)", "color": "white" });
    }
        , function () {
            $(this).find('.erroSign').removeClass("fa-angle-down").addClass("fa-angle-right")
                .css({ "font-weight": "normal", "color": "white" });
            $(this).css("border-radius", "2px");
        }
    );

    $('ul.primary li li').hover(function () {
        if ($(this).find("a:first-child").hasClass("activeItem")) {
            $(this).find("a:first-child").css("background-color", "orange");
        }
        else {
            $(this).find("a:first-child").css("background-color", "orange").css("color", "white");
        }
    }
        , function () {
            if ($(this).find("a:first-child").hasClass("activeItem")) {
                $(this).find("a:first-child").css("background-color", "orange");
            }
            else {
                $(this).find("a:first-child").css("background-color", "rgb(51, 122, 183)");
            }
        }
    );

    $("ul.primary li li a").click(
        function () {
            //Remove Active Color When Item is Clicked
            $("ul.primary li li a").removeClass("activeItem");
            $("ul.primary li li a").not(this).css("background-color", "rgb(51, 122, 183)");
            //Add Active Color When Item is Clicked
            $(this).addClass("activeItem");
            //a()-li(N)-ul(treeview-menu)-li(treeview)          
            var isProvince = $(this).parent().parent().parent().find("a.aprovince").first();
            if (isProvince.length === 1) {
                $(this).parent().parent().parent().find("a.aprovince").first().trigger("click");
            }
        }
    );
};