(function () {
    var controllerId = 'app.views.employees.updatePastEmployment';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.pastEmployeement',
        function ($rootScope, $scope, $state, $stateParams, pastEmploymentService) {
            var vm = this;
            vm.pastEmployment = {};

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };
            $scope.fdate = new Date();
            $scope.tdate = new Date();

            vm.update = function () {
                if ($scope.pastEmploymentUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.pastEmployment.id = $stateParams.id;
                    vm.pastEmployment.employeeId = $rootScope.employeeId;
                    vm.pastEmployment.fromDate = $scope.fdate;
                    vm.pastEmployment.toDate = $scope.tdate;

                    pastEmploymentService.updatePastEmployeement(vm.pastEmployment)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('employeeDetail', { id: $rootScope.employeeId });

                        });
                }
            };


            function loadPastEmployments() {
                pastEmploymentService.getPastEmployeementByID({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.pastEmployment = result;

                });
            }

            vm.back = function () {
                $state.go('employeeDetail', { id: $rootScope.employeeId });
            };


            loadPastEmployments();

        }
    ]);
})();