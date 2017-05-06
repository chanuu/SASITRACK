(function () {
    angular.module('app').controller('app.views.eventheaders.createAlbumItem', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.album', 'Upload',
        function ($rootScope, $scope, $modalInstance, albumService, Upload) {
            var vm = this;
            $scope.albumitem = null;

            vm.save = function () {
                if ($scope.albumCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {

                    $scope.albumitem.eventHeaderId = $rootScope.eventHeaderId;
                    $scope.albumitem.url = "app/theme/UI/images/Events/" + $scope.file.name;

                    if ($scope.albumCreateForm.file.$valid && $scope.file) {
                        $scope.upload($scope.file);
                    }

                    albumService.create($scope.albumitem)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };



            $scope.upload = function (file) {
                Upload.upload({
                    url: '/api/upload',
                    data: { file: file, key: 3 }
                }).then(function (resp) {
                    console.log('Success ' + resp.config.data.file.name + 'uploaded. Response: ' + resp.data);
                }, function (resp) {
                    console.log('Error status: ' + resp.status);
                }, function (evt) {
                    var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                    console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
                });
            };

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();