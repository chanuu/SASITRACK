(function () {
    var controllerId = 'app.views.employees.updatePromotion';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.promotion',
        function ($rootScope, $scope, $state, $stateParams, promotionService) {
            var vm = this;
            vm.promotion = {};

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };
            $scope.fdate = new Date();

            vm.update = function () {
                if ($scope.promotionUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.promotion.id = $stateParams.id;
                    vm.promotion.employeeId = $rootScope.employeeId;
                    vm.promotion.promotedDate = $scope.fdate;

                    promotionService.updatePromotion(vm.promotion)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('employeeDetail', { id: $rootScope.employeeId });

                        });
                }
            };


            function loadPromotions() {
                promotionService.getPromotionByID({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.promotion = result;

                });
            }

            vm.back = function () {
                $state.go('employeeDetail', { id: $rootScope.employeeId });
            };


            loadPromotions();

        }
    ]);
})();