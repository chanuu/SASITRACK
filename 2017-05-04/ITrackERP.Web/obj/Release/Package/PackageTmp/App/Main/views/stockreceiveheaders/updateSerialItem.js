(function () {
    var controllerId = 'app.views.stockreceiveheaders.updateSerialItem';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.serialItem', 
        function ($rootScope, $scope, $state, $stateParams, serialitemService) {
            var vm = this;
            

            vm.update = function () {
                if ($scope.serialItemUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.serialitem.receiveNoteItemId = $rootScope.hId;
                    vm.serialitem.itemCode = $rootScope.hItemCode;

                    serialitemService.update(vm.serialitem)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('stockreceiveheader');
                        });
                }
            };

            

            function loadSerialItems() {
                serialitemService.getSerialItemByID({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.serialitem = result;

                });
            }

            vm.back = function () {
                $state.go('stockreceiveheader');
            };


            loadSerialItems();

        }
    ]);
})();