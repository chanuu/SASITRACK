(function () {
    angular.module('app').controller('app.views.workorders.createWorkOrder', [
        '$scope', '$modalInstance', 'abp.services.app.workOrder', 'abp.services.app.style',
        function ($scope, $modalInstance, workoderService, styleService) {
            var vm = this;
            $scope.workorders = [];
            $scope.styles = [];
            $scope.styleId = null;
            $scope.selectedStyle = null;

            vm.save = function () {

                vm.workOrder.styleId = $scope.selectedStyle.id;
                vm.workOrder.styleNo = $scope.selectedStyle.styleNo;
                workoderService.create(vm.workOrder)
                    .success(function () {
                        abp.notify.success(App.localize('SavedSuccessfully'));
                        $modalInstance.close();

                    });
            };

           

            function getStyles() {
                styleService.getStyles({}).success(function (result) {

                    vm.styles = result.items;
                });
            }
            getStyles();

            //
            $scope.afterSelectedWorkOrder = function (selected) {
                if (selected) {
                    $scope.selectedWorkOrder = selected.originalObject;


                }
            }

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();