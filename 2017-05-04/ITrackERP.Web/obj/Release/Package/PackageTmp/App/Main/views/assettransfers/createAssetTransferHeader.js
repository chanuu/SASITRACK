(function () {
    angular.module('app').controller('app.views.assettransfers.createAssetTransferHeader', [
        '$scope', '$modalInstance', 'abp.services.app.assetTransferHeader', 'abp.services.app.session',
        function ($scope, $modalInstance, assettransferService, sessionService) {
            var vm = this;
            $scope.assettransfers = [];
            $scope.currentuser = {};

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