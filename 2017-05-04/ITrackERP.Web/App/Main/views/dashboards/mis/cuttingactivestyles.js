(function () {
    var controllerId = 'app.views.dashboard.mis.cuttingactivestyles';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.cuttingMaster'
        , function ($rootScope, $scope, $state, $stateParams, cuttingMasterAppSerice) {
            var vm = this;


            vm.items = [];




            function getCuttingMaster() {
                cuttingMasterAppSerice.getActiveCuttingMaster({}).success(function (result) {
                    vm.items = result.items;
                    console.log(vm.items);
                });
            };


            getCuttingMaster();

            //Home logic...
        }
    ]);
})();


