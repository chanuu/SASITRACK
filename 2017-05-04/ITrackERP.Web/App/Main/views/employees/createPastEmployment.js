(function () {
    angular.module('app').controller('app.views.employees.createPastEmployment', ['$rootScope','$modal',
        '$scope', '$modalInstance', 'abp.services.app.pastEmployeement',
        function ($rootScope,$modal, $scope, $modalInstance, pastEmploymentService) {
            var vm = this;
            $scope.pastEmployment = null;

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };
            $scope.fdate = new Date();
            $scope.tdate = new Date();

            vm.save = function () {
                if ($scope.pastEmploymentCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    $scope.pastEmployment.employeeId = $rootScope.employeeId;
                    $scope.pastEmployment.fromDate = $scope.fdate;
                    $scope.pastEmployment.toDate = $scope.tdate;

                    pastEmploymentService.createPastEmployeement($scope.pastEmployment)
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