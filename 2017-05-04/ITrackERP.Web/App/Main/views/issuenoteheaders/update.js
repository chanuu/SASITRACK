(function () {
    var controllerId = 'app.views.issuenoteheaders.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.issueNoteHeader', 'abp.services.app.department', 'abp.services.app.session', 'abp.services.app.style',
        function ($scope, $state, $stateParams, issuenoteheaderService, departmentService, sessionService, styleService) {
            var vm = this;

            vm.update = function () {
                if ($scope.issuenoteheaderUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    
                    sessionService.getCurrentLoginInformations({}).success(function (result) {
                        $scope.currentuser = result;
                    });

                    vm.issuenoteheader.styleId = $scope.selectedStyle.id;
                    vm.issuenoteheader.styleNo = $scope.selectedStyle.styleNo;
                    vm.issuenoteheader.issueTo = $scope.selectedLineNo.name;
                    vm.issuenoteheader.issuedBy = $scope.currentuser.user.name;

                    issuenoteheaderService.update(vm.issuenoteheader)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('issuenoteheader');

                        });
                }
            };


          
            function loadIssueNoteHeaders() {
                issuenoteheaderService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.issuenoteheader = result;

                    styleService.getDetailByStyleNo({
                        styleNo: vm.issuenoteheader.styleNo
                    }).success(function (result) {
                        $scope.selectedStyle = result;
                    });


                    departmentService.getDetailByLineNo({
                        name: vm.issuenoteheader.issueTo
                    }).success(function (result) {
                        $scope.selectedLineNo = result;
                    });


                });
            };


            vm.back = function () {
                $state.go('issuenoteheader');
            };


            loadIssueNoteHeaders();


        }
    ]);
})();