(function () {
    var controllerId = 'app.views.assetdisposals.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.assetDisposalHeader', 
        function ($scope, $state, $stateParams, assetdisposalService) {
            var vm = this;

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };
            $scope.fdate = new Date();

            vm.update = function () {
                if ($scope.assetDisposalHeaderUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.assetdisposal.date = $scope.fdate;
                    assetdisposalService.updateHeader(vm.assetdisposal)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('assetdisposal');

                        });
                }
            };


            function loadAssetDisposalHeaders() {
                assetdisposalService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.assetdisposal = result;

                });
            }
            
            vm.back = function () {
                $state.go('assetdisposal');
            };


            loadAssetDisposalHeaders();

        }
    ]);
})();