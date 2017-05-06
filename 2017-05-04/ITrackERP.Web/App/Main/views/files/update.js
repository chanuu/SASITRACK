(function () {
    var controllerId = 'app.views.files.update';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.customeFieldSetup', 'abp.services.app.categorySetup', 'abp.services.app.file', 'Upload','$http',
        function ($rootScope, $scope, $state, $stateParams, customfieldsetuptService, categoryService, fileService, Upload, $http) {
            var vm = this;

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
         
            vm.file = {};

            vm.customfieldsetups = [];
            $scope.selectedItemType = null;

            vm.customfields = {};

            vm.customcaption1 = "Custom Field 1";
            vm.customcaption2 = "Custom Field 2";
            vm.customcaption3 = "Custom Field 3";
            vm.customcaption4 = "Custom Field 4";
            vm.customcaption5 = "Custom Field 5";
            vm.customcaption6 = "Custom Field 6";

            vm.update = function () {
                if ($scope.fileUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.file.type = $scope.selectedItemType.itemType;
                    vm.file.customeFiledSetupId = $scope.selectedItemType.id;

                    if ($scope.selectedCategory1 != null)
                    {
                        vm.file.category1 = $scope.selectedCategory1.categoryName;
                        if ($scope.selectedCategory2 != null)
                        {
                            vm.file.category2 = $scope.selectedCategory2.categoryName;
                            if ($scope.selectedCategory3 != null)
                            {
                                vm.file.category3 = $scope.selectedCategory3.categoryName;
                                if ($scope.selectedCategory4 != null)
                                {
                                    vm.file.category4 = $scope.selectedCategory4.categoryName;
                                    if ($scope.selectedCategory5 != null)
                                    {
                                        vm.file.category5 = $scope.selectedCategory5.categoryName;
                                    }
                                    else {
                                        vm.file.category5 = null;
                                    }
                                }
                                else {
                                    vm.file.category4 = null;
                                    vm.file.category5 = null;
                                }
                            }
                            else {
                                vm.file.category3 = null;
                                vm.file.category4 = null;
                                vm.file.category5 = null;
                            }
                        }
                        else {
                            vm.file.category2 = null;
                            vm.file.category3 = null;
                            vm.file.category4 = null;
                            vm.file.category5 = null;
                        }
                    }
                   

                    if (vm.file.path != "N/A") {
                        vm.file.path = vm.file.path;

                    }

                    else if ($scope.file != null) {
                        vm.file.path = "app/theme/UI/files/" + $scope.file.name;
                    }

                    else {
                        vm.file.path = "N/A";
                    }




                    if ($scope.fileUpdateForm.file.$valid && $scope.file) {

                        $scope.upload($scope.file, "f");
                    }

                }

                fileService.update(vm.file)
                    .success(function () {
                        abp.notify.success(App.localize('SavedSuccessfully'));
                        
                        $state.go('file');

                    });

               
            };


          

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


            function loadCategories() {
                fileService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.file = result;

                    customfieldsetuptService.getDetail({
                        id: vm.file.customeFiledSetupId
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

                    categoryService.getDetailByName({
                        categoryName: vm.file.category1, levelNo: "1"
                    }).success(function (result1) {
                        $scope.selectedCategory1 = result1;
                    });

                    categoryService.getDetailByName({
                        categoryName: vm.file.category2, levelNo: "2"
                    }).success(function (result2) {
                        $scope.selectedCategory2 = result2;
                    });

                    categoryService.getDetailByName({
                        categoryName: vm.file.category3, levelNo: "3"
                    }).success(function (result3) {
                        $scope.selectedCategory3 = result3;
                    });

                    categoryService.getDetailByName({
                        categoryName: vm.file.category4, levelNo: "4"
                    }).success(function (result4) {
                        $scope.selectedCategory4 = result4;
                    });

                    categoryService.getDetailByName({
                        categoryName: vm.file.category5, levelNo: "5"
                    }).success(function (result5) {
                        $scope.selectedCategory5 = result5;
                    });

                });
            }


            $scope.getCustomFieldsEvent = function () {
                vm.customcaption1 = $scope.selectedItemType.customeField1;
                vm.customcaption2 = $scope.selectedItemType.customeField2;
                vm.customcaption3 = $scope.selectedItemType.customeField3;
                vm.customcaption4 = $scope.selectedItemType.customeField4;
                vm.customcaption5 = $scope.selectedItemType.customeField5;
                vm.customcaption6 = $scope.selectedItemType.customeField6;

                GetCategoryItemsByLevelNo(levelno);
            }

          
            vm.categoryChange = function (value) {

                if ($scope.selectedItemType == null)
                {
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
                if (value != null) {
                    GetCategoryItemsByLevelNo(value);
                }
               
            }

            function GetCategoryItemsByLevelNo(levelno) {
                categoryService.getCategoryItemsByLevelNo({ name: $scope.selectedItemType.itemType, levelNo: levelno }).success(function (result) {
                    vm.categoryItems = result.items;
                    if (levelno == "1") {
                        vm.category1Items = vm.categoryItems;                   
                    }
                    else if (levelno == "2") {
                        vm.category2Items = vm.categoryItems;
                    }
                    else if (levelno == "3") {
                        vm.category3Items = vm.categoryItems;
                    }
                    else if (levelno == "4") {
                        vm.category4Items = vm.categoryItems;
                    }
                    else if (levelno == "5") {
                        vm.category5Items = vm.categoryItems;
                    }
                });
            }


            vm.deleteFile = function (file) {
                abp.message.confirm(App.localize('AreYouSureToDeleteFile'),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            $http.delete('/api/Upload/' + file.id + '/f').then(function (data) {
                                file.path = "N/A";

                                fileService.update(file)
                               .success(function () {
                                   abp.notify.success(App.localize('DeletedSuccessfully'));
                                   loadCategories();
                               });
                            }).catch(function (data) {
                                $scope.error = "An error has occured while deleting file! " + data;
                            });
                        }
                    });
            };

            vm.back = function () {
                $state.go('file');
            };


            loadCategories();

        }
    ]);
})();