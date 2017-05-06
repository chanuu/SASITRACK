(function () {
    angular.module('app').controller('app.views.employees.createAward', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.award',
        function ($rootScope, $scope, $modalInstance, awardService) {
            var vm = this;
            $scope.award = null;

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };
            $scope.fdate = new Date();

            vm.save = function () {
                if ($scope.awardCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    $scope.award.employeeId = $rootScope.employeeId;
                    $scope.award.awardDate = $scope.fdate;

                    awardService.createAward($scope.award)
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