(function () {
    angular.module('app').controller('app.views.dividingplans.createItems', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.dividingPlanHeader', 'abp.services.app.operationPool',
        function ($rootScope, $scope, $modalInstance, dividingplanService, operationpoolService) {
            var vm = this;
            $scope.dividingplandetail = null;

            $scope.dividingplandetail = {};
         
            $scope.operations = [];
            $scope.selectedOperationCode = null;

            vm.save = function () {
                if ($scope.dividingPlanHeaderItemCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    $scope.dividingplandetail.operationNo = $scope.selectedOperationCode.operationCode;
                    $scope.dividingplandetail.dividingPlanHeaderId = $rootScope.hId;
                    dividingplanService.createItem($scope.dividingplandetail)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };


            $scope.getOperationFieldsEvent = function (key) {
                $scope.dividingplandetail.operationName = $scope.selectedOperationCode.operationName;
                $scope.dividingplandetail.smvType = $scope.selectedOperationCode.smvType;
                $scope.dividingplandetail.machineType = $scope.selectedOperationCode.machineType;
                $scope.dividingplandetail.operationRole = $scope.selectedOperationCode.operationRole;
                $scope.dividingplandetail.partName = $scope.selectedOperationCode.partName;
                $scope.dividingplandetail.smv = $scope.selectedOperationCode.smv;
            }


            function getOperations() {
                operationpoolService.getOperations({}).success(function (result) {

                    vm.operations = result.items;
                });
            }
            getOperations();

            //
            $scope.afterSelectedOperationCodes = function (selected) {
                if (selected) {
                    $scope.selectedOperationCode = selected.originalObject;


                }
            }

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();