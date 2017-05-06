(function () {
    var controllerId = 'app.views.dashboard';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;

            $scope.amChartOptions = {
                data: [
                    {
                        emplyee: "14605-renuka",
                        pcs: 1000,
                        expenses: 18.1
                    }, {
                        emplyee: "14606-imalka",
                        pcs: 550,
                        expenses: 22.8
                    }, {
                        emplyee: "14608-amali",
                        pcs: 850,
                        expenses: 23.9
                    }, {
                        emplyee: "14245-wenuri",
                        pcs: 50,
                        expenses: 25.1
                    }, {
                        emplyee: "147808-bimali",
                        pcs: 780,
                        expenses: 25.1
                    },
                 {
                     emplyee: "14741-Wimala",
                     pcs: 250,
                     expenses: 25.1
                 },
                  {
                      emplyee: "13580-sumana",
                      pcs: 780,
                      expenses: 25.1
                  },
                  {
                      emplyee: "12504-ashanthi",
                      pcs: 220,
                      expenses: 25.1
                  },
                    {
                    emplyee: "14605-renuka",
                    pcs: 1000,
                    expenses: 18.1
                }, {
                    emplyee: "14606-imalka",
                    pcs: 980,
                    expenses: 22.8
                }, {
                    emplyee: "14608-amali",
                    pcs: 850,
                    expenses: 23.9
                }, {
                    emplyee: "14245-wenuri",
                    pcs: 780,
                    expenses: 25.1
                }, {
                    emplyee: "147808-bimali",
                    pcs: 780,
                    expenses: 25.1
                },
                 {
                     emplyee: "14741-Wimala",
                     pcs: 900,
                     expenses: 25.1
                 },
                  {
                      emplyee: "13580-sumana",
                      pcs: 780,
                      expenses: 25.1
                  },
                  {
                      emplyee: "12504-ashanthi",
                      pcs: 650,
                      expenses: 25.1
                  },
                    {
                        emplyee: "14503-imalka",
                        pcs: 780,
                        expenses: 25.1
                    },

                {
                    emplyee: "05120-ranasinghe",
                    pcs: 780,
                    expenses: 25
                }],

                type: "serial",
                "theme": "light",
                categoryField: "emplyee",
                "marginLeft": 80,
                rotate: false,
                "mouseWheelZoomEnabled": true,
                pathToImages: 'app/Main/plugins/amcharts/images/',
                legend: {
                    enabled: true
                },


                chartScrollbar: {
                    "graph": "g1",
                    "oppositeAxis": false,
                    "offset": 30,
                    "scrollbarHeight": 50,
                    "backgroundAlpha": 0,
                    "selectedBackgroundAlpha": 0.1,
                    "selectedBackgroundColor": "#888888",
                    "graphFillAlpha": 0,
                    "graphLineAlpha": 0.5,
                    "selectedGraphFillAlpha": 0,
                    "selectedGraphLineAlpha": 1,
                    "autoGridCount": true,
                    "color": "#AAAAAA"
                },
                categoryAxis: {
                    gridPosition: "start",
                    "dashLength": 1,
                    parseDates: false,
                    "minorGridEnabled": true,
                    labelsEnabled: false,
                },
                "chartCursor": {
                    "categoryBalloonDateFormat": "YYYY",
                    "cursorAlpha": 0,
                    "pan": true,
                    "valueLineEnabled": true,
                    "valueLineBalloonEnabled": true,
                    "cursorColor": "#258cbb",
                    "valueLineAlpha": 0.5,
                    "fullWidth": true,
                    "limitToGraph": "g1",
                    "valueLineAlpha": 0.5,
                    "valueZoomable": true

                },
                valueAxes: [{
                  
                    title: "Pcs",
                    ignoreAxisWidth: true,
                    labelsEnabled :false,
                },


                {

                }],


                graphs: [{
                    "id": "g1",
                    "balloon": {
                        "drop": true,
                        "adjustBorderColor": false,
                        "color": "#ffffff"
                    },
                 
                    title: "Pcs",
                    valueField: "pcs",
                    "bullet": "round",
                    "bulletBorderAlpha": 1,
                    "bulletColor": "#FFFFFF",
                    "bulletSize": 10,
                    fillAlphas: 0.0,
                    "graphFillAlpha": 0,
                    "lineThickness": 2,
                    ignoreAxisWidth: true,
                    "useLineColorForBulletBorder": true,
                    "balloonText": "[[value]]",

                }]

            }

            //Home logic...
        }
    ]);
})();


