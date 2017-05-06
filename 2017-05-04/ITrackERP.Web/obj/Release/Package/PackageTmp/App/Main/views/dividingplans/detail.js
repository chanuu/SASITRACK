(function () {
    var controllerId = 'app.views.dividingplans.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$modal', '$state', '$stateParams', 'abp.services.app.dividingPlanHeader',
        function ($rootScope, $scope, $modal, $state, $stateParams, dividingplanService) {
            var vm = this;
            $rootScope.hId = $stateParams.id;

            function loadDividingPlanHeaders() {
                dividingplanService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.dividingplan = result;
                });
            }


            vm.back = function () {
                $state.go('dividingplan');
            };

            loadDividingPlanHeaders();



            vm.delete = function (dividingplan) {
                abp.message.confirm(App.localize('AreYouSureToDeleteDividingPlanItem' + dividingplan.operationNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            dividingplanService.deleteItem({ id: dividingplan.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                loadDividingPlanHeaders();
                            });
                        }
                    });
            };



            vm.dividingplanItemCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/dividingplans/createItems.cshtml',
                    controller: 'app.views.dividingplans.createItems as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    loadDividingPlanHeaders();
                });
            };



        }
    ]);
})();