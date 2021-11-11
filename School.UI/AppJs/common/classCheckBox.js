var classCheckBox = {
    getCheckOptionByElement: function (htmlSelector) {
        for (var i = 0; i < htmlSelector.length; i++) {
            if (htmlSelector[i].checked) {
                return htmlSelector[i].value;
            }
        }
    }
    ,
    getCheckOptionById_notUsed: function (_rd, element) {
        var rd = document.getElementById(_rd.id);
        for (var i = 0; i < rd.length; i++) {
            if (rd[i].checked) {
                var accountType = rd[i].value;
                $(element).val(rd[i].value);
                // $("#AccountTypeId").val(rd[i].value);
                //elementId = #elementId or .elementId or elementId as tagName
            }
        }
    }
    ,
    getCheckOptionByName_notUsed: function (_rd) {
        var rd = document.getElementsByName(_rd.name);
        for (var i = 0; i < rd.length; i++) {
            if (rd[i].checked) {
                var _value = rd[i].value;
                return _value;
            }
        }
    }
};
