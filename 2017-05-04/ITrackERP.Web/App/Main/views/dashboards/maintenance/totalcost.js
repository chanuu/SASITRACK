(function () {
    var controllerId = 'app.views.dashboard.maintenance.totalcost';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.jobCardHeader'
        , function ($rootScope, $scope, $state, $stateParams, jobcardheaderAppService) {
            var vm = this;

            $scope.isProcessed = false;
            $scope.filter = {};
            $scope.jobCardHeader = [];
     
            $rootScope.JobCardHeadersTotalCal = [];

            // date picker options 

            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };

            $scope.fdate = new Date();
            $scope.tdate = new Date();

            vm.process = function () {

                $scope.filter.fromDate = $scope.fdate.getFullYear() + "-" + ($scope.fdate.getMonth() + 1) + "-" + $scope.fdate.getDate();
                $scope.filter.toDate = $scope.tdate.getFullYear() + "-" + ($scope.tdate.getMonth() + 1) + "-" + $scope.tdate.getDate();

                jobcardheaderAppService.getJobCardHeadersByDateRange({
                    from: $scope.filter.fromDate,
                    to: $scope.filter.toDate
                }).success(function (result) {
                    $scope.jobCardHeader = result.items;
                 
                    $rootScope.JobCardHeadersTotalCal = $scope.jobCardHeader;

                    $state.go('totalcostforjobs');
                });

            }

            //Home logic...
        }
    ]);
})();


