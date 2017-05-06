(function () {
    var controllerId = 'app.views.issuenoteheaders.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$modal', '$state', '$stateParams', 'abp.services.app.issueNoteHeader', 'abp.services.app.issueNoteItem',
    function ($rootScope, $scope, $modal, $state, $stateParams, issueNoteHeaderService, issueNoteItemService) {
        var vm = this;

        $rootScope.IssueNoteHeaderId = $stateParams.id;

        function loadIssueNoteHeaders() {
            issueNoteHeaderService.getDetail({
                id: $stateParams.id
            }).success(function (result) {
                vm.issuenoteheader = result;
            });
        }

        vm.back = function () {
            $state.go('issuenoteheader');
        };

        loadIssueNoteHeaders();

        vm.delete = function (issuenoteitem) {
            abp.message.confirm(App.localize('AreYouSureToDeleteIssueNoteItem' + issuenoteitem.cutNo),
                function (isConfirmed) {
                    if (isConfirmed) {
                        issueNoteItemService.delete({ id: issuenoteitem.id }).success(function () {
                            abp.notify.success(App.localize('SuccessfullyDeleted'));
                            loadIssueNoteHeaders();
                        });
                    }
                });
        };
     

    
        vm.issueNoteItemCreationModal = function () {
            var modalInstance = $modal.open({
                templateUrl: '/App/Main/views/issuenoteheaders/createIssueNoteItem.cshtml',
                controller: 'app.views.cuttingratios.createItem as vm',
                backdrop: 'static'
            });
            modalInstance.result.then(function () {
                loadIssueNoteHeaders();
            });
        };



    }
    ]);
})();