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
                graphs: [{
                    balloonText: "[[title]]: [[value]]",
                    columnWidth: 20,

                    lineColor: "#FF80AB",
                    title: "Fabric Used",
                    lineThickness: 2,
                    valueField: "value2"
                }, {
                    balloonText: "[[title]]: [[value]]",
                    lineThickness: 2,

                    title: "Fabric Plan",
                    lineColor: "#3F51B5",
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


