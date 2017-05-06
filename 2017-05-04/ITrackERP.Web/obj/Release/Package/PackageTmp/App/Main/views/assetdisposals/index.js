(function () {
    angular.module('app').controller('app.views.assetdisposals.index', [
        '$scope', '$modal', 'abp.services.app.assetDisposalHeader',
        function ($scope, $modal, assetdisposalService) {
            var vm = this;

            vm.assetdisposals = [];

            function getAssetDisposalHeader() {
                assetdisposalService.getAssetDisposalHeader({}).success(function (result) {
                    vm.assetdisposals = result.items;
                });
            }


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }



            vm.delete = function (assetdisposal) {
                abp.message.confirm(App.localize('AreYouSureToDeleteAssetDisposal', assetdisposal.disposalNoteNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            assetdisposalService.deleteHeader({ id: assetdisposal.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                getAssetDisposalHeader();
                            });
                        }
                    });
            };


           
            vm.assetdisposalCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/assetdisposals/createAssetDisposalHeader.cshtml',
                    controller: 'app.views.assetdisposals.createAssetDisposalHeader as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getAssetDisposalHeader();
                });
            };



            getAssetDisposalHeader();


        }
    ]);
})();