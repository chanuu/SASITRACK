(function () {
    var controllerId = 'app.views.employees.detail';
    angular.module('app').controller(controllerId, ['$rootScope', '$modal',
        '$scope', '$state', '$stateParams', 'abp.services.app.employee', 'abp.services.app.award', 'abp.services.app.promotion', 'abp.services.app.pastEmployeement', '$http',
        function ($rootScope,$modal, $scope, $state, $stateParams, employeeService, awardService, promotionService, pastEmploymentService, $http) {
            var vm = this;

            $rootScope.employeeId = $stateParams.id;
            vm.employee = {};
             
            function loadEmployees() {
                employeeService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.employee = result;
                });
            }


            vm.deleteEmployeeImage = function (employee) {
                abp.message.confirm(App.localize('AreYouSureToDeleteEmployeeImage' + employee.id),
                    function (isConfirmed) {
                        if (isConfirmed) {

                            $http.delete('/api/Upload/' + employee.id + '/1').then(function (data) {

                                employee.imagePath = "N/A";
                                employeeService.updateEmployee(employee)
                        .success(function () {
                            abp.notify.success(App.localize('DeletedSuccessfully'));
                            loadEmployees();

                        });
                                

                            }).catch(function (data) {
                                $scope.error = "An error has occured while deleting file! " + data;
                            });
                        }
                    });

            };

            vm.deletePastEmployment = function (employee) {
                abp.message.confirm(App.localize('AreYouSureToDeletePastEmployment'),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            pastEmploymentService.deletePastEmployment({ id: employee.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                loadEmployees();
                            });
                        }
                    });
            };
            vm.deletePromotion = function (employee) {
                abp.message.confirm(App.localize('AreYouSureToDeletePromotion', employee.toDesignation),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            promotionService.deletePromotion({ id: employee.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                loadEmployees();
                            });
                        }
                    });
            };
            vm.deleteAward = function (employee) {
                abp.message.confirm(App.localize('AreYouSureToDeleteAward', employee.awardName),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            awardService.deleteAward({ id: employee.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                loadEmployees();
                            });
                        }
                    });
            };

            vm.pastEmploymentCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/employees/createPastEmployment.cshtml',
                    controller: 'app.views.employees.createPastEmployment as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    loadEmployees();
                });
            };

            vm.promotionCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/employees/createPromotion.cshtml',
                    controller: 'app.views.employees.createPromotion as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    loadEmployees();
                });
            };

            vm.awardCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/employees/createAward.cshtml',
                    controller: 'app.views.employees.createAward as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    loadEmployees();
                });
            };

            vm.backToEventsPage = function () {
                $state.go('employees');
            };

            loadEmployees();


        }
    ]);
})();