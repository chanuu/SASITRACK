(function () {
    var controllerId = 'app.views.dashboards.maintenance.jobCardInDetail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$modal', '$state', '$stateParams', 'abp.services.app.jobCardHeader', 'abp.services.app.jobCardItem', 'abp.services.app.serialItem',
    function ($rootScope, $scope, $modal, $state, $stateParams, jobCardHeaderService, jobCardItemService, serialitemService) {
        var vm = this;
        $rootScope.JobCardHeaderId = $stateParams.id;
        $scope.jobCardHeader = {};

        function loadJobCardDetails() {
            jobCardHeaderService.getDetail({
                id: $stateParams.id
            }).success(function (result) {
                vm.jobcardheader = result;
               
            });
        }

        vm.back = function () {
            $state.go('mechanicjobs');
        };

        loadJobCardDetails();

        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;   //set the sortKey to the param passed
            $scope.reverse = !$scope.reverse; //if true make it false and vice versa
        }

              
    }
    ]);
})();