app.controller('PostRequirementsCtrl', ['$scope', 'PostRequirementsService', function ($scope, PostRequirementsService) {
    $scope.Requirements = {};
    //var requirements = [];
    //for (i = 1; i <= 13; i++) {
    //    requirements.push({ ItemId: i, Quantity: '' })
    //}

    $scope.saveRequirementData = function (data) {
        PostRequirementsService.saveSchoolRequirementData(data).then(function (data) {
            if (data.data = 1) {
                $scope.showSuccess = true;
                $scope.showError = false;
                $scope.successMsg = 'You have posted requirements Successfully!';
                $scope.Requirements = {};
                $scope.PostRequirementsform.$setPristine();
            }
            else {
                $scope.showSuccess = false;
                $scope.showError = true;
                $scope.successMsg = 'There is Problem in posting Requirements. Please contact Administratior!';
            }
        });
    }

}]);