(function () {
    var controllerId = 'app.views.buyers.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.buyer',
        function ($scope, $state, $stateParams, buyerService) {
            var vm = this;
            
            vm.update = function () {
                if ($scope.buyerUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    buyerService.update(vm.buyer)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('buyers');

                        });
                }
            };

            function loadBuyers() {
                buyerService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.buyer = result;
                });
            }


            vm.backToEventsPage = function () {
                $state.go('buyers');
            };

            loadBuyers();


        }
    ]);
})();