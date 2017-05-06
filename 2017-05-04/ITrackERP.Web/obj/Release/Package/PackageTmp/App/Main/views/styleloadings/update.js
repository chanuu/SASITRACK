(function () {
    var controllerId = 'app.views.styleloadings.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.styleLoading', 'abp.services.app.style', 'abp.services.app.department',
        function ($scope, $state, $stateParams, styleloadingService, styleService, departmentService) {
            var vm = this;
            $scope.styles = [];
            $scope.selectedStyle = null;

            $scope.departments = [];
            $scope.selectedLineNo = null;

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };

            $scope.fdate = new Date();
            $scope.tdate = new Date();

            vm.update = function () {
                if ($scope.styleloadingUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    
                    vm.styleloading.styleId = $scope.selectedStyle.id;
                    vm.styleloading.styleNo = $scope.selectedStyle.styleNo;
                    vm.styleloading.lineNo = $scope.selectedLineNo.name;
                    vm.styleloading.fromDate = $scope.fdate;
                    vm.styleloading.toDate = $scope.tdate;

                    styleloadingService.update(vm.styleloading)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('styleloading');

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

            function loadStyleLoadings() {
                styleloadingService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.styleloading = result;
                    $scope.selectedStyle = vm.styleloading.style;
                });
            };


            vm.back = function () {
                $state.go('styleloading');
            };


            getStyles();

            loadStyleLoadings();


        }
    ]);
})();