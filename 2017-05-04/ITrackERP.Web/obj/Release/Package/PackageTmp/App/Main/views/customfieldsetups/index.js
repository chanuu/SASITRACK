(function () {
    angular.module('app').controller('app.views.customfieldsetups.index', [
        '$scope', '$modal', 'abp.services.app.customeFieldSetup',
        function ($scope, $modal, customfieldsetuptService) {
            var vm = this;

            vm.customfieldsetups = [];

            function GetCustomFieldSetup() {
                customfieldsetuptService.getCustomeFieldSetup({}).success(function (result) {
                    vm.customfieldsetups = result.items;
                });
            };


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            };



            vm.delete = function (customfieldsetup) {
                abp.message.confirm(App.localize('AreYouSureToDeleteCustomFieldSetUp' + customfieldsetup.customFieldNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            customfieldsetuptService.delete({ id: customfieldsetup.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                GetCustomFieldSetup();
                            });
                        }
                    });
            };

            vm.customfieldsetupCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/customfieldsetups/createCustomFieldSetup.cshtml',
                    controller: 'app.views.customfieldsetups.createCustomFieldSetup as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    GetCustomFieldSetup();
                });
            };



            GetCustomFieldSetup();


        }
    ]);
})();