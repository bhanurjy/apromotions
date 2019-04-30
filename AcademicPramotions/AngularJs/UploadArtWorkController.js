app.controller('UploadArtworkCtrl', ['$scope', 'UploadArtWorkService', function ($scope, UploadArtWorkService) {
    $scope.data = {};
    GetItemsSponsoring();
    GetSportsInfo();
    GetSeasonInfo();
    GetSchoolNames();
    $scope.ItemsList = [];

    $scope.selectedItems = [];
    $scope.toggleItemSelection = function toggleItemSelection(item) {
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

    //To get the items sponsoring from the database
    function GetItemsSponsoring() {
        var promiseGet = UploadArtWorkService.GetItemsSponsoring();
        promiseGet.then(function (sponsoringItems) {
            $scope.ItemsList = sponsoringItems.data;
        },
       function (error) {
           $log.error('Some Error in Getting Records.', error);
           window.location.href = appUrl + '/Home/ErrorPage';
       })
    }

    //To get the sports information from the database
    function GetSportsInfo() {
        var promiseGet = UploadArtWorkService.GetSportsInfo();
        promiseGet.then(function (sponsoringItems) {
            $scope.SportsInfoList = sponsoringItems.data;
        },
       function (error) {
           $log.error('Some Error in Getting Records.', error);
           window.location.href = appUrl + '/Home/ErrorPage';
       })
    }

    //To get the Years information from the database
    function GetSeasonInfo() {
        var promiseGet = UploadArtWorkService.GetSeasonInfo();
        promiseGet.then(function (SeasonInfo) {
            $scope.SeasonInfoList = SeasonInfo.data;
        },
       function (error) {
           $log.error('Some Error in Getting Records.', error);
           window.location.href = appUrl + '/Home/ErrorPage';
       })
    }

    //To save the details of art work in to the database
    $scope.saveUploadedArtwork = function () {
        $scope.data.SchoolId = $scope.ArtWork.SponsoredSchool.SchoolInfoId.SchoolInfoId;
        $scope.data.Invoice = $scope.ArtWork.Invoice;
        $scope.data.Sport = $scope.ArtWork.Sport;
        $scope.data.Season = $scope.ArtWork.Season;
        $scope.data.ItemsSponsering = $scope.selectedItems.toString();
        $scope.data.UploadArt = $scope.ArtWork.UploadArt;
        $scope.data.Instructions = $scope.ArtWork.Instructions;
        UploadArtWorkService.saveUploadedArtworkData($scope.data).then(function (data) {
            if (data.data = 1) {
                $scope.showSuccess = true;
                $scope.showError = false;
                $scope.successMsg = 'Uploaded Artwork Successfully!';
                $scope.ArtWork = {};
                $scope.Uploadartworkform.$setPristine();
            }
            else {
                $scope.showSuccess = false;
                $scope.showError = true;
                $scope.successMsg = 'There is Problem in Uploading Artwork. Please contact Administratior!';
            }
        });
    }

    //Auto complete
    $scope.SchoolNameAutoComplete = function () {

        $scope.OriginalEmpName = "";
        $('[name=SponsoredSchool]').autocomplete({
            source: $scope.allschools,
            minLength: 3,
            select: function (event, ui) {
                $scope.ArtWork.SponsoredSchool = ui.item.label;
                $scope.ArtWork.SchoolInfoId = ui.item.id;
            }
        });
        $scope.isDisable = false;
    };
    $scope.sponsoredSchoolOptions = {
    debounce: {
      default: 500,
      blur: 250
    },
    getterSetter: true
  };
    //To get all registered school names for auto complete
    function GetSchoolNames() {
        var promiseGet = UploadArtWorkService.GetSchoolNames();
        promiseGet.then(function (schools) {
            $scope.allschools = schools.data;
        },
       function (error) {
           $log.error('Some Error in Getting Records.', error);
           window.location.href = appUrl + '/Home/ErrorPage';
       })
    }

}]);

//Directory for file read
app.directive("fileread", [function () {
    return {
        scope: {
            fileread: "="
        },
        link: function (scope, element, attributes) {
            element.bind("change", function (changeEvent) {
                var reader = new FileReader();
                reader.onload = function (loadEvent) {
                    scope.$apply(function () {
                        scope.fileread = loadEvent.target.result;
                    });
                }
                reader.readAsDataURL(changeEvent.target.files[0]);
            });
        }
    }
}

]);

//
