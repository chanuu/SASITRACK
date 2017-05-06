(function () {
    angular.module('app').controller('app.views.stockreceiveheaders.createReceiveNoteItem', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.receiveNoteItem', 'abp.services.app.itemMaster', 'abp.services.app.stockLedger', 
        function ($rootScope, $scope, $modalInstance, receivenoteitemService, itemmasterService, stockLedgerService) {
            var vm = this;
            $scope.receivenoteitems = [];
            $scope.itemMasterId = null;
            $scope.itemmasters = [];
            $scope.selectedItemCode = null;


            $scope.stockLedgerItem = {};


            vm.save = function () {
                if ($scope.receivenoteitemCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {

                    vm.receivenoteitem.itemCode = $scope.selectedItemCode.itemNo;
                    vm.receivenoteitem.itemMasterId = $scope.selectedItemCode.id;
                    vm.receivenoteitem.isIncludeSerials = $scope.selectedItemCode.serialItem;
                    vm.receivenoteitem.stockReceiveHeaderId = $rootScope.hId;

                    receivenoteitemService.create(vm.receivenoteitem)
                        .success(function () {

                            $scope.stockLedgerItem.itemCode = vm.receivenoteitem.itemCode;
                            $scope.stockLedgerItem.date = $rootScope.wDate
                            $scope.stockLedgerItem.transactionType = "Stock Receive";
                            $scope.stockLedgerItem.docNo = $rootScope.wReceiveNoteNo;
                            $scope.stockLedgerItem.usedStock = vm.receivenoteitem.nos;                          
                            $scope.stockLedgerItem.status = "Approved";

                            stockLedgerService.create($scope.stockLedgerItem)
                       .success(function () {
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

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();