(function () {
    var controllerId = 'app.views.dividingplans.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.dividingPlanHeader', 'abp.services.app.style', 'abp.services.app.department',
        function ($scope, $state, $stateParams, dividingplanheaderService, styleService, departmentService) {
            var vm = this;
            $scope.styles = [];
            vm.dividingplan = {};
           

            $scope.departments = [];
            $scope.selectedLineNo = null;


            vm.update = function () {
                if ($scope.dividingPlanHeaderUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.dividingplan.styleId = $scope.selectedStyle.id;
                    vm.dividingplan.lineNo = $scope.selectedLineNo.name;
                    dividingplanheaderService.updateHeader(vm.dividingplan)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('dividingplan');

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
            };
            function loadDividingplans() {
                dividingplanheaderService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.dividingplan = result;
                    
                    styleService.getDetail({
                        id: vm.dividingplan.styleId
                    }).success(function (result) {
                        $scope.selectedStyle = result;
                    });


                    departmentService.getDetailByLineNo({
                        name: vm.dividingplan.lineNo
                    }).success(function (result) {
                        $scope.selectedLineNo = result;
                    });

                });
            };


            vm.back = function () {
                $state.go('dividingplan');
            };


            getStyles();

            loadDividingplans();


        }
    ]);
})();