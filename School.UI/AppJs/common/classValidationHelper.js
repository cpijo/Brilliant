
var ClassValidationHelper = {

    ValidateInput: function (validateControls) {
        var hasError = true;
        for (var i = 0; i < validateControls.length; i++) {
            if ($('#' + validateControls[i]).val() === '' || $('#' + validateControls[i]).val() < 1) {
                $('#' + validateControls[i]).css("border-color", "red");
                alert(validateControls[i]);
                hasError = false;
            }
            else {
                $('#' + validateControls[i]).css("border-color", "silver");
            }
        }
        return hasError;
    }
    ,
    ValidateInputSetValu: function (validateControls,value) {
        for (var i = 0; i < validateControls.length; i++) {
            if ($('#' + validateControls[i]).val() === '' || $('#' + validateControls[i]).val() < 1) {
                $('#' + validateControls[i]).val(value);
            }
            else {
                ;
            }
        }
    }
    ,
    ValidateEmail: function (validateControls) {

        var hasError = true;
        var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        var email = "";
        for (var i = 0; i < validateControls.length; i++) {
            email = $('#' + validateControls[i]).val();
            if (email===undefined) {
                return false;
            }
            if (email.match(mailformat)) {
                $('#' + validateControls[i]).css("border-color", "silver");
            }
            else {
                $('#' + validateControls[i]).css("border-color", "red");
                hasError = false;
            }
        }

        return hasError;
    }
    ,
    ValidatePhone: function (validateControls) {
        // Is Not Complete
        var hasError = true;
        for (var i = 0; i < validateControls.length; i++) {        
                hasError = false;
            }
        return hasError;
    }
    ,
    ValidatePassword: function (validateControls) {

        var hasError = true;
        password = $('#' + validateControls[0]).val();
        passwordConfirm = $('#' + validateControls[1]).val();
        if (password === passwordConfirm) {
            $('#' + validateControls[1]).css("border-color", "silver");
        }
        else {
            $('#' + validateControls[1]).css("border-color", "red");
            hasError = false;
        }

        return hasError;
    }
    ,
    preValidateDropbox: function (validateControls) {

        var isSelect = "";
        for (var i = 0; i < validateControls.length; i++) {
            isSelect = $('#' + validateControls[i]).val();
            if (isSelect === "-Select-") {
                $('#' + validateControls[i]).val('');
            }
            else if (isSelect === "") {
                $('#' + validateControls[i]).val('');
            }
        }
    }
    ,
    errorEmptyField: function () {
        var message = "Please Fill all Empty Fields marked red";
        var title = "Empty Fields";
        var msgObj = { message: message, type: "error", title: title };
        classMessageResponse.showMessage(msgObj);
    }
    ,
    errorEmail: function () {
        var message = "You have entered an invalid email address!";
        var title = "Invalid email address!";
        var msgObj = { message: message, type: "error", title: title };
        classMessageResponse.showMessage(msgObj);
    }
    ,
    errorPassword: function () {
        var message = "Password does not Match!";
        var title = "Invalid Password!";
        var msgObj = { message: message, type: "error", title: title };
        classMessageResponse.showMessage(msgObj);
    }
    ,
    errorMessage: function (obj) {

        var message = obj.message;
        var title = obj.title;
        var type = obj.type;
        var msgObj = { message: message, type: type, title: title };
        classMessageResponse.showMessage(msgObj);
    }
    ,
    setBorderColor: function (validateControls) {
        var validForm = true;
        for (var i = 0; i < validateControls.length; i++) {
            if ($('#' + validateControls[i]).val() === '' || $('#' + validateControls[i]).val() < 0) {
                $('#' + validateControls[i]).css("border-color", "red");
                validForm = false;
            }
            else {
                $('#' + validateControls[i]).css("border-color", "silver");
            }
        }
        return validForm;
    }
    ,
    preValidateInputs: function (validateControls) {
        return ClassValidation.setBorderColor(validateControls);
    }
    ,
    allowOnlyNumber: function (me) {

        var input = me.target.value;
        var _tagId = me.target.id;

        var letters = /^[A-Za-z]+$/;
        for (var i = 0; i < input.length; i++) {
            if (input[i].match(letters)) {
                input = input.substring(0, (input.length - 1));
                $("#" + _tagId).val(input);
                break;
            }
            else {
                ;
            }
        }

        var number = input.replace(/[^\d]/g, '');

        if (number.length > 2) {
            input = input.substring(0, (input.length - 1));
            $("#" + _tagId).val(input);
        }
    }
    ,
    formatPhoneNumber: function (me) {

        var input = me.target.value;
        var letters = /^[A-Za-z]+$/;
        for (var i = 0; i < input.length; i++) {
            if (input[i].match(letters)) {
                
                input = input.substring(0, (input.length - 1));
                var _tagId = me.target.id;
                $("#" + _tagId).val(input);// 0724445555(072) 444-5555
                $('#' + _tagId).css("border-color", "red");
                //return false;
                break;
            }
            else {
                ;
            }
        }
        
        var _tagId0 = me.target.getAttribute('id');//JavaScript
        var tagId = me.target.id;
        var number = input.replace(/[^\d]/g, '');
        if (number.length === 6) {
            number = number.replace(/(\d{3})(\d{3})/, "$1-$2");
            $("#" + tagId).val(number);
        } else if (number.length === 10) {
            number = number.replace(/(\d{3})(\d{3})(\d{4})/, "($1) $2-$3");
            $("#" + tagId).val(number);// 0724445555(072) 444-5555
            $('#' + tagId).css("border-color", "silver");
            var intRegex = /[0-9 -()+]+$/;

        } else if (number.length > 10) {
            number = number.replace(/(\d{3})(\d{3})(\d{4})/, "($1) $2-$3");
            number = number.substring(0, 14);
            $("#" + tagId).val(number);// 0724445555(072) 444-5555
        }
        if (number.length > 0) {
            if (number.length < 10) {
                $('#' + tagId).css("border-color", "orange");
            }
        }
    },
    onlyPhoneNumber: function (me) {

        var input = me.target.value;
        var letters = /^[A-Za-z]+$/;
        for (var i = 0; i < input.length; i++) {
            if (input[i].match(letters)) {

                input = input.substring(0, (input.length - 1));
                var _tagId = me.target.id;
                $("#" + _tagId).val(input);// 0724445555(072) 444-5555
                //$('#' + _tagId).css("border-color", "red");
                //return false;
                break;
            }
            else {
                ;
            }
        }

        var _tagId0 = me.target.getAttribute('id');//JavaScript
        var tagId = me.target.id;
        var number = input.replace(/[^\d]/g, '');
        if (number.length === 10) {
            number = number.replace(/(\d{3})(\d{3})(\d{4})/, "($1) $2-$3");
            $("#" + tagId).val(number);// 0724445555(072) 444-5555
            $('#' + tagId).css("border-color", "silver");
            var intRegex = /[0-9 -()+]+$/;

        } else if (number.length > 10) {          
            number = number.substring(0, 10);
            $("#" + tagId).val(number);// 0724445555(072) 444-5555
        }
        else if (number.length > 1) {

            if (number.length < 10) {

            number = number.substring(0, 10);
                $("#" + tagId).val(number);// 0724445555(072) 444-5555
                $('#' + tagId).css("border-color", "orange");
        }

            number = number.substring(0, 10);
            $("#" + tagId).val(number);// 0724445555(072) 444-5555
        }
        if (number.length < 0) {
            if (number.length < 10) {
                $('#' + tagId).css("border-color", "red");
            }
        }
    }
};