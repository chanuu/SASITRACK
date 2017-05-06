(function () {
    var controllerId = 'app.views.issuenoteheaders.updateItem';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.cuttingMaster',
        function ($rootScope, $scope, $state, $stateParams, cuttingmasterService) {
            var vm = this;
            vm.cuttem = {};

            vm.update = function () {
                if ($scope.cuttingItemUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {

                    vm.cuttem.id = $stateParams.id;
                    vm.cuttem.cuttingMasterId = $rootScope.cuttingMasterId;

                    cuttingmasterService.updateItem(vm.cuttem)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                         
                            $state.go('cuttingmasterdetail', { 'id': $rootScope.cuttingMasterId });
                        });
                }
            };


            function loadItems() {
                cuttingmasterService.getItemDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.cuttem = result;
                });
            }


        


            vm.back = function () {
                $state.go('cuttingmasterdetail', { 'id': $rootScope.cuttingMasterId });
            };


            loadItems();

        }
    ]);
})();