(function () {
    angular.module('app').controller('app.views.jobcardheaders.index', [
        '$scope', '$modal', 'abp.services.app.jobCardHeader',
        function ($scope, $modal, jobCardHeaderService) {
            var vm = this;

            vm.jobCardHeaders = [];

            function getjobCardHeader() {
                jobCardHeaderService.getJobCardHeader({}).success(function (result) {
                    vm.jobCardHeaders = result.items;
                });
            }


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }



            vm.delete = function (jobCardHeader) {
                abp.message.confirm(App.localize('AreYouSureToDeleteJobCardHeader' + jobCardHeader.jobcardNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            jobCardHeaderService.delete({ id: jobCardHeader.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                getjobCardHeader();
                            });
                        }
                    });
            };



            vm.jobCardheaderCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/jobcardheaders/createJobCardHeader.cshtml',
                    controller: 'app.views.jobcardheaders.createJobCardHeader as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getjobCardHeader();
                });
            };

            getjobCardHeader();


        }
    ]);
})();