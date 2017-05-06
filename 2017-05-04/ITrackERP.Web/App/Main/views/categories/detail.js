(function () {
    var controllerId = 'app.views.categories.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', '$modal', 'abp.services.app.categorySetup', '$http', 
        function ($rootScope, $scope, $state, $stateParams, $modal, categoryService, $http) {
            var vm = this;
         
            vm.category = {};

            function loadCategories() {
               categoryService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.category = result;
                
                });
            }

            vm.backToEventsPage = function () {
                $state.go('category');
            };

            loadCategories();
      
        }
    ]);
})();