(function () {
    var controllerId = 'app.views.stockreceiveheaders.updateReceiveNoteItems';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.receiveNoteItem', 'abp.services.app.itemMaster',
        function ($rootScope, $scope, $state, $stateParams, receivenoteitemService, itemmasterService) {
            var vm = this;
            vm.stockreceiveheader = {};

            $scope.itemmasters = [];
            $scope.selectedItemCode = null;

            vm.update = function () {
                if ($scope.receiveNoteItemUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    
                    vm.receivenoteitem.itemCode = $scope.selectedItemCode.itemNo;
                    vm.receivenoteitem.itemMasterId = $scope.selectedItemCode.id;
                    vm.receivenoteitem.isIncludeSerials = $scope.selectedItemCode.serialItem;
                    vm.receivenoteitem.stockReceiveHeaderId = $rootScope.hId;

                    receivenoteitemService.update(vm.receivenoteitem)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('stockreceiveheader');

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

            function loadReceiveNoteItems() {
                receivenoteitemService.getReceiveNoteItemsByID({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.receivenoteitem = result;
                   // $scope.selectedItemCode = vm.receivenoteitem.itemCode;

                    itemmasterService.getDetailByItemCode({
                        itemNo: vm.receivenoteitem.itemCode
                    }).success(function (result) {
                        $scope.selectedItemCode = result;
                    });
                    
                });
            }

            vm.back = function () {
                $state.go('stockreceiveheader');
            };


            loadReceiveNoteItems();

        }
    ]);
})();