(function () {
    'use strict';
    
    var app = angular.module('app', [
        'ngAnimate',
       
        'angular.filter',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp',
        'angucomplete-alt',
        'angularUtils.directives.dirPagination',
        'angularUtils.directives.itrack',
        'amChartsDirective',
        'angularRipple',
        'ngFileUpload',
        'ngMessages',
        'ui.slimscroll',
        'highcharts-ng',
        'underscore',
        'ngAvatar'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');

            if (abp.auth.hasPermission('Pages.Users')) {
                $stateProvider
                    .state('users', {
                        url: '/users',
                        templateUrl: '/App/Main/views/users/index.cshtml',
                        menu: 'Users' //Matches to name of 'Users' menu in ITrackERPNavigationProvider
                    });
                $urlRouterProvider.otherwise('/users');
            }

            if (abp.auth.hasPermission('Pages.Tenants')) {
                $stateProvider
                    .state('tenants', {
                        url: '/tenants',
                        templateUrl: '/App/Main/views/tenants/index.cshtml',
                        menu: 'Tenants' //Matches to name of 'Tenants' menu in ITrackERPNavigationProvider
                    });
                $urlRouterProvider.otherwise('/tenants');
            }

            if (abp.auth.hasPermission('Pages.Styles')) {
                $stateProvider
                    .state('styles', {
                        url: '/styles',
                        templateUrl: '/App/Main/views/styles/index.cshtml',
                        menu: 'Styles' //Matches to name of 'Tenants' menu in ITrackERPNavigationProvider
                    });
                $urlRouterProvider.otherwise('/styles');
            }
           
            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in ITrackERPNavigationProvider
                  
                })



                 //buyers
                  .state('buyers', {
                      url: '/buyers',
                      templateUrl: '/App/Main/views/buyers/index.cshtml',
                      menu: 'Buyers' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })
                .state('buyerDetail', {
                    url: '/buyers/:id',
                    templateUrl: '/App/Main/views/buyers/detail.cshtml',
                    menu: 'Buyers' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                })

                .state('buyerUpdate', {
                    url: '/buyers/update/:id',
                    templateUrl: '/App/Main/views/buyers/update.cshtml',
                    menu: 'Buyers' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                })

                //rent machines

                 .state('rentmachines', {
                     url: '/rentmachines',
                     templateUrl: '/App/Main/views/rentmachines/index.cshtml',
                     menu: 'RentMachines' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                 })

                .state('rentmachineDetail', {
                    url: '/rentmachines/:id',
                    templateUrl: '/App/Main/views/rentmachines/detail.cshtml',
                    menu: 'RentMachines' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                })

                .state('rentmachineUpdate', {
                    url: '/rentmachines/update/:id',
                    templateUrl: '/App/Main/views/rentmachines/update.cshtml',
                    menu: 'RentMachines' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                })

                //assets

                 .state('assets', {
                     url: '/assets',
                     templateUrl: '/App/Main/views/assets/index.cshtml',
                     menu: 'Assets' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                 })

                .state('assetDetail', {
                    url: '/assets/:id',
                    templateUrl: '/App/Main/views/assets/detail.cshtml',
                    menu: 'Assets' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                })

                .state('assetUpdate', {
                    url: '/assets/update/:id',
                    templateUrl: '/App/Main/views/assets/update.cshtml',
                    menu: 'Assets' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                })

                 //machine types

                 .state('machinetypes', {
                     url: '/machinetypes',
                     templateUrl: '/App/Main/views/machinetypes/index.cshtml',
                     menu: 'MachineTypes' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                 })

                .state('machinetypeDetail', {
                    url: '/machinetypes/:id',
                    templateUrl: '/App/Main/views/machinetypes/detail.cshtml',
                    menu: 'MachineTypes' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                })

                .state('machinetypeUpdate', {
                    url: '/machinetypes/update/:id',
                    templateUrl: '/App/Main/views/machinetypes/update.cshtml',
                    menu: 'MachineTypes' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                })


        //asset disposal header and detail

                 .state('assetdisposal',
                {
                    url: '/assetdisposals',
                    templateUrl: '/App/Main/views/assetdisposals/index.cshtml',
                    menu: 'AssetDisposals' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                .state('assetdisposalDetail',
                {
                    url: '/assetdisposals/:id',
                    templateUrl: '/App/Main/views/assetdisposals/detail.cshtml',
                    menu: 'AssetDisposals' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })

                  .state('assetdisposalUpdate',
                  {
                      url: '/assetdisposals/update/:id',
                      templateUrl: '/App/Main/views/assetdisposals/update.cshtml',
                      menu: 'AssetDisposals' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })
                 .state('createDisposalItems',
                  {
                      url: '/assetdisposals/item/create',
                      templateUrl: '/App/Main/views/assetdisposals/createItems.cshtml',
                      menu: 'AssetDisposals' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                .state('updateDisposalItems',
                  {
                      url: '/assetdisposals/item/update/:id',
                      templateUrl: '/App/Main/views/assetdisposals/updateItems.cshtml',
                      menu: 'AssetDisposals' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })


            //asset transfer header and detail

                .state('assettransfer',
                {
                    url: '/assettransfers',
                    templateUrl: '/App/Main/views/assettransfers/index.cshtml',
                    menu: 'AssetTransfers' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                 .state('assettransferDetail',
                {
                    url: '/assettransfers/:id',
                    templateUrl: '/App/Main/views/assettransfers/detail.cshtml',
                    menu: 'AssetTransfers' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                 .state('assettransferUpdate',
                  {
                      url: '/assettransfers/update/:id',
                      templateUrl: '/App/Main/views/assettransfers/update.cshtml',
                      menu: 'AssetTransfers' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })
                .state('createTransferItems',
                  {
                      url: '/assettransfers/item/create',
                      templateUrl: '/App/Main/views/assettransfers/createItems.cshtml',
                      menu: 'AssetTransfers' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })
                .state('updateTransferItems',
                  {
                      url: '/assettransfers/item/update/:id',
                      templateUrl: '/App/Main/views/assettransfers/updateItems.cshtml',
                      menu: 'AssetTransfers' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                //machine requirement

                .state('machinerequirement',
                {
                    url: '/machinerequirements',
                    templateUrl: '/App/Main/views/machinerequirements/index.cshtml',
                    menu: 'MachineRequirements' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                .state('machinerequirementDetail',
                {
                    url: '/machinerequirements/:id',
                    templateUrl: '/App/Main/views/machinerequirements/detail.cshtml',
                    menu: 'MachineRequirements' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                 .state('machinerequirementUpdate',
                  {
                      url: '/machinerequirements/update/:id',
                      templateUrl: '/App/Main/views/machinerequirements/update.cshtml',
                      menu: 'MachineRequirements' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })
                .state('createMachineRequirementItems',
                  {
                      url: '/machinerequirements/item/create',
                      templateUrl: '/App/Main/views/machinerequirements/createItems.cshtml',
                      menu: 'MachineRequirements' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })
                .state('updateMachineRequirementItems',
                  {
                      url: '/machinerequirements/item/update/:id',
                      templateUrl: '/App/Main/views/machinerequirements/updateItems.cshtml',
                      menu: 'MachineRequirements' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })


                                //style loading

                .state('styleloading',
                {
                    url: '/styleloadings',
                    templateUrl: '/App/Main/views/styleloadings/index.cshtml',
                    menu: 'StyleLoadings' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                .state('styleloadingDetail',
                {
                    url: '/styleloadings/:id',
                    templateUrl: '/App/Main/views/styleloadings/detail.cshtml',
                    menu: 'StyleLoadings' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                 .state('styleloadingUpdate',
                  {
                      url: '/styleloadings/update/:id',
                      templateUrl: '/App/Main/views/styleloadings/update.cshtml',
                      menu: 'StyleLoadings' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                //custom field set up

                .state('customfieldsetup',
                {
                    url: '/customfieldsetups',
                    templateUrl: '/App/Main/views/customfieldsetups/index.cshtml',
                    menu: 'CustomFieldSetups' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                .state('customfieldsetupDetail',
                {
                    url: '/customfieldsetups/:id',
                    templateUrl: '/App/Main/views/customfieldsetups/detail.cshtml',
                    menu: 'CustomFieldSetups' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                 .state('customfieldsetupUpdate',
                  {
                      url: '/customfieldsetups/update/:id',
                      templateUrl: '/App/Main/views/customfieldsetups/update.cshtml',
                      menu: 'CustomFieldSetups' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                //operation

                .state('operation',
                {
                    url: '/operations',
                    templateUrl: '/App/Main/views/operations/index.cshtml',
                    menu: 'OperationPool' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                .state('operationDetail',
                {
                    url: '/operations/:id',
                    templateUrl: '/App/Main/views/operations/detail.cshtml',
                    menu: 'OperationPool' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                 .state('operationUpdate',
                  {
                      url: '/operations/update/:id',
                      templateUrl: '/App/Main/views/operations/update.cshtml',
                      menu: 'OperationPool' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                 .state('createFolderDetails',
                  {
                      url: '/operations/item/create',
                      templateUrl: '/App/Main/views/operations/createFolderTypes.cshtml',
                      menu: 'OperationPool' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                .state('updateFolderDetails',
                  {
                      url: '/operations/item/updatefolder/:id',
                      templateUrl: '/App/Main/views/operations/updateFolderTypes.cshtml',
                      menu: 'OperationPool' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                .state('createFootDetails',
                  {
                      url: '/operations/item/create',
                      templateUrl: '/App/Main/views/operations/createFootTypes.cshtml',
                      menu: 'OperationPool' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                .state('updateFootDetails',
                  {
                      url: '/operations/item/updatefoot/:id',
                      templateUrl: '/App/Main/views/operations/updateFootTypes.cshtml',
                      menu: 'OperationPool' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                .state('createThreadDetails',
                  {
                      url: '/operations/item/create',
                      templateUrl: '/App/Main/views/operations/createThreadTypes.cshtml',
                      menu: 'OperationPool' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                .state('updateThreadDetails',
                  {
                      url: '/operations/item/updatethread/:id',
                      templateUrl: '/App/Main/views/operations/updateThreadTypes.cshtml',
                      menu: 'OperationPool' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })
                .state('createNeedleDetails',
                  {
                      url: '/operations/item/create',
                      templateUrl: '/App/Main/views/operations/createNeedleTypes.cshtml',
                      menu: 'OperationPool' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                .state('updateNeedleDetails',
                  {
                      url: '/operations/item/updateneedle/:id',
                      templateUrl: '/App/Main/views/operations/updateNeedleTypes.cshtml',
                      menu: 'OperationPool' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                 .state('createAttatchmentDetails',
                  {
                      url: '/operations/item/create',
                      templateUrl: '/App/Main/views/operations/createAttatchmentTypes.cshtml',
                      menu: 'OperationPool' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                .state('updateAttatchmentDetails',
                  {
                      url: '/operations/item/updateattatchment/:id',
                      templateUrl: '/App/Main/views/operations/updateAttatchmentTypes.cshtml',
                      menu: 'OperationPool' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })


                 //dividing plan header and detail

                 .state('dividingplan',
                {
                    url: '/dividingplans',
                    templateUrl: '/App/Main/views/dividingplans/index.cshtml',
                    menu: 'DividingPlans' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                .state('dividingplanDetail',
                {
                    url: '/dividingplans/:id',
                    templateUrl: '/App/Main/views/dividingplans/detail.cshtml',
                    menu: 'DividingPlans' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })

                  .state('dividingplanUpdate',
                  {
                      url: '/dividingplans/update/:id',
                      templateUrl: '/App/Main/views/dividingplans/update.cshtml',
                      menu: 'DividingPlans' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })
                 .state('createDividingPlanItems',
                  {
                      url: '/dividingplans/item/create',
                      templateUrl: '/App/Main/views/dividingplans/createItems.cshtml',
                      menu: 'DividingPlans' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                .state('updateDividingPlanItems',
                  {
                      url: '/dividingplans/item/update/:id',
                      templateUrl: '/App/Main/views/dividingplans/updateItems.cshtml',
                      menu: 'DividingPlans' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })


                 //departments

                 .state('departments', {
                     url: '/departments',
                     templateUrl: '/App/Main/views/departments/index.cshtml',
                     menu: 'Departments' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                 })

                .state('departmentDetail', {
                    url: '/departments/:id',
                    templateUrl: '/App/Main/views/departments/detail.cshtml',
                    menu: 'Departments' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                })

                .state('departmentUpdate', {
                    url: '/departments/update/:id',
                    templateUrl: '/App/Main/views/departments/update.cshtml',
                    menu: 'Departments' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                })

                  //stock receive header , receive note item and serail item

                 .state('stockreceiveheader',
                {
                    url: '/stockreceiveheaders',
                    templateUrl: '/App/Main/views/stockreceiveheaders/index.cshtml',
                    menu: 'StockReceiveHeaders' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                .state('stockreceiveheaderDetail',
                {
                    url: '/stockreceiveheaders/:id',
                    templateUrl: '/App/Main/views/stockreceiveheaders/detail.cshtml',
                    menu: 'StockReceiveHeaders' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                .state('stockreceiveheaderUpdate',
                  {
                      url: '/stockreceiveheaders/update/:id',
                      templateUrl: '/App/Main/views/stockreceiveheaders/update.cshtml',
                      menu: 'StockReceiveHeaders' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })
              .state('createReceiveNoteItems',
                  {
                      url: '/stockreceiveheaders/item/create',
                      templateUrl: '/App/Main/views/stockreceiveheaders/createReceiveNoteItem.cshtml',
                      menu: 'StockReceiveHeaders' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                .state('updateReceiveNoteItems',
                  {
                      url: '/stockreceiveheaders/item/update/:id',
                      templateUrl: '/App/Main/views/stockreceiveheaders/updateReceiveNoteItem.cshtml',
                      menu: 'StockReceiveHeaders' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })
                .state('serialItemDetail',
                {
                    url: '/stockreceiveheaders/item/:id',
                    templateUrl: '/App/Main/views/stockreceiveheaders/serialItemDetail.cshtml',
                    menu: 'StockReceiveHeaders' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                .state('updateSerialItems',
                  {
                      //   url: '/stockreceiveheaders/item/:id/item/update/:id',
                      templateUrl: '/App/Main/views/stockreceiveheaders/updateSerialItem.cshtml',
                      menu: 'StockReceiveHeaders' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                 //item master

                 .state('itemmaster',
                {
                    url: '/itemmasters',
                    templateUrl: '/App/Main/views/itemmasters/index.cshtml',
                    menu: 'ItemMasters' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                .state('itemmasterDetail',
                {
                    url: '/itemmasters/:id',
                    templateUrl: '/App/Main/views/itemmasters/detail.cshtml',
                    menu: 'ItemMasters' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })

                  .state('itemmasterUpdate',
                  {
                      url: '/itemmasters/update/:id',
                      templateUrl: '/App/Main/views/itemmasters/update.cshtml',
                      menu: 'ItemMasters' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })
                 //job card header

                 .state('jobcardheader',
                {
                    url: '/jobcardheaders',
                    templateUrl: '/App/Main/views/jobcardheaders/index.cshtml',
                    menu: 'JobCardHeaders' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                .state('jobcardheaderDetail',
                {
                    url: '/jobcardheaders/:id',
                    templateUrl: '/App/Main/views/jobcardheaders/detail.cshtml',
                    menu: 'JobCardHeaders' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                 .state('jobcardheaderUpdate',
                  {
                      url: '/jobcardheaders/update/:id',
                      templateUrl: '/App/Main/views/jobcardheaders/update.cshtml',
                      menu: 'JobCardHeaders' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })
                .state('createJobCardItems',
                  {
                      url: '/jobcardheaders/item/create',
                      templateUrl: '/App/Main/views/jobcardheaders/createJobCardItem.cshtml',
                      menu: 'JobCardHeaders' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                .state('updateJobCardItems',
                  {
                      url: '/jobcardheaders/item/update/:id',
                      templateUrl: '/App/Main/views/jobcardheaders/updateJobCardItem.cshtml',
                      menu: 'JobCardHeaders' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })


                

                  .state('styleDetail', {
                      url: '/styles/:id',
                      templateUrl: '/App/Main/views/styles/detail.cshtml',
                      menu: 'Style' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })
                 .state('styleUpdate', {
                     url: '/styles/update/:id',
                     templateUrl: '/App/Main/views/styles/update.cshtml',
                     menu: 'Style' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                 })

                 .state('workorder',
                {
                    url: '/workorders',
                    templateUrl: '/App/Main/views/workorders/index.cshtml',
                    menu: 'WorkOrder' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })
                .state('workOrderDetail',
                {
                    url: '/workorders/:id',
                    templateUrl: '/App/Main/views/workorders/detail.cshtml',
                    menu: 'WorkOrder' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                })

                  .state('workorderUpdate',
                  {
                      url: '/workorders/update/:id',
                      templateUrl: '/App/Main/views/workorders/update.cshtml',
                      menu: 'WorkOrder' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                  .state('cuttingratios',
                  {
                      url: '/cuttingratios',
                      templateUrl: '/App/Main/views/cuttingratios/index.cshtml',
                      menu: 'cuttingRatio' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                  .state('cuttingratiosdetial',
                  {
                      url: '/cuttingratios/:id',
                      templateUrl: '/App/Main/views/cuttingratios/detail.cshtml',
                      menu: 'cuttingRatio' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                  .state('cuttingmasters',
                  {
                      url: '/cuttingmasters',
                      templateUrl: '/App/Main/views/cuttingmasters/index.cshtml',
                      menu: 'CuttingMasters' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                  .state('cuttingmasterdetail',
                  {
                      url: '/cuttingmasters/:id',
                      templateUrl: '/App/Main/views/cuttingmasters/detail.cshtml',
                      menu: 'CuttingMasters' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                  .state('createCuttingItem',
                  {
                      url: '/cuttingmasters/item/create',
                      templateUrl: '/App/Main/views/cuttingmasters/createItem.cshtml',
                      menu: 'CuttingMasters' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                  .state('dashbaord',
                  {
                      url: '/dashboards/',
                      templateUrl: '/App/Main/views/dashboards/dashboard.cshtml',
                      menu: 'Dashboard' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                  .state('cuttingdashbaord',
                  {
                      url: '/dashboards/cutting/',
                      templateUrl: '/App/Main/views/dashboards/cutting/cuttingoptions.cshtml',
                      menu: 'Cuttingdashbaord' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })



                  .state('tablecutdashboard',
                  {
                      url: '/dashboards/cutting/tablecut',
                      templateUrl: '/App/Main/views/dashboards/cutting/tablecut.cshtml',
                      menu: 'Cuttingdashbaord' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })


                 .state('tablecutdetails',
                  {
                      url: '/dashboards/cutting/tablecutdetails',
                      templateUrl: '/App/Main/views/dashboards/cutting/tablecutdetails.cshtml',
                      menu: 'Cuttingdashbaord' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })


                 .state('fabricutilization',
                  {
                      url: '/dashboards/cutting/fabricutilization',
                      templateUrl: '/App/Main/views/dashboards/cutting/fabricutilization.cshtml',
                      menu: 'Cuttingdashbaord' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                 .state('fabricutilizationdetails',
                  {
                      url: '/dashboards/cutting/fabricutilizationdetails',
                      templateUrl: '/App/Main/views/dashboards/cutting/fabricutilizationdetails.cshtml',
                      menu: 'Fabricutilizationdetails' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })



                 .state('mis',
                  {
                      url: '/dashboards/mis/',
                      templateUrl: '/App/Main/views/dashboards/mis/view1.cshtml',
                      menu: 'mis' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                 .state('cutsummary',
                  {
                      url: '/dashboards/mis/cuttingstylesummary/:id',
                      templateUrl: '/App/Main/views/dashboards/mis/cuttingstylesummary.cshtml',
                      menu: 'mis' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })


                 .state('cuttingactivestyles',
                  {
                      url: '/dashboards/mis/cuttingactivestyles',
                      templateUrl: '/App/Main/views/dashboards/mis/cuttingactivestyles.cshtml',
                      menu: 'mis' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })




                 .state('assetsdashbaord',
                  {
                      url: '/dashboards/assets/',
                      templateUrl: '/App/Main/views/dashboards/assets/assetoptions.cshtml',
                      menu: 'Cuttingdashbaord' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

              .state('machinesummary',
                  {
                      url: '/dashboards/assets/machinerequirement',
                      templateUrl: '/App/Main/views/dashboards/assets/machinerequirement.cshtml',
                      menu: 'Cuttingdashbaord' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                  .state('rentsummary',
                  {
                      url: '/dashboards/assets/rentmachines',
                      templateUrl: '/App/Main/views/dashboards/assets/rentmachines.cshtml',
                      menu: 'rentsummary' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })


                //maintenance reports
                  .state('maintenancedashboard', {
                      url: '/dashboards/maintenance/',
                      templateUrl: '/App/Main/views/dashboards/maintenance/maintenanceoptions.cshtml',
                      menu: 'Maintenancedashboard' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                              //  Report 1
                //all job cards report
                .state('jobcarddashboard',
                  {
                      url: '/dashboards/maintenance/jobcards',
                      templateUrl: '/App/Main/views/dashboards/maintenance/jobcards.cshtml',
                      menu: 'Maintenancedashboard' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                //job cards of selected asset
                .state('jobcarddetailsofselectedasset',
                  {
                      url: '/dashboards/maintenance/jobCardsOfSelectedAsset',
                      templateUrl: '/App/Main/views/dashboards/maintenance/jobCardsOfSelectedAsset.cshtml',
                      menu: 'Maintenancedashboard' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                //job cards of selected asset in detail
                 .state('jobcardsofselectedassetdetails',
                  {
                      url: '/dashboards/maintenance/jobcards/:id',
                      templateUrl: '/App/Main/views/dashboards/maintenance/jobCardInDetail.cshtml',
                      menu: 'Maintenancedashboard' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })


                //  Report 2
                //total cost
                 .state('totalcost',
                  {
                      url: '/dashboards/maintenance/totalcost',
                      templateUrl: '/App/Main/views/dashboards/maintenance/totalcost.cshtml',
                      menu: 'Maintenancedashboard' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                //total cost for jobs in detail
                 .state('totalcostforjobs',
                  {
                      url: '/dashboards/maintenance/totalcost/:id',
                      templateUrl: '/App/Main/views/dashboards/maintenance/jobCardsForTotalCost.cshtml',
                      menu: 'Maintenancedashboard' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                //  Report 3
                  //item balance
                 .state('itembalance',
                  {
                      url: '/dashboards/maintenance/itembalance',
                      templateUrl: '/App/Main/views/dashboards/maintenance/itembalance.cshtml',
                      menu: 'Maintenancedashboard' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                //  Report 4
                 //mechanic jobs

                 .state('mechanicjobs',
                  {
                      url: '/dashboards/maintenance/mechanicjobs',
                      templateUrl: '/App/Main/views/dashboards/maintenance/mechanicjobs.cshtml',
                      menu: 'Maintenancedashboard' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                //job card details
                .state('jobcarddetails',
                  {
                      url: '/dashboards/maintenance/jobcarddetails',
                      templateUrl: '/App/Main/views/dashboards/maintenance/jobcarddetails.cshtml',
                      menu: 'Maintenancedashboard' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                //mechanic jobs in detail
                 .state('mechanicjobsdetails',
                  {
                      url: '/dashboards/maintenance/mechanicjobs/:id',
                      templateUrl: '/App/Main/views/dashboards/maintenance/jobCardInDetail.cshtml',
                      menu: 'Maintenancedashboard' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

           

                  .state('production',
                  {
                      url: '/dashboards/cutting/production',
                      templateUrl: '/App/Main/views/dashboards/cutting/production.cshtml',
                      menu: 'Cuttingdashbaord' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                  .state('productionsumm',
                  {
                      url: '/dashboards/summary/tablecutdetails',
                      templateUrl: '/App/Main/views/dashboards/summary/tablecutdetails.cshtml',
                      menu: 'Cuttingdashbaord' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                   .state('styles', {
                    url: '/styles',
                    templateUrl: '/App/Main/views/styles/index.cshtml',
                    menu: 'Style' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                });



        }
    ]).constant("apiUrl", "api/files/");;
})();