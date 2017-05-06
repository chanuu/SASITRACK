(function () {
    angular.module('app').controller('app.views.stockreceiveheaders.createSerialItem', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.serialItem',
        function ($rootScope, $scope, $modalInstance, serialitemService) {
            var vm = this;

            $scope.filter = {};
       
            
            vm.save = function () {
                if ($scope.serialItemCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.serialitem.receiveNoteItemId = $rootScope.hId;
                    vm.serialitem.itemCode = $rootScope.hItemCode;

                    serialitemService.create(vm.serialitem)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();
                        });
                }
            };


            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();