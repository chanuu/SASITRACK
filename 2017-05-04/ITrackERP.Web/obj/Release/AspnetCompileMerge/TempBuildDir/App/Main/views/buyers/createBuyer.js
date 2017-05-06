(function () {
    angular.module('app').controller('app.views.buyers.createBuyer', [
        '$scope', '$modalInstance', 'abp.services.app.buyer',
        function ($scope, $modalInstance,buyerService) {
            var vm = this;
         
           
           
            vm.save = function () {

                buyerService.create(vm.buyerProfile)
                    .success(function () {
                        abp.notify.success(App.localize('SavedSuccessfully'));
                        $modalInstance.close();
                       
                    });
            };



            vm.cancel = function () {
                $modalInstance.close();
            };
            
        }
    ]);
})();