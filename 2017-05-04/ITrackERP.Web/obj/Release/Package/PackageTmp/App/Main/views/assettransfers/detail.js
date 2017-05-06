(function () {
    var controllerId = 'app.views.assettransfers.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$modal', '$state', '$stateParams', 'abp.services.app.assetTransferHeader', 'abp.services.app.session', 'abp.services.app.assetLedger',
        function ($rootScope, $scope, $modal, $state, $stateParams, assettransferService, sessionService, assetLedgerService) {
            var vm = this;
            $rootScope.wId = $stateParams.id;
            vm.assetledger = {};


            function loadAssetTransferHeaders() {
                assettransferService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.assettransfer = result;
                    $rootScope.wDate = vm.assettransfer.date;
                    $rootScope.wDocNo = vm.assettransfer.transferNoteNo;
                    $rootScope.wDocType = vm.assettransfer.type;
                    $rootScope.wUsedBy = vm.assettransfer.toLocation;
                });
            }


            vm.back = function () {
                $state.go('assettransfers');
            };

            loadAssetTransferHeaders();



            vm.delete = function (assettransfer) {
                abp.message.confirm(App.localize('AreYouSureToDeleteAssetTransfer', assettransfer.assetNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            assettransferService.deleteDetail({ id: assettransfer.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                loadAssetTransferHeaders();
                            });
                        }
                    });
            };


            vm.update = function (assettransfer) {
                abp.message.confirm(App.localize('AreYouSureToApproveAssetTransfer ' + assettransfer.transferNoteNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            vm.assettransfer.status = "Approved";

                            sessionService.getCurrentLoginInformations({}).success(function (result) {
                                $scope.currentuser = result;
                            });
                            vm.assettransfer.approvedBy = $scope.currentuser.user.name;
                            assettransferService.updateHeader(vm.assettransfer).success(function () {

                                assetLedgerService.updateAssetLedgerByDocNo({
                                  docNo:  vm.assettransfer.transferNoteNo
                                }).success(function (result) {
                                    
                                });

      
                                abp.notify.success(App.localize('SuccessfullyApproved'));
                                loadAssetTransferHeaders();
                            });
                        }
                    });
            };
           
       


            vm.assettransferItemCreationModal = function () {
                if (vm.assettransfer.approvedBy != "N/A") {
                    abp.notify.error(App.localize('You Can Not Create Items'));
                    return;
                }
                else {
                    var modalInstance = $modal.open({
                        templateUrl: '/App/Main/views/assettransfers/createItems.cshtml',
                        controller: 'app.views.assettransfers.createItems as vm',
                        backdrop: 'static'
                    });
                }

                modalInstance.result.then(function () {
                    loadAssetTransferHeaders();
                });
            };



        }
    ]);
})();