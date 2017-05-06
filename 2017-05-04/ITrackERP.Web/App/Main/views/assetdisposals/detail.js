(function () {
    var controllerId = 'app.views.assetdisposals.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$modal', '$state', '$stateParams', 'abp.services.app.assetDisposalHeader', 'abp.services.app.session', 'abp.services.app.assetLedger',
        function ($rootScope, $scope, $modal, $state, $stateParams, assetdisposalService, sessionService, assetLedgerService) {
            var vm = this;
            $rootScope.hId = $stateParams.id;

            function loadAssetDisposalHeaders() {
                assetdisposalService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.assetdisposal = result;
                    $rootScope.hDate = vm.assetdisposal.date;
                    $rootScope.hDocNo = vm.assetdisposal.disposalNoteNo;
                });
            }


            vm.back = function () {
                $state.go('assetdisposal');
            };

            loadAssetDisposalHeaders();



            vm.delete = function (assetdisposal) {
                abp.message.confirm(App.localize('AreYouSureToDeleteAssetDisposalDetail'+ assetdisposal.assetNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            assetdisposalService.deleteDetail({ id: assetdisposal.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                loadAssetDisposalHeaders();
                            });
                        }
                    });
            };


            vm.update = function (assetdisposal) {
                abp.message.confirm(App.localize('AreYouSureToApproveAssetDisposal' + assetdisposal.disposalNoteNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            vm.assetdisposal.status = "Approved";

                            sessionService.getCurrentLoginInformations({}).success(function (result) {
                                $scope.currentuser = result;
                            });
                            vm.assetdisposal.approvedBy = $scope.currentuser.user.name;
                            assetdisposalService.updateHeader(vm.assetdisposal).success(function () {
       
                                assetLedgerService.updateAssetLedgerByDocNo({
                                    docNo: vm.assetdisposal.disposalNoteNo
                                }).success(function (result) {

                                });

                                abp.notify.success(App.localize('SuccessfullyApproved'));
                                loadAssetDisposalHeaders();
                            });
                        }
                    });
            };


            vm.assetdisposalItemCreationModal = function () {
                if (vm.assetdisposal.approvedBy != "N/A") {
                    abp.notify.error(App.localize('You Can Not Create Items'));
                    return;
                }
                else {
                    var modalInstance = $modal.open({
                        templateUrl: '/App/Main/views/assetdisposals/createItems.cshtml',
                        controller: 'app.views.assetdisposals.createItems as vm',
                        backdrop: 'static'
                    });

                }
                modalInstance.result.then(function () {
                    loadAssetDisposalHeaders();
                });
            };



        }
    ]);
})();