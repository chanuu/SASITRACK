(function () {
    var controllerId = 'app.views.styles.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.style', 'abp.services.app.department', 'abp.services.app.buyer',
        function ($scope, $state, $stateParams, styleService, departmentService, buyerService) {
            var vm = this;

            $scope.buyers = [];
            $scope.selectedBuyer = null;

            $scope.departments = [];
            $scope.selectedLineNo = null;

            vm.update = function () {

                if ($scope.styleUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.style.department = $scope.selectedLineNo.name;
                    vm.style.buyerName = $scope.selectedBuyer.buyerName;
                styleService.update(vm.style)
                    .success(function () {
                        abp.notify.success(App.localize('SavedSuccessfully'));
                        $state.go('styles');

                    });
                    }
            };


            function loadStyles() {
                styleService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.style = result;


                    departmentService.getDetailByLineNo({
                        name: vm.style.department
                    }).success(function (result) {
                        $scope.selectedLineNo = result;
                    });

                    buyerService.getDetailByName({
                        buyerName: vm.style.buyerName
                    }).success(function (result) {
                        $scope.selectedBuyer = result;
                    });

                });
            }


            function getDepartments() {
                departmentService.getDepartments({}).success(function (result) {

                    vm.departments = result.items;
                });
            }
            getDepartments();


            function getBuyers() {
                buyerService.getBuyers({}).success(function (result) {

                    $scope.buyers = result.items;
                });
            }
            getBuyers();


            vm.backToEventsPage = function () {
                $state.go('styles');
            };

            loadStyles();


        }
    ]);
})();