(function () {
    angular.module('app').controller('app.views.itemmasters.createItemMaster', [
        '$scope', '$modalInstance', 'abp.services.app.itemMaster', 'abp.services.app.customeFieldSetup',
        function ($scope, $modalInstance, itemmasterService, customfieldsetuptService) {
            var vm = this;
            $scope.itemmasters = [];

            $scope.customfieldsetups = [];
            $scope.customeFiledSetupId = null;
            $scope.selectedItemType = null;

            vm.customcaption1 = "Custom Field 1";
            vm.customcaption2 = "Custom Field 2";
            vm.customcaption3 = "Custom Field 3";
            vm.customcaption4 = "Custom Field 4";
            vm.customcaption5 = "Custom Field 5";
            vm.customcaption6 = "Custom Field 6";

            vm.save = function () {
                if ($scope.itemmasterCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.itemmaster.customeFiledSetupId = $scope.selectedItemType.id;
                    vm.itemmaster.itemType = $scope.selectedItemType.itemType;

                    itemmasterService.create(vm.itemmaster)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };


            $scope.getCustomFieldsEvent = function (key) {
                vm.customcaption1 = $scope.selectedItemType.customeField1;
                vm.customcaption2 = $scope.selectedItemType.customeField2;
                vm.customcaption3 = $scope.selectedItemType.customeField3;
                vm.customcaption4 = $scope.selectedItemType.customeField4;
                vm.customcaption5 = $scope.selectedItemType.customeField5;
                vm.customcaption6 = $scope.selectedItemType.customeField6;
            }


            function getItemTypes() {
                customfieldsetuptService.getCustomeFieldSetup({}).success(function (result) {
                    vm.customfieldsetups = result.items;
                });
            }
            getItemTypes();

            //
            $scope.afterSelectedItemType = function (selected) {
                if (selected) {
                    $scope.selectedItemType = selected.originalObject;
                }
            }




            $scope.afterSelecteItemMaster = function (selected) {
                if (selected) {
                    $scope.afterSelectedItemMaster = selected.originalObject;


                }
            }

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();