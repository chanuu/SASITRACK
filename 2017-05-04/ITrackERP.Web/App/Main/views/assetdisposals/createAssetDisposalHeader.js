(function () {
    angular.module('app').controller('app.views.assetdisposals.createAssetDisposalHeader', [
        '$scope', '$modalInstance', 'abp.services.app.assetDisposalHeader', 'abp.services.app.session',
        function ($scope, $modalInstance, assetdisposalService, sessionService) {
            var vm = this;
            $scope.assetdisposals = [];
            $scope.currentuser = {};

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };
            $scope.fdate = new Date();

            vm.save = function () {              
                if ($scope.assetdisposalCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.assetdisposal.date = $scope.fdate;

                    sessionService.getCurrentLoginInformations({}).success(function (result) {
                        $scope.currentuser = result;
                    });
                    vm.assetdisposal.disposalBy = $scope.currentuser.user.name;

                    assetdisposalService.createHeader(vm.assetdisposal)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };


            $scope.afterSelectedAssetDisposalHeader = function (selected) {
                if (selected) {
                    $scope.afterSelectedAssetDisposalHeader = selected.originalObject;


                }
            }

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();