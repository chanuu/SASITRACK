(function () {
    var controllerId = 'app.views.jobcardheaders.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.jobCardHeader', 'abp.services.app.asset', 'abp.services.app.employee',
        function ($scope, $state, $stateParams, jobcardheaderService, assetService, employeeService) {
            var vm = this;
            
            $scope.assets = [];
            $scope.selectedAssetNo = null;

            $scope.employees = [];
            $scope.selectedEmployeeFullName = null;

            vm.update = function () {
                if ($scope.jobcardheaderUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.jobCardHeader.assetNo = $scope.selectedAssetNo.assetNo;
                    vm.jobCardHeader.doneBy = $scope.selectedEmployeeFullName.fullName;

                    jobcardheaderService.update(vm.jobCardHeader)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('jobcardheader');

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
            
            function loadJobCardHeaders() {
                jobcardheaderService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.jobCardHeader = result;
                 
                    assetService.getDetailByAssetNo({
                        assetNo: vm.jobCardHeader.assetNo
                    }).success(function (result) {
                        $scope.selectedAssetNo = result;
                    });

                    employeeService.getDetailByEmployeeFullName({
                        fullName: vm.jobCardHeader.doneBy
                    }).success(function (result) {
                        $scope.selectedEmployeeFullName = result;
                    });


                });
            };


            vm.back = function () {
                $state.go('jobcardheader');
            };


            loadJobCardHeaders();


        }
    ]);
})();