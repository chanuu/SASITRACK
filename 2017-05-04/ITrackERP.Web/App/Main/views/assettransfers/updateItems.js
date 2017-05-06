(function () {
    var controllerId = 'app.views.assettransfers.updateItems';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.assetTransferHeader', 'abp.services.app.asset',
        function ($rootScope, $scope, $state, $stateParams, assettransferService, assetService) {
            var vm = this;
            vm.assettransfer = {};

            $scope.assets = [];
            $scope.selectedAssetNo = null;

            vm.update = function () {
                if ($scope.assetTransferHeaderDetailUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.assettransfer.id = $stateParams.id;
                    vm.assettransfer.assetTransferHeaderId = $rootScope.wId;
                    vm.assettransfer.assetNo = $scope.selectedAssetNo.assetNo;
                    assettransferService.updateDetail(vm.assettransfer)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('assettransfer');

                        });
                }
            };

            function getAssets() {               
                if ($rootScope.wDocType == "ETA") {
                        assetService.getAssetByLocation({ location: $rootScope.wfrom }).success(function (result) {
                            vm.assets = result.items;
                        });
                    }
                    else {
                        assetService.getAssetByAssetUsedBy({ assetUsedBy: $rootScope.wfrom }).success(function (result) {
                            vm.assets = result.items;
                        });
                    }
            }
            getAssets();

            //
            $scope.afterSelectedAssetNos = function (selected) {
                if (selected) {
                    $scope.selectedAssetNo = selected.originalObject;
                }
            }




            function loadAssetTransferHeaders() {
                assettransferService.getAssetTransferDetailsByID({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.assettransfer = result;

                    assetService.getDetailByAssetNo({
                        assetNo: vm.assettransfer.assetNo
                    }).success(function (result) {
                        $scope.selectedAssetNo = result;
                    });

                });
            }

            vm.back = function () {
                $state.go('assettransfer');
            };


            loadAssetTransferHeaders();

        }
    ]);
})();