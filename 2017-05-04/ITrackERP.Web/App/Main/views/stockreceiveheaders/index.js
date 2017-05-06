(function () {
    angular.module('app').controller('app.views.stockreceiveheaders.index', [
        '$scope', '$modal', 'abp.services.app.stockReceiveHeader',
        function ($scope, $modal, stockReceiveHeaderService) {
            var vm = this;

            vm.stockReceiveHeaders = [];

            function getstockReceiveHeader() {
                stockReceiveHeaderService.getStockReceiveHeader({}).success(function (result) {
                    vm.stockReceiveHeaders = result.items;
                });
            }


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }



            vm.delete = function (stockReceiveHeader) {
                abp.message.confirm(App.localize('AreYouSureToDeleteStockReceiveHeader' + stockReceiveHeader.receiveNoteNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            stockReceiveHeaderService.delete({ id: stockReceiveHeader.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                getstockReceiveHeader();
                            });
                        }
                    });
            };



            vm.stockreceiveheaderCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/stockreceiveheaders/createStockReceiveHeader.cshtml',
                    controller: 'app.views.stockreceiveheaders.createStockReceiveHeader as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getstockReceiveHeader();
                });
            };



            getstockReceiveHeader();


        }
    ]);
})();