(function () {
    angular.module('app').controller('app.views.dividingplans.createDividingPlanHeader', [
        '$scope', '$modalInstance', 'abp.services.app.dividingPlanHeader', 'abp.services.app.style', 'abp.services.app.department',
        function ($scope, $modalInstance, dividingplanService, styleService, departmentService) {
            var vm = this;
            $scope.dividingplans = [];

            $scope.styles = [];
            $scope.styleId = null;
            $scope.selectedStyle = null;



            $scope.departments = [];
            $scope.selectedLineNo = null;


            vm.save = function () {
                if ($scope.dividingplanCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.dividingplan.styleId = $scope.selectedStyle.id;
                    vm.dividingplan.lineNo = $scope.selectedLineNo.name;
                    dividingplanService.createHeader(vm.dividingplan)
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
            $scope.afterSelectedDividingPlanHeader = function (selected) {
                if (selected) {
                    $scope.afterSelectedDividingPlanHeader = selected.originalObject;


                }
            }

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();