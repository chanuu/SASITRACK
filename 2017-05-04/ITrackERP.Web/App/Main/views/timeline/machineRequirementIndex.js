(function () {
    angular.module('app').controller('app.views.timeline.machineRequirementIndex', ['$rootScope',
        '$scope', '$modal', '$modalInstance', 'abp.services.app.machineRequirement',
    function ($rootScope, $scope, $modal, $modalInstance, machinerequirementService) {
        var vm = this;

        $scope.machineRequirementId = $rootScope.machineRequirementId;

        vm.machinerequirements = [];
        vm.styleloading = {};

        function getMachineRequirement() {
            machinerequirementService.getMachineRequirementItems({ machineRequirementId: $rootScope.machineRequirementId }).success(function (result) {
                vm.machinerequirements = result.items;
            });
        }

        getMachineRequirement();

        function getStyleLoading() {
            machinerequirementService.getDetail({ id: $rootScope.machineRequirementId }).success(function (result) {
                vm.styleloading = result;
            });
        }

        getStyleLoading();

        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;   //set the sortKey to the param passed
            $scope.reverse = !$scope.reverse; //if true make it false and vice versa
        }


        vm.delete = function (machinerequirement) {
            abp.message.confirm(App.localize('AreYouSureToDeleteMachineRequirementItem' + machinerequirement.machineType),
                function (isConfirmed) {
                    if (isConfirmed) {
                        machinerequirementService.deleteItem({ id: machinerequirement.id }).success(function () {
                            abp.notify.success(App.localize('SuccessfullyDeleted'));
                            getMachineRequirement();
                        });
                    }
                });
        };

        vm.styleLoadingUpdateModal = function () {

            var modalInstance = $modal.open({
                templateUrl: '/App/Main/views/timeline/updateStyleLoading.cshtml',
                controller: 'app.views.timeline.updateStyleLoading as vm',
                backdrop: 'static'
            });

            modalInstance.result.then(function () {
                getStyleLoading();
            });

    };

            vm.machinerequirementItemCreationModal = function () {
                
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/timeline/createItems.cshtml',
                    controller: 'app.views.timeline.createItems as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getMachineRequirement();
                });
            };

            vm.machinerequirementItemUpdateModal = function (machinerequirement) {

                $rootScope.itemId = machinerequirement.id;

                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/timeline/updateItem.cshtml',
                    controller: 'app.views.timeline.updateItem as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getMachineRequirement();
                });
            };


            vm.machinerequirementItemDetailModal = function (machinerequirement) {

                $rootScope.itemId = machinerequirement.id;

                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/timeline/detail.cshtml',
                    controller: 'app.views.timeline.detail as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getMachineRequirement();
                });
            };

            

            vm.cancel = function () {
                $modalInstance.close();
            };
        }
    ]);
})();