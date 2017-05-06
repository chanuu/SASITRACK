(function () {
    var controllerId = 'app.views.dashboard.assets.rentmachines';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.rentMachine'
        , function ($rootScope, $scope, $state, $stateParams, rentMachinesAppSerice) {
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


      
            vm.process = function () {

                rentMachinesAppSerice.getRentMachines({
                   
                }).success(function (result) {
                    $scope.rentMachines = result;

                    // remove array obect array and feed in to array
                    angular.forEach($scope.rentMachines, function (value, index) {

                        angular.forEach(value, function (value1, index1) {

                            console.log();
                            $scope.converteddata.push({ machineType: value1.machineType, nos: 1  });
                        });



                    });


                    vm.groupBy();







                });


            }




            vm.groupBy = function () {

                $scope.result = [];

                $scope.converteddata.reduce(function (res, value) {
                    if (!res[value.machineType]) {
                        res[value.machineType] = {
                            nos: 0,
                            machineType: value.machineType
                        };
                        $scope.result.push(res[value.machineType])
                    }
                    res[value.machineType].nos += value.nos
                    return res;
                }, {});


                // remove array obect array and feed in to array
                angular.forEach($scope.result, function (value1, index) {



                    $scope.cdata.push({ machineType: value1.machineType, nos: value1.nos });



                });
                $scope.tcuttojson = angular.toJson($scope.cdata);

                $scope.objects = [];
                $.each($scope.cdata, function (index, value) {
                    $scope.objects.push([value.machineType, value.nos]);
                });

                $scope.chartConfig = {
                    chart: {
                        type: 'bar'
                    },
                    series: [{
                        data: $scope.objects,
                        name: 'Nos',
                        type: 'column'
                    }],
                    title: {
                        text: 'Rent Machine By Type'
                    }
                }

                // $scope.chartdatatojson = [{ "style": "110090A", "pcs": 752 }, { "style": "C-5102", "pcs": 111 }, { "style": "6069", "pcs": 736 }];

                console.log($scope.tcuttojson);



            }


            vm.process();


          



















        }










            //Home logic...

    ]);
})();


