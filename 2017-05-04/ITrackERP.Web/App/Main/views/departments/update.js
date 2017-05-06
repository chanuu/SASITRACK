(function () {
    var controllerId = 'app.views.departments.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.department',
        function ($scope, $state, $stateParams, departmentService) {
            var vm = this;
           
            vm.update = function () {
                if ($scope.departmentUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    departmentService.update(vm.department)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('departments');

                        });
                }
            };

           
            

            function loadDepartments() {
                departmentService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.department = result;
                });
            }


            vm.backToEventsPage = function () {
                $state.go('departments');
            };

            loadDepartments();


        }
    ]);
})();