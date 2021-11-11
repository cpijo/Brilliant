
function previousValue(newValues, oldValues) {
    this.newValues = newValues;
    this.oldValues = oldValues;

    //if (newValues===null) {
    //    this.newValues = previousValueDefaults.newValues;
    //}
    //if (oldValues === null) {
    //    this.newValues = previousValueDefaults.oldValues;
    //}
}

var previousValueDefaults = {
    newValues: {
        emailAddress: null,
        phoneNumber: null,
        ImageID: null,
        userId: '444',
        userRole: 'escort'
    },
    oldValues: {
        emailAddress: null,
        phoneNumber: null,
        ImageID: null,
        userId: '888',
        userRole: 'agent'
    }
};
