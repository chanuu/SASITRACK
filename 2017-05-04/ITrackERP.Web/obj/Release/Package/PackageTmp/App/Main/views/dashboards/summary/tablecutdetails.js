(function () {
    var controllerId = 'app.views.dashboard.summary.tablecutdetails';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.cuttingMaster', 'abp.services.app.estimateConsumption', 'abp.services.app.production'
        , function ($rootScope, $scope, $state, $stateParams, cuttingMasterAppSerice, consumptionAppSerice, dailyproductionAppService) {
            var vm = this;


            $scope.filter = {};
            $scope.amOptions = {};
            $scope.chartConfig2 = {};
            $scope.converteddata = [];
            $scope.cdata = [];
            $scope.tcuttojson = [];


            $scope.fabricUsed = [];
            $scope.fabricUsedCon = [];


            vm.productiondata = [];
            $rootScope.pdata = [];
            $rootScope.pdataformated = [];

          
            $scope.fdate = new Date();
            $scope.tdate = new Date();

            vm.process = function () {


              //  $scope.filter.fromDate = $scope.fdate.getFullYear() + "-" + ($scope.fdate.getMonth() + 1) + "-" + $scope.fdate.getDate();
              //  $scope.filter.toDate = $scope.tdate.getFullYear() + "-" + ($scope.tdate.getMonth() + 1) + "-" + $scope.tdate.getDate();


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



                    console.log(value1.noOfItem);
                    console.log(value1.styleNo);
                    $scope.cdata.push({ style: value1.styleNo, pcs: value1.noOfItem });



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
                        type: 'column'
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
                        type: 'column'
                       
                    },
                    {

                       data: $scope.fabircactual,
                       name: 'Actual',
                       type: 'column',
                       color: '#6A3D9A'
                    },
                     {

                         data: $scope.overused,
                         name: 'Over Used',
                         type: 'column',
                         color: '#FE6383'
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

           

            vm.getProductionDetails = function () {

                dailyproductionAppService.getProductionSummary({
                    date: $scope.fdate.getFullYear() + "-" + ($scope.fdate.getMonth() + 1) + "-" + $scope.fdate.getDate(),
           
                }).success(function (result) {

                    $rootScope.pdata = result;

                    angular.forEach($rootScope.pdata, function (value, index) {

                        angular.forEach(value, function (value1, index1) {

                         
                            $rootScope.pdataformated.push({ styleNo: value1.styleNo, date: value1.date, lineNo: value1.lineNo, poNo: value1.poNo, color: value1.color, size: value1.size, lineIn: value1.lineIn, lineOut: value1.lineOut });
                        });



                    });

                    vm.groupByProduction();

                    vm.formatData();
                   
                });

            }
            console.log("Log");
            console.log($rootScope.pdataformated);

            vm.getProductionDetails();

           

            $rootScope.productionresult = [];
            $rootScope.lstlinein = [];
            $scope.lstlineout = [];



            vm.groupByProduction = function () {



                $rootScope.pdataformated.reduce(function (res, value) {
                    if (!res[value.lineNo]) {
                        res[value.lineNo] = {
                            lineIn: 0,
                            lineOut: 0,
                            lineNo: value.lineNo
                        };
                        $rootScope.productionresult.push(res[value.lineNo])
                    }
                    res[value.lineNo].lineIn += value.lineIn;
                    res[value.lineNo].lineOut += value.lineOut;
                    return res;
                }, {});

                
                // remove array obect array and feed in to array
                angular.forEach($rootScope.productionresult, function (value1, index) {


                    


                    $rootScope.lstlinein.push([value1.lineNo, value1.lineIn]);

                    $scope.lstlineout.push([value1.lineNo, value1.lineOut]);

                 
                  




                });


                $rootScope.config= {
                    chart: {
                        type: 'bar'
                    },

                    series: [{
                        data: $rootScope.lstlinein,
                        name: 'LineIn',
                        type: 'column',
                        color: '#33B8FF'

                    },
                    {

                        data: $scope.lstlineout,
                        name: 'LineOut',
                        type: 'column',
                        color: '#71FF33'
                    }

                    ],
                    title: {
                        text: 'Production summary'
                    },
                    xAxis: {
                        categories: ['5190', '044730(3875)', 'D1767374', 'D1767366']
                    }
                }


            }



            vm.formatData = function () {

                angular.forEach($rootScope.productionresult, function (value1, index) {

                    $rootScope[index].datai =[]
                    $rootScope[index].datai = $rootScope.pdataformated.filter(function (i) {

                        return i.lineNo === value1.lineNo;
                    });

                    console.log(datai);

                   








                });

            }

           






            }










            //Home logic...
        
    ]);
})();


