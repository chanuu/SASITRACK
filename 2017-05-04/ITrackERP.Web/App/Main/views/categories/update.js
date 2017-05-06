(function () {
    var controllerId = 'app.views.categories.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.categorySetup', 'abp.services.app.customeFieldSetup',
        function ($scope, $state, $stateParams, categoryService, customfieldsetuptService) {
            var vm = this;
            vm.update = function () {

                if ($scope.categoryUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.category.name = $scope.selectedItemType.itemType;

                    categoryService.update(vm.category)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('category');

                        });
                }
            };

            function loadCategories() {
                categoryService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.category = result;

                    customfieldsetuptService.getDetailByName({ itemType: vm.category.name}).success(function (result1) {
                        $scope.selectedItemType = result1;
                    });


                });
            }

            function getItemTypes() {
                customfieldsetuptService.getCustomeFieldSetup({}).success(function (result) {
                    vm.customfieldsetups = result.items;
                });
            }
            getItemTypes();

            vm.backToEventsPage = function () {
                $state.go('category');
            };

            loadCategories();
        }
    ]);
})();