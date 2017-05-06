(function () {
    angular.module('app').controller('app.views.cuttingmasters.createItem', ['$rootScope',
        '$scope', 'abp.services.app.cuttingRatio', 'abp.services.app.cuttingMaster','abp.services.app.estimateConsumption',
        function ($rootScope, $scope, ratioService, cuttingMasterService,estimateConsmption) {
            var vm = this;
           
            $scope.ratios = [];
            $scope.items = [];

            $scope.selectedRatio = null;
            $scope.cuttingMaster = null;

            $scope.estimateConsmption = {} ;

            vm.save = function () {

              

                    $scope.cuttingMaster.cuttingMasterId = $rootScope.cId;
                 
                    $scope.cuttingMaster.cuttingRatioId = $scope.selectedRatio.id;
                  
                    $scope.cuttingMaster.date = new Date();

                    $scope.cuttingMaster.tagPrintedTime = new Date();

                    $scope.cuttingMaster.color = $scope.selectedRatio.color;
                 

                    $scope.cuttingMaster.noOfPlys = $scope.cuttingMaster.noOfItem;
                

                    $scope.cuttingMaster.isTagGenarated = false;
                   

                    $scope.cuttingMaster.isIssued = "false";
                   

                    $scope.cuttingMaster.length = 1;

                    $scope.lot = 0;

                    angular.forEach($scope.selectedRatio.cuttingRatioItem, function(value, key) {
                        $scope.lot =$scope.lot + value.lot; 
                    });

                 
                    
                    $scope.estimateConsmption.layerNo = $scope.cuttingMaster.layerNo;

                    $scope.estimateConsmption.styleId = $scope.selectedRatio.styleId;

                    $scope.estimateConsmption.date = new Date();

                    $scope.estimateConsmption.noOfPlys = $scope.cuttingMaster.noOfPlys;

                    

                    $scope.estimateConsmption.actualSinglePcsConsumption = 0;

                    $scope.estimateConsmption.totalFabricPlan = $scope.cuttingMaster.noOfPlys * $scope.selectedRatio.markerLength;

                    $scope.estimateConsmption.TotalPcs = $scope.cuttingMaster.noOfPlys * $scope.lot;

                    $scope.estimateConsmption.singlePcsConsumption = $scope.estimateConsmption.totalFabricPlan / $scope.estimateConsmption.TotalPcs;

                    $scope.estimateConsmption.actualFabric = 0;

                    $scope.estimateConsmption.deference =0;

                 
                    


                    cuttingMasterService.createItem($scope.cuttingMaster)
                        .success(function () {

                            estimateConsmption.create($scope.estimateConsmption)
                             .success(function () {
                             });

                            abp.notify.success(App.localize('SavedSuccessfully'));
                        });

                   
              


            
              
            };



            function getRatios() {
                ratioService.getCuttingRatioByStyle({ id: $rootScope.cId }).success(function (result) {
                    $scope.ratios = result.items;
                });
            };

            //

            getRatios();
            vm.cancel = function () {
              
            };

        }
    ]);
})();