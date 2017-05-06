(function () {
    var controllerId = 'app.views.dashboard.maintenance.jobCardsForTotalCost';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.jobCardHeader'
        , function ($rootScope, $scope, $state, $stateParams, jobcardheaderAppSerice) {
            var vm = this;
            vm.jobCardHeader = [];
            vm.jobCardHeader = $rootScope.JobCardHeadersTotalCal;
            var totalCost = 0;

            vm.cost = {};

            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }


            angular.forEach(vm.jobCardHeader, function (item) {
                totalCost = totalCost + item.totalCost;
            });

            vm.cost = totalCost;

        }


            //Home logic...

    ]);
})();


