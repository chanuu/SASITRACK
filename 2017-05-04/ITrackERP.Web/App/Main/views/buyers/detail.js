(function () {
    var controllerId = 'app.views.buyers.detail';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.buyer',
        function ($scope, $state, $stateParams, buyerService) {
            var vm = this;

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