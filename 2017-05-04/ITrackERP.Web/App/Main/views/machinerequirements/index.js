(function () {
    angular.module('app').controller('app.views.machinerequirements.index', [
        '$scope', '$modal', 'abp.services.app.machineRequirement',
        function ($scope, $modal, machinerequirementService) {
            var vm = this;

            vm.machinerequirements = [];

            function getMachineRequirement() {
                machinerequirementService.getMachineRequirement({}).success(function (result) {
                    vm.machinerequirements = result.items;
                });
            }


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }


            vm.delete = function (machinerequirement) {
                abp.message.confirm(App.localize('AreYouSureToDeleteMachineRequirement', machinerequirement.styleNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            machinerequirementService.deleteHeader({ id: machinerequirement.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                getMachineRequirement();
                            });
                        }
                    });
            };


            vm.machinerequirementCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/machinerequirements/createMachineRequirement.cshtml',
                    controller: 'app.views.machinerequirements.createMachineRequirement as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getMachineRequirement();
                });
            };



            getMachineRequirement();


        }
    ]);
})();