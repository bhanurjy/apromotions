'use strict';
app.service('UploadArtWorkService', function ($http) {
    this.GetItemsSponsoring = function () {
        var url = '/Sponsor/getSponsoringItems/';
        var result = $http({
            method: "GET",
            url: url
        });
        return result;
    }

    this.GetSportsInfo = function () {
        var url = '/Sponsor/getSportsInfo/';
        var SportsInfo = $http({
            method: 'Get',
            url: url
        });
        return SportsInfo;
    };

    this.GetSeasonInfo = function () {
        var url = '/Sponsor/getSeasonInfo/';
        var SeasonInfo = $http({
            method: 'Get',
            url: url
        });
        return SeasonInfo;
    };

    //To save the details of art work in to the database
    this.saveUploadedArtworkData = function (data) {
        var url = '/Sponsor/UploadArtworkInfo/';
        var result = $http({
            method: "POST",
            data: data,
            url: url
        });
        return result;
    }

    //To get the school names
    this.GetSchoolNames = function () {
        var url = '/Sponsor/getSchoolInfo/';
        var SchoolInfo = $http({
            method: 'Get',
            url: url
        });
        return SchoolInfo;
    }
})