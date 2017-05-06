(function () {
    var controllerId = 'app.views.dashboard.cutting.fabricutilizationdetails';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.estimateConsumption'
        , function ($rootScope, $scope, $state, $stateParams, consumptionAppSerice) {
            var vm = this;

            $scope.selected = [];
            $scope.isProcessed = false;
         
         
            $scope.datalist = [];

            $scope.selected = $rootScope.chartdata;
           
            $scope.datalist = $rootScope.converteddata;
          



            $scope.amChartOptions = {
                data: $scope.selected,
                type: "serial",
                theme: "light",
                "legend": {
                    "equalWidths": false,
                    "periodValueText": "total(m): [[value.sum]]",
                    "position": "top",
                    "valueAlign": "left",
                    "useMarkerColorForLabels":true,
                    "valueWidth": 100,
                },
                graphs: [{
                    balloonText: "[[title]]: [[value]]",
                  
                    type: "column",
                    fillColors: '#32DADD',
                    title: "Fabric Used",
                    "fillAlphas": 0.8,
                    "columnWidth": 0.3,
                    "lineAlpha": 0.2,
                    valueField: "value2"
                }, {
                    balloonText: "[[title]]: [[value]]",
                    type: "column",
                    "fillAlphas": 0.8,
                    "lineAlpha": 0.2,
                    "columnWidth": 0.3,
                    title: "Fabric Plan",
                    fillColors: '#B6A2DE',
                    valueField: "value1"
                }],
                zoomOutButtonRollOverAlpha: 0.15,

                autoMarginOffset: 5,
                columnWidth: 1,
                categoryField: "style"

            }





        
           



            $scope.Split = function (string, nb) {
                var array = string.split(',');
                return array[nb];
            }


            $scope.getOverUsed = function (items) {
                return items
                .map(function (x) { return x.deference; })
                .reduce(function (w, z) { return w + z; });
            };

            $scope.getActual = function (items) {
                return items
                .map(function (x) { return x.actualFabric; })
                .reduce(function (a, b) { return a + b; });
            };




            

            //Home logic...
        }
    ]);
})();


