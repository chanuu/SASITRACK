(function () {
    angular.module('app').controller('app.views.eventheaders.index', [
        '$scope', '$modal', 'abp.services.app.eventHeader','abp.services.app.album', '$http',
        function ($scope, $modal, eventheaderService, albumService, $http) {
            var vm = this;

            vm.eventheaders = [];
            vm.eventheader = {};

            function getEventHeader() {
                eventheaderService.getAll({}).success(function (result) {
                    vm.eventheaders = result.items;
                });
            }


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }



            vm.delete = function (eventheader) {
                abp.message.confirm(App.localize('AreYouSureToDeleteEventHeader' + eventheader.name),
                    function (isConfirmed) {
                        if (isConfirmed) {

                            eventheaderService.getDetail({
                                id: eventheader.id
                            }).success(function (result) {
                                vm.eventheader = result;
                           

                            angular.forEach(vm.eventheader.albums, function (value, key) {

                                $http.delete('/api/Upload/' + value.id + '/3').then(function (data) {
                                    albumService.delete({ id: value.id }).success(function () {
                                    });

                                }).catch(function (data) {
                                    $scope.error = "An error has occured while deleting files! " + data;
                                });

                            });

                            eventheaderService.delete({ id: eventheader.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                getEventHeader();
                            });

                            });



                        }
                    });
            };



            vm.eventHeaderCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/eventheaders/createEventHeader.cshtml',
                    controller: 'app.views.eventheaders.createEventHeader as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getEventHeader();
                });
            };

            getEventHeader();


        }
    ]);
})();