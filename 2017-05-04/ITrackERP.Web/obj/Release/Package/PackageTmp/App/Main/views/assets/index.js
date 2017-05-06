(function () {
    angular.module('app').controller('app.views.assets.index', [
        '$scope', '$modal', 'abp.services.app.asset',
        function ($scope, $modal, assetService) {
            var vm = this;

            vm.assets = [];

            function GetAssets() {
                assetService.getAsset({}).success(function (result) {
                    vm.assets = result.items;
                });
            };


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            };



            vm.delete = function (asset) {
                abp.message.confirm(App.localize('AreYouSureToDeleteAsset' + asset.assetNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            assetService.deleteAsset({ id: asset.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                GetAssets();
                            });
                        }
                    });
            };

            vm.assetCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/assets/createAsset.cshtml',
                    controller: 'app.views.assets.createAsset as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    GetAssets();
                });
            };



            GetAssets();


        }
    ]);
})();