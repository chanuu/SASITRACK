(function () {
    angular.module('app').controller('app.views.machinetypes.index', [
        '$scope', '$modal', 'abp.services.app.machineType',
        function ($scope, $modal, machinetypeService) {
            var vm = this;

            vm.machinetypes = [];

           
            function GetMachineTypes() {
                machinetypeService.getMachineTypes({}).success(function (result) {
                    vm.machinetypes = result.items;
                });
            };


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            };



            vm.delete = function (machinetype) {
                abp.message.confirm(App.localize('AreYouSureToDeleteMachineType', machinetype.machineTypeName),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            machinetypeService.deleteMachineType({ id: machinetype.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                GetMachineTypes();
                            });
                        }
                    });
            };

            vm.machinetypeCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/machinetypes/createMachinetype.cshtml',
                    controller: 'app.views.machinetypes.createMachinetype as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    GetMachineTypes();
                });
            };



            GetMachineTypes();


        }
    ]);
})();