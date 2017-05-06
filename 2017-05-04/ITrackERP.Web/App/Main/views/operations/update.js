(function () {
    var controllerId = 'app.views.operations.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.operationPool',
        function ($scope, $state, $stateParams, operationService) {
            var vm = this;
            
            vm.update = function () {

                if ($scope.operationUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    operationService.update(vm.operation)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('operation');

                        });
                }
            };

           
           
            function loadOperations() {
                operationService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.operation = result;
                });
            }


            vm.backToEventsPage = function () {
                $state.go('operation');
            };

            loadOperations();


        }
    ]);
})();