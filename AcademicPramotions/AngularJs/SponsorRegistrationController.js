app.controller('SponsorRegistrationFormCtrl', ['$scope', 'SponsorService', 'SchoolsService', function ($scope, SponsorService, SchoolsService) {
    $scope.SponsorInfo = {};
    GetDistricts();

    //To get Districts
    function GetDistricts() {
        var promiseGet = SchoolsService.getState();
        promiseGet.then(function (state) {
            $scope.StateList = state.data;
        },
       function (error) {
           $log.error('Some Error in Getting Records.', error);
           window.location.href = appUrl + '/Home/ErrorPage';
       })
    }

    $scope.saveRegistrationData = function (data) {
        SponsorService.saveSponsorRegistrationFormData(data).then(function (data) {
            if (data.data = 1) {
                $scope.showSuccess = true;
                $scope.showError = false;
                $scope.successMsg = 'Sponsor have registred Successfully!';
                $scope.SponsorInfo = {};
                $scope.Sponsorregform.$setPristine();
            }
            else {
                $scope.showSuccess = false;
                $scope.showError = true;
                $scope.successMsg = 'There is Problem in Registration. Please contact Administratior!';
            }
        });
    }
    //To validate Password
    $scope.validatePassword = function (password) {
        if (password != undefined && password != "") {
            if (password.length < 6) {
                $scope.invalidpassword = true;
                return false;
            }
            else {
                $scope.invalidpassword = false;
                return true;
            }
        } else {
            $scope.invalidpassword = true;
            return false;
        }
    }

    //To validate Email
    $scope.validateEmail = function (email) {
        var emailTemplate = /^(|(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6})$/i;
        if (!emailTemplate.test(email)) {
            $scope.invalidEmail = true;
            return false;
        } else if (emailTemplate.test(email)) {
            $scope.invalidEmail = false;
            return true;
        } else {
            $scope.invalidEmail = true;
            return false;
        }
    }

    //To validate Telephone
    $scope.validateTelephone = function (telephone) {
        if (telephone != undefined && telephone != "") {
            if (telephone.length < 10) {
                $scope.invalidPhone = true;
                return false;
            }
            else if (telephone.length > 10) {
                $scope.invalidPhone = true;
                return false;
            } else {
                $scope.invalidPhone = false;
                return true;
            }
        } else {
            $scope.invalidPhone = true;
            return false;
        }
    }

    //To validate Alternate Telephone
    $scope.validateAlternateTelephone = function (telephone) {
        if (telephone != undefined && telephone != "") {
            if (telephone.length < 10) {
                $scope.invalidAlternatephone = true;
                return false;
            }
            else if (telephone.length > 10) {
                $scope.invalidAlternatephone = true;
                return false;
            } else {
                $scope.invalidAlternatephone = false;
                return true;
            }
        } else {
            $scope.invalidAlternatephone = true;
            return false;
        }
    }

    //To validate Zipcode
    $scope.validateZipcode = function (zipcode) {
        if (zipcode != undefined && zipcode != "") {
            if (zipcode.length < 6) {
                $scope.invalidzipcode = true;
                return false;
            } else {
                $scope.invalidzipcode = false;
                return true;
            }
        } else {
            $scope.invalidzipcode = true;
            return false;
        }
    }

    //To validate User Name exist in db or not
    $scope.validateUserName = function (username) {
        SponsorService.validateUserName(username).then(function (data) {
            if (data.data == true) {
                $scope.invalidUsername = true;
                return false;
            }
            else {
                $scope.invalidUsername = false
                return true;
            }
        });
    }

}]);