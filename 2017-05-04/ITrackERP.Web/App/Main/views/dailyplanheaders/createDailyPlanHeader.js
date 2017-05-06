(function () {
    angular.module('app').controller('app.views.dailyplanheaders.createDailyPlanHeader', [
        '$scope', '$modalInstance', 'abp.services.app.dailyPlanHeader', 'abp.services.app.session', 
        function ($scope, $modalInstance, dailyplanheaderService, sessionService) {
            var vm = this;

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };

            $scope.fdate = new Date();

            vm.save = function () {

                if ($scope.dailyplanheaderCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {

                    sessionService.getCurrentLoginInformations({}).success(function (result) {
                        $scope.currentuser = result;
                    });

                    vm.dailyplanheader.date = $scope.fdate;
                    vm.dailyplanheader.planBy = $scope.currentuser.user.name;
                    vm.dailyplanheader.status = "Pending";
                    vm.dailyplanheader.approvedBy = "N/A";

                    dailyplanheaderService.create(vm.dailyplanheader)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };

           
            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();