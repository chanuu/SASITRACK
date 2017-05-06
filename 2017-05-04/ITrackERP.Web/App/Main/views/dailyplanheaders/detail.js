(function () {
    var controllerId = 'app.views.dailyplanheaders.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$modal', '$state', '$stateParams', 'abp.services.app.dailyPlanHeader', 'abp.services.app.dailyPlanItem', 'abp.services.app.session',
    function ($rootScope, $scope, $modal, $state, $stateParams, dailyplanheaderService, dailyplanitemService, sessionService) {
        var vm = this;

        $scope.currentuser = {};
        $rootScope.DailyPlanHeaderId = $stateParams.id;

        function loadDailyPlanHeaders() {
            dailyplanheaderService.getDetail({
                id: $stateParams.id
            }).success(function (result) {
                vm.dailyplanheader = result;
            });
        }

        vm.back = function () {
            $state.go('dailyplanheader');
        };

        loadDailyPlanHeaders();

        vm.delete = function (dailyplanitem) {
            abp.message.confirm(App.localize('AreYouSureToDeleteDailyPlanItem' + dailyplanitem.poNo),
                function (isConfirmed) {
                    if (isConfirmed) {
                        dailyplanitemService.delete({ id: dailyplanitem.id }).success(function () {
                            abp.notify.success(App.localize('SuccessfullyDeleted'));
                            loadDailyPlanHeaders();
                        });
                    }
                });
        };


        vm.dailyplanitemCreationModal = function () {
            var modalInstance = $modal.open({
                templateUrl: '/App/Main/views/dailyplanheaders/createDailyPlanItem.cshtml',
                controller: 'app.views.dailyplanheaders.createDailyPlanItem as vm',
                backdrop: 'static'
            });
            modalInstance.result.then(function () {
                loadDailyPlanHeaders();
            });
        };



        vm.update = function (dailyplanheader) {
            abp.message.confirm(App.localize('AreYouSureToApproveDailyPlanHeader ' + dailyplanheader.date),
                function (isConfirmed) {
                    if (isConfirmed) {
                        vm.dailyplanheader.status = "Approved";

                        sessionService.getCurrentLoginInformations({}).success(function (result) {
                            $scope.currentuser = result;
                        });

                        vm.dailyplanheader.approvedBy = $scope.currentuser.user.name;

                        dailyplanheaderService.update(vm.dailyplanheader).success(function () {

                          
                            abp.notify.success(App.localize('SuccessfullyApproved'));
                            loadDailyPlanHeaders();
                        });
                    }
                });
        };


    }
    ]);
})();