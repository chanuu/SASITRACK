(function () {
    angular.module('app').controller('app.views.issuenoteheaders.createIssueNoteHeader', [
        '$scope', '$modalInstance', 'abp.services.app.issueNoteHeader', 'abp.services.app.department', 'abp.services.app.session', 'abp.services.app.style',
        function ($scope, $modalInstance, issueNoteHeaderService, departmentService, sessionService, styleService) {
            var vm = this;

            $scope.departments = [];
            $scope.selectedLineNo = null;

            $scope.styleId = null;
            $scope.selectedStyle = null;

            vm.save = function () {

                if ($scope.issuenoteheaderCreateForm.$invalid) {
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

                    issueNoteHeaderService.create(vm.issuenoteheader)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };

            function getStyles() {
                styleService.getStyles({}).success(function (result) {

                    vm.styles = result.items;
                });
            }
            getStyles();

            //
            $scope.afterSelectedMachineRequirement = function (selected) {
                if (selected) {
                    $scope.selectedMachineRequirement = selected.originalObject;


                }
            }

            function getDepartments() {
                departmentService.getDepartments({}).success(function (result) {

                    vm.departments = result.items;
                });
            }
            getDepartments();

            //
            $scope.afterSelectedLineNo = function (selected) {
                if (selected) {
                    $scope.selectedLineNo = selected.originalObject;


                }
            }

         
            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();