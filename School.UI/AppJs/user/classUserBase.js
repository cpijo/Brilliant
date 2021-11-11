
function classUserBase(firstName, profileName, Email, accountType) {
    //if (!new.target) {
    //    return new userImageVerify("", "", "", "");
    //}
    this.firstName = firstName;
    this.profileName = profileName;
    this.Email = Email;
    this.accountType = accountType;

    this.validateObj = {
        validateText: undefined,
        validateEmail: undefined,
        validatePhone: undefined
    };
}

classUserBase.prototype.setAccountType = function (element, elementName, elementSelector) {
    var elementValue = "";
    if (element === "") {
        elementValue = classCheckBox.getCheckOptionByElement(document.getElementsByName(elementName));
    }
    else {
        elementValue = classCheckBox.getCheckOptionByElement(document.getElementsByName(element.name));
    }
    $(elementSelector).val(elementValue);
};


classUserBase.prototype.setNullInput = function (controls) {
    for (var i = 0; i < controls.length; i++) {
        if ($('#' + controls[i]).val() === '' || $('#' + controls[i]).val() < 1) {
            $('#' + controls[i]).val("not filled");
            if (controls[i] === "Age") {
                $('#' + controls[i]).val("0");
            }
        }
    }
};

classUserBase.prototype.setDefaultValue = function (controls, value) {
    for (var i = 0; i < controls.length; i++) {
        if ($('#' + controls[i]).val() === '' || $('#' + controls[i]).val() < 1) {
            $('#' + controls[i]).val(value);
        }
        else {
            ;
        }
    }
};

classUserBase.prototype.clearAll = function (controls, value) {
    for (var i = 0; i < controls.length; i++) {
        $('#' + controls[i]).css("border-color", "blue");
        $('#' + controls[i]).val("");
    }
};


classUserBase.prototype.validateInput = function (controls) {
    //var _controls = ['txtFirstName', 'txtAmailAddress'];
    var isValid = ClassValidationHelper.ValidateInput(controls);
    if (isValid === false) {
        ClassValidationHelper.errorEmptyField();
        return false;
    }
};

classUserBase.prototype.validateByObject = function (validateObj) {
    var isValid = true;
    var isValidText = true;
    var isValidEmail = true;
    var isValidPhone = true;
    //debugger;
    if (validateObj.validateText !== undefined) {
        isValid = ClassValidationHelper.ValidateInput(validateObj.validateText);
        if (isValid === false) {
            ClassValidationHelper.errorEmptyField();
            isValidText = false;
        }
    }
    if (validateObj.validateEmail !== undefined) {
        isValid = ClassValidationHelper.ValidateEmail(validateObj.validateEmail);
        if (isValid === false) {
            ClassValidationHelper.errorEmptyField();
            isValidEmail = false;
        }
    }
    if (validateObj.validatePhone !== undefined) {
        isValid = ClassValidationHelper.validatePhone(validateObj.validatePhone);
        if (isValid === false) {
            ClassValidationHelper.errorEmptyField();
            isValidPhone = false;
        }
    }

    if (isValidText === false) {
        isValid = false;
    }
    else if (isValidEmail === false) {
        isValid = false;
    }
    else if (isValidPhone === false) {
        isValid = false;
    }
    return isValid;
};

function ValidateObj(validateText, validateEmail, validatePhone) {

    this.validateText = validateText;
    this.validateEmail = validateEmail;
    this.validatePhone = validatePhone;
}

//userDetails.setAccountType.call(myuserService);
//userDetails.validateInput.call(myuserService);
//userDetails.validateByObject.call(myuserService);