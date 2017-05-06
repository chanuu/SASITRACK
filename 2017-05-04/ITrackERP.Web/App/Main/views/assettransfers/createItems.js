(function () {
    angular.module('app').controller('app.views.assettransfers.createItems', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.assetTransferHeader', 'abp.services.app.asset', 'abp.services.app.assetLedger', 
        function ($rootScope, $scope, $modalInstance, assettransferService, assetService, assetLedgerService) {
            var vm = this;
            $scope.assettransferdetail = null;
            vm.asset = {};

            $scope.assets = [];
            $scope.selectedAssetNo = null;

            $scope.assetTransferItem = {};
            $scope.uniqueTransactionID = {};
            $scope.assetType = {};

            vm.save = function () {
                if ($scope.assetTransferHeaderItemCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    $scope.assettransferdetail.assetNo = $scope.selectedAssetNo.assetNo;
                    $scope.assettransferdetail.assetTransferHeaderId = $rootScope.wId;


                    assettransferService.createDetail($scope.assettransferdetail)
                        .success(function () {
                           
                            $scope.assetTransferItem.date =  $rootScope.wDate;
                            $scope.assetTransferItem.assetID = $scope.selectedAssetNo.id;                                                 
                            $scope.assetTransferItem.docType = $rootScope.wDocType;
                            $scope.assetTransferItem.docNo = $rootScope.wDocNo;                          
                           
                            $scope.assetTransferItem.status = "Pending";                        
                            $scope.assetTransferItem.assetType = "Production";
                            
                            if ($scope.assetTransferItem.docType == "ETA") {
                                $scope.assetTransferItem.usedBy = $rootScope.wUsedBy;
                                $scope.assetTransferItem.usedByLocation = "N/A";
                            }
                            else {                           
                                $scope.assetTransferItem.usedBy = $scope.selectedAssetNo.location;
                                $scope.assetTransferItem.usedByLocation = $rootScope.wUsedBy;
                            }


                            assetLedgerService.create($scope.assetTransferItem)
                       .success(function () {
                       });
                                                                                  
                            if ($scope.assetTransferItem.docType == "ETA") {
                                $scope.selectedAssetNo.location = $scope.assetTransferItem.usedBy;
                                $scope.selectedAssetNo.assetUsedBy = "N/A";
                            } else {
                                $scope.selectedAssetNo.assetUsedBy = $rootScope.wUsedBy;
                            }

                            assetService.update($scope.selectedAssetNo)
                       .success(function () {
                       });

                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

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
            $scope.afterSelectedAssetNo = function (selected) {
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