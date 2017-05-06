(function () {
    angular.module('app').controller('app.views.cuttingmasters.create', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.style','abp.services.app.cuttingMaster',
        function ($rootScope,$scope, $modalInstance,styleService, cuttingMasterService) {
            var vm = this;
            vm.styles = [];

            $scope.selectedStyle = null;
            $scope.cuttingMaster = null;

            vm.save = function () {

                $scope.cuttingMaster.styleId = $scope.selectedStyle.id;
                $scope.cuttingMaster.styleNo = $scope.selectedStyle.styleNo;
                $scope.cuttingMaster.status = "Pending";
                cuttingMasterService.create($scope.cuttingMaster)
                    .success(function () {
                        abp.notify.success(App.localize('SavedSuccessfully'));
                        $modalInstance.close();

                    });
            };


         

            function getStyles() {
                styleService.getStyles({}).success(function (result) {

                    vm.styles = result.items;
                });
            }
            getStyles();

            //


            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();