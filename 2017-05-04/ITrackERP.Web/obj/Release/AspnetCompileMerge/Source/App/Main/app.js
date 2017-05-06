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
        'angularRipple'

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


                  .state('buyers', {
                      url: '/buyers',
                      templateUrl: '/App/Main/views/buyers/index.cshtml',
                      menu: 'Buyers' //Matches to name of 'Events' menu in ITRACKNavigationProvider
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




                  .state('production',
                  {
                      url: '/dashboards/cutting/production',
                      templateUrl: '/App/Main/views/dashboards/cutting/production.cshtml',
                      menu: 'Cuttingdashbaord' //Matches to name of 'Events' menu in ITRACKNavigationProvider
                  })

                   .state('styles', {
                    url: '/styles',
                    templateUrl: '/App/Main/views/styles/index.cshtml',
                    menu: 'Style' //Matches to name of 'About' menu in ITrackERPNavigationProvider
                });



        }
    ]);
})();