(function() {
    var controllerId = 'app.views.home';
    angular.module('app').controller(controllerId, [
        '$scope', function($scope) {
            var vm = this;

            $scope.amChartOptions = {
                data: [{
                    line: "V-1",
                    pcs: 1000,
                    expenses: 18.1
                }, {
                    line:"V-2",
                    pcs: 980,
                    expenses: 22.8
                }, {
                    line: "V-3",
                    pcs: 850,
                    expenses: 23.9
                }, {
                    line: "V-4",
                    pcs: 780,
                    expenses: 25.1
                }, {
                    line: "V-4",
                    pcs: 780,
                    expenses: 25.1
                },
                 {
                     line: "V-5",
                     pcs: 900,
                     expenses: 25.1
                 },
                  {
                      line: "V-6",
                      pcs: 780,
                      expenses: 25.1
                  },
                  {
                      line: "V-7",
                      pcs: 650,
                      expenses: 25.1
                  },
                    {
                        line: "V-8",
                        pcs: 780,
                        expenses: 25.1
                    },

                {
                    line: "V-9",
                    pcs: 780,
                    expenses: 25
                }],

          

                type: "serial",
                "theme": "light",
                categoryField: "line",
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
                    parseDates: false,
                    "minorGridEnabled": true
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
                    position: "top",
                    title: "Pcs",
                    ignoreAxisWidth: true
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
                    type: "smoothedLine",
                    title: "Pcs",
                    valueField: "pcs",
                    "bullet": "round",
                    fillAlphas: 0.4,
                    "graphFillAlpha": 0,
                    "lineThickness": 2,
                    ignoreAxisWidth: true,
                    "useLineColorForBulletBorder": true,
                    "balloonText": "[[category]]<br><b><span style='font-size:14px;'>[[value]]</span></b>",
       
                }]
          
            }

         
            //Home logic...
        }
    ]);
})();


