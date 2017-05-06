(function () {
    var controllerId = 'app.views.dashboard.assets.machinerequirement';
    angular.module('app').controller(controllerId, ['$filter','$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.machineRequirement', 'abp.services.app.asset','_'
        , function ($filter,$rootScope, $scope, $state, $stateParams, machineRequirement,assetAppService, _) {
            var vm = this;

            $scope.isProcessed = false;
            $scope.filter = {};
            $scope.cuttingMaster = [];
            $rootScope.converteddata = [];
            $rootScope.chartdata = [];
            $rootScope.tablecuttojson = [];
            $rootScope.converteddata.machines = [];
            $scope.machineTypeTotal = [];

            $scope.assetList = [];
           
        
            $scope.mtypes = ['SND', 'SND (UBT)', 'SND (PULLAR)', 'SND (CHAIN)', 'NEEDLE FEEDING', 'DND', 'DND (UBT)', 'DND (PULLAR)', 'DND (CHAIN)', '3OVL', '3OVL(WITH FEEDER)', '4OVL', '5OVL', 'BABY OVL', 'H/CUTTER', 'FLAT LOCK', 'BAR TACK', 'BUTTON HOLE', 'BUTTON ATTACH', 'BUTTON ATTACH(CHAIN)', 'BUTTON ATTACH(LOCK)', 'BUTTON FEEDER', 'WRAP MACHINE', 'BLIND HEM', 'BLIND HEM(IN SIDE)', 'BLIND HEM(OUT SIDE)', 'SLEEVE SETTING', 'SHOULDER PAD', 'PEARL', 'AMF', 'SYLINDER BED', 'FEED OF THE ARM', 'KANSAI', 'ILOT MACHINE', 'PUNCH MACHINE', 'HOOK & BAR', 'SIG ZAG', 'POINTER M/C', 'HEAT SEAL', 'IRON (SQ)', 'IRON (NA)', 'IRON (LONG ARM)', 'TBL', 'QC TBL']
            

            $scope.scroll = function () {
                $('#container').slimScroll({
                  
                   width:'700px'
                  


                });
            }

            // date picker options 


           // get asset by location
            vm.getLocationAssetList = function (location) {
                assetAppService.getAssetByLocation({
                    location: location
                }).success(function (result) {

                    $scope.assetList = result;

                    vm.removeObject();

                    vm.assetGroupByType($scope.assetList);

                    vm.combineAvailAndRequirement();
               //  vm.assetGroupByType($scope.assetList);

                  
                  
                })
            }

            $scope.assetJson = [];

            vm.removeObject = function () {
                $scope.assetJson.length = 0;
                angular.forEach($scope.assetList, function (type1, index1) {

                    angular.forEach(type1, function (type, index1) {

                        $scope.assetJson.push({ type: type.assetName, assetNo: type.assetNo, location: type.location,nos:1 })
                    });

                });
               
            }



            $scope.finalMachineResult = [];
           

            // group asset by type 
            vm.combineAvailAndRequirement = function () {
                $scope.finalMachineResult.length = 0;
                // go through machine types define by tempalte 
                angular.forEach($scope.mtypes, function (type, index1) {
                    var num = 0;
                    var _required = 0;
                    var avail = $filter('filter')($scope.mtype, { type: type });

                    angular.forEach(avail, function (t, index) {
                        num = t.nos;
                    });

                    if (avail.length > 0) {
                        num = num;
                    }

                    var required = $filter('filter')($scope.result, { type: type });
                    angular.forEach(required, function (x, index) {
                        _required = x.Nos;
                    });

                   
                   

                    $scope.finalMachineResult.push({ type: type, nos: num, required: _required, deference: num - _required });

                   

                });
                console.log($scope.finalMachineResult);

            }



            vm.assetGroupByType = function (list)
            {

                $scope.mtype = [];
                $scope.assetJson.reduce(function (res, value) {
                    if (!res[value.type]) {
                        res[value.type] = {
                            nos: 0,
                            type: value.type
                        };
                        $scope.mtype.push(res[value.type])
                    }
                    res[value.type].nos += value.nos
                    return res;
                }, {});

              

            }




            
           



            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };


          
           
            $scope.fdate = new Date();
          
            vm.process = function () {
               
              
                $scope.filter.fromDate = $scope.fdate.getFullYear() + "-" + ($scope.fdate.getMonth()+1) + "-" + $scope.fdate.getDate();
            

                machineRequirement.getMachineRequirementItemByDate({
                    from: $scope.filter.fromDate
                }).success(function (result) {
                    $scope.cuttingMaster = result;
                    
                    // remove array obect array and feed in to array
                    angular.forEach($scope.cuttingMaster, function (value, index) {

                        $rootScope.converteddata.length = 0;
                        $scope.machineTypeTotal.length = 0;
                        angular.forEach(value, function (value1, index1) {

                            $rootScope.converteddata.machines = [];
                            $rootScope.converteddata.machines.length = 0;
                         
                            angular.forEach($scope.mtypes, function (currentmachine, index1) {

                                
                                $scope.matchedType = {};

                                $scope.matchedType = $filter('filter')(value1.machineRequirementItems, { machineType: currentmachine });

                                $scope.availMchins = $filter('filter')(value1.machineRequirementItems, { machineType: currentmachine });


                               
                               if ($scope.matchedType.length == 0) {
                                   // newVal is defined
                                   $rootScope.converteddata.machines.push({ currentmachine: currentmachine, total: 0 });
                                   $scope.machineTypeTotal.push({ type: currentmachine, Nos: 0 });
                               } else {

                                   angular.forEach($scope.matchedType, function (selected, index1) {
                                       //
                                       $rootScope.converteddata.machines.push({ currentmachine: currentmachine, total: selected.nos });
                                       //
                                       $scope.machineTypeTotal.push({ type: currentmachine, Nos: selected.nos });
                                   });
                               }
                              

                            });
                                    
                                   

                            $rootScope.converteddata.push({ styleNo: value1.styleNo, lineNo: value1.lineNo, machines: $rootScope.converteddata.machines });
                            vm.groupBy();
                            vm.getLocationAssetList('VTW');
                           
                        });
                       

                    });

                

                });


            }




            vm.process();
           
           


            vm.groupBy = function () {

                $scope.result = [];

                $scope.machineTypeTotal.reduce(function (res, value) {
                    if (!res[value.type]) {
                        res[value.type] = {
                            Nos: 0,
                            type: value.type
                        };
                        $scope.result.push(res[value.type])
                    }
                    res[value.type].Nos += value.Nos
                    return res;
                }, {});

            }

            //Home logic...
        }
    ]);
})();


