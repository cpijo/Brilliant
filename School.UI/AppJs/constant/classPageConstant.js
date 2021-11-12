
var classPageConstant = {
    urlPage: {
        url:null,// "/home/index",
        requestType: "post",
        reponseType: "partialView"
    }
    ,
    galleryPage: {
        basePartialHolder: "#Home-Container #homePage",
        partialHolder: "#Home-Container #homePage #partialHolder",
        divHeader: "#Home-Container #homePage .divHeader p.headerText",
        button: "#Home-Container #homePage #btnCloseGeneric",
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
        basePartialHolder: "#Home-Container #popupChildChat",
        partialHolder: "#Home-Container #popupChildChat #partialHolder",
        divHeader: "#Home-Container #popupChildChat .divHeader p.headerText",
        popupName: "popupChildChat",
        z_index: "90"
    }
    ,
    popupChildOne: {
        popupOverlayLayout: "#PopupOverlayChildOne",
        basePartialHolder: "#Home-Container #popupChildOne",
        partialHolder: "#Home-Container #popupChildOne #partialHolder",
        divHeader: "#Home-Container #popupChildOne .divHeader p.headerText",
        popupName: "popupChildOne",
        z_index: "100,101"
    }
    ,
    popupChildTwo: {
        popupOverlayLayout: "#PopupOverlayChildTwo",
        basePartialHolder: "#Home-Container #popupChildTwo",
        partialHolder: "#Home-Container #popupChildTwo #partialHolder",
        divHeader: "#Home-Container #popupChildTwo .divHeader p.headerText",
        popupName: "popupChildTwo",
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
        basePartialHolder: "#Home-Container #popupChildThree",
        partialHolder: "#Home-Container #popupChildThree #partialHolder",
        divHeader: "#Home-Container #popupChildThree .divHeader p.headerText",
        popupName: "popupChildThree",
        z_index: "300,301"
    }
    ,
    popupChildFour: {
        popupOverlayLayout: "#PopupOverlayChildFour",
        basePartialHolder: "#Home-Container #popupChildFour",
        partialHolder: "#Home-Container #popupChildFour #partialHolder",
        divHeader: "#Home-Container #popupChildFour .divHeader p.headerText",
        popupName: "popupChildFour",
        z_index: "400"
    }
    ,
    popupChildFive: {
        popupOverlayLayout: "#PopupOverlayChildFive",
        basePartialHolder: "#Home-Container #popupChildFive",
        partialHolder: "#Home-Container #popupChildFive #partialHolder",
        divHeader: "#Home-Container #popupChildFive .divHeader p.headerText",
        popupName: "popupChildFive",
        z_index: "500"
    }
    ,
    popupChildLast: {
        popupOverlayLayout: "#PopupOverlayChildLast",
        basePartialHolder: "#Home-Container #popupChildLast",
        partialHolder: "#Home-Container #popupChildLast #partialHolder",
        divHeader: "#Home-Container #popupChildLast .divHeader p.headerText",
        popupName: "popupChildLast",
        z_index: "1000"
    }
    ,
    popupChildMessage: {
        popupOverlayLayout: "#Home-Container #PopupOverlayChildLast",
        basePartialHolder: "#Home-Container #popupChildLast",
        partialHolder: "#Home-Container #popupChildLast #partialHolder",
        divHeader: "#Home-Container #popupChildLast .divHeader p.headerText",
        popupName: "popupChildLast",
        z_index: "1000"
    },
    appendPartial: {
            partialHolder: "#partialHolder"
    }

};
