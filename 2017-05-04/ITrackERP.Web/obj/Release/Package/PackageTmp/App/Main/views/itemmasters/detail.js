(function () {
    var controllerId = 'app.views.itemmasters.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$modal', '$state', '$stateParams', 'abp.services.app.itemMaster',
        function ($rootScope, $scope, $modal, $state, $stateParams, itemmasterService) {
            var vm = this;
            $rootScope.hId = $stateParams.id;

            function loadItemMasters() {
                itemmasterService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.itemmaster = result;
                });
            }


            vm.back = function () {
                $state.go('itemmaster');
            };

            loadItemMasters();

        }
    ]);
})();