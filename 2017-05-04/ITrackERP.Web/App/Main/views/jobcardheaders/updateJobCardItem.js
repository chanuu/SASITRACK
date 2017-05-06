(function () {
    var controllerId = 'app.views.jobcardheaders.updateJobCardItem';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.jobCardItem', 'abp.services.app.itemMaster', 'abp.services.app.serialItem',
        function ($rootScope, $scope, $state, $stateParams, jobcarditemService, itemmasterService, serialitemService) {
            var vm = this;
            vm.jobcarditem = {};

            $scope.itemmasters = [];
            $scope.selectedItemCode = null;
            $scope.serialitems = [];
            $scope.selectedSerialNo = null;

            vm.update = function () {
                if ($scope.jobcardItemUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                   
                    vm.jobcarditem.id = $stateParams.id;
                    vm.jobcarditem.jobCardHeaderId = $rootScope.JobCardHeaderId;
                    vm.jobcarditem.itemCode = $scope.selectedItemCode.itemNo;
                    vm.jobcarditem.serialNo = $scope.selectedSerialNo.serialNo;


                    jobcarditemService.update(vm.jobcarditem)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('jobcardheader');
                        });
                }
            };


            function getItemMasters() {
                itemmasterService.getItemMaster({}).success(function (result) {
                    vm.itemmasters = result.items;
                });
            }
            getItemMasters();


            $scope.afterSelectedItemCode = function (selected) {
                if (selected) {
                    $scope.selectedItemCode = selected.originalObject;


                }
            }

            function getSerialItems() {
                serialitemService.getSerialItem({}).success(function (result) {
                    vm.serialitems = result.items;
                });
            }
            getSerialItems();


            $scope.afterSelectedSerialNo = function (selected) {
                if (selected) {
                    $scope.selectedSerialNo = selected.originalObject;


                }


            }
            
            function loadJobCardItems() {
                jobcarditemService.getJobCardItemByID({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.jobcarditem = result;
                   
                    serialitemService.getDetailBySerialNo({
                        serialNo: vm.jobcarditem.serialNo
                    }).success(function (result) {
                        $scope.selectedSerialNo = result;
                    });


                    itemmasterService.getDetailByItemCode({
                        itemNo: vm.jobcarditem.itemCode
                    }).success(function (result) {
                        $scope.selectedItemCode = result;
                    });



                });
            }

            vm.back = function () {
                $state.go('jobcardheader');
            };


            loadJobCardItems();

        }
    ]);
})();