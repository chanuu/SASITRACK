(function () {
    angular.module('app').controller('app.views.dailyplanheaders.createDailyPlanItem', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.dailyPlanItem', 'abp.services.app.style',
        function ($rootScope, $scope, $modalInstance, dailyplanitemService, styleService) {
            var vm = this;

            $scope.styles = [];
            $scope.selectedStyle = null;

            vm.save = function () {
                if ($scope.dailyplanitemCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.dailyplanitem.dailyPlanHeaderId = $rootScope.DailyPlanHeaderId;
                    vm.dailyplanitem.styleNo = $scope.selectedStyle.styleNo;

                    dailyplanitemService.create(vm.dailyplanitem)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();
                        });
                }
            };


            function getStyles() {
                styleService.getStyles({}).success(function (result) {
                    vm.styles = result.items;
                });
            }

            getStyles();

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();