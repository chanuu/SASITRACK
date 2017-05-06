(function () {
    angular.module('app').controller('app.views.jobcardheaders.createJobCardItem', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.jobCardItem', 'abp.services.app.itemMaster', 'abp.services.app.serialItem', 'abp.services.app.stockLedger', 'abp.services.app.jobCardHeader','abp.services.app.receiveNoteItem',
        function ($rootScope, $scope, $modalInstance, jobcarditemService, itemmasterService, serialitemService, stockLedgerService, jobCardHeaderService, receivenoteitemService) {
            var vm = this;
            $scope.jobcarditem = {};
            $scope.itemmasters = [];

            $scope.selectedItemCode = null;

            $scope.serialitems = [];
            $scope.selectedSerialNo = null;

            $scope.stockLedgerItem = {};
            vm.jobcardheader = {};
            $scope.item = {};
            

            vm.save = function () {
                if ($scope.jobcardItemCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    $scope.jobcarditem.jobCardHeaderId = $rootScope.JobCardHeaderId;
                    $scope.jobcarditem.itemCode = $scope.selectedItemCode.itemNo;

                    if ($scope.selectedItemCode.serialItem == true) {
                        $scope.jobcarditem.serialNo = $scope.selectedSerialNo.serialNo;
                        $scope.jobcarditem.amount = 1;
                    }
                    else {
                        $scope.jobcarditem.serialNo = "N/A";
                    }
                  
                    jobcarditemService.create($scope.jobcarditem)
                        .success(function () {

                            $scope.stockLedgerItem.itemCode = $scope.jobcarditem.itemCode;
                            $scope.stockLedgerItem.date = $rootScope.wDate
                            $scope.stockLedgerItem.transactionType = "Job";
                            $scope.stockLedgerItem.docNo = $rootScope.wJobCardNo;
                            $scope.stockLedgerItem.usedStock = $scope.jobcarditem.amount;
                            $scope.stockLedgerItem.status = "Pending";
                                                     
                            stockLedgerService.create($scope.stockLedgerItem)
                       .success(function () {

                           if ($scope.jobcarditem.serialNo != "N/A") {
                               serialitemService.updateSerialItemBySerialNo({
                                   serialNo: $scope.jobcarditem.serialNo
                               }).success(function () {
                               });
                           }

                       });

                           
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();
                        });
                }
            };


            function getItemMasters() {
                itemmasterService.getItemMaster({}).success(function (result) {
                    vm.itemmasters = result.items;
                });
            }
            getItemMasters();


            $scope.afterSelectedItemCode = function (selected) {
                if (selected) {
                    $scope.selectedItemCode = selected.originalObject;
                }
            }

          
            vm.getSerialItems = function () {
                serialitemService.getSerialItemByItemCode({ itemCode: $scope.selectedItemCode.itemNo })
                        .success(function (result) {
                            vm.serialitems = result.items;
                        });
                }
               
            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();