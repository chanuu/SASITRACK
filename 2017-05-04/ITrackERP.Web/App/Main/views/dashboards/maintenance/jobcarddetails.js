(function () {
    var controllerId = 'app.views.dashboard.maintenance.jobcarddetails';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.jobCardHeader'
        , function ($rootScope, $scope, $state, $stateParams, jobcardheaderAppSerice) {
            var vm = this;
            vm.jobCardHeader = [];
            vm.jobCardHeader = $rootScope.jobsDoneByMechanic;



            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }


        }


            //Home logic...

    ]);
})();


