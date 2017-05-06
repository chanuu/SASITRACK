(function () {
    angular.module('app').controller('app.views.files.createFile', [
        '$scope', '$modalInstance', 'abp.services.app.file', 'abp.services.app.customeFieldSetup', 'abp.services.app.categorySetup','Upload',
        function ($scope, $modalInstance, fileService, customfieldsetuptService, categoryService, Upload) {
            var vm = this;
            
            $scope.customfieldsetups = [];
            $scope.selectedItemType = null;

            $scope.selectedCategory1 = null;
            $scope.selectedCategory2 = null;
            $scope.selectedCategory3 = null;
            $scope.selectedCategory4 = null;
            $scope.selectedCategory5 = null;

            vm.category1Items = [];
            vm.category2Items = [];
            vm.category3Items = [];
            vm.category4Items = [];
            vm.category5Items = [];

            vm.customcaption1 = "Custom Field 1";
            vm.customcaption2 = "Custom Field 2";
            vm.customcaption3 = "Custom Field 3";
            vm.customcaption4 = "Custom Field 4";
            vm.customcaption5 = "Custom Field 5";
            vm.customcaption6 = "Custom Field 6";

            vm.save = function () {
                if ($scope.fileCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {

                    vm.file.customeFiledSetupId = $scope.selectedItemType.id;

                    vm.file.type = $scope.selectedItemType.itemType;

                    if ($scope.fileCreateForm.file.$valid && $scope.file) {
                            $scope.upload($scope.file, "f");                       
                    }

                    if ($scope.selectedCategory1 != null) {
                        vm.file.category1 = $scope.selectedCategory1.categoryName;
                    }
                    if ($scope.selectedCategory2 != null) {
                        vm.file.category2 = $scope.selectedCategory2.categoryName;
                    }
                    if ($scope.selectedCategory3 != null) {
                        vm.file.category3 = $scope.selectedCategory3.categoryName;
                    }
                    if ($scope.selectedCategory4 != null) {
                        vm.file.category4 = $scope.selectedCategory4.categoryName;
                    }
                    if ($scope.selectedCategory5 != null) {
                        vm.file.category5 = $scope.selectedCategory5.categoryName;
                    }

                    if ($scope.file != null)
                    {
                        vm.file.path = "app/theme/UI/files/" + $scope.file.name;
                    }
                    
                    else
                    {
                        vm.file.path = "N/A";
                    }
                    fileService.create(vm.file)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };



            $scope.getCustomFieldsEvent = function (levelno) {
                
                    vm.customcaption1 = $scope.selectedItemType.customeField1;
                    vm.customcaption2 = $scope.selectedItemType.customeField2;
                    vm.customcaption3 = $scope.selectedItemType.customeField3;
                    vm.customcaption4 = $scope.selectedItemType.customeField4;
                    vm.customcaption5 = $scope.selectedItemType.customeField5;
                    vm.customcaption6 = $scope.selectedItemType.customeField6;
                
                    GetCategoryItemsByLevelNo(levelno);
            }
            
            $scope.getItems = function (levelno) {
             
                if ($scope.selectedItemType == null) {
                    $scope.selectedCategory1 = null;
                    $scope.selectedCategory2 = null;
                    $scope.selectedCategory3 = null;
                    $scope.selectedCategory4 = null;
                    $scope.selectedCategory5 = null;

                    vm.file.customField1 = null;
                    vm.file.customField2 = null;
                    vm.file.customField3 = null;
                    vm.file.customField4 = null;
                    vm.file.customField5 = null;
                    vm.file.customField6 = null;

                }
                    GetCategoryItemsByLevelNo(levelno);            
            }

            function GetCategoryItemsByLevelNo(levelno) {
                categoryService.getCategoryItemsByLevelNo({ name: $scope.selectedItemType.itemType, levelNo: levelno }).success(function (result) {
                    vm.categoryItems = result.items;
                    if(levelno == "1")
                    {
                        vm.category1Items = vm.categoryItems;
                        $scope.selectedCategory1 = null;
                        $scope.selectedCategory2 = null;
                        $scope.selectedCategory3 = null;
                        $scope.selectedCategory4 = null;
                        $scope.selectedCategory5 = null;
                    }
                    else if (levelno == "2") {
                        vm.category2Items = vm.categoryItems;
                        $scope.selectedCategory2 = null;
                        $scope.selectedCategory3 = null;
                        $scope.selectedCategory4 = null;
                        $scope.selectedCategory5 = null;
                    }
                    else if (levelno == "3") {
                        vm.category3Items = vm.categoryItems;
                        $scope.selectedCategory3 = null;
                        $scope.selectedCategory4 = null;
                        $scope.selectedCategory5 = null;
                    }
                    else if (levelno == "4") {
                        vm.category4Items = vm.categoryItems;
                        $scope.selectedCategory4 = null;
                        $scope.selectedCategory5 = null;
                    }
                    else if (levelno == "5") {
                        vm.category5Items = vm.categoryItems;
                        $scope.selectedCategory5 = null;
                    }
                });
            }

        

            $scope.upload = function (file, value) {              
                Upload.upload({
                    url: '/api/upload/',
                    data: { file: file, key: value }
                }).then(function (resp) {
                    // console.log('Success ' + resp.config.data.file.name + 'uploaded. Response: ' + resp.data);
                }, function (resp) {
                    // console.log('Error status: ' + resp.status);
                }, function (evt) {
                    var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                    //  console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
                });
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