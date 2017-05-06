(function () {
    angular.module('app').controller('app.views.elements.index', [
        '$scope', '$modal', 'abp.services.app.element','$http',
        function ($scope, $modal, elementService, $http) {
            var vm = this;

            vm.elements = [];


            function GetElements() {
                elementService.getElements({}).success(function (result) {
                    vm.elements = result.items;
                });
            };


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            };



            vm.delete = function (element) {
                abp.message.confirm(App.localize('AreYouSureToDeleteElement' + element.name),
                    function (isConfirmed) {
                        if (isConfirmed) {

                            $http.delete('/api/Upload/' + element.id + '/4').then(function (data) {
                                elementService.delete({ id: element.id }).success(function () {
                                    abp.notify.success(App.localize('SuccessfullyDeleted'));
                                    GetElements();
                                });

                            }).catch(function (data) {
                                $scope.error = "An error has occured while deleting file! " + data;
                            });


                        }
                    });
            };

            vm.elementCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/elements/createElement.cshtml',
                    controller: 'app.views.elements.createElement as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    GetElements();
                });
            };



            GetElements();


        }
    ]);
})();