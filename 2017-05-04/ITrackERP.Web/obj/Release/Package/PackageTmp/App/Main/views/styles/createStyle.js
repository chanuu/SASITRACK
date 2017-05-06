(function () {
    angular.module('app').controller('app.views.styles.createStyle', [
        '$scope', '$modalInstance', 'abp.services.app.style', 'abp.services.app.buyer',
        function ($scope, $modalInstance, styleService,buyerService) {
            var vm = this;
            $scope.styles = [];
            $scope.buyers = [];
            $scope.selectedBuyer = null;
            
            vm.save = function () {
               
               
                    vm.style.buyerName = $scope.selectedBuyer.buyerName;
                    styleService.create(vm.style)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));


                        });
             
            };


            vm.Page = function () {
                $state.go('styles');
            };

             function getBuyers() {
                 buyerService.getBuyers({}).success(function (result) {

                     $scope.buyers = result.items;
                 });
             }
            getBuyers();
          
            //
            

            vm.cancel = function () {
                $modalInstance.close();
            };
            
        }
    ]);
})();