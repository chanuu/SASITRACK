(function () {
    angular.module('app').controller('app.views.rentmachines.index', [
        '$scope', '$modal', 'abp.services.app.rentMachine',
        function ($scope, $modal, rentmachineService) {
            var vm = this;

            vm.rentMachines = [];
         
            function GetRentMachines() {
                rentmachineService.getRentMachines({}).success(function (result) {
                    vm.rentMachines = result.items;
                });
            };


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            };



            vm.delete = function (rentmachine) {
                abp.message.confirm(App.localize('AreYouSureToDeleteRentMachine', rentmachine.machineSerialNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            rentmachineService.deleteRentMachine({ id: rentmachine.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                GetRentMachines();
                            });
                        }
                    });
            };

            vm.rentmachineCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/rentmachines/createRentmachine.cshtml',
                    controller: 'app.views.rentmachines.createRentmachine as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    GetRentMachines();
                });
            };



            GetRentMachines();


        }
    ]);
})();