(function () {
    var controllerId = 'app.views.dashboard.cutting.tablecutdetails';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.cuttingMaster'
        , function ($rootScope, $scope, $state, $stateParams, cuttingMasterAppSerice) {
            var vm = this;

            $scope.isProcessed = false;
        
            $scope.datalist = $rootScope.converteddata

            $scope.chartdata = $rootScope.chartdata;

           
            
            $scope.getSum = function (items) {
                return items
                .map(function (x) { return x.noOfItem; })
                .reduce(function (a, b) { return a + b; });
            };


            $scope.Split = function (string, nb) {
                var array = string.split(',');
                return array[nb];
            }




            $scope.amChartOptions = {

                data: $scope.chartdata,
                type: "pie",
                theme: 'light',
                outlineAlpha: 0.4,
                angle: 30,
                balloonText: "Style No:[[title]]<br><span style='font-size:14px'><b>Pcs:[[value]]</b> ([[percents]]%)</span>",
                depth3D: 15,
                legend: {
                    "position": "right",
                    "marginRight": 100,
                    "autoMargins": false
                },
                valueField: "pcs",
                titleField: "style",
            };







            }










            //Home logic...
        
    ]);
})();


