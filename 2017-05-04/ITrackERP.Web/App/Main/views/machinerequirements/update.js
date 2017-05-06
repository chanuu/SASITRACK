(function () {
    var controllerId = 'app.views.machinerequirements.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.machineRequirement', 'abp.services.app.style','abp.services.app.department',
        function ($scope, $state, $stateParams, machinerequirementService, styleService, departmentService) {
            var vm = this;
            $scope.styles = [];
            $scope.selectedStyle = null;

            $scope.filter = {};
            $scope.dpOpenStatus2 = {};
            $scope.selectedLineNo = null;

            $scope.setDpOpenStatus2 = function (id) {
                $scope.dpOpenStatus2[id] = true
            };

            $scope.fdate = new Date();
            $scope.tdate = new Date();

            vm.update = function () {
                if ($scope.machineRequirementUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.machinerequirement.styleId = $scope.selectedStyle.id;
                    vm.machinerequirement.styleNo = $scope.selectedStyle.styleNo;
                    vm.machinerequirement.fromDate = $scope.fdate;
                    vm.machinerequirement.toDate = $scope.tdate;
                    vm.machinerequirement.lineNo = $scope.selectedLineNo.name;
                    machinerequirementService.updateHeader(vm.machinerequirement)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('machinerequirement');

                        });
                }
            };

            function getStyles() {
                styleService.getStyles({}).success(function (result) {

                    vm.styles = result.items;
                });
            };
            function loadMachineRequirements() {
                machinerequirementService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.machinerequirement = result;

                    styleService.getDetailByStyleNo({
                        styleNo: vm.machinerequirement.styleNo
                    }).success(function (result) {
                        $scope.selectedStyle = result;
                    });


                    departmentService.getDetailByLineNo({
                        name: vm.machinerequirement.lineNo
                    }).success(function (result) {
                        $scope.selectedLineNo = result;
                    });


                });
            };


            function getDepartments() {
                departmentService.getDepartments({}).success(function (result) {

                    vm.departments = result.items;
                });
            }
            getDepartments();

            vm.back = function () {
                $state.go('machinerequirement');
            };


            getStyles();

            loadMachineRequirements();


        }
    ]);
})();