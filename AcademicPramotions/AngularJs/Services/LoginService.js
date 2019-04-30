'use strict';
app.service('LoginService', function ($http) {
    
    this.ValidateLogin = function (username, password) {
        var url = '/Home/ValidateLoginCredentials';
        var login = $http({
            method: "POST",
            url: url,
            data: { UserName: username, Password: password},
            cache: false
        });

        return login;
    };
})