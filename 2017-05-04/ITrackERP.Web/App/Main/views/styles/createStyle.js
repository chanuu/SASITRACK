(function () {
    angular.module('app').controller('app.views.styles.createStyle', [
        '$scope', '$modalInstance', 'abp.services.app.style', 'abp.services.app.buyer', 'abp.services.app.department',
        function ($scope, $modalInstance, styleService, buyerService, departmentService) {
            var vm = this;
            $scope.style = {};
            $scope.buyers = [];
            $scope.selectedBuyer = null;
            
            $scope.departments = [];
            $scope.selectedLineNo = null;

            vm.save = function () {
               
                if ($scope.styleCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.style.buyerName = $scope.selectedBuyer.buyerName;
                    vm.style.department = $scope.selectedLineNo.name;

                    styleService.create(vm.style)
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

          
             function getBuyers() {
                 buyerService.getBuyers({}).success(function (result) {

                     $scope.buyers = result.items;
                 });
             }
            getBuyers();
          

            vm.Page = function () {
                $state.go('styles');
            };


            vm.cancel = function () {
                $modalInstance.close();
            };
            
        }
    ]);
})();