(function () {
    var controllerId = 'app.views.styleloadings.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$modal', '$state', '$stateParams', 'abp.services.app.styleLoading',
        function ($rootScope, $scope, $modal, $state, $stateParams, styleloadingService) {
            var vm = this;

            function loadStyleLoadings() {
                styleloadingService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.styleloading = result;
                });
            }


            vm.back = function () {
                $state.go('styleloading');
            };

            loadStyleLoadings();        

        }
    ]);
})();