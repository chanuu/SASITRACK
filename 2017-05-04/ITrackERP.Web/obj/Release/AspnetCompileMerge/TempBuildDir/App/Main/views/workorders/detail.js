(function () {
    var controllerId = 'app.views.workorders.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope','$modal', '$state', '$stateParams', 'abp.services.app.workOrder',
        function ($rootScope, $scope,$modal, $state, $stateParams, workorderService) {
            var vm = this;
            $rootScope.wId = $stateParams.id;
            function loadWorkOrders() {
                workorderService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.workOrder = result;
                });
            }


            vm.back = function () {
                $state.go('workorders');
            };

            loadWorkOrders();


            vm.workorderItemCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/workorders/createItems.cshtml',
                    controller: 'app.views.workorders.createItems as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    loadWorkOrders();
                });
            };



        }
    ]);
})();