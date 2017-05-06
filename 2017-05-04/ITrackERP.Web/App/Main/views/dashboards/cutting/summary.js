(function () {
    var controllerId = 'app.views.dashboard.cutting.summary';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.cuttingMaster', 'abp.services.app.estimateConsumption', 'abp.services.app.production', 'abp.services.app.workOrder'
        , function ($rootScope, $scope, $state, $stateParams, cuttingMasterAppSerice, consumptionAppSerice, dailyproductionAppService, workOrderAppService) {
            var vm = this;


            $scope.filter = {};
            $scope.amOptions = {};
            $scope.chartConfig2 = {};
            $scope.converteddata = [];
            $scope.cdata = [];
            $scope.tcuttojson = [];


            $scope.fabricUsed = [];
            $scope.fabricUsedCon = [];

            $scope.orderTotal =0;
            vm.productiondata = [];
            $rootScope.pdata = [];
            $rootScope.pdataformated = [];


            $scope.fdate = new Date();
            $scope.tdate = new Date();


            $scope.cutSummary = [];




            vm.process = function () {


                //  $scope.filter.fromDate = $scope.fdate.getFullYear() + "-" + ($scope.fdate.getMonth() + 1) + "-" + $scope.fdate.getDate();
                //  $scope.filter.toDate = $scope.tdate.getFullYear() + "-" + ($scope.tdate.getMonth() + 1) + "-" + $scope.tdate.getDate();

                cuttingMasterAppSerice.getCuttingSummary({
                    from: $scope.fdate.getFullYear() + "-" + ($scope.fdate.getMonth() + 1) + "-" + $scope.fdate.getDate()
                }).success(function (result) {
                    $scope.cutSummary = result;

                })


                cuttingMasterAppSerice.getCuttingItems({
                    from: $scope.fdate.getFullYear() + "-" + ($scope.fdate.getMonth() + 1) + "-" + $scope.fdate.getDate(),
                    to: $scope.filter.toDate = $scope.tdate.getFullYear() + "-" + ($scope.tdate.getMonth() + 1) + "-" + $scope.tdate.getDate()
                }).success(function (result) {
                    $scope.cuttingMaster = result;

                    // remove array obect array and feed in to array
                    angular.forEach($scope.cuttingMaster, function (value, index) {

                        angular.forEach(value, function (value1, index1) {

                            console.log();
                            $scope.converteddata.push({ styleNo: value1.styleNo, date: value1.date, color: value1.color, size: value1.size, noOfItem: value1.noOfItem, poNo: value1.poNo });
                        });



                    });


                    vm.groupBy();







                });


            }



            vm.getOrderQty = function (value,styleNo) {

                workOrderAppService.getOrderQty({
                    styleNo: styleNo
                }).success(function (result) {

                   value = result;
                    console.log(value + "Test");
                    
                  
                });
                return value;
            }


            vm.groupBy = function () {

                $scope.result = [];

                $scope.converteddata.reduce(function (res, value) {
                    if (!res[value.styleNo]) {
                        res[value.styleNo] = {
                            noOfItem: 0,
                            styleNo: value.styleNo
                        };
                        $scope.result.push(res[value.styleNo])
                    }
                    res[value.styleNo].noOfItem += value.noOfItem
                    return res;
                }, {});


                // remove array obect array and feed in to array
                angular.forEach($scope.result, function (value1, index) {


                    var value = 0;
                  
                 
                    workOrderAppService.getOrderQty({
                        styleNo: value1.styleNo
                    }).success(function (result) {

                        value = result.result;
                     


                    });

                   
                    $scope.cdata.push({ style: value1.styleNo, pcs: value1.noOfItem, orderQty: value });

                    console.log($scope.cdata);

                });


                $scope.tcuttojson = angular.toJson($scope.cdata);

                $scope.objects = [];
                $.each($scope.cdata, function (index, value) {
                    $scope.objects.push([value.style, value.pcs]);
                });

                $scope.chartConfig = {
                    chart: {
                        type: 'bar'
                    },
                    series: [{
                        data: $scope.objects,
                        name: 'StyleNo',
                        type: 'column',

                        color: '#B6A2DE'
                    }],
                    title: {
                        text: 'Table Cut By Style'
                    }
                }

                // $scope.chartdatatojson = [{ "style": "110090A", "pcs": 752 }, { "style": "C-5102", "pcs": 111 }, { "style": "6069", "pcs": 736 }];

                console.log($scope.tcuttojson);



            }


            vm.process();


            $scope.datalist = $scope.converteddata

            //  $scope.chartdata = $rootScope.chartdata;

            $scope.getSum = function (items) {
                return items
                .map(function (x) { return x.noOfItem; })
                .reduce(function (a, b) { return a + b; });
            };


            $scope.Split = function (string, nb) {
                var array = string.split(',');
                return array[nb];
            }




            ///////////////////////fabric cnsumtion chart////////////

            vm.processFabric = function () {




                consumptionAppSerice.getEstimateItems({
                    from: $scope.fdate.getFullYear() + "-" + ($scope.fdate.getMonth() + 1) + "-" + $scope.fdate.getDate(),
                    to: $scope.filter.toDate = $scope.tdate.getFullYear() + "-" + ($scope.tdate.getMonth() + 1) + "-" + $scope.tdate.getDate()
                }).success(function (result) {
                    $scope.fabricUsed = result;


                    angular.forEach($scope.fabricUsed, function (value, index) {

                        angular.forEach(value, function (value1, index1) {

                            console.log();
                            $scope.fabricUsedCon.push({ styleNo: value1.styleNo, date: value1.date, layerNo: value1.layerNo, totlaPcs: value1.totalPcs, noOfPlys: value1.noOfPlys, singlePcsConsumption: value1.singlePcsConsumption, totalFabricPlan: value1.totalFabricPlan, actualFabric: value1.actualFabric, deference: value1.deference });
                        });



                    });





                    $scope.isProcessed = true;

                    vm.groupByFabric();

                    //  $state.go('fabricutilizationdetails');

                });


            }


            $scope.fabircresult = [];
            $scope.fabircchart = [];
            $scope.fabircactual = [];
            $scope.overused = [];
            $scope.cat = [];


            vm.groupByFabric = function () {



                $scope.fabricUsedCon.reduce(function (res, value) {
                    if (!res[value.styleNo]) {
                        res[value.styleNo] = {
                            actualFabric: 0,
                            totalFabricPlan: 0,
                            styleNo: value.styleNo
                        };
                        $scope.fabircresult.push(res[value.styleNo])
                    }
                    res[value.styleNo].totalFabricPlan += value.totalFabricPlan;
                    res[value.styleNo].actualFabric += value.actualFabric;
                    return res;
                }, {});


                // remove array obect array and feed in to array
                angular.forEach($scope.fabircresult, function (value1, index) {


                    console.log($scope.fabircresult);


                    $scope.fabircchart.push([value1.styleNo, value1.totalFabricPlan]);

                    $scope.fabircactual.push([value1.styleNo, value1.actualFabric]);

                    $scope.overused.push([value1.styleNo, value1.actualFabric - value1.totalFabricPlan]);

                    $scope.cat.push(value1.styleNo);




                });


                $scope.chartConfig2 = {
                    chart: {
                        type: 'bar'
                    },

                    series: [{
                        data: $scope.fabircchart,
                        name: 'Plan',
                        type: 'column',
                        color: '#32DADD'

                    },
                    {

                        data: $scope.fabircactual,
                        name: 'Actual',
                        type: 'column',
                        color: '#B6A2DE'
                    },
                     {

                         data: $scope.overused,
                         name: 'Over Used',
                         type: 'column',
                         color: '#FFB980'
                     }

                    ],
                    title: {
                        text: 'Fabric Consumtion Plan Vs Actual'
                    },
                    xAxis: {
                        categories: ['5190', '044730(3875)', 'D1767374', 'D1767366']
                    }
                }


            }


            // 6A3D9A - purple     1F79B4 - Blue     FE6383 - pink


            vm.processFabric();





            /////////////////////////////////////// Production Chart //////////////////////////////////////






        }










            //Home logic...

    ]);
})();


