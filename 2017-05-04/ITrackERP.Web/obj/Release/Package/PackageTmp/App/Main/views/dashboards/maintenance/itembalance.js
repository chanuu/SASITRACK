(function () {
    angular.module('app').controller('app.views.dashboards.maintenance.itembalance', [
        '$scope', '$modal', 'abp.services.app.stockLedger','abp.services.app.itemMaster',
        function ($scope, $modal, stockLedgerService, itemmasterService) {
            var vm = this;

            vm.stockledgeritems = [];

            vm.reportitems = [];
            vm.reportitem = {};
            vm.items = {};

            
            function getItems() {
                stockLedgerService.getItemBalance({}).success(function (result) {
                    vm.stockledgeritems = result.items;
                   
                    angular.forEach(vm.stockledgeritems, function (item) {
                          
                        vm.reportitem = {};
                                                          
                        vm.reportitem.itemCode = item.itemCode;
                        vm.reportitem.balanceStock = item.balanceStock;

                        itemmasterService.getDetailByItemCode({ itemNo: item.itemCode }).success(function (result) {
                                vm.items = {};
                                vm.items = result;

                               // console.log(vm.items.status);

                                vm.reportitem.status = vm.items.status;
                                vm.reportitem.itemType = vm.items.itemType;
                            });
                        

                        vm.reportitems.push(vm.reportitem);

                    });

                    
                });
              
            }

            getItems();

            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }

          
        }
    ]);
})();