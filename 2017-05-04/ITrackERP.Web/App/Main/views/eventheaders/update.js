(function () {
    var controllerId = 'app.views.eventheaders.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.eventHeader', 'abp.services.app.department', 
        function ($scope, $state, $stateParams, eventheaderService, departmentService) {
            var vm = this;

            $scope.departments = [];
            $scope.selectedLineNo = null;

            $scope.filter = {};
            $scope.dpOpenStatus = {};
            vm.eventheader = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };
            $scope.fdate = new Date();
            $scope.edate = new Date();

           /* $scope.dateSetUp = function (fdate) {
                vm.eventheader.date = fdate;
            };

            $scope.expectedDateSetUp = function (edate) {
                vm.eventheader.expectedDate = edate;
            };*/

            vm.update = function () {
                if ($scope.eventheaderUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.eventheader.date = $scope.fdate;
                    vm.eventheader.expectedDate = $scope.edate;
                    vm.eventheader.department = $scope.selectedLineNo.name;

                    eventheaderService.update(vm.eventheader)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('eventheaders');

                        });
                }
            };



            function loadEventHeaders() {
                eventheaderService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.eventheader = result;
                 
                    departmentService.getDetailByLineNo({
                        name: vm.eventheader.department
                    }).success(function (result) {
                        $scope.selectedLineNo = result;
                    });


                });
            };

            vm.back = function () {
                $state.go('eventheaders');
            };


            function getDepartments() {
                departmentService.getDepartments({}).success(function (result) {

                    vm.departments = result.items;
                });
            }
            getDepartments();


            loadEventHeaders();


        }
    ]);
})();