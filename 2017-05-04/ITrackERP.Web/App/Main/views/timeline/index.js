(function () {
    angular.module('app').controller('app.views.timeline.index', ['$rootScope',
        '$scope', '$state', '$modal', 'abp.services.app.machineRequirement', 'abp.services.app.department', 'abp.services.app.style',
        function ($rootScope, $scope, $state, $modal, machineRequirementService, departmentService, styleService) {
            var vm = this;
         
            vm.machinerequirement = [];
            vm.departments = [];
            var copied = null;
            

            //display style loading items function

            vm.getTimeLineItems = function () {

                $scope.config = {};
                $scope.resources = [];
                $scope.events = [];

                vm.copiedevent = {};
                $scope.selectedStyle = {};
                $scope.selectedLineNo = {};
                vm.styleloading = {};

                departmentService.getDepartments({}).success(function (result) {
                    vm.departments = result.items;

                    vm.departments.sort();

                    angular.forEach(vm.departments, function (departmentvalue, key) {
                        $scope.resources.push({
                            name: departmentvalue.name, id: departmentvalue.id
                        });

                    });

                    //config object


                    $scope.config = {
                        scale: "Day",
                        days: 365,
                        startDate: "2017-04-01",
                        onEventMoved: function (args) {
                            $scope.update(args);
                            args.preventDefault();
                        },
                        bubble: new DayPilot.Bubble(),

                        resourceBubble: new DayPilot.Bubble(),

                        onBeforeEventRender: function(args) {
                            args.data.bubbleHtml = "<div><b>" + args.data.text + "</b></div><div>Complete: " + args.data.complete + "%</div><div>Start: " + new DayPilot.Date(args.data.start).toString("M/d/yyyy") + "</div><div>End: " + new DayPilot.Date(args.data.end).toString("M/d/yyyy") + "</div>";
                            args.data.barColor = $scope.getRandomColor();
                        },

                        onEventResized: function (args) {
                            $scope.update(args);
                        },

                        allowEventOverlap: false,

                        eventClickHandling: "Select",
                        onEventSelected: function (args) {
                            $scope.selectedEvents = $scope.dp.multiselect.events();
                            $scope.$apply();
                        },
                        onEventClicked: function (args) {
                            $scope.getMachineRequirementIndex(args);
                        },
                        onTimeRangeSelected: function (args) { $scope.add();},

                        contextMenu : new DayPilot.Menu({items: [
                       // { text: "Edit", onClick: function (args) { $scope.dp.events.edit(args.source); } },
                       {text:"Copy", onclick: function() {copied = this.source;} },
                        {
                            text: "Delete", onClick: function (args) { $scope.delete(args);}
                        },
                        {text:"-"},
                        //{ text: "Select", onClick: function (args) { $scope.dp.multiselect.add(args.source); } },
                        ]}),

                        contextMenuSelection : new DayPilot.Menu({items: [
                        {text:"Paste", onclick: function() {
                            if (!copied) { alert('You need to copy an event first.'); return; } 
                            var selection = this.source;
                            var duration = copied.end().getTime() - copied.start().getTime(); // milliseconds

                            machineRequirementService.getDetail({
                                id: copied.id()
                            }).success(function (result1) {
                                vm.styleloading = result1;
                            
                                departmentService.getDetail({
                                    id: selection.resource
                                }).success(function (result2) {
                                    $scope.selectedLineNo = result2;
                             
                            styleService.getDetailByStyleNo({
                                styleNo: copied.text()
                            }).success(function (result3) {
                                $scope.selectedStyle = result3;
                           
                            vm.copiedevent.styleId = $scope.selectedStyle.id;
                            vm.copiedevent.styleNo = copied.text();
                            vm.copiedevent.lineNo = $scope.selectedLineNo.name;
                            vm.copiedevent.fromDate = selection.start;
                            vm.copiedevent.toDate = selection.start.addMilliseconds(duration);
                            vm.copiedevent.locationCode = vm.styleloading.locationCode;
                            vm.copiedevent.remark = vm.styleloading.remark;
                            vm.copiedevent.id = vm.styleloading.id;

                                machineRequirementService.duplicateEvent(vm.copiedevent)
                                .success(function () {
                                    abp.notify.success(App.localize('CopiedSuccessfully'));
                                    $scope.updateTimeLine();
                                });
                            });
                            });
                            });                                
                        }                          
                        }
                        ]}),

                        timeHeaders: [
                            { groupBy: "Month" },
                            { groupBy: "Cell", format: "d" }
                        ],
                        durationBarVisible: true,
                        durationBarMode: "PercentComplete",
                        resources: $scope.resources
                    };



                    //events object

                    machineRequirementService.getMachineRequirement({}).success(function (result1) {
                        vm.machinerequirement = result1.items;

                        angular.forEach(vm.departments, function (departmentvalue, key) {

                            angular.forEach(vm.machinerequirement, function (machinereqvalue, key1) {
                                if (machinereqvalue.lineNo == departmentvalue.name) {

                                    $scope.today = new Date();

                                    $scope.event = {};
                                    $scope.event.start = machinereqvalue.fromDate;
                                    $scope.event.end = machinereqvalue.toDate;
                                    $scope.event.id = machinereqvalue.id;
                                    $scope.event.resource = departmentvalue.id;
                                    $scope.event.text = machinereqvalue.styleNo;

                                    var startDate = new Date($scope.event.start);
                                    var endDate = new Date($scope.event.end);
                                    var today = new Date();

                                    if (endDate < today && startDate < today)
                                    {
                                        $scope.event.complete = 100;
                                    }
                                    else if (endDate > today && startDate > today) {
                                        $scope.event.complete = 0;
                                    }
                                    else if (endDate > today && startDate < today) {                                      

                                        var timeDiff1 = Math.abs(startDate.getTime() - endDate.getTime());
                                        var diffDays1 = Math.ceil(timeDiff1 / (1000 * 3600 * 24));

                                        var timeDiff2 = Math.abs(startDate.getTime() - today.getTime());
                                        var diffDays2 = Math.ceil(timeDiff2 / (1000 * 3600 * 24));

                                        $scope.event.complete = (diffDays2 / diffDays1) * 100;
                                    }

                                    
                                 //   $scope.event.backColor = $scope.getRandomColor();
                                    $scope.events.push($scope.event);
                                }

                            });

                        });
                    });




                });

            }


            vm.getTimeLineItems();

            // get random color

            $scope.getRandomColor = function () {
                var letters = '0123456789ABCDEF';
                var color = '#';
                for (var i = 0; i < 6; i++) {
                    color += letters[Math.floor(Math.random() * 16)];
                }
                return color;
            }

            $scope.updateTimeLine = function () {
                vm.getTimeLineItems();
            }
          
            //view machine req of a style

            $scope.getMachineRequirementIndex = function (args) {

                $rootScope.machineRequirementId = args.e.id();

                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/timeline/machineRequirementIndex.cshtml',
                    controller: 'app.views.timeline.machineRequirementIndex as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    vm.getTimeLineItems();
                });
            };


            //style loading delete function

            $scope.delete = function (args) {
                abp.message.confirm(App.localize('AreYouSureToDeleteStyleLoading' + args.source.text()),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            machineRequirementService.deleteHeader({ id: args.source.id() }).success(function () {
                                abp.notify.success(App.localize('SuccessfullyDeleted'));

                                $scope.selectedLineNo = {};

                                departmentService.getDetail({
                                    id: args.source.resource()
                                }).success(function (result) {
                                    $scope.selectedLineNo = result;
                               
                                $scope.dp.message("Event Deleted: Style " + args.source.text() + ", Line: " + $scope.selectedLineNo.name + ", Start Date: " + args.source.start() + ", End Date: " + args.source.end());                              
                                $scope.dp.events.remove(args.source);

                                });                            
                            });
                        }
                    });
            };

            //style loading update function

            $scope.update = function (args) {
                $scope.dp.message("Event moved: " + args.e.text());

                $scope.selectedEvent = {};
                $scope.selectedDepartment = {};
                vm.requirement = {};

                machineRequirementService.getDetail({
                    id: args.e.id()
                }).success(function (result1) {
                    $scope.selectedEvent = result1;

                    departmentService.getDetail({
                        id: args.e.resource()
                    }).success(function (result2) {
                        $scope.selectedDepartment = result2;

                        vm.requirement.id = args.e.id();
                        vm.requirement.styleId = $scope.selectedEvent.styleId;
                        vm.requirement.styleNo = args.e.text();
                        vm.requirement.fromDate = args.newStart;
                        vm.requirement.toDate = args.newEnd;
                        vm.requirement.lineNo = $scope.selectedDepartment.name;
                        vm.requirement.locationCode = $scope.selectedEvent.locationCode;
                        vm.requirement.remark = $scope.selectedEvent.remark;

                        machineRequirementService.updateHeader(vm.requirement)

                              .success(function () {
                                  abp.notify.success(App.localize('SavedSuccessfully'));
                                  $scope.dp.message("Event Updated: " + args.e.text());
                                  vm.getTimeLineItems();
                              });
                    });
                });

            }
           

            //style loading create function
                $scope.add = function () {

                    var modalInstance = $modal.open({
                        templateUrl: '/App/Main/views/machinerequirements/createMachineRequirement.cshtml',
                        controller: 'app.views.machinerequirements.createMachineRequirement as vm',
                        backdrop: 'static'
                    });

                    modalInstance.result.then(function () {                      
                        vm.getTimeLineItems();
                    });

            };

            $scope.move = function () {
                var event = $scope.events[0];
                event.start = event.start.addDays(1);
                event.end = event.end.addDays(1);
            };

            $scope.rename = function () {
                $scope.events[0].text = "New name";
            };

            $scope.scale = function (val) {
                $scope.config.scale = val;
            };


        }
    ]);
})();