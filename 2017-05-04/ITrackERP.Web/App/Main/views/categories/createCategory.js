(function () {
    angular.module('app').controller('app.views.categories.createCategory', [
        '$scope', '$modalInstance', 'abp.services.app.categorySetup', 'abp.services.app.customeFieldSetup',
        function ($scope, $modalInstance, categoryService, customfieldsetuptService) {
            var vm = this;

            $scope.customfieldsetups = [];
            $scope.selectedItemType = null;

            vm.save = function () {
                if ($scope.categoryCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {

                    vm.category.name = $scope.selectedItemType.itemType;

                    categoryService.create(vm.category)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();
                        });
                }
            };


            function getItemTypes() {
                customfieldsetuptService.getCustomeFieldSetup({}).success(function (result) {
                    vm.customfieldsetups = result.items;
                });
            }
            getItemTypes();

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();