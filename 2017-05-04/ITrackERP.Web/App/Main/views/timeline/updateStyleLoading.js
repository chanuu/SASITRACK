(function () {
    var controllerId = 'app.views.timeline.updateStyleLoading';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$modalInstance', '$stateParams', 'abp.services.app.machineRequirement', 'abp.services.app.style', 'abp.services.app.department',
        function ($rootScope, $scope, $state, $modalInstance, $stateParams, machinerequirementService, styleService, departmentService) {
            var vm = this;

            $scope.styles = [];
            vm.departments = [];
            $scope.selectedStyle = null;
            $scope.selectedLineNo = null;
            vm.machinerequirement = {};

            vm.update = function () {
                if ($scope.machineRequirementUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.machinerequirement.styleId = $scope.selectedStyle.id;
                    vm.machinerequirement.styleNo = $scope.selectedStyle.styleNo;
                    vm.machinerequirement.lineNo = $scope.selectedLineNo.name;

                    machinerequirementService.updateHeader(vm.machinerequirement)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();
                        });
                }
            };

        
            function loadMachineRequirements() {
                machinerequirementService.getDetail({
                    id: $rootScope.machineRequirementId
                }).success(function (result) {
                    vm.machinerequirement = result;

                    styleService.getDetailByStyleNo({
                        styleNo: vm.machinerequirement.styleNo
                    }).success(function (result) {
                        $scope.selectedStyle = result;
                    });


                    departmentService.getDetailByLineNo({
                        name: vm.machinerequirement.lineNo
                    }).success(function (result) {
                        $scope.selectedLineNo = result;
                    });


                });
            };

            function getStyles() {
                styleService.getStyles({}).success(function (result) {
                    vm.styles = result.items;
                });
            };

            getStyles();

            function getDepartments() {
                departmentService.getDepartments({}).success(function (result) {
                    vm.departments = result.items;
                });
            }
            getDepartments();

            vm.cancel = function () {
                $modalInstance.close();
            };

         
            loadMachineRequirements();


        }
    ]);
})();