(function () {
    angular.module('app').controller('app.views.assets.createAsset', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.asset', 'abp.services.app.customeFieldSetup', 'abp.services.app.department',
        function ($rootScope,$scope, $modalInstance, assetService, customfieldsetuptService, departmentService) {
            var vm = this;
            vm.asset = {};
            $scope.customfieldsetups = [];
            $scope.customeFiledSetupId = null;
            vm.selectedAssetType = null;
           
            vm.departments = [];
            vm.selectedLineNo = null;

            vm.customcaption1 = "Custom Field 1";
            vm.customcaption2 = "Custom Field 2";
            vm.customcaption3 = "Custom Field 3";
            vm.customcaption4 = "Custom Field 4";
            vm.customcaption5 = "Custom Field 5";
            vm.customcaption6 = "Custom Field 6";

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };

            $scope.pdate = new Date();

            vm.save = function () {

                if ($scope.assetCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.asset.purchaseDate = $scope.pdate;
                    vm.asset.customeFiledSetupId = vm.selectedAssetType.id;
                    vm.asset.assetType = vm.selectedAssetType.customFieldNo;
                    vm.asset.assetUsedBy = vm.selectedLineNo.name;

                    assetService.create(vm.asset)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };

            $scope.getCustomFieldsEvent = function (key) {           
                vm.customcaption1 = vm.selectedAssetType.customeField1;
                vm.customcaption2 = vm.selectedAssetType.customeField2;
                vm.customcaption3 = vm.selectedAssetType.customeField3;
                vm.customcaption4 = vm.selectedAssetType.customeField4;
                vm.customcaption5 = vm.selectedAssetType.customeField5;
                vm.customcaption6 = vm.selectedAssetType.customeField6;
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


            
            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();