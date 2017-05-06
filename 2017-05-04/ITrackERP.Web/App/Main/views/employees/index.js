(function () {
    angular.module('app').controller('app.views.employees.index', [
        '$scope', '$modal', 'abp.services.app.employee', '$http',
        function ($scope, $modal, employeeService, $http) {
            var vm = this;

            vm.employees = [];

            function getEmployee() {
                employeeService.getEmployee({}).success(function (result) {
                    vm.employees = result.items;
                });
            }


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }



            vm.delete = function (employee) {
                abp.message.confirm(App.localize('AreYouSureToDeleteEmployee' + employee.epfNo),
                    function (isConfirmed) {
                        if (isConfirmed) {

                            $http.delete('/api/Upload/' + employee.id + '/1').then(function (data) {
                                employeeService.deleteEmployee({ id: employee.id }).success(function () {
                                    abp.notify.success(App.localize('SuccessfullyDeleted'));
                                    getEmployee();
                                });

                            }).catch(function (data) {
                                $scope.error = "An error has occured while deleting file! " + data;
                            });
                           
                        }
                    });
            };



            vm.employeeCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/employees/createEmployee.cshtml',
                    controller: 'app.views.employees.createEmployee as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getEmployee();
                });
            };



            getEmployee();


        }
    ]);
})();