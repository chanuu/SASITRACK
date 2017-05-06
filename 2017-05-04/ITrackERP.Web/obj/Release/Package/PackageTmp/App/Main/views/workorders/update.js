(function () {
    var controllerId = 'app.views.workorders.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.workOrder', 'abp.services.app.style',
        function ($scope, $state, $stateParams, workorderService, styleService) {
            var vm = this;
            $scope.styles = [];
            $scope.selectedStyle = null;

            vm.update = function () {

                vm.workOrder.styleId = $scope.selectedStyle.id;
                workorderService.update(vm.workOrder)
               
                    .success(function () {
                        abp.notify.success(App.localize('SavedSuccessfully'));
                        $state.go('styles');

                    });
            };

            function getStyles() {
                styleService.getStyles({}).success(function (result) {

                    vm.styles = result.items;
                });
            };
            function loadOrders() {
                workorderService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.workOrder = result;
                    $scope.selectedStyle = vm.workOrder.style;
                });
            };
            getStyles();

            loadOrders();


        }
    ]);
})();