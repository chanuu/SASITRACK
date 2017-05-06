(function () {
    angular.module('app').controller('app.views.assetdisposals.createItems', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.assetDisposalHeader', 'abp.services.app.asset', 'abp.services.app.assetLedger',
        function ($rootScope, $scope, $modalInstance, assetdisposalService, assetService, assetLedgerService) {
            var vm = this;
            $scope.assetdisposaldetail = null;

            $scope.assets = [];
            $scope.selectedAssetNo = null;

            vm.save = function () {

                if ($scope.assetDisposalHeaderItemCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    $scope.assetdisposaldetail.assetNo = $scope.selectedAssetNo.assetNo;
                    $scope.assetdisposaldetail.assetDisposalHeaderId = $rootScope.hId;

                    assetdisposalService.createDetail($scope.assetdisposaldetail)
                        .success(function () {

                            $scope.assetdisposaldetail.date = $rootScope.hDate;
                            $scope.assetdisposaldetail.assetID = $scope.selectedAssetNo.id;
                            $scope.assetdisposaldetail.docType = "DPN";
                            $scope.assetdisposaldetail.docNo = $rootScope.hDocNo;
                            $scope.assetdisposaldetail.usedBy = "Disposed";
                            $scope.assetdisposaldetail.status = "Pending";
                            $scope.assetdisposaldetail.assetType = "Production";

                            assetLedgerService.create($scope.assetdisposaldetail)
                       .success(function () {
                       });

                            $scope.selectedAssetNo.location = "Disposed";
                            $scope.selectedAssetNo.assetUsedBy = "Disposed";

                            assetService.update($scope.selectedAssetNo)
                       .success(function () {
                       });

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
            $scope.afterSelectedAssetNos = function (selected) {
                if (selected) {
                    $scope.selectedAssetNo = selected.originalObject;
                }
            }

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();