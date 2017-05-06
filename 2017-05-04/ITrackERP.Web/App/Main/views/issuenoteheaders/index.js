(function () {
    angular.module('app').controller('app.views.issuenoteheaders.index', [
        '$scope', '$modal', 'abp.services.app.issueNoteHeader',
        function ($scope, $modal, issueNoteHeaderService) {
            var vm = this;

            vm.issueNoteHeaders = [];

            function getissueNoteHeader() {
                issueNoteHeaderService.getIssueNoteHeader({}).success(function (result) {
                    vm.issueNoteHeaders = result.items;
                });
            }


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }



            vm.delete = function (issuenoteheader) {
                abp.message.confirm(App.localize('AreYouSureToDeleteIssueNoteHeader' + issuenoteheader.issueNoteNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            issueNoteHeaderService.delete({ id: issuenoteheader.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                getissueNoteHeader();
                            });
                        }
                    });
            };



            vm.issueNoteHeaderCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/issuenoteheaders/createIssueNoteHeader.cshtml',
                    controller: 'app.views.issuenoteheaders.createIssueNoteHeader as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getissueNoteHeader();
                });
            };

            getissueNoteHeader();


        }
    ]);
})();