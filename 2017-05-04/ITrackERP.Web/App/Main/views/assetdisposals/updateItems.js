(function () {
    var controllerId = 'app.views.assetdisposals.updateItems';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.assetDisposalHeader', 'abp.services.app.asset',
        function ($rootScope, $scope, $state, $stateParams, assetdisposalService, assetService) {
            var vm = this;
            vm.assetdisposal = {};

            $scope.assets = [];
            $scope.selectedAssetNo = null;

            vm.update = function () {
                if ($scope.assetDisposalHeaderDetailUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.assetdisposal.id = $stateParams.id;
                    vm.assetdisposal.assetDisposalHeaderId = $rootScope.hId;
                    vm.assetdisposal.assetNo = $scope.selectedAssetNo.assetNo;
                    assetdisposalService.updateDetail(vm.assetdisposal)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('assetdisposal');

                        });
                }
            };

            function getAssets() {
                assetService.getAsset({}).success(function (result) {

                    vm.assets = result.items;
                });
            }
            getAssets();

            //
            $scope.afterSelectedAssetNos = function (selected) {
                if (selected) {
                    $scope.selectedAssetNo = selected.originalObject;
                }
            }

            function loadAssetDisposalHeaders() {
                assetdisposalService.getAssetDisposalDetailsByID({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.assetdisposal = result;

                    assetService.getDetailByAssetNo({
                        assetNo: vm.assetdisposal.assetNo
                    }).success(function (result) {
                        $scope.selectedAssetNo = result;
                    });

                });
            }

            vm.back = function () {
                $state.go('assetdisposal');
            };


            loadAssetDisposalHeaders();

        }
    ]);
})();