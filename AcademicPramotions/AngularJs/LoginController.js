app.controller('LoginController', ['$scope', 'LoginService', '$log', function ($scope, LoginService, $log) {
    $scope.Login = {};
    var appUrl = '';
    //To post the login credentials
    $scope.LoginSubmit = function () {
        var username = $scope.Login.UserName;
        var password = $scope.Login.Password;
        var promiseGet = LoginService.ValidateLogin(username, password);
        promiseGet.then(function (login) {
            if (login.data == "1") {
                window.location.href = appUrl + '/Home/AdminDashBoard';
            } else if (login.data == "2") {
                window.location.href = appUrl + '/Schools/SchoolDashBoard';
            } else if (login.data == "3") {
                window.location.href = appUrl + '/Sponsor/SponsorDashBoard';
            }
            else {
                $scope.invalidCredentials = true;
            }
        },
       function (error) {
           window.location.href = appUrl + '/Home/ErrorPage';
       });
    }
    //when cancel button is clicked
    $scope.cancelPage = function () {
        $scope.Login = "";
        $scope.invalidCredentials = false;
        $scope.loginForm.$setPristine();
    }
}]);