(function () {
    angular.module('app').controller('app.views.operations.index', [
        '$scope', '$modal', 'abp.services.app.operationPool','$http',
        function ($scope, $modal, operationService, $http) {
            var vm = this;

            vm.operations = [];
            vm.operationdetail = {};

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
                abp.message.confirm(App.localize('AreYouSureToDeleteOperation' + operation.operationCode),
                    function (isConfirmed) {
                        if (isConfirmed) {
                       
                            operationService.getDetail({
                                id: operation.id
                            }).success(function (result) {
                                vm.operationdetail = result;

                                angular.forEach(vm.operationdetail.workCycleImages, function (value, key) {

                                    $http.delete('/api/Upload/' + value.id + '/2').then(function (data) {
                                        workCycleImageDetailService.deleteWorkCycleImage({ id: value.id }).success(function () {
                                        });

                                    }).catch(function (data) {
                                        $scope.error = "An error has occured while deleting files! " + data;
                                    });

                                });

                                operationService.deleteOperation({ id: operation.id }).success(function () {
                                    abp.notify.success(App.localize('SuccessfullyDeleted'));
                                    GetOperations();
                                });


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