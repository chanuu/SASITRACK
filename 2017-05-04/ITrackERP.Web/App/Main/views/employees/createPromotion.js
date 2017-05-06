(function () {
    angular.module('app').controller('app.views.employees.createPromotion', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.promotion',
        function ($rootScope, $scope, $modalInstance, promotionService) {
            var vm = this;
            $scope.award = null;

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };
            $scope.fdate = new Date();

            vm.save = function () {
                if ($scope.promotionCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    $scope.promotion.employeeId = $rootScope.employeeId;
                    $scope.promotion.promotedDate = $scope.fdate;

                    promotionService.createPromotion($scope.promotion)
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