(function () {
    var controllerId = 'app.views.itemmasters.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.itemMaster', 'abp.services.app.customeFieldSetup',
        function ($scope, $state, $stateParams, itemmasterService, customfieldsetuptService) {
            var vm = this;
            vm.itemmaster = {};

            $scope.customfieldsetups = [];
            $scope.customeFiledSetupId = null;
            $scope.selectedItemType = null;

            vm.customfields = {};

            vm.customcaption1 = "Custom Field 1";
            vm.customcaption2 = "Custom Field 2";
            vm.customcaption3 = "Custom Field 3";
            vm.customcaption4 = "Custom Field 4";
            vm.customcaption5 = "Custom Field 5";
            vm.customcaption6 = "Custom Field 6";

            vm.update = function () {
                if ($scope.itemMasterUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.itemmaster.customeFiledSetupId = $scope.selectedItemType.id;
                    vm.itemmaster.itemType = $scope.selectedItemType.itemType;

                    itemmasterService.update(vm.itemmaster)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('itemmaster');

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

            function loadItemMasters() {
                itemmasterService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.itemmaster = result;
                  
                    customfieldsetuptService.getDetail({
                        id: vm.itemmaster.customeFiledSetupId
                    }).success(function (result) {

                        vm.customfields = result;
                        vm.customcaption1 = vm.customfields.customeField1;
                        vm.customcaption2 = vm.customfields.customeField2;
                        vm.customcaption3 = vm.customfields.customeField3;
                        vm.customcaption4 = vm.customfields.customeField4;
                        vm.customcaption5 = vm.customfields.customeField5;
                        vm.customcaption6 = vm.customfields.customeField6;
                        $scope.selectedItemType = vm.customfields;
                    });



                });
            }

            vm.back = function () {
                $state.go('itemmaster');
            };


            loadItemMasters();

        }
    ]);
})();