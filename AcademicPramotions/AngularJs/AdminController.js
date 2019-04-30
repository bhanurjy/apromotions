app.controller('AdminCtrl', ['$scope', 'AdminService', function ($scope, AdminService) {
    //var appUrl = globalappUrl;
    $scope.programListCurrentPage = 1;
    $scope.rowsPerPage = 5;
    $scope.maxSize = 10;
    $scope.selection = [];

    //For getting the selected checkbox Id's 
    $scope.toggleSelection = function toggleSelection(schoolId) {
        var idx = $scope.selection.indexOf(schoolId);
        // is currently selected
        if (idx > -1) {
            $scope.selection.splice(idx, 1);
        }
            // is newly selected
        else {
            $scope.selection.push(schoolId);
        }
    };

    //To approve the student as a valied student of their college
    $scope.approveSchool = function () {
        var seletedschools = $scope.selection.toString();
        if (seletedschools != "") {
            var promiseGet = AdminService.ApproveSchools(seletedschools);
            promiseGet.then(function (Students) {
                if (window.IsSessionTimedout(Students))
                { return; }
                if (Students.data == "true" || Students.data == true) {
                    $scope.showSuccess = true;
                    $scope.showError = false;
                    $scope.successMsg = 'Student(s) approved successfully.';
                    $timeout(function () {
                        getSubmittedStudents();
                    }, 1000)
                    //getSubmittedStudents();
                    //window.location.reload();

                } else {
                    $scope.showSuccess = false;
                    $scope.showError = true;
                    $scope.errorMsg = 'Sorry, there is a  problem right now to approve the student(s).Please try again later.';
                }
            },
            function (error) {
                window.location.href = appUrl + '/Home/ErrorPage';
            });
        } else {
            $scope.showError = true;
            $scope.errorMsg = 'Please Check atleast one Student to approve/ Unapprove.';
        }
    }


}])