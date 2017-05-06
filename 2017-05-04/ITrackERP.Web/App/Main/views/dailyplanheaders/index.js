(function () {
    angular.module('app').controller('app.views.dailyplanheaders.index', [
        '$scope', '$modal', 'abp.services.app.dailyPlanHeader',
        function ($scope, $modal, dailyplanheaderService) {
            var vm = this;

            vm.dailyplanheaders = [];

            function getDailyPlanHeader() {
                dailyplanheaderService.getAll({}).success(function (result) {
                    vm.dailyplanheaders = result.items;
                });
            }


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }



            vm.delete = function (dailyplanheader) {
                abp.message.confirm(App.localize('AreYouSureToDeleteDailyPlanHeaderOn' + dailyplanheader.date),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            dailyplanheaderService.delete({ id: dailyplanheader.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                getDailyPlanHeader();
                            });
                        }
                    });
            };



            vm.dailyplanheaderCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/dailyplanheaders/createDailyPlanHeader.cshtml',
                    controller: 'app.views.dailyplanheaders.createDailyPlanHeader as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getDailyPlanHeader();
                });
            };

            getDailyPlanHeader();


        }
    ]);
})();