(function () {
    var controllerId = 'app.views.cuttingratios.detail';
    angular.module('app').controller(controllerId, ['$modal','$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.cuttingRatio',
        function ($modal,$rootScope, $scope, $state, $stateParams, ratioAppSerice) {
            var vm = this;
           

            function loadCuttingRatio() {
                ratioAppSerice.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.cuttingRatio = result;
                    $rootScope.ratioId = $stateParams.id;
                });
            }


            vm.back = function () {
                $state.go('workorders');
            };

            loadCuttingRatio();



            vm.cuttingRatioItem = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/cuttingratios/createItem.cshtml',
                    controller: 'app.views.cuttingratios.createItem as vm',
                    backdrop: 'static'
                });
                modalInstance.result.then(function () {
                    loadIssueNoteHeaders();
                });
            };



        }
    ]);
})();