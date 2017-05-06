(function () {
    var controllerId = 'app.views.dashboard.maintenance.mechanicjobs';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.jobCardHeader', 'abp.services.app.employee',
         function ($rootScope, $scope, $state, $stateParams, jobcardheaderAppService, employeeAppService) {
             var vm = this;

             vm.employees = [];
             $scope.selectedEmployeeFullName = null;

             $scope.isProcessed = false;
             $scope.filter = {};
             vm.jobCardHeader = [];
             $rootScope.jobsDoneByMechanic = [];

             $rootScope.converteddata = [];
             $rootScope.chartdata = [];
             $rootScope.tablecuttojson = [];

             // date picker options 


             $scope.dpOpenStatus = {};

             $scope.setDpOpenStatus = function (id) {
                 $scope.dpOpenStatus[id] = true
             };

             $scope.fdate = new Date();
             $scope.tdate = new Date();


             function getEmployees() {
                 employeeAppService.getEmployee({}).success(function (result) {
                     vm.employees = result.items;
                 });
             }
             getEmployees();

             //
             $scope.afterSelectedEmployeeFullName = function (selected) {
                 if (selected) {
                     $scope.selectedEmployeeFullName = selected.originalObject;
                 }
             }



             vm.process = function () {

                 $scope.filter.fromDate = $scope.fdate.getFullYear() + "-" + ($scope.fdate.getMonth() + 1) + "-" + $scope.fdate.getDate();
                 $scope.filter.toDate = $scope.tdate.getFullYear() + "-" + ($scope.tdate.getMonth() + 1) + "-" + $scope.tdate.getDate();

                 jobcardheaderAppService.getJobCardHeadersByDateRangeAndDoneBy({
                     from: $scope.filter.fromDate,
                     to: $scope.filter.toDate,
                     doneBy: $scope.selectedEmployeeFullName.fullName
                 }).success(function (result) {
                     vm.jobCardHeader = result.items;
                     $rootScope.jobsDoneByMechanic = vm.jobCardHeader;
                   
                     $state.go('jobcarddetails');

                 });
             }

           
             //Home logic...
         }
    ]);
})();


