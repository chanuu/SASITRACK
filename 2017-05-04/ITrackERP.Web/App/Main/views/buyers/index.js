(function () {
    angular.module('app').controller('app.views.buyers.index', [
        '$scope', '$modal', 'abp.services.app.buyer',
        function ($scope, $modal, buyerService) {
            var vm = this;




            vm.buyers = [];

            function getBuyers() {
                buyerService.getBuyers({}).success(function (result) {
                    vm.buyers = result.items;
                });
            };


            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            };

            vm.showHideGrid = function () {

                event.preventDefault();
                var hpanel = $(this).closest('div.hpanel');
                var icon = $(this).find('i:first');
                var body = hpanel.find('div.panel-body');
                var footer = hpanel.find('div.panel-footer');
                body.slideToggle(300);
                footer.slideToggle(200);

                // Toggle icon from up to down
                icon.toggleClass('fa-chevron-up').toggleClass('fa-chevron-down');
                hpanel.toggleClass('').toggleClass('panel-collapse');
                setTimeout(function () {
                    hpanel.resize();
                    hpanel.find('[id^=map-]').resize();
                }, 50);

            };

            vm.delete = function (buyer)
            {
                abp.message.confirm(App.localize('AreYouSureToDeleteBuyer'+ buyer.buyerName),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            buyerService.delete({ id: buyer.id }).success(function ()
                            {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));
                                
                                getBuyers();
                            });
                        }
                    });

                
            }


           


            vm.buyerCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/buyers/createBuyer.cshtml',
                    controller: 'app.views.buyers.createBuyer as vm',
                    backdrop: 'static'
                });
                
                modalInstance.result.then(function () {
                    getBuyers();
                });
            };
           


            getBuyers();


        }
    ]);
})();