(function () {
    var controllerId = 'app.views.employees.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.employee', 'abp.services.app.department','$http','Upload',
        function ($scope, $state, $stateParams, employeeService, departmentService, $http, Upload) {
            var vm = this;

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };
            $scope.fdate = new Date();

            $scope.departments = [];
            $scope.selectedLineNo = null;

            vm.update = function () {
                if ($scope.employeeUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.employee.date = $scope.fdate;
                    vm.employee.department = $scope.selectedLineNo.name;

                    /*
                    if ($scope.file != null) {
                        vm.employee.imagePath = "app/theme/UI/images/Employees/" + $scope.file.name;
                    }
                    else {
                        vm.employee.imagePath = "N/A";
                    }

                    if ($scope.employeeUpdateForm.file.$valid && $scope.file) {
                        $scope.upload($scope.file);
                    }
                    */

                    if (vm.employee.imagePath != "N/A") {
                        vm.employee.imagePath = vm.employee.imagePath;

                    }
                    else if ($scope.employeeUpdateForm.file.$dirty && $scope.file) {
                        vm.employee.imagePath = "app/theme/UI/images/Employees/" + $scope.file.name;
                    }
                    else {
                        vm.employee.imagePath = "N/A";
                    }

                    if ($scope.employeeUpdateForm.file.$valid && $scope.file && $scope.employeeUpdateForm.file.$dirty) {
                        $scope.upload($scope.file);
                    }

                    employeeService.updateEmployee(vm.employee)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('employees');

                        });
                }
            };

            function loadEmployees() {
                employeeService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.employee = result;

                    departmentService.getDetailByLineNo({
                        name: vm.employee.department
                    }).success(function (result) {
                        $scope.selectedLineNo = result;
                    });


                });
            }



            $scope.upload = function (file) {
                Upload.upload({
                    url: '/api/upload/',
                    data: { file: file, key: 1 }
                }).then(function (resp) {
                    // console.log('Success ' + resp.config.data.file.name + 'uploaded. Response: ' + resp.data);
                }, function (resp) {
                    // console.log('Error status: ' + resp.status);
                }, function (evt) {
                    var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                    //  console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
                });
            };

            vm.deleteEmployeeImage = function (employee) {
                abp.message.confirm(App.localize('AreYouSureToDeleteEmployeeImage' + employee.name),
                    function (isConfirmed) {
                        if (isConfirmed) {

                            $http.delete('/api/Upload/' + employee.id + '/1').then(function (data) {

                                employee.imagePath = "N/A";
                                employeeService.updateEmployee(employee)
                        .success(function () {
                            abp.notify.success(App.localize('DeletedSuccessfully'));
                            loadEmployees();

                        });


                            }).catch(function (data) {
                                $scope.error = "An error has occured while deleting file! " + data;
                            });
                        }
                    });

            };



            function getDepartments() {
                departmentService.getDepartments({}).success(function (result) {

                    vm.departments = result.items;
                });
            }
            getDepartments();

            

            vm.back = function () {
                $state.go('employees');
            };

            loadEmployees();


        }
    ]);
})();