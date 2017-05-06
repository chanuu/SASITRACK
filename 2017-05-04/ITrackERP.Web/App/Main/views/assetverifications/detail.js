(function () {
    var controllerId = 'app.views.assettransfers.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$modal', '$state', '$stateParams', 'abp.services.app.assetVerificationHeader', 'abp.services.app.session', 'abp.services.app.assetLedger',
        function ($rootScope, $scope, $modal, $state, $stateParams, assetverificationheaderService, sessionService, assetLedgerService) {
            var vm = this;
            $rootScope.wId = $stateParams.id;
            vm.assetverificationheader = {};


            function loadAssetVerificationHeaders() {
                assetverificationheaderService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.assetverificationheader = result;
                });
            }


            vm.back = function () {
                $state.go('assetverification');
            };

            loadAssetVerificationHeaders();



            vm.update = function (assetverificationheader) {
                abp.message.confirm(App.localize('AreYouSureToApproveAssetVerification'),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            
                            sessionService.getCurrentLoginInformations({}).success(function (result) {
                                $scope.currentuser = result;
                            });
                            vm.assetverificationheader.approvedBy = $scope.currentuser.user.name;
                            $scope.getDatetime = new Date();
                            vm.assetverificationheader.approvedAt = $scope.getDatetime;

                            assetverificationheaderService.update(vm.assetverificationheader).success(function () {
                                
                                assetLedgerService.updateAssetLedgerByDocNo({
                                    docNo: vm.assetverificationheader.assetVerificationNo
                                }).success(function (result) {

                                });

                                abp.notify.success(App.localize('SuccessfullyApproved'));
                                loadAssetVerificationHeaders();
                            });
                        }
                    });
            };




          
        }
    ]);
})();