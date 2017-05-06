(function () {
    angular.module('app').controller('app.views.employees.createEmployee', [
        '$scope', '$modalInstance', 'abp.services.app.employee', 'abp.services.app.department', 'Upload',
        function ($scope, $modalInstance, employeeService, departmentService, Upload) {
            var vm = this;

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };
            $scope.fdate = new Date();

            $scope.departments = [];
            $scope.selectedLineNo = null;

            vm.save = function () {
                if ($scope.employeeCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.employee.dateOfBirth = $scope.fdate;
                    vm.employee.department = $scope.selectedLineNo.name;

                    if ($scope.file != null)
                    {
                        vm.employee.imagePath = "app/theme/UI/images/Employees/" + $scope.file.name;
                    }
                    else {
                        vm.employee.imagePath = "N/A";
                    }

                    if ($scope.employeeCreateForm.file.$valid && $scope.file) {
                        $scope.upload($scope.file);
                    }

                    employeeService.createEmployee(vm.employee)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };


            $scope.upload = function (file) {
                Upload.upload({
                    url: '/api/upload/',
                    data: { file: file, key: 1}
                }).then(function (resp) {
                   // console.log('Success ' + resp.config.data.file.name + 'uploaded. Response: ' + resp.data);
                }, function (resp) {
                   // console.log('Error status: ' + resp.status);
                }, function (evt) {
                    var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                  //  console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
                });
            };

            function getDepartments() {
                departmentService.getDepartments({}).success(function (result) {
                    vm.departments = result.items;
                });
            }
            getDepartments();

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();