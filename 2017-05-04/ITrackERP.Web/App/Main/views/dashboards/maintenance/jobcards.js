(function () {
    var controllerId = 'app.views.dashboard.maintenance.jobcards';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.jobCardHeader', 'abp.services.app.asset',
         function ($rootScope, $scope, $state, $stateParams, jobcardheaderAppService, assetService) {
            var vm = this;

            vm.assets = [];
            $scope.selectedAssetNo = null;


            $scope.isProcessed = false;
            $scope.filter = {};
            vm.jobCardHeader = [];
            $rootScope.allJobCardHeader = [];

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


            function getAssets() {
                assetService.getAsset({}).success(function (result) {
                    vm.assets = result.items;
                });
            }
            getAssets();

            //
            $scope.afterSelectedAssetNo = function (selected) {
                if (selected) {
                    $scope.selectedAssetNo = selected.originalObject;
                }
            }



            vm.process = function () {


                $scope.filter.fromDate = $scope.fdate.getFullYear() + "-" + ($scope.fdate.getMonth() + 1) + "-" + $scope.fdate.getDate();
                $scope.filter.toDate = $scope.tdate.getFullYear() + "-" + ($scope.tdate.getMonth() + 1) + "-" + $scope.tdate.getDate();;

                jobcardheaderAppService.getJobCardHeadersByDateRangeAndAssetNo({
                    from: $scope.filter.fromDate,
                    to: $scope.filter.toDate,
                    assetNo: $scope.selectedAssetNo.assetNo
                }).success(function (result) {
                    vm.jobCardHeader = result.items;
                    $rootScope.allJobCardHeader = vm.jobCardHeader;

                    $state.go('jobcarddetailsofselectedasset');

                });


            }

            //Home logic...
        }
    ]);
})();


