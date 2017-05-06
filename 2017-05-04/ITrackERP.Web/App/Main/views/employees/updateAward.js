(function () {
    var controllerId = 'app.views.employees.updateAward';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.award',
        function ($rootScope, $scope, $state, $stateParams, awardService) {
            var vm = this;
            vm.award = {};

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };
            $scope.fdate = new Date();

            vm.update = function () {
                if ($scope.awardUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.award.id = $stateParams.id;
                    vm.award.employeeId = $rootScope.employeeId;
                    vm.award.awardDate = $scope.fdate;

                    awardService.updateAward(vm.award)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('employeeDetail', { id: $rootScope.employeeId });

                        });
                }
            };


            function loadAwards() {
                awardService.getAwardByID({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.award = result;
                    
                });
            }

            vm.back = function () {
                $state.go('employeeDetail', { id: $rootScope.employeeId });
            };


            loadAwards();

        }
    ]);
})();