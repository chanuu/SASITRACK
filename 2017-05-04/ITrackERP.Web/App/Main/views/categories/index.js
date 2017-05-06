(function () {
    angular.module('app').controller('app.views.categories.index', [
        '$scope', '$modal', 'abp.services.app.categorySetup','$http',
        function ($scope, $modal, categoryService, $http) {
            var vm = this;

            vm.categories = [];

            function GetAll() {
                categoryService.getAll({}).success(function (result) {
                    vm.categories = result.items;
                });
            };


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            };



            vm.delete = function (category) {
                abp.message.confirm(App.localize('AreYouSureToDeleteCategory' + category.name),
                    function (isConfirmed) {
                        if (isConfirmed) {                        
                            categoryService.delete({ id: category.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                GetAll();
                            });
                        }
                    });
            };

            vm.categoryCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/categories/createCategory.cshtml',
                    controller: 'app.views.categories.createCategory as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    GetAll();
                });
            };

            GetAll();


        }
    ]);
})();