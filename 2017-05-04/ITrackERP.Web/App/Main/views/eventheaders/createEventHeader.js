(function () {
    angular.module('app').controller('app.views.eventheaders.createEventHeader', [
        '$scope', '$modalInstance', 'abp.services.app.eventHeader', 'abp.services.app.department',
        function ($scope, $modalInstance, eventheaderService, departmentService) {
            var vm = this;

            $scope.departments = [];
            $scope.selectedLineNo = null;

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };
            $scope.fdate = new Date();
            $scope.edate = new Date();

            vm.save = function () {

                if ($scope.eventheaderCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.eventheader.date = $scope.fdate;
                    vm.eventheader.expectedDate = $scope.edate;
                    vm.eventheader.department = $scope.selectedLineNo.name;

                    eventheaderService.create(vm.eventheader)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
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