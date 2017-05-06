(function () {
    angular.module('app').controller('app.views.assettransfers.index', [
        '$scope', '$modal', 'abp.services.app.assetTransferHeader',
        function ($scope, $modal, assettransferService) {
            var vm = this;

            vm.assetdisposals = [];

            function getAssetTransferHeader() {
                assettransferService.getAssetTransferHeader({}).success(function (result) {
                    vm.assettransfers = result.items;
                });
            }


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }


            vm.delete = function (assettransfer) {
                abp.message.confirm(App.localize('AreYouSureToDeleteAssetTransfer', assettransfer.transferNoteNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            assettransferService.deleteHeader({ id: assettransfer.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                getAssetTransferHeader();
                            });
                        }
                    });
            };


            vm.assettransferCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/assettransfers/createAssetTransferHeader.cshtml',
                    controller: 'app.views.assettransfers.createAssetTransferHeader as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getAssetTransferHeader();
                });
            };



            getAssetTransferHeader();


        }
    ]);
})();