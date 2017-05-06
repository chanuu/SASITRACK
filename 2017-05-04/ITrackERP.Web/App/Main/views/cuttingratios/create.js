(function () {
    angular.module('app').controller('app.views.cuttingratios.create', [
        '$scope', '$modalInstance', 'abp.services.app.style', 'abp.services.app.cuttingRatio',
        function ($scope, $modalInstance, styleService, ratioService) {
            var vm = this;
            vm.styles = [];
           
            $scope.selectedStyle = null;

            vm.save = function () {

                vm.cuttingRatio.styleId = $scope.selectedStyle.id;
                ratioService.create(vm.cuttingRatio)
                    .success(function () {
                        abp.notify.success(App.localize('SavedSuccessfully'));


                    });
            };


            vm.Page = function () {
                $state.go('styles');
            };

            function getStyles() {
                styleService.getStyles({}).success(function (result) {

                    vm.styles = result.items;
                });
            }
            getStyles();

            //


            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();