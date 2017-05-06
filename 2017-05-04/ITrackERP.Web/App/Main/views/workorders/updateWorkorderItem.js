(function () {
    var controllerId = 'app.views.workorders.updateWorkorderItem';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.workorderRatio',
        function ($rootScope, $scope, $state, $stateParams, workorderRatioService) {
            var vm = this;
            vm.item = {};

            vm.update = function () {
                if ($scope.workorderitemUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {

                    vm.item.id = $stateParams.id;
                    vm.item.WorkOrderHeaderId = $rootScope.wId;

                    workorderRatioService.update(vm.item)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                           
                            $state.go('workOrderDetail', { 'id': $rootScope.wId });
                        });
                }
            };


            function loadIssueNoteItems() {
                workorderRatioService.getItemDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.item = result;
                });
            }


           
            vm.back = function () {
                $state.go('workOrderDetail', { 'id': $rootScope.wId });
            };


            loadIssueNoteItems();

        }
    ]);
})();