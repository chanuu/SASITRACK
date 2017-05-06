(function () {
    angular.module('app').controller('app.views.cuttingratios.index', [
        '$scope', '$modal', 'abp.services.app.cuttingRatio',
        function ($scope, $modal, cuttingRatioService) {
            var vm = this;
               vm.ratio = [];

           


            function getRatios() {
                cuttingRatioService.getCuttingRatio({}).success(function (result) {
                    vm.ratio = result.items;
                });
            };


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            };



          

            vm.create = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/cuttingratios/create.cshtml',
                    controller: 'app.views.cuttingratios.create as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    //getStyles();
                });
            };



            getRatios();


        }
    ]);
})();