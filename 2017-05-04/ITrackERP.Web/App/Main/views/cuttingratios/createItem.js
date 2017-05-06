(function () {
    angular.module('app').controller('app.views.cuttingratios.createItem', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.cuttingRatio',
        function ($rootScope, $scope, $modalInstance, cuttingRatioAppService) {
            var vm = this;
            $scope.item = {};
            vm.save = function () {
                if ($scope.ratioForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                   
                    $scope.item.cuttingRatioId = $rootScope.ratioId;
                    cuttingRatioAppService.createItem($scope.item)
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