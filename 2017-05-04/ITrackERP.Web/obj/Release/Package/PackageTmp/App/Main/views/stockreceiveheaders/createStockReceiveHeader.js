(function () {
    angular.module('app').controller('app.views.stockreceiveheaders.createStockReceiveHeader', [
        '$scope', '$modalInstance', 'abp.services.app.stockReceiveHeader', 'abp.services.app.session',
        function ($scope, $modalInstance, stockreceiveheaderService, sessionService) {
            var vm = this;

            $scope.filter = {};
            $scope.dpOpenStatus = {};
            vm.stockreceiveheader = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };

            $scope.rdate = new Date();

            vm.save = function () {

                if ($scope.stockreceiveheaderCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.stockreceiveheader.date = $scope.rdate;

                    sessionService.getCurrentLoginInformations({}).success(function (result) {
                        $scope.currentuser = result;
                    });
                    vm.stockreceiveheader.by = $scope.currentuser.user.name;


                    stockreceiveheaderService.create(vm.stockreceiveheader)
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