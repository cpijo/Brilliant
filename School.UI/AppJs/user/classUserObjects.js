
function userDetails(UserID, ProfileName, LastName,
    UserName, UserPassword, AboutMe, Age,
    Gender, Race, Languages, bodySize, bodyHeight,
    Country, Province, Password, Location, City, Email) {

    this.UserID = UserID;
    this.ProfileName = ProfileName;
    this.LastName = LastName;
    this.UserName = UserName;
    this.UserPassword = UserPassword;
    this.AboutMe = AboutMe;
    this.Age = Age;
    this.Gender = Gender;
    this.Race = Race;
    this.Languag = Languages;
    this.bodySize = bodySize;
    this.bodyHeight = bodyHeight;
    this.Country = Country;
    this.Province = Province;
    this.Password = Password;
    this.Location = Location;
    this.City = City;
    this.Email = Email;

    //this.validateObj = {
    //    validateText: undefined,
    //    validateEmail: undefined,
    //    validatePhone: undefined
    //};
}
userDetails.prototype = new classUserBase();


function userContact(Phone1, Phone2, EmailAddress) {

    this.Phone1 = Phone1;
    this.Phone2 = Phone2;
    this.EmailAddress = EmailAddress;

    //this.validateObj = {
    //    validateText: undefined,
    //    validateEmail: undefined,
    //    validatePhone: undefined
    //};
}
userContact.prototype = new classUserBase();

//function userService(QuotaHour, HalfHour, HourPrice, DayPrice, NightPrice, aboutMe, Availability) {
function userService() {

    //this.QuotaHour = QuotaHour;
    //this.HalfHour = HalfHour;
    //this.HourPrice = HourPrice;
    //this.DayPrice = DayPrice;
    //this.NightPrice = NightPrice;
    //this.aboutMe = aboutMe;
    //this.Availability = Availability;

    //this.validateObj = {
    //    validateText: undefined,
    //    validateEmail: undefined,
    //    validatePhone: undefined
    //};
}
userService.prototype = new classUserBase();
userService.prototype.ServiceType = function (controls) {
    for (var i = 0; i < controls.length; i++) {
        if ($('#' + controls[i]).val() === '' || $('#' + controls[i]).val() < 1) {
            $('#' + controls[i]).val("not filled");
            if (controls[i] === "Age") {
                $('#' + controls[i]).val("0");
            }
        }
    }
};
userService.prototype.hasChangeValue = function (oldValues,newValues ) {
 
    var changeObj = new Object();
    var newproperty = "";
    var oldproperty = "";
    for (oldproperty in oldValues) {
        for (newproperty in newValues) {
            if (oldproperty === newproperty) {
                if (oldValues[oldproperty] !== newValues[newproperty]) {
                    changeObj[oldproperty] = { "old": oldValues[oldproperty], "new": newValues[newproperty] };
                    //changeObj[oproperty] = true;
                }
            }
        }
    }

    return changeObj;
};



function userImail(imageName, imageType, imageSize, imagePath) {

    this.imageName = imageName;
    this.imageType = imageType;
    this.imageSize = imageSize;
    this.imagePath = imagePath;

    //this.validateObj = {
    //    validateText: undefined,
    //    validateEmail: undefined,
    //    validatePhone: undefined
    //};
}
userImail.prototype = new classUserBase();


function userEmailVerify(firstName, profileName, Email, accountType) {

    this.firstName = firstName;
    this.profileName = profileName;
    this.Email = Email;
    this.accountType = accountType;

    //this.validateObj = {
    //    validateText: undefined,
    //    validateEmail: undefined,
    //    validatePhone: undefined
    //};
}
userEmailVerify.prototype = new classUserBase();