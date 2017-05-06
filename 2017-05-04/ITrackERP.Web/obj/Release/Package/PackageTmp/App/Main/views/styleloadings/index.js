(function () {
    angular.module('app').controller('app.views.styleloadings.index', [
        '$scope', '$modal', 'abp.services.app.styleLoading',
        function ($scope, $modal, styleloadingService) {
            var vm = this;

            vm.styleloadings = [];

            function getStyleLoading() {
                styleloadingService.getStyleLoading({}).success(function (result) {
                    vm.styleloadings = result.items;
                });
            }


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }


            vm.delete = function (styleloading) {
                abp.message.confirm(App.localize('AreYouSureToDeleteStyleLoading', styleloading.styleNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            styleloadingService.delete({ id: styleloading.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                getStyleLoading();
                            });
                        }
                    });
            };


            vm.styleloadingCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/styleloadings/createStyleLoading.cshtml',
                    controller: 'app.views.styleloadings.createStyleLoading as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getStyleLoading();
                });
            };


            getStyleLoading();


        }
    ]);
})();