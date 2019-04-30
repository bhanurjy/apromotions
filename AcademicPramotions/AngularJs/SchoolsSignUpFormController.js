app.controller('SchoolsSignUpFormCtrl', ['$scope', 'SchoolsService', function ($scope, SchoolsService) {
    $scope.SchoolInfo = {};
    GetDistricts();
    
    $scope.ItemsRequiredFor = ['football', 'basketball', 'others'];
    $scope.selectedItems = [];
    $scope.toggleSelection = function toggleSelection(item) {
        $scope.IsVisible = false;
        if (item == "others") {
            $scope.IsVisible = true;
        }
        var idx = $scope.selectedItems.indexOf(item);
        // is currently selected
        if (idx > -1) {
            $scope.selectedItems.splice(idx, 1);
        }
            // is newly selected
        else {
            $scope.selectedItems.push(item);
        }
    };

    //To bind the years checkboxes
    $scope.ReceiveItemsForYear = [
        { Id:"1",value:"16-17" },
        { Id: "2", value: "17-18" }
    ];
    $scope.selectedYears = [];
    $scope.toggleSelectedYear = function toggleSelectedYear(item) {
        var idx = $scope.selectedYears.indexOf(item);
        // is currently selected
        if (idx > -1) {
            $scope.selectedYears.splice(idx, 1);
        }
            // is newly selected
        else {
            $scope.selectedYears.push(item);
        }
    };

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

    $scope.saveSignUpData = function (data) {
        $scope.selectedItemsNew = [];
        if (data.OthersTextInfo != null) {
            $scope.selectedItems.push(data.OthersTextInfo);
            for (i = 0; i < $scope.selectedItems.length; i++) {
                if ($scope.selectedItems[i] != "others") {
                    $scope.selectedItemsNew.push($scope.selectedItems[i]);
                }
            }
            //$scope.selectedItems.Remove("others");
        }
        if (data.OthersTextInfo != null) {
            $scope.SchoolInfo.ItemsRequiredFor = $scope.selectedItemsNew.toString();
        }
        else {
            $scope.SchoolInfo.ItemsRequiredFor = $scope.selectedItems.toString();
        }
        $scope.SchoolInfo.ReceiveItemsForYear = $scope.selectedYears.toString();
        SchoolsService.saveSchoolSignUpFormData(data).then(function (data) {
            if (data.data = 1) {
                $scope.showSuccess = true;
                $scope.showError = false;
                $scope.successMsg = 'You have registred Successfully!';
                $scope.SchoolInfo = {};
                $scope.Schoolsignupform.$setPristine();
            }
            else {
                $scope.showSuccess = false;
                $scope.showError = true;
                $scope.successMsg = 'There is Problem in Registration. Please contact Administratior!';
            }
        });
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

    //To validate Telephone
    $scope.validateTelephone = function (telephone) {
        if (telephone != undefined && telephone != "") {
            if (telephone.length < 10) {
                $scope.invalidTelephone = true;
                return false;
            }
            else if(telephone.length > 10) {
                $scope.invalidTelephone = true;
                return false;
            }else {
                $scope.invalidTelephone = false;
                return true;
            }
        } else {
            $scope.invalidTelephone = true;
            return false;
        }
    }

    //To validate Alternate Telephone
    $scope.validateAlternateTelephone = function (telephone) {
        if (telephone != undefined && telephone != "") {
            if (telephone.length < 10) {
                $scope.invalidAlternateTelephone = true;
                return false;
            }
            else if (telephone.length > 10) {
                $scope.invalidAlternateTelephone = true;
                return false;
            } else {
                $scope.invalidAlternateTelephone = false;
                return true;
            }
        } else {
            $scope.invalidAlternateTelephone = true;
            return false;
        }
    }

    //To validate User Name exist in db or not
    $scope.validateUserName = function (username) {
        SchoolsService.validateUserName(username).then(function (data) {
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
}]);