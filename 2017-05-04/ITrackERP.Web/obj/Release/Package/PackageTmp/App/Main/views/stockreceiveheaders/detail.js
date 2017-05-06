(function () {
    var controllerId = 'app.views.stockreceiveheaders.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$modal', '$state', '$stateParams', 'abp.services.app.stockReceiveHeader', 'abp.services.app.receiveNoteItem', 'abp.services.app.stockLedger',
        function ($rootScope, $scope, $modal, $state, $stateParams, stockReceiveHeaderService, receiveNoteItemService, stockLedgerService) {
            var vm = this;
            $rootScope.hId = $stateParams.id;

            $scope.stockLedgerItem = {};

            function loadStockReceiveHeaders() {
                stockReceiveHeaderService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.stockreceiveheader = result;
                    $rootScope.wDate = vm.stockreceiveheader.date;
                    $rootScope.wReceiveNoteNo = vm.stockreceiveheader.receiveNoteNo;
                });
            }


            vm.backToEventsPage = function () {
                $state.go('stockreceiveheader');
            };

            loadStockReceiveHeaders();

            vm.delete = function (stockreceiveheader) {
                abp.message.confirm(App.localize('AreYouSureToDeleteReceiveNoteItem'+ stockreceiveheader.itemCode),
                    function (isConfirmed) {
                        if (isConfirmed) {

                            $scope.stockLedgerItem.itemCode = stockreceiveheader.itemCode;
                            $scope.stockLedgerItem.date = $rootScope.wDate
                            $scope.stockLedgerItem.transactionType = "Stock Cancel";
                            $scope.stockLedgerItem.docNo = $rootScope.wReceiveNoteNo;
                            $scope.stockLedgerItem.usedStock = stockreceiveheader.nos;
                            $scope.stockLedgerItem.status = "Approved";
                           
                            stockLedgerService.create($scope.stockLedgerItem)
                       .success(function () {
                       });

                            receiveNoteItemService.delete({ id: stockreceiveheader.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                loadStockReceiveHeaders();
                            });
                        }
                    });
            };


            vm.receiveNoteItemCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/stockreceiveheaders/createReceiveNoteItem.cshtml',
                    controller: 'app.views.stockreceiveheaders.createReceiveNoteItem as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    loadStockReceiveHeaders();
                });
            };
        }
    ]);
})();