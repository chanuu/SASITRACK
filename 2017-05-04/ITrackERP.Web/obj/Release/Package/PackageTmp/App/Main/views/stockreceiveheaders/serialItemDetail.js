(function () {
    var controllerId = 'app.views.stockreceiveheaders.serialItemDetail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$modal', '$state', '$stateParams', 'abp.services.app.receiveNoteItem', 'abp.services.app.serialItem',
        function ($rootScope, $scope, $modal, $state, $stateParams, receiveNoteItemService, serialItemService) {
            var vm = this;
            $rootScope.hId = $stateParams.id;

            function loadReceiveNoteItems() {
                receiveNoteItemService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.receivenoteitem = result;
                    $rootScope.hItemCode = vm.receivenoteitem.itemCode;
                });
            }


            vm.back = function () {
                $state.go('stockreceiveheader');
            };

            loadReceiveNoteItems();



            vm.delete = function (serialitem) {
                abp.message.confirm(App.localize('AreYouSureToDeleteSerialItem', serialitem.serialNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            serialItemService.delete({ id: serialitem.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                loadReceiveNoteItems();
                            });
                        }
                    });
            };


            vm.serialItemCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/stockreceiveheaders/createSerialItem.cshtml',
                    controller: 'app.views.stockreceiveheaders.createSerialItem as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    loadReceiveNoteItems();
                });
            };



        }
    ]);
})();