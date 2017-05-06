(function () {
    angular.module('app').controller('app.views.departments.createDepartment', [
        '$scope', '$modalInstance', 'abp.services.app.department', 
        function ($scope, $modalInstance, departmentService) {
            var vm = this;
        
            $scope.filter = {};
            vm.save = function () {

                if ($scope.departmentCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    departmentService.create(vm.department)
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