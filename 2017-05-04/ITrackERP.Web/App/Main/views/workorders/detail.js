(function () {
    var controllerId = 'app.views.workorders.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$modal', '$state', '$stateParams', 'abp.services.app.workOrder', 'abp.services.app.workorderRatio',
        function ($rootScope, $scope,$modal, $state, $stateParams, workorderService,workorderRatioService) {
            var vm = this;
            $rootScope.wId = $stateParams.id;
            function loadWorkOrders() {
                workorderService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.workOrder = result;
                });
            }



            vm.delete = function (item) {
                abp.message.confirm(
                  App.localize('Are You Sure you want to delete item'),
                  function (isConfirmed) {
                      if (isConfirmed) {
                          workorderRatioService.delete({
                              id: item.id
                          }).success(function () {
                              abp.notify.success(App.localize('SuccessfullyDeleted'));
                              loadWorkOrders();
                          });
                      }
                  }
              );

            }




            vm.back = function () {
                $state.go('workorders');
            };

            loadWorkOrders();


            vm.workorderItemCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/workorders/createItems.cshtml',
                    controller: 'app.views.workorders.createItems as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    loadWorkOrders();
                });
            };



        }
    ]);
})();