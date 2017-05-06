(function () {
    var controllerId = 'app.views.elements.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.element', '$http', 'Upload',
        function ($scope, $state, $stateParams, elementService, $http, Upload) {
            var vm = this;


            vm.update = function () {

                if ($scope.elementUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    if (vm.element.path != "N/A") {
                        vm.element.path = vm.element.path;

                    }
                    else if ($scope.elementUpdateForm.file.$dirty && $scope.file) {
                        vm.element.path = "app/theme/UI/images/Elements/" + $scope.file.name;
                    }
                    else {
                        vm.element.path = "N/A";
                    }

                    if ($scope.elementUpdateForm.file.$valid && $scope.file && $scope.elementUpdateForm.file.$dirty) {
                        $scope.upload($scope.file);
                    }
                    elementService.update(vm.element)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('elements');

                        });
                }
            };


            function loadElements() {
                elementService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.element = result;
                });
            }


            $scope.upload = function (file) {
                Upload.upload({
                    url: '/api/upload/',
                    data: { file: file, key: 4 }
                }).then(function (resp) {
                    // console.log('Success ' + resp.config.data.file.name + 'uploaded. Response: ' + resp.data);
                }, function (resp) {
                    // console.log('Error status: ' + resp.status);
                }, function (evt) {
                    var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                    //  console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
                });
            };



            vm.deleteElementImage = function (element) {
                abp.message.confirm(App.localize('AreYouSureToDeleteElementImage' + element.name),
                    function (isConfirmed) {
                        if (isConfirmed) {

                            $http.delete('/api/Upload/' + element.id + '/4').then(function (data) {
                                element.path = "N/A";
                                elementService.update(element)
                        .success(function () {
                            abp.notify.success(App.localize('DeletedSuccessfully'));
                            loadElements();

                        });

                            }).catch(function (data) {
                                $scope.error = "An error has occured while deleting file! " + data;
                            });
                        }
                    });

            };
            vm.backToEventsPage = function () {
                $state.go('elements');
            };

            loadElements();


        }
    ]);
})();