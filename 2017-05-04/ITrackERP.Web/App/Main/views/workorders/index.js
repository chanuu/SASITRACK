(function () {
    angular.module('app').controller('app.views.workorders.index', [
        '$scope', '$modal', 'abp.services.app.workOrder',
        function ($scope, $modal, workorderService) {
            var vm = this;

            vm.workorders = [];

            function getWorkOrder() {
                workorderService.getWorkOrder({}).success(function (result) {
                    vm.workorders = result.items;
                });
            }


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }

            vm.workorderCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/workorders/createWorkOrder.cshtml',
                    controller: 'app.views.workorders.createWorkOrder as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getWorkOrder();
                });
            };

           

            getWorkOrder();


        }
    ]);
})();