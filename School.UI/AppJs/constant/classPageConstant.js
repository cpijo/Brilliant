
var classPageConstant = {
    urlPage: {
        url:null,// "/home/index",
        requestType: "post",
        reponseType: "partialView"
    }
    ,
    galleryPage: {
        basePartialHolder: "#Home-Container #HomeBodyGallery",
        partialHolder: "#Home-Container #HomeBodyGallery #partialHolder",
        divHeader: "#Home-Container #HomeBodyGallery .divHeader p.headerText",
        button: "#Home-Container #HomeBodyGallery #btnCloseGeneric",
        popupName: "partialHolder"
    }
    ,
    loginPage: {
        popupOverlayLayout: "#PopupOverlayLogIn",
        basePartialHolder: "#Home-Container #PopupBodyUserLogin",
        partialHolder: "#Home-Container #PopupBodyUserLogin #partialHolder",
        divHeader: "#Home-Container #PopupBodyUserLogin .divHeader p.headerText",
        popupName: "PopupBodyUserLogin"
    }
    ,

    registerEmailVerifyPage: {
        popupOverlayLayout: "#PopupOverlayLogIn",
        basePartialHolder: "#Home-Container #PopupBodyRegister",
        partialHolder: "#Home-Container #PopupBodyRegister #partialHolder",
        divHeader: "#Home-Container #PopupBodyRegister .divHeader p.headerText",
        popupName: "PopupBodyRegister"
    }
    ,
    popupChildChat: {
        popupOverlayLayout: "#PopupOverlayChildChat",
        basePartialHolder: "#Home-Container #PopupBodyChildChat",
        partialHolder: "#Home-Container #PopupBodyChildChat #partialHolder",
        divHeader: "#Home-Container #PopupBodyChildChat .divHeader p.headerText",
        popupName: "PopupBodyChildChat",
        z_index: "90"
    }
    ,
    popupChildOne: {
        popupOverlayLayout: "#PopupOverlayChildOne",
        basePartialHolder: "#Home-Container #PopupBodyChildOne",
        partialHolder: "#Home-Container #PopupBodyChildOne #partialHolder",
        divHeader: "#Home-Container #PopupBodyChildOne .divHeader p.headerText",
        popupName: "PopupBodyChildOne",
        z_index: "100,101"
    }
    ,
    popupChildTwo: {
        popupOverlayLayout: "#PopupOverlayChildTwo",
        basePartialHolder: "#Home-Container #PopupBodyChildTwo",
        partialHolder: "#Home-Container #PopupBodyChildTwo #partialHolder",
        divHeader: "#Home-Container #PopupBodyChildTwo .divHeader p.headerText",
        popupName: "PopupBodyChildTwo",
        z_index: "200,201",
        divHeaderBackgroundColor: "rgb(59, 90, 108)",
        divHeaderClass: {
            "background-color": "rgb(59, 90, 108)",
            "display": "none"
        }
    }
    ,
    popupChildThree: {
        popupOverlayLayout: "#PopupOverlayChildThree",
        basePartialHolder: "#Home-Container #PopupBodyChildThree",
        partialHolder: "#Home-Container #PopupBodyChildThree #partialHolder",
        divHeader: "#Home-Container #PopupBodyChildThree .divHeader p.headerText",
        popupName: "PopupBodyChildThree",
        z_index: "300,301"
    }
    ,
    popupChildFour: {
        popupOverlayLayout: "#PopupOverlayChildFour",
        basePartialHolder: "#Home-Container #PopupBodyChildFour",
        partialHolder: "#Home-Container #PopupBodyChildFour #partialHolder",
        divHeader: "#Home-Container #PopupBodyChildFour .divHeader p.headerText",
        popupName: "PopupBodyChildFour",
        z_index: "400"
    }
    ,
    popupChildFive: {
        popupOverlayLayout: "#PopupOverlayChildFive",
        basePartialHolder: "#Home-Container #PopupBodyChildFive",
        partialHolder: "#Home-Container #PopupBodyChildFive #partialHolder",
        divHeader: "#Home-Container #PopupBodyChildFive .divHeader p.headerText",
        popupName: "PopupBodyChildFive",
        z_index: "500"
    }
    ,
    popupChildLast: {
        popupOverlayLayout: "#PopupOverlayChildLast",
        basePartialHolder: "#Home-Container #PopupBodyChildLast",
        partialHolder: "#Home-Container #PopupBodyChildLast #partialHolder",
        divHeader: "#Home-Container #PopupBodyChildLast .divHeader p.headerText",
        popupName: "PopupBodyChildLast",
        z_index: "1000"
    }
    ,
    popupChildMessage: {
        popupOverlayLayout: "#Home-Container #PopupOverlayChildLast",
        basePartialHolder: "#Home-Container #PopupBodyChildLast",
        partialHolder: "#Home-Container #PopupBodyChildLast #partialHolder",
        divHeader: "#Home-Container #PopupBodyChildLast .divHeader p.headerText",
        popupName: "PopupBodyChildLast",
        z_index: "1000"
    },
    appendPartial: {
            partialHolder: "#partialHolder"
    }

};
