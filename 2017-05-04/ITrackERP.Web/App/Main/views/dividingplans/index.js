(function () {
    angular.module('app').controller('app.views.dividingplans.index', [
        '$scope', '$modal', 'abp.services.app.dividingPlanHeader',
        function ($scope, $modal, dividingplanService) {
            var vm = this;

            vm.dividingplans = [];

            function getDividingPlanHeader() {
                dividingplanService.getDividingPlanHeader({}).success(function (result) {
                    vm.dividingplans = result.items;
                });
            }


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }


            vm.delete = function (dividingplan) {
                abp.message.confirm(App.localize('AreYouSureToDeleteDividingPlan' + dividingplan.styleId),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            dividingplanService.deleteHeader({ id: dividingplan.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                getDividingPlanHeader();
                            });
                        }
                    });
            };


            vm.dividingplanCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/dividingplans/createDividingPlanHeader.cshtml',
                    controller: 'app.views.dividingplans.createDividingPlanHeader as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getDividingPlanHeader();
                });
            };



            getDividingPlanHeader();


        }
    ]);
})();