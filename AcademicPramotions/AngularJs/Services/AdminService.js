'use strict';
app.service('AdminService', function ($http) {

    this.ApproveSchools = function (seletedschools) {
        var selectedSchools = $http({
            method: "POST",
            url: "/Admin/ApproveSchools?selectedSchools=" + seletedschools,
            cache: false
        });

        return selectedSchools;
    };
})