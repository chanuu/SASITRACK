(function () {
    var controllerId = 'app.views.dashboard.cutting.fabricutilization';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.estimateConsumption'
        , function ($rootScope, $scope, $state, $stateParams, consumptionAppSerice) {
            var vm = this;

            $scope.selected = [];
            $rootScope.chartdata = [];

            $scope.isProcessed = false;
            $scope.filter = {};
            $scope.cuttingMaster = [];
            $rootScope.converteddata = [];


            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };



            $scope.fdate = new Date();
            $scope.tdate = new Date();


            vm.process = function () {

                $scope.filter.fromDate = $scope.fdate.getFullYear() + "-" + ($scope.fdate.getMonth() + 1) + "-" + $scope.fdate.getDate();
                $scope.filter.toDate = $scope.tdate.getFullYear() + "-" + ($scope.tdate.getMonth() + 1) + "-" + $scope.tdate.getDate();;


                consumptionAppSerice.getEstimateItems({
                    from: $scope.filter.fromDate,
                    to: $scope.filter.toDate
                }).success(function (result) {
                    $scope.cuttingMaster = result;


                    angular.forEach($scope.cuttingMaster, function (value, index) {

                        angular.forEach(value, function (value1, index1) {

                            console.log();
                            $rootScope.converteddata.push({ styleNo: value1.styleNo, date: value1.date, layerNo: value1.layerNo, totlaPcs: value1.totalPcs, noOfPlys: value1.noOfPlys, singlePcsConsumption: value1.singlePcsConsumption, totalFabricPlan: value1.totalFabricPlan, actualFabric: value1.actualFabric, deference: value1.deference });
                        });



                    });





                    $scope.isProcessed = true;

                    vm.groupBy();

                    $state.go('fabricutilizationdetails');

                });


            }



            vm.groupBy = function () {

                $scope.result = [];
                console.log("Log");
                console.log($rootScope.converteddata);
                $rootScope.converteddata.reduce(function (res, value) {
                    if (!res[value.styleNo]) {
                        res[value.styleNo] = {
                            actualFabric: 0,
                            totalFabricPlan :0,
                            styleNo: value.styleNo
                        };
                        $scope.result.push(res[value.styleNo])
                    }
                    res[value.styleNo].totalFabricPlan += value.totalFabricPlan;
                    res[value.styleNo].actualFabric += value.actualFabric;

                   
                    return res;
                }, {});

                console.log($rootScope.converteddata);
                // remove array obect array and feed in to array
                angular.forEach($scope.result, function (value1, index) {



                   
                    $rootScope.chartdata.push({ style: value1.styleNo, value1: value1.totalFabricPlan, value2: value1.actualFabric });



                });
               

            }










            //Home logic...
        }
    ]);
})();


