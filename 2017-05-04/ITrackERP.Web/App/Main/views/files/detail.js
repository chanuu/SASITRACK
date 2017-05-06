(function () {
    var controllerId = 'app.views.files.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', '$modal', 'abp.services.app.file', 'abp.services.app.customeFieldSetup',
        function ($rootScope, $scope, $state, $stateParams, $modal, fileService, customfieldsetuptService) {
            var vm = this;

            vm.files = {};

            vm.customcaption1 = "Custom Field 1";
            vm.customcaption2 = "Custom Field 2";
            vm.customcaption3 = "Custom Field 3";
            vm.customcaption4 = "Custom Field 4";
            vm.customcaption5 = "Custom Field 5";
            vm.customcaption6 = "Custom Field 6";

           
            function loadFiles() {
                fileService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.files = result;


                    customfieldsetuptService.getDetail({
                        id: vm.files.customeFiledSetupId
                    }).success(function (result) {

                        vm.customfields = result;
                        vm.customcaption1 = vm.customfields.customeField1;
                        vm.customcaption2 = vm.customfields.customeField2;
                        vm.customcaption3 = vm.customfields.customeField3;
                        vm.customcaption4 = vm.customfields.customeField4;
                        vm.customcaption5 = vm.customfields.customeField5;
                        vm.customcaption6 = vm.customfields.customeField6;
                    });



                });
            }

            loadFiles();

        }
    ]);
})();