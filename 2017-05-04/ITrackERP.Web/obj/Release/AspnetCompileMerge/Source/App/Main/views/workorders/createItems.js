(function () {
    angular.module('app').controller('app.views.workorders.createItems', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.workOrder',
        function ($rootScope, $scope, $modalInstance, workoderService) {
            var vm = this;
            $scope.workrOderRatio = null;

            vm.save = function () {

                $scope.workrOderRatio.workOrderHeaderId = $rootScope.wId;
                workoderService.createItem($scope.workrOderRatio)
                    .success(function () {
                        abp.notify.success(App.localize('SavedSuccessfully'));
                        $modalInstance.close();

                    });
            };




            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();