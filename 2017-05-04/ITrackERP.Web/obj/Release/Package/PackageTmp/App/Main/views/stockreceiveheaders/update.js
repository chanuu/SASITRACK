(function () {
    var controllerId = 'app.views.stockreceiveheaders.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.stockReceiveHeader',
        function ($scope, $state, $stateParams, stockReceiveHeaderService) {
            var vm = this;

            vm.update = function () {
                if ($scope.stockreceiveheaderUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    stockReceiveHeaderService.update(vm.stockReceiveHeader)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('stockreceiveheader');

                        });
                }
            };

            function loadStockReceiveHeaders() {
                stockReceiveHeaderService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.stockReceiveHeader = result;
                });
            }


            vm.backToEventsPage = function () {
                $state.go('stockreceiveheader');
            };

            loadStockReceiveHeaders();


        }
    ]);
})();