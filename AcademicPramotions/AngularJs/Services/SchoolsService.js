'use strict';
app.service('SchoolsService', function ($http) {

    this.saveSchoolSignUpFormData = function (data) {
        var url =  '/Schools/SaveSchoolInfo/';
        var result = $http({
            method: "POST",
            data:  data,
            url: url
        });
        return result;
    }

    this.getState = function () {
        var url = '/Schools/GetState/';
        var District = $http({
            method: 'Get',
            url: url
        });
        return District;
    };

    this.validateUserName = function (username) {
        var url = '/Schools/ValidateUserName/';
        var result = $http({
            method: "POST",
            data: { UserName: username },
            url: url
        });
        return result;
    }
})