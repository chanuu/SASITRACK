(function () {
    angular.module('app').controller('app.views.cuttingmasters.index', ['$rootScope',
        '$scope', '$modal', 'abp.services.app.cuttingMaster',
        function ($rootScope,$scope, $modal, cuttingMasterService) {
            var vm = this;
            vm.items = [];




            function getCuttingMaster() {
                cuttingMasterService.getCuttingMaster({}).success(function (result) {
                    vm.items = result.items;
                });
            };


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            };





            vm.create = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/cuttingmasters/create.cshtml',
                    controller: 'app.views.cuttingmasters.create as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getCuttingMaster();
                });
            };



            getCuttingMaster();


        }
    ]);
})();