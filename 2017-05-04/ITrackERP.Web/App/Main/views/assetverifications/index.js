(function () {
    angular.module('app').controller('app.views.assetverifications.index', [
        '$scope', '$modal', 'abp.services.app.assetVerificationHeader', 'Upload',
        function ($scope, $modal, assetVerificationHeaderService, Upload) {
            var vm = this;

            vm.assetVerificationHeader = [];

            function GetAll() {
                assetVerificationHeaderService.getAll({}).success(function (result) {
                    vm.assetVerificationHeader = result.items;
                });
            };


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            };

            GetAll();

            
            vm.process = function () {
               
                    if ($scope.file == null) {
                        abp.notify.error(App.localize('Please upload a file.'));
                        
                    }
                    else {
                     
                        if ($scope.file) {
                            $scope.upload($scope.file);
                        }
                    }             
            }

            $scope.upload = function (file) {
                Upload.upload({
                    url: '/api/upload/',
                    data: { file: file, key: "v" }
                }).then(function (resp) {
                    $scope.file = null;
                    GetAll();
                    // console.log('Success ' + resp.config.data.file.name + 'uploaded. Response: ' + resp.data);
                }, function (resp) {
                    // console.log('Error status: ' + resp.status);
                }, function (evt) {
                    var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                    //  console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
                });
                
            };

        }
    ]);
})();