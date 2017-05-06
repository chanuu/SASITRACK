(function () {
    var controllerId = 'app.views.assettransfers.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.assetTransferHeader',
        function ($scope, $state, $stateParams, assettransferService) {
            var vm = this;

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };

            $scope.fdate = new Date();

            vm.update = function () {
                if ($scope.assetTransferHeaderUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.assettransfer.date = $scope.fdate;

                    assettransferService.updateHeader(vm.assettransfer)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('assettransfer');

                        });
                }
            };


            function loadAssetTransferHeaders() {
                assettransferService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.assettransfer = result;

                });
            }

            vm.back = function () {
                $state.go('assettransfer');
            };


            loadAssetTransferHeaders();

        }
    ]);
})();