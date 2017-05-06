(function () {
    var controllerId = 'app.views.departments.detail';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.department',
        function ($scope, $state, $stateParams, departmentService) {
            var vm = this;

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