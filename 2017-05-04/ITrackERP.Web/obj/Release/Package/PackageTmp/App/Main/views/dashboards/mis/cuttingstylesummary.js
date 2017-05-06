(function () {
    var controllerId = 'app.views.dashboard.mis.cuttingstylesummary';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.cuttingMaster','abp.services.app.workOrder'
        , function ($rootScope, $scope, $state, $stateParams, cuttingMasterAppSerice,workOrderAppService) {
            var vm = this;

            $scope.isProcessed = false;
            $scope.filter = {};
            $scope.cuttingMaster = [];
            $scope.cuttingDetails = [];
            $rootScope.converteddata = [];
            $scope.orderdetailsconverted = [];
            $scope.styleId = {};
            $rootScope.chartdata = [];
            $scope.tablecuttojson = [];
            $scope.totaltableCut = 0;
            $scope.qty = 0;



            //order details 
            $scope.orderDetails = [];

            $rootScope.cId = $stateParams.id;


            // date picker options 

            $rootScope.cId = $stateParams.id;


            function loadCuttingRatio() {
                cuttingMasterAppSerice.getCuttingItemByID({
                    id: $stateParams.id
                }).success(function (result) {
                    $scope.cuttingMaster = result;


                    // remove array obect array and feed in to array
                    angular.forEach($scope.cuttingMaster, function (value, index) {

                        angular.forEach(value, function (value1, index1) {

                            console.log();
                            $rootScope.converteddata.push({ styleNo: value1.styleNo, date: value1.date, color: value1.color, size: value1.size, noOfItem: value1.noOfItem, poNo: value1.poNo });
                        });

                        vm.groupBy();

                        vm.getDetails();

                       

                    });


                });
            }



            loadCuttingRatio();



         vm.getDetails =   function () {
                cuttingMasterAppSerice.getDetail({
                    id: $rootScope.cId
                }).success(function (result) {
                    $scope.cuttingDetails = result;
                    console.log($scope.cuttingDetails);
                    $scope.styleId = $scope.cuttingDetails.styleId;
                    vm.getOrderDetails();
                });
            }



        // call group by for summarizing informations 

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
                    $scope.totaltableCut = value1.noOfItem;


                });
                $scope.tablecuttojson = angular.toJson($rootScope.chartdata);

                // $scope.chartdatatojson = [{ "style": "110090A", "pcs": 752 }, { "style": "C-5102", "pcs": 111 }, { "style": "6069", "pcs": 736 }];

                console.log($scope.tablecuttojson);



            }




            // get order Details 

            vm.getOrderDetails = function () {
                workOrderAppService.getDetailByStyle({

                    id: $scope.styleId

                }).success(function (result) {

                    $scope.orderDetails = result;


                    angular.forEach($scope.orderDetails, function (value, index) {

                        angular.forEach(value, function (value1, index1) {

                            console.log();
                            $scope.orderdetailsconverted.push({ color: value1.color, size: value1.size, quantity: value1.quantity, poNo: value1.poNo });
                        });





                        console.log($scope.orderDetails);

                        vm.ordersummary();

                    });
                });

                };


            vm.ordersummary = function () {

                $scope.resultorder = [];


                $scope.qty = 0;
                angular.forEach($scope.orderdetailsconverted, function (value1, index) {

                    $scope.qty = value1.quantity + $scope.qty;

                });




               
            }



            //Home logic...
       

       

        }])

})();


