(function () {
    var controllerId = 'app.views.jobcardheaders.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$modal', '$state', '$stateParams', 'abp.services.app.jobCardHeader', 'abp.services.app.jobCardItem', 'abp.services.app.session', 'abp.services.app.stockLedger', 'abp.services.app.serialItem', 'abp.services.app.jobCardItem',
    function ($rootScope, $scope, $modal, $state, $stateParams, jobCardHeaderService, jobCardItemService, sessionService, stockLedgerService, serialitemService, jobcarditemService) {
            var vm = this;
            $rootScope.JobCardHeaderId = $stateParams.id;
            $scope.jobCardHeader = {};
            $scope.stockLedgerItem = {};
            var totalcost = 0;

            function loadJobCardHeaders() {
                jobCardHeaderService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.jobcardheader = result;
                    $rootScope.wDate = vm.jobcardheader.date;
                    $rootScope.wJobCardNo = vm.jobcardheader.jobcardNo;
                    $rootScope.wStatus = vm.jobcardheader.status;
                });
            }

            vm.back = function () {
                $state.go('jobcardheader');
            };

            loadJobCardHeaders();

            vm.delete = function (jobcarditem) {
                abp.message.confirm(App.localize('AreYouSureToDeleteJobCardItem' + jobcarditem.itemCode),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            jobCardItemService.delete({ id: jobcarditem.id }).success(function () {
                          
                                $scope.stockLedgerItem.itemCode = jobcarditem.itemCode;
                                $scope.stockLedgerItem.date = $rootScope.wDate
                                $scope.stockLedgerItem.transactionType = "Job Cancel";
                                $scope.stockLedgerItem.docNo = $rootScope.wJobCardNo;
                                $scope.stockLedgerItem.usedStock = jobcarditem.amount;
                                $scope.stockLedgerItem.status = $rootScope.wStatus;

                                stockLedgerService.create($scope.stockLedgerItem)
                           .success(function () {                         
                           });

                                if (jobcarditem.serialNo != "N/A") {
                                    serialitemService.updateSerialItemBySerialNo1({
                                        serialNo: jobcarditem.serialNo
                                    }).success(function () {
                                    });
                                }

                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                loadJobCardHeaders();
                            });
                        }
                    });
            };

            vm.update = function (jobcardheader) {
                abp.message.confirm(App.localize('AreYouSureToApproveJobCardHeader ' + jobcardheader.jobcardNo),
                    function (isConfirmed) {
                        if (isConfirmed) {

                            vm.jobcardheader.status = "Approved";

                            jobcarditemService.getJobCardHeaderTotalCost({
                                id: $stateParams.id
                            }).success(function (result) {
                                totalcost = result;
                            });

                            vm.jobcardheader.totalCost = totalcost;

                            sessionService.getCurrentLoginInformations({}).success(function (result) {
                                $scope.currentuser = result;
                            });

                            vm.jobcardheader.checkedBy = $scope.currentuser.user.name;
                                                  
                            
                            jobCardHeaderService.update(vm.jobcardheader).success(function () {
                               
                                stockLedgerService.updateStockLedgerByDocNo({
                                    docNo: vm.jobcardheader.jobcardNo
                                }).success(function (result) {

                                });


                                abp.notify.success(App.localize('SuccessfullyApproved'));
                                loadJobCardHeaders();
                            });
                        }
                    });
            };


            vm.jobCardItemCreationModal = function () {
                if (vm.jobcardheader.checkedBy != "N/A") {
                    abp.notify.error(App.localize('You Can Not Create Items'));
                    return;
                }
                else {

                    var modalInstance = $modal.open({
                        templateUrl: '/App/Main/views/jobcardheaders/createJobCardItem.cshtml',
                        controller: 'app.views.jobcardheaders.createJobCardItem as vm',
                        backdrop: 'static'
                    });
                }
                modalInstance.result.then(function () {
                    loadJobCardHeaders();
                });
            };



        }
    ]);
})();