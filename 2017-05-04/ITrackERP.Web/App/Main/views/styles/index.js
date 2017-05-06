(function () {
    angular.module('app').controller('app.views.styles.index', [
        '$scope', '$modal', 'abp.services.app.style',
        function ( $scope, $modal, styleService) {
            var vm = this;
        
            vm.styles = [];
          
            function getStyles() {
                styleService.getStyles({}).success(function (result) {
                    vm.styles = result.items;
                });
            };


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            };

           

            vm.delete = function (style) {
                abp.message.confirm(App.localize('AreYouSureToDeleteStyle' + style.styleNo),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            styleService.deleteStyle({ id: style.id }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                getStyles();
                            });
                        }
                    });
            };
      

            vm.styleCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/styles/createStyle.cshtml',
                    controller: 'app.views.styles.createStyle as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getStyles();
                });
            };



            getStyles();

          
        }
    ]);
})();