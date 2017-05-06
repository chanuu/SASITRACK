(function () {
    var controllerId = 'app.views.machinerequirements.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$modal', '$state', '$stateParams', 'abp.services.app.machineRequirement',
        function ($rootScope, $scope, $modal, $state, $stateParams, machinerequirementService) {
            var vm = this;
            $rootScope.wId = $stateParams.id;

            function loadMachineRequirements() {
                machinerequirementService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.machinerequirement = result;
                });
            }


            vm.back = function () {
                $state.go('machinerequirement');
            };

            loadMachineRequirements();



            vm.delete = function (machinerequirement) {
                abp.message.confirm(App.localize('AreYouSureToDeleteRentMachineRequirementItem', machinerequirement.machineType),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            machinerequirementService.deleteItem({ id: machinerequirement.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                loadMachineRequirements();
                            });
                        }
                    });


            };
            vm.machinerequirementItemCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/machinerequirements/createItems.cshtml',
                    controller: 'app.views.machinerequirements.createItems as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    loadMachineRequirements();
                });
            };



        }
    ]);
})();