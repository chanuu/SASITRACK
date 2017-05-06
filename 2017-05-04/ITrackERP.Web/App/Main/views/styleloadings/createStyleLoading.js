(function () {
    angular.module('app').controller('app.views.styleloadings.createStyleLoading', [
        '$scope', '$modalInstance', 'abp.services.app.styleLoading', 'abp.services.app.style', 'abp.services.app.department',
        function ($scope, $modalInstance, styleloadingService, styleService, departmentService) {
            var vm = this;
            $scope.styleloadings = [];

            $scope.styles = [];
            $scope.styleId = null;
            $scope.selectedStyle = null;

            $scope.selectedLineNo = null;

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };

            $scope.fdate = new Date();
            $scope.tdate = new Date();


            vm.save = function () {
                if ($scope.styleloadingCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.styleloading.styleId = $scope.selectedStyle.id;
                    vm.styleloading.styleNo = $scope.selectedStyle.styleNo;
                    vm.styleloading.lineNo = $scope.selectedLineNo.name;
                    vm.styleloading.fromDate = $scope.fdate;
                    vm.styleloading.toDate = $scope.tdate;


                    styleloadingService.create(vm.styleloading)
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

            //
            $scope.afterSelectedLineNo = function (selected) {
                if (selected) {
                    $scope.selectedLineNo = selected.originalObject;


                }
            }


            function getStyles() {
                styleService.getStyles({}).success(function (result) {

                    vm.styles = result.items;
                });
            }
            getStyles();

            //
            $scope.afterselectedStyle = function (selected) {
                if (selected) {
                    $scope.selectedStyle = selected.originalObject;


                }
            }

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();