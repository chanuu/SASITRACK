(function () {
    var controllerId = 'app.views.dashboard.cutting.tablecut';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.cuttingMaster'
        , function ($rootScope, $scope, $state, $stateParams, cuttingMasterAppSerice) {
            var vm = this;

            $scope.isProcessed = false;
            $scope.filter = {};
            $scope.cuttingMaster = [];
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
            vm.process = function () {

              
                $scope.filter.fromDate = $scope.fdate.getFullYear() + "-" + ($scope.fdate.getMonth()+1) + "-" + $scope.fdate.getDate();
                $scope.filter.toDate = $scope.tdate.getFullYear() + "-" + ($scope.tdate.getMonth()+1) + "-" + $scope.tdate.getDate();;


                cuttingMasterAppSerice.getCuttingItems({
                    from: $scope.filter.fromDate,
                    to: $scope.filter.toDate
                }).success(function (result) {
                    $scope.cuttingMaster = result;

                    // remove array obect array and feed in to array
                    angular.forEach($scope.cuttingMaster, function (value, index) {

                        angular.forEach(value, function (value1, index1) {

                            console.log();
                            $rootScope.converteddata.push({ styleNo: value1.styleNo, date: value1.date, color: value1.color, size: value1.size, noOfItem: value1.noOfItem, poNo: value1.poNo });
                        });



                    });


                    vm.groupBy();





                    $state.go('tablecutdetails');

                });


            }




            vm.groupBy = function () {

                $scope.result = [];

                $rootScope.converteddata.reduce(function (res, value) {
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

                   

                        console.log();
                        $rootScope.chartdata.push({ style: value1.styleNo, pcs: value1.noOfItem });
                      


                });
                $rootScope.tablecuttojson = angular.toJson($rootScope.chartdata);
               // $scope.chartdatatojson = [{ "style": "110090A", "pcs": 752 }, { "style": "C-5102", "pcs": 111 }, { "style": "6069", "pcs": 736 }];

                console.log($rootScope.tablecuttojson);



            }











            //Home logic...
        }
    ]);
})();


