(function () {
    var controllerId = 'app.views.eventheaders.detail';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$scope', '$state', '$stateParams', '$modal', 'abp.services.app.eventHeader', 'abp.services.app.album', 'abp.services.app.invitee', '$http', 'Upload', 'Lightbox',
        function ($rootScope, $scope, $state, $stateParams, $modal, eventheaderService, albumService, inviteeService, $http, upload, Lightbox) {
            var vm = this;
            $rootScope.eventHeaderId = $stateParams.id;
            vm.eventheaders = {};
            $scope.images = [];
           
            function loadEventHeaders() {
                eventheaderService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.eventheaders = result;

                    $scope.images = [];

                    angular.forEach(vm.eventheaders.albums, function (value, key) {
                        $scope.images.push({ url: value.url, thumbUrl: value.url, caption: value.name, id: value.id });
                    });

                });
            }


            vm.backToEventsPage = function () {
                $state.go('eventheaders');
            };

            loadEventHeaders();


            vm.deleteAlbumItem = function (albumitem) {
                abp.message.confirm(App.localize('AreYouSureToDeleteAlbumItem' + albumitem.name),
                    function (isConfirmed) {
                        if (isConfirmed) {
                           
                            $http.delete('/api/Upload/' + albumitem.id + '/3').then(function (data) {
                                albumService.delete({ id: albumitem.id }).success(function () {
                                    abp.notify.success(App.localize('SuccessfullyDeleted'));
                                    loadEventHeaders();
                                });

                            }).catch(function (data) {
                                $scope.error = "An error has occured while deleting file! " + data;
                            });

                        }
                    });
            };


            vm.deleteInvitee = function (invitee) {
                abp.message.confirm(App.localize('AreYouSureToDeleteInvitee', invitee.name),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            inviteeService.delete({ id: invitee.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                loadEventHeaders();
                            });
                        }
                    });
            };


            $scope.openLightboxModal = function (index) {
                Lightbox.openModal($scope.images, index);
            };

          
            vm.albumCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/eventheaders/createAlbumItem.cshtml',
                    controller: 'app.views.eventheaders.createAlbumItem as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    loadEventHeaders();
                });
            };


            vm.inviteeCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/eventheaders/createInvitee.cshtml',
                    controller: 'app.views.eventheaders.createInvitee as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    loadEventHeaders();
                });
            };

         

        }
    ]);
})();