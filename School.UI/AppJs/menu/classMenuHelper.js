
var classMenuHelper = {

    openCloseMenu: function (width) {

        if ($('#layoutLeftId').hasClass('isOpen')) {

            $("#layoutLeftId").removeClass("isOpen");
            document.getElementById("layoutLeftId").style.width = "0";
            document.getElementById("layoutRightId").style.marginLeft = "0";

            $("#holder-logIn").css("display", "block");
        }
        else {
            $("#layoutLeftId").addClass("isOpen");
            document.getElementById("layoutLeftId").style.width = "250px";
            document.getElementById("layoutRightId").style.marginLeft = "250px";

            if (width < 576) {
                $("#holder-logIn").css("display", "none");
            }
            if (width < 280) {
                document.getElementById("layoutLeftId").style.width = "200px";
                document.getElementById("layoutRightId").style.marginLeft = "200px";
            }
        }

        if ($('#layoutRightId').hasClass('noDelayCloseOpen')) {

            if ($('#layoutLeftId').hasClass('startEasy')) {
                $("#layoutLeftId").removeClass("startEasy");
            }
            else {
                $("#layoutRightId").addClass("addDelay");
                $("#layoutRightId").removeClass("noDelayCloseOpen");
            }
        }

    }
    ,
    openMenu: function (width) {
        $("#layoutLeftId").addClass("isOpen");
        document.getElementById("layoutLeftId").style.width = "250px";
        document.getElementById("layoutRightId").style.marginLeft = "250px";

        if (width < 576) {
            $("#holder-logIn").css("display", "none");
        }
        if (width < 280) {
            document.getElementById("layoutLeftId").style.width = "200px";
            document.getElementById("layoutRightId").style.marginLeft = "200px";
        }
    }
    ,
    closeMenu: function (width) {
        $("#layoutLeftId").removeClass("isOpen");
        document.getElementById("layoutLeftId").style.width = "0";
        document.getElementById("layoutRightId").style.marginLeft = "0";
    }
    ,
    myStopBubbling: function () {
        $(".div-img , #gallery-page img").click(function (event) {

            if (event.stopPropagation) {    // standard
                event.stopPropagation();
            } else {    // IE6-8
                event.cancelBubble = true;
            }

            //OR USE THIS
            event.preventDefault();
            event.stopPropagation();
        });
    }
    ,
    openMobileMenu: function () {

        if ($('#layout-page #popupMenuId').hasClass('mobileOpenMenu')) {

            $("#layout-page #popupMenuId").removeClass("mobileOpenMenu");
            $("#layout-page #popupMenuId").addClass("mobileCloseMenu");//.css("display", "none");

            setTimeout(function () {
                $('#layout-page #popupMenuId').hide();
            }, 1000); //Same time as animation
        }
        else {
            $("#layout-page #popupMenuId").addClass("mobileOpenMenu");
            $("#layout-page #popupMenuId").removeClass("mobileCloseMenu");
            $("#layout-page #popupMenuId").css("display", "block");
        }
    }

    ,
    openMenuOly: function () {

        $("#layout-page #popupMenuId").addClass("mobileOpenMenu");
        $("#layout-page #popupMenuId").removeClass("mobileCloseMenu");
        $("#layout-page #popupMenuId").css("display", "block");
    }
    ,
    closeMenuOnly: function () {

        $("#layout-page #popupMenuId").removeClass("mobileOpenMenu");
        $("#layout-page #popupMenuId").addClass("mobileCloseMenu");//.css("display", "none");

        setTimeout(function () {
            $('#layout-page #popupMenuId').hide();
        }, 1000); //Same time as animation      
    }
    ,
    closeOn: function () {

        if ($('#layout-page #popupMenuId').hasClass('mobileOpenMenu')) {
            $("#layout-page #popupMenuId").removeClass("mobileOpenMenu");
            $("#layout-page #popupMenuId").addClass("mobileCloseMenu");//.css("display", "none");

            setTimeout(function () {
                $('#layout-page #popupMenuId').hide();
            }, 1000); //Same time as animation    
        }
    }
    ,
    changeTheme: function () {
        var menus = $('#menuId .sidebar-menu li') 
        //id="menu-student-maint"  id = "menu-student-reg"  menu-teacher
        //.menu-st  .menu-a
    }
};

