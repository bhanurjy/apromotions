'use strict';
app.service('SponsorService', function ($http) {

    this.saveSponsorRegistrationFormData = function (data) {
        var url = '/Sponsor/SaveSponsorInfo/';
        var result = $http({
            method: "POST",
            data: data,
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
        var url = '/Sponsor/ValidateUserName/';
        var result = $http({
            method: "POST",
            data: { UserName: username },
            url: url
        });
        return result;
    }
})