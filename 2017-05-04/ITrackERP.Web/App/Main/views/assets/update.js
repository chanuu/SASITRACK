(function () {
    var controllerId = 'app.views.assets.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.asset', 'abp.services.app.customeFieldSetup', 'abp.services.app.department',
        function ($scope, $state, $stateParams, assetService, customfieldsetuptService, departmentService) {
            var vm = this;
            
            vm.departments = [];
            $scope.selectedLineNo = null;

            $scope.customfieldsetups = [];
            $scope.customeFiledSetupId = null;
            $scope.selectedAssetType = null;

            vm.customfields = {};

            vm.customcaption1 = "Custom Field 1";
            vm.customcaption2 = "Custom Field 2";
            vm.customcaption3 = "Custom Field 3";
            vm.customcaption4 = "Custom Field 4";
            vm.customcaption5 = "Custom Field 5";
            vm.customcaption6 = "Custom Field 6";


            vm.update = function () {
                if ($scope.assetUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {

                    vm.asset.customeFiledSetupId = $scope.selectedAssetType.id;
                    vm.asset.assetType = $scope.selectedAssetType.customFieldNo;
                    vm.asset.assetUsedBy = $scope.selectedLineNo.name;

                    assetService.update(vm.asset)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('assets');

                        });
                }
            };
            
            $scope.getCustomFieldsEvent = function (key) {
                vm.customcaption1 = $scope.selectedAssetType.customeField1;
                vm.customcaption2 = $scope.selectedAssetType.customeField2;
                vm.customcaption3 = $scope.selectedAssetType.customeField3;
                vm.customcaption4 = $scope.selectedAssetType.customeField4;
                vm.customcaption5 = $scope.selectedAssetType.customeField5;
                vm.customcaption6 = $scope.selectedAssetType.customeField6;
            }

            function getAssetTypes() {
                customfieldsetuptService.getCustomeFieldSetup({}).success(function (result) {
                    vm.customfieldsetups = result.items;
                });
              
            }
            getAssetTypes();

            
            function getDepartments() {
                departmentService.getDepartments({}).success(function (result) {
                    vm.departments = result.items;
                });
            }
            getDepartments();



            function loadAssets() {
                assetService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.asset = result;
                   
                    customfieldsetuptService.getDetail({
                        id: vm.asset.customeFiledSetupId
                    }).success(function (result) {

                        vm.customfields = result;
                        vm.customcaption1 = vm.customfields.customeField1;
                        vm.customcaption2 = vm.customfields.customeField2;
                        vm.customcaption3 = vm.customfields.customeField3;
                        vm.customcaption4 = vm.customfields.customeField4;
                        vm.customcaption5 = vm.customfields.customeField5;
                        vm.customcaption6 = vm.customfields.customeField6;
                        $scope.selectedAssetType = vm.customfields;
                    });

                    departmentService.getDetailByLineNo({
                        name: vm.asset.assetUsedBy
                    }).success(function (result) {
                        $scope.selectedLineNo = result;
                    });

                });
            }


            vm.backToEventsPage = function () {
                $state.go('assets');
            };

            loadAssets();


        }
    ]);
})();