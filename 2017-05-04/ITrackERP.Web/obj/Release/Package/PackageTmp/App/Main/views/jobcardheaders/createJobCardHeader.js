(function () {
    angular.module('app').controller('app.views.jobcardheaders.createJobCardHeader', [
        '$scope', '$modalInstance', 'abp.services.app.jobCardHeader', 'abp.services.app.asset', 'abp.services.app.employee',
        function ($scope, $modalInstance, jobCardheaderService, assetService, employeeService) {
            var vm = this;

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };

            $scope.rdate = new Date();

            $scope.assets = [];
            $scope.selectedAssetNo = null;

            $scope.employees = [];
            $scope.selectedEmployeeFullName = null;

            vm.save = function () {

                if ($scope.jobcardheaderCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.jobCardHeader.date = $scope.rdate;
                    vm.jobCardHeader.assetNo = $scope.selectedAssetNo.assetNo;
                    vm.jobCardHeader.doneBy = $scope.selectedEmployeeFullName;
                 
                    jobCardheaderService.create(vm.jobCardHeader)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };



            function getAssets() {
                assetService.getAsset({}).success(function (result) {

                    vm.assets = result.items;
                });
            }
            getAssets();

            //
            $scope.afterSelectedAssetNo = function (selected) {
                if (selected) {
                    $scope.selectedAssetNo = selected.originalObject;
                }
            }


            function getEmployees() {
                employeeService.getEmployee({}).success(function (result) {
                    vm.employees = result.items;
                });
            }
            getEmployees();

            //
            $scope.afterselectedEmployeeFullName = function (selected) {
                if (selected) {
                    $scope.selectedEmployeeFullName = selected.originalObject;
                }
            }


            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();