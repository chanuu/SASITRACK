(function () {
    var controllerId = 'app.views.styles.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.style',
        function ($scope, $state, $stateParams, styleService) {
            var vm = this;


            vm.update = function () {

               
                styleService.update(vm.style)
                    .success(function () {
                        abp.notify.success(App.localize('SavedSuccessfully'));
                        $state.go('styles');

                    });
            };


            function loadStyles() {
                styleService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.style = result;
                });
            }


            vm.backToEventsPage = function () {
                $state.go('styles');
            };

            loadStyles();


        }
    ]);
})();