(function () {
    angular.module('app').controller('app.views.assettransfers.createAssetTransferHeader', [
        '$scope', '$modalInstance', 'abp.services.app.assetTransferHeader', 'abp.services.app.session', 'abp.services.app.department',
        function ($scope, $modalInstance, assettransferService, sessionService, departmentService) {
            var vm = this;
            $scope.assettransfers = [];
            $scope.currentuser = {};

            $scope.departments = [];
            $scope.selectedLineNo1 = null;
            $scope.selectedLineNo2 = null;

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };

            $scope.fdate = new Date();

            vm.save = function () {

                if ($scope.assettransferCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.assettransfer.date = $scope.fdate;

                    sessionService.getCurrentLoginInformations({}).success(function (result) {
                            $scope.currentuser = result;
                        });
                    vm.assettransfer.transferBy = $scope.currentuser.user.name;

                    if (vm.assettransfer.type == 'ITA') {
                        vm.assettransfer.fromLocation = $scope.selectedLineNo1.name;
                        vm.assettransfer.toLocation = $scope.selectedLineNo2.name;
                    }
                    assettransferService.createHeader(vm.assettransfer)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };

/*
            function getTenants() {
                tenantService.getTenants({}).success(function (result) {
                    vm.tenants = result.items;
                });
            }
            getTenants();

            //
            $scope.afterSelectedTenancyName = function (selected) {
                if (selected) {
                    $scope.selectedTenancyName = selected.originalObject;
                }
            }
            */


            function getDepartments() {
                departmentService.getDepartments({}).success(function (result) {
                    vm.departments = result.items;
                });
            }
            getDepartments();

            $scope.afterSelectedAssetTransferHeader = function (selected) {
                if (selected) {
                    $scope.afterSelectedAssetTransferHeader = selected.originalObject;


                }
            }

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();