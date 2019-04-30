'use strict';
app.service('PostRequirementsService', function ($http) {

    //To save the details of school requirements in to the database
    this.saveSchoolRequirementData = function (data) {
        var url = '/Schools/SaveSchoolRequirementsInfo/';
        var result = $http({
            method: "POST",
            data: data,
            url: url
        });
        return result;
    }
})