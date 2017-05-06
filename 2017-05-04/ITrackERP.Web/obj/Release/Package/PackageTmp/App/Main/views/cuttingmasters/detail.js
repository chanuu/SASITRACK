(function () {
    var controllerId = 'app.views.cuttingmasters.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.cuttingMaster',
        function ($rootScope, $scope, $state, $stateParams, cuttingMasterAppSerice) {
            var vm = this;
           
            $rootScope.cId = $stateParams.id;
            function loadCuttingRatio() {
                cuttingMasterAppSerice.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.cuttingMaster = result;
                });
            }


            vm.finalized = function () {
                abp.message.confirm(
                    App.localize('Are You Sure To Finalized Style'),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            cuttingMasterAppSerice.finalized({
                                id: $rootScope.cId
                            }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyFinalized'));
                               
                            });
                        }
                    }
                );
            };



            vm.back = function () {
                $state.go('workorders');
            };

            loadCuttingRatio();


        }
    ]);
})();