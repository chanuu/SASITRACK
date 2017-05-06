(function () {
    angular.module('app').controller('app.views.departments.index', [
        '$scope', '$modal', 'abp.services.app.department',
        function ($scope, $modal, departmentService) {
            var vm = this;

            vm.departments = [];

            function GetDepartments() {
                departmentService.getDepartments({}).success(function (result) {
                    vm.departments = result.items;
                });
            };


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            };



            vm.delete = function (department) {
                abp.message.confirm(App.localize('AreYouSureToDeleteDepartment'+ department.name),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            departmentService.delete({ id: department.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                GetDepartments();
                            });
                        }
                    });
            };

            vm.departmentCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/departments/createDepartment.cshtml',
                    controller: 'app.views.departments.createDepartment as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    GetDepartments();
                });
            };



            GetDepartments();


        }
    ]);
})();