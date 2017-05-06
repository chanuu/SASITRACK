(function () {
    angular.module('app').controller('app.views.files.index', ['$rootScope',
        '$scope', '$modal', 'abp.services.app.file', '$http', 'abp.services.app.customeFieldSetup',
        function ($rootScope, $scope, $modal, fileService, $http, customfieldsetuptService) {
            var vm = this;

            vm.files = [];
            $scope.myOrderBy = null;
            vm.customfieldsetups = [];
            $scope.selectedItemType = null;

            vm.customcaption1 = "Custom Field 1";
            vm.customcaption2 = "Custom Field 2";
            vm.customcaption3 = "Custom Field 3";
            vm.customcaption4 = "Custom Field 4";
            vm.customcaption5 = "Custom Field 5";
            vm.customcaption6 = "Custom Field 6";

            function GetAll() {
                fileService.getAllByFileType({ customeFiledSetupId: $scope.selectedItemType.id }).success(function (result) {
                    vm.files = result.items;
                    $rootScope.customfieldsetupid = id;

                });
            };

          
           
            function getItemTypes() {
                customfieldsetuptService.getCustomeFieldSetup({}).success(function (result) {
                    vm.customfieldsetups = result.items;
                });
            }
           
            getItemTypes();

            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            };

            $scope.filterByType = function () {
             
                $scope.myOrderBy = $scope.selectedItemType.itemType;
             
                fileService.getAllByFileType({ customeFiledSetupId: $scope.selectedItemType.id }).success(function (result) {
                    vm.files = result.items;

                });

                vm.customcaption1 = "";
                vm.customcaption2 = "";
                vm.customcaption3 = "";
                vm.customcaption4 = "";
                vm.customcaption5 = "";
                vm.customcaption6 = "";

                customfieldsetuptService.getDetail({
                    id: $scope.selectedItemType.id
                }).success(function (result) {

                    vm.customfields = result;
                   
                        vm.customcaption1 = vm.customfields.customeField1;                    
                        vm.customcaption2 = vm.customfields.customeField2;                    
                        vm.customcaption3 = vm.customfields.customeField3;                   
                        vm.customcaption4 = vm.customfields.customeField4;                   
                        vm.customcaption5 = vm.customfields.customeField5;                  
                        vm.customcaption6 = vm.customfields.customeField6;
                    
                });

            };



            vm.delete = function (file) {
                abp.message.confirm(App.localize('AreYouSureToDeleteFile'),
                    function (isConfirmed) {
                        if (isConfirmed) {

                            $http.delete('/api/Upload/' + file.id + '/f').then(function (data) {
                            });


                            fileService.delete({ id: file.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                GetAll($scope.selectedItemType.id);
                            });
                        }
                    });
            };

            vm.fileCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/files/createFile.cshtml',
                    controller: 'app.views.files.createFile as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    GetAll($scope.selectedItemType.id);
                });
            };

            


        }
    ]);
})();