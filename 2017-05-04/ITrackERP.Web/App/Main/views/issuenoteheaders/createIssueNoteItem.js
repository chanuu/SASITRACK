(function () {
    angular.module('app').controller('app.views.issuenoteheaders.createIssueNoteItem', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.issueNoteItem', 
        function ($rootScope, $scope, $modalInstance, issuenoteitemService) {
            var vm = this;
           
            vm.save = function () {
                if ($scope.issuenoteItemCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    $scope.issuenoteitem.issueNoteHeaderId = $rootScope.IssueNoteHeaderId;

                    issuenoteitemService.create($scope.issuenoteitem)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();
                        });
                }
            };


          
            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();