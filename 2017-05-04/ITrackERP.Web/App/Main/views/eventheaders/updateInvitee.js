(function () {
    var controllerId = 'app.views.eventheaders.updateInvitee';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.invitee', 'abp.services.app.employee',
        function ($rootScope, $scope, $state, $stateParams, inviteeService, employeeService) {
            var vm = this;
            vm.invitee = {};
            vm.employees = [];
            $scope.selectedEmployee = null;

            vm.update = function () {
                if ($scope.inviteeUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    
                    vm.invitee.eventHeaderId = $rootScope.eventHeaderId;
                    vm.invitee.name = $scope.selectedEmployee.fullName;

                    inviteeService.update(vm.invitee)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('eventheaderDetail', { id: $rootScope.eventHeaderId });

                        });
                }
            };

            function getEmployees() {
                employeeService.getEmployee({}).success(function (result) {
                    vm.employees = result.items;
                });
            }
            getEmployees();

            function loadInvitees() {
                inviteeService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.invitee = result;

                    employeeService.getDetailByFullName({
                        fullName: vm.invitee.name
                    }).success(function (result) {
                        $scope.selectedEmployee = result;
                    });

                });
            }

            vm.back = function () {
                $state.go('eventheaderDetail', { id: $rootScope.eventHeaderId });
            };


            loadInvitees();

        }
    ]);
})();