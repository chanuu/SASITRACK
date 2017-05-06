(function () {
    var controllerId = 'app.views.issuenoteheaders.updateIssueNoteItem';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.issueNoteItem', 
        function ($rootScope, $scope, $state, $stateParams, issuenoteitemService) {
            var vm = this;
            vm.issuenoteitem = {};

            vm.update = function () {
                if ($scope.issueNoteItemUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {

                    vm.issuenoteitem.id = $stateParams.id;
                    vm.issuenoteitem.issueNoteHeaderId = $rootScope.IssueNoteHeaderId;

                    issuenoteitemService.update(vm.issuenoteitem)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('issuenoteheader');
                        });
                }
            };
   

            function loadIssueNoteItems() {
                issuenoteitemService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.issuenoteitem = result;                
                });
            }

            vm.back = function () {
                $state.go('issuenoteheader');
            };


            loadIssueNoteItems();

        }
    ]);
})();