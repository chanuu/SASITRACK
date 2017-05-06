(function () {
    var controllerId = 'app.views.dailyplanheaders.updateItem';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.dailyPlanItem', 'abp.services.app.style',
        function ($rootScope, $scope, $state, $stateParams, dailyplanitemService, styleService) {
            var vm = this;
            vm.dailyplanitem = {};

            $scope.selectedStyle = null;

            vm.update = function () {
                if ($scope.dailyplanitemUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.dailyplanitem.styleNo = $scope.selectedStyle.styleNo;
                    vm.dailyplanitem.id = $stateParams.id;
                    vm.dailyplanitem.dailyPlanHeaderId = $rootScope.DailyPlanHeaderId;

                    dailyplanitemService.update(vm.dailyplanitem)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('dailyplanheaderDetail', { id: $rootScope.DailyPlanHeaderId });
                        });
                }
            };


            function getStyles() {
                styleService.getStyles({}).success(function (result) {

                    vm.styles = result.items;
                });
            }
            getStyles();

            function loadDailyPlanItems() {
                dailyplanitemService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.dailyplanitem = result;

                    styleService.getDetailByStyleNo({
                        styleNo: vm.dailyplanitem.styleNo
                    }).success(function (result) {
                        $scope.selectedStyle = result;
                    });

                });
            }

            vm.back = function () {
                $state.go('dailyplanheaderDetail', { id: $rootScope.DailyPlanHeaderId });
            };


            loadDailyPlanItems();

        }
    ]);
})();