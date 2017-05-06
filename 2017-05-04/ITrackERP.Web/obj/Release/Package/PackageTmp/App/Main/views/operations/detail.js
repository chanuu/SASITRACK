(function () {
    var controllerId = 'app.views.operations.detail';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$scope', '$state', '$stateParams', '$modal', 'abp.services.app.operationPool', 'abp.services.app.folderDetail', 'abp.services.app.footDetail', 'abp.services.app.threadDetail', 'abp.services.app.needleDetail', 'abp.services.app.attatchmentDetail',
        function ($rootScope, $scope, $state, $stateParams, $modal, operationService, folderDetailService, footDetailService, threadDetailService, needleDetailService, attatchmentDetailService) {
            var vm = this;
            $rootScope.hId = $stateParams.id;

            function loadOperations() {
                operationService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.operation = result;
                });
            }


            vm.backToEventsPage = function () {
                $state.go('operation');
            };

            loadOperations();



            vm.deleteFolderType = function (operation) {
                abp.message.confirm(App.localize('AreYouSureToDeleteFolderType', operation.folderType),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            folderDetailService.deleteFolderDetail({ id: operation.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                loadOperations();
                            });
                        }
                    });
            };


            vm.deleteFootType = function (operation) {
                abp.message.confirm(App.localize('AreYouSureToDeleteFootType', operation.footType),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            footDetailService.deleteFootDetail({ id: operation.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                loadOperations();
                            });
                        }
                    });
            };


            vm.deleteThreadType = function (operation) {
                abp.message.confirm(App.localize('AreYouSureToDeleteThreadType', operation.threadType),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            threadDetailService.deleteThreadDetail({ id: operation.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                loadOperations();
                            });
                        }
                    });
            };

            vm.deleteNeedleType = function (operation) {
                abp.message.confirm(App.localize('AreYouSureToDeleteNeedleType', operation.needleType),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            needleDetailService.deleteNeedleDetail({ id: operation.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                loadOperations();
                            });
                        }
                    });
            };

            
            vm.deleteAttatchmentType = function (operation) {
                abp.message.confirm(App.localize('AreYouSureToDeleteAttatchmentType', operation.attatchmentType),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            attatchmentDetailService.deleteAttatchmentDetail({ id: operation.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                loadOperations();
                            });
                        }
                    });
            };



            vm.folderTypeCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/operations/createFolderTypes.cshtml',
                    controller: 'app.views.operations.createFolderTypes as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    loadOperations();
                });
            };


            vm.footTypeCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/operations/createFootTypes.cshtml',
                    controller: 'app.views.operations.createFootTypes as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    loadOperations();
                });
            };


            vm.threadTypeCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/operations/createThreadTypes.cshtml',
                    controller: 'app.views.operations.createThreadTypes as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    loadOperations();
                });
            };


            vm.needleTypeCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/operations/createNeedleTypes.cshtml',
                    controller: 'app.views.operations.createNeedleTypes as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    loadOperations();
                });
            };
           

            vm.attatchmentTypeCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/operations/createAttatchmentTypes.cshtml',
                    controller: 'app.views.operations.createAttatchmentTypes as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    loadOperations();
                });
            };

        }
    ]);
})();