(function () {
    angular.module('app').controller('app.views.machinerequirements.createMachineRequirement', [
        '$scope', '$modalInstance', 'abp.services.app.machineRequirement', 'abp.services.app.style',
        function ($scope, $modalInstance, machinerequirementService, styleService) {
            var vm = this;
            $scope.machinerequirements = [];
            $scope.styles = [];
            $scope.styleId = null;
            $scope.selectedStyle = null;

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };

            $scope.fdate = new Date();
            $scope.tdate = new Date();

            vm.save = function () {

                if ($scope.machineRequirementCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {

                    vm.machinerequirement.styleId = $scope.selectedStyle.id;
                    vm.machinerequirement.styleNo = $scope.selectedStyle.styleNo;

                    vm.machinerequirement.fromDate = $scope.fdate.getFullYear() + "-" + ($scope.fdate.getMonth() + 1) + "-" + $scope.fdate.getDate();
                    vm.machinerequirement.toDate = $scope.tdate.getFullYear() + "-" + ($scope.tdate.getMonth() + 1) + "-" + $scope.tdate.getDate();;
                    machinerequirementService.createHeader(vm.machinerequirement)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };



            function getStyles() {
                styleService.getStyles({}).success(function (result) {

                    vm.styles = result.items;
                });
            }
            getStyles();

            //
            $scope.afterSelectedMachineRequirement = function (selected) {
                if (selected) {
                    $scope.selectedMachineRequirement = selected.originalObject;


                }
            }

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();