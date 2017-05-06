(function () {
    angular.module('app').controller('app.views.itemmasters.index', [
        '$scope', '$modal', 'abp.services.app.itemMaster',
        function ($scope, $modal, itemMasterService) {
            var vm = this;

            vm.itemMasters = [];

            function getItemMaster() {
                itemMasterService.getItemMaster({}).success(function (result) {
                    vm.itemMasters = result.items;
                });
            }


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }



            vm.delete = function (itemMaster) {
                abp.message.confirm(App.localize('AreYouSureToDeleteItemMaster' + itemMaster.itemType),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            itemMasterService.delete({ id: itemMaster.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                getItemMaster();
                            });
                        }
                    });
            };



            vm.itemmasterCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/itemmasters/createItemMaster.cshtml',
                    controller: 'app.views.itemmasters.createItemMaster as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getItemMaster();
                });
            };

            getItemMaster();


        }
    ]);
})();