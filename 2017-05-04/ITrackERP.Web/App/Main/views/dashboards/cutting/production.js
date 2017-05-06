(function () {
    var controllerId = 'app.views.dashboard.cutting.production';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.cuttingMaster'
        , function ($rootScope, $scope, $state, $stateParams, cuttingMasterAppSerice) {
            var vm = this;

            $scope.amChartOptions = {
                type: "serial",
                theme: "light",
                marginRight: 40,
                marginLeft: 40,
               autoMarginOffset: 20,
                mouseWheelZoomEnabled: true,
                dataDateFormat: "YYYY-MM-DD",
                valueAxes: [{
                    id: "v1",
                    axisAlpha: 0,
                    position: "left",
                    ignoreAxisWidth: true
                }],
                balloon: {
                    borderThickness: 1,
                    shadowAlpha: 0
                },
                graphs: [{
                    id: "g1",
                    
                    fillAlphas: 0.9,
                    balloon: {
                        drop: true,
                        adjustBorderColor: false,
                        color: "#ffffff"
                    },
                    bullet: "round",
                    bulletBorderAlpha: 1,
                    bulletColor: "#FFFFFF",
                    bulletSize: 5,
                    hideBulletsCount: 50,
                    lineThickness: 2,
                    title: "red line",
                    useLineColorForBulletBorder: true,
                    valueField: "value",
                    balloonText: "<span style='font-size:18px;'>[[value]]%</span>"
                }],
                chartScrollbar: {
                    graph: "g1",
                    oppositeAxis: false,
                    offset: 30,
                    scrollbarHeight: 80,
                    backgroundAlpha: 0,
                    selectedBackgroundAlpha: 0.1,
                    selectedBackgroundColor: "#888888",
                    graphFillAlpha: 0,
                    graphLineAlpha: 0.5,
                    selectedGraphFillAlpha: 0,
                    selectedGraphLineAlpha: 1,
                    autoGridCount: true,
                    color: "#AAAAAA"
                },
                chartCursor: {
                    pan: true,
                    valueLineEnabled: true,
                    valueLineBalloonEnabled: true,
                    cursorAlpha: 1,
                    cursorColor: "#258cbb",
                    limitToGraph: "g1",
                    valueLineAlpha: 0.2,
                    valueZoomable: true
                },
                valueScrollbar: {
                    oppositeAxis: false,
                    offset: 50,
                    scrollbarHeight: 10
                },
                categoryField: "date",
               
                export: {
                    "enabled": true
                },
                data: [{
                    "date": "7587",
                    "value": 50
                }, {
                    "date": "7996",
                    "value": 66
                }, {
                    "date": "8013",
                    "value": 64
                }, {
                    "date": "8948",
                    "value": 112
                }, {
                    "date": "9550",
                    "value": 67
                }, {
                    "date": "9874",
                    "value": 49
                }, {
                    "date": "15455",
                    "value": 0
                }, {
                    "date": "4998",
                    "value": 64
                }, {
                    "date": "6961",
                    "value": 41
                }, {
                    "date": "7345",
                    "value": 0
                }, {
                    "date": "8253",
                    "value": 0
                }, {
                    "date": "6973",
                    "value": 72
                }, {
                    "date": "11731",
                    "value": 0
                }, {
                    "date": "12157",
                    "value": 36
                }, {
                    "date": "12244",
                    "value": 43
                }, {
                    "date": "12316",
                    "value": 49
                }, {
                    "date": "12636",
                    "value": 70
                }, {
                    "date": "12599",
                    "value": 0
                }, {
                    "date": "19939",
                    "value": 56
                }, {
                    "date": "13238",
                    "value": 66
                }, {
                    "date": "13318",
                    "value": 0
                }, {
                    "date": "13367",
                    "value": 24
                }, {
                    "date": "11676",
                    "value": 45
                }, {
                    "date": "13925",
                    "value": 94
                }, {
                    "date": "12468",
                    "value": 52
                }, {
                    "date": "13658",
                    "value": 73
                }, {
                    "date": "13551",
                    "value": 0
                }, {
                    "date": "14054",
                    "value": 39
                }, {
                    "date": "14719",
                    "value": 47
                }, {
                    "date": "14587",
                    "value": 0
                }, {
                    "date": "14843",
                    "value": 70
                }, {
                    "date": "14971",
                    "value": 72
                }, {
                    "date": "14961",
                    "value": 61
                }, {
                    "date": "15398",
                    "value": 57
                }, {
                    "date": "15574",
                    "value": 74
                }, {
                    "date": "15954",
                    "value": 45
                }]
            }













            $scope.isProcessed = false;
            $scope.filter = null;
            $scope.cuttingMaster = [];
            $scope.converteddata = [];


            $scope.Split = function (string, nb) {
                var array = string.split(',');
                return array[nb];
            }



            $scope.getSum = function (items) {
                return items
                .map(function (x) { return x.noOfItem; })
                .reduce(function (a, b) { return a + b; });
            };



            vm.process = function () {

                cuttingMasterAppSerice.getCuttingItems({
                    from: $scope.filter.fromDate,
                    to: $scope.filter.toDate
                }).success(function (result) {
                    $scope.cuttingMaster = result;


                    angular.forEach($scope.cuttingMaster, function (value, index) {

                        angular.forEach(value, function (value1, index1) {

                            console.log();
                            $scope.converteddata.push({ styleNo: value1.styleNo, date: value1.date, color: value1.color, size: value1.size, noOfItem: value1.noOfItem, poNo: value1.poNo });
                        });



                    });





                    $scope.isProcessed = true;

                });


            }

            //Home logic...
        }
    ]);
})();


