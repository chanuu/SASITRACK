(function () {
    angular.module('app').controller('app.views.eventheaders.createInvitee', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.invitee', 'abp.services.app.employee',
        function ($rootScope, $scope, $modalInstance, inviteeService, employeeService) {
            var vm = this;
            $scope.invitee = null;
            vm.employees = [];
            $scope.selectedEmployee = null;

            
            vm.save = function () {
                if ($scope.inviteeCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    $scope.invitee.eventHeaderId = $rootScope.eventHeaderId;
                    $scope.invitee.name = $scope.selectedEmployee.fullName;

                    inviteeService.create($scope.invitee)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };


            function getEmployees() {
                employeeService.getEmployee({}).success(function (result) {
                    vm.employees = result.items;
                });
            }
            getEmployees();

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();