(function () {
    var controllerId = 'app.views.dailyplanheaders.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.dailyPlanHeader', 'abp.services.app.session', 
        function ($scope, $state, $stateParams, dailyplanheaderService, sessionService) {
            var vm = this;

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };

            $scope.fdate = new Date();

            vm.update = function () {
                if ($scope.dailyplanheaderUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {

                    sessionService.getCurrentLoginInformations({}).success(function (result) {
                        $scope.currentuser = result;
                    });

                    vm.dailyplanheader.date = $scope.fdate;
                    vm.dailyplanheader.planBy = $scope.currentuser.user.name;

                    dailyplanheaderService.update(vm.dailyplanheader)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('dailyplanheader');

                        });
                }
            };



            function loadDailyPlanHeaders() {
                dailyplanheaderService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.dailyplanheader = result;

                });
            };


            vm.back = function () {
                $state.go('dailyplanheader');
            };


            loadDailyPlanHeaders();


        }
    ]);
})();