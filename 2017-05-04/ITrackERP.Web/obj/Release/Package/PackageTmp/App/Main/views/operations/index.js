(function () {
    angular.module('app').controller('app.views.operations.index', [
        '$scope', '$modal', 'abp.services.app.operationPool',
        function ($scope, $modal, operationService) {
            var vm = this;




            vm.operations = [];

           

            function GetOperations() {
                operationService.getOperations({}).success(function (result) {
                    vm.operations = result.items;
                });
            };


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            };

            vm.delete = function (operation) {
                abp.message.confirm(App.localize('AreYouSureToDeleteOperation', operation.operationCode),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            operationService.deleteOperation({ id: operation.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                GetOperations();
                            });
                        }
                    });
            };

            vm.operationCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/operations/createOperation.cshtml',
                    controller: 'app.views.operations.createOperation as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    GetOperations();
                });
            };



            GetOperations();


        }
    ]);
})();