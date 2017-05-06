(function () {
    var controllerId = 'app.views.dividingplans.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$modal', '$state', '$stateParams', 'abp.services.app.dividingPlanHeader', 'abp.services.app.department', 'abp.services.app.layoutHeader', 'abp.services.app.layoutItem', 'abp.services.app.element',
        function ($rootScope, $scope, $modal, $state, $stateParams, dividingplanService, departmentService, layoutheaderService, layoutitemService, elementService) {
            var vm = this;
            vm.dividingplanheader = {};
            vm.department = {};
            vm.dividingplan = {};
            vm.layoutheaderbyid = {};
           
            vm.categories = ['Category 1', 'Category 2', 'Category 3', 'Category 4', 'Category 5', 'Category 6'];
         
                $rootScope.hId = $stateParams.id;

                function loadDividingPlanHeaders() {
                    dividingplanService.getDetail({
                        id: $stateParams.id
                    }).success(function (result) {
                        vm.dividingplan = result;
                        
                        departmentService.getDetailByLineNo({
                            name: vm.dividingplan.lineNo
                        }).success(function (result1) {
                            vm.department = result1;
                            $rootScope.linesize = vm.department.length + " " + vm.department.width;
                        });

                    });                   
                }

                vm.back = function () {
                    $state.go('dividingplan');
                };

                loadDividingPlanHeaders();
                
                vm.delete = function (dividingplan) {
                    abp.message.confirm(App.localize('AreYouSureToDeleteDividingPlanItem' + dividingplan.operationNo),
                        function (isConfirmed) {
                            if (isConfirmed) {
                                dividingplanService.deleteItem({ id: dividingplan.id }).success(function () {
                                    abp.notify.success(App.localize('SuccessfullyDeleted'));
                                    loadDividingPlanHeaders();
                                });
                            }
                        });
                };



                vm.dividingplanItemCreationModal = function () {
                    var modalInstance = $modal.open({
                        templateUrl: '/App/Main/views/dividingplans/createItems.cshtml',
                        controller: 'app.views.dividingplans.createItems as vm',
                        backdrop: 'static'
                    });

                    modalInstance.result.then(function () {
                        loadDividingPlanHeaders();
                    });
                };
      
           
                // General Parameters for this app, used during initialization
                var AllowTopLevel = false;
                var CellSize = new go.Size(10, 10);

                $scope.initt = function () {
                    if (window.goSamples) goSamples();  // init for these samples -- you don't need to call this
                    var $ = go.GraphObject.make;
                    myDiagram =
                      $(go.Diagram, "myDiagramDiv",
                        {
                            grid: $(go.Panel, "Grid",
                                    { gridCellSize: CellSize },
                                    $(go.Shape, "LineH", { stroke: "lightgray" }),
                                    $(go.Shape, "LineV", { stroke: "lightgray" })
                                  ),
                            // support grid snapping when dragging and when resizing
                            "draggingTool.isGridSnapEnabled": true,
                            "draggingTool.gridSnapCellSpot": go.Spot.Center,
                            "resizingTool.isGridSnapEnabled": true,
                            allowDrop: true,  // handle drag-and-drop from the Palette
                            // For this sample, automatically show the state of the diagram's model on the page
                            "ModelChanged": function (e) {
                                if (e.isTransactionFinished) {
                                    document.getElementById("savedModel").textContent = myDiagram.model.toJson();
                                }
                            },
                            "animationManager.isEnabled": false,
                            "undoManager.isEnabled": true
                        });

                    // Regular Nodes represent items to be put onto racks.
                    // Nodes are currently resizable, but if that is not desired, just set resizable to false.
                    myDiagram.nodeTemplate =
                      $(go.Node, "Auto",
                        {
                            resizable: false, resizeObjectName: "SHAPE",
                            
                            rotatable: true,
                            // because the gridSnapCellSpot is Center, offset the Node's location
                            //    locationSpot: new go.Spot(0, 0, CellSize.width / 2, CellSize.height / 2),
                            locationSpot: go.Spot.Center,
                           
                            layerName: "Background",
                            // provide a visual warning about dropping anything onto an "item"
                            mouseDragEnter: function (e, node) {
                                e.handled = true;
                                node.findObject("SHAPE").fill = "white";
                                highlightGroup(node.containingGroup, false);
                            },
                            mouseDragLeave: function (e, node) {
                                node.updateTargetBindings();
                            },
                            mouseDrop: function (e, node) {  // disallow dropping anything onto an "item"
                                node.diagram.currentTool.doCancel();
                            }
                        },
                        // always save/load the point that is the top-left corner of the node, not the location
                        new go.Binding("position", "pos", go.Point.parse).makeTwoWay(go.Point.stringify),
                        // this is the primary thing people see
                        $(go.Shape, "RoundedRectangle",
                          {
                              name: "SHAPE",
                              fill: "white",
                              portId: "", fromLinkable: true, toLinkable: true, cursor: "pointer",
                              minSize: CellSize,
                              desiredSize: CellSize  // initially 1x1 cell
                          },
                          new go.Binding("fill", "color"),
                          new go.Binding("desiredSize", "size", go.Size.parse).makeTwoWay(go.Size.stringify)),

                          // set the image path as source
                          $(go.Picture,
                           { margin: 2, width: 200, height: 100, background: null, imageStretch: go.GraphObject.Fill },
                          new go.Binding("source")),

                        // with the textual key in the middle
                        $(go.TextBlock,
                          { alignment: go.Spot.Center, font: 'bold 16px sans-serif', editable: true },
                          new go.Binding("text", "key")
                          )
                      )
                    ;  // end Node
                    // Groups represent racks where items (Nodes) can be placed.
                    // Currently they are movable and resizable, but you can change that
                    // if you want the racks to remain "fixed".
                    // Groups provide feedback when the user drags nodes onto them.
                    function highlightGroup(grp, show) {
                        if (!grp) return;
                        if (show) {  // check that the drop may really happen into the Group
                            var tool = grp.diagram.toolManager.draggingTool;
                            var map = tool.draggedParts || tool.copiedParts;  // this is a Map
                            if (grp.canAddMembers(map.toKeySet())) {
                                grp.isHighlighted = true;
                                return;
                            }
                        }
                        grp.isHighlighted = false;
                    }
                    var groupFill = "rgba(128,128,128,0.2)";
                    var groupStroke = "gray";
                    var dropFill = "rgba(128,255,255,0.2)";
                    var dropStroke = "red";
                    myDiagram.groupTemplate =
                      $(go.Group,
                        {
                            layerName: "Background",
                            resizable: false, resizeObjectName: "SHAPE",
                            movable:false,
                            // because the gridSnapCellSpot is Center, offset the Group's location
                            locationSpot: new go.Spot(0, 0, CellSize.width / 2, CellSize.height / 2)
                        },
                        // always save/load the point that is the top-left corner of the node, not the location
                        new go.Binding("position", "pos", go.Point.parse).makeTwoWay(go.Point.stringify),
                        { // what to do when a drag-over or a drag-drop occurs on a Group
                            mouseDragEnter: function (e, grp, prev) { highlightGroup(grp, true); },
                            mouseDragLeave: function (e, grp, next) { highlightGroup(grp, false); },
                            mouseDrop: function (e, grp) {
                                var ok = grp.addMembers(grp.diagram.selection, true);
                                if (!ok) grp.diagram.currentTool.doCancel();
                            }
                        },
                        $(go.Shape, "Rectangle",  // the rectangular shape around the members
                          {
                              name: "SHAPE",
                              fill: groupFill,
                              stroke: groupStroke,
                              minSize: new go.Size(CellSize.width * 2, CellSize.height * 2)
                          },
                          new go.Binding("desiredSize", "size", go.Size.parse).makeTwoWay(go.Size.stringify),
                          new go.Binding("fill", "isHighlighted", function (h) { return h ? dropFill : groupFill; }).ofObject(),
                          new go.Binding("stroke", "isHighlighted", function (h) { return h ? dropStroke : groupStroke; }).ofObject())
                      );


                    // decide what kinds of Parts can be added to a Group
                    myDiagram.commandHandler.memberValidation = function (grp, node) {
                        if (grp instanceof go.Group && node instanceof go.Group) return false;  // cannot add Groups to Groups
                        // but dropping a Group onto the background is always OK
                        return true;
                    };
                    // what to do when a drag-drop occurs in the Diagram's background
                    myDiagram.mouseDragOver = function (e) {
                        if (!AllowTopLevel) {
                            // but OK to drop a group anywhere
                            if (!e.diagram.selection.all(function (p) { return p instanceof go.Group; })) {
                                e.diagram.currentCursor = "not-allowed";
                            }
                        }
                    };
                    myDiagram.mouseDrop = function (e) {
                        if (AllowTopLevel) {
                            // when the selection is dropped in the diagram's background,
                            // make sure the selected Parts no longer belong to any Group
                            if (!e.diagram.commandHandler.addTopLevelParts(e.diagram.selection, true)) {
                                e.diagram.currentTool.doCancel();
                            }
                        } else {
                            // disallow dropping any regular nodes onto the background, but allow dropping "racks"
                            if (!e.diagram.selection.all(function (p) { return p instanceof go.Group; })) {
                                e.diagram.currentTool.doCancel();
                            }
                        }
                    };
                    // start off with four "racks" that are positioned next to each other


                    layoutheaderService.headerIdCheck({
                        dividingPlanHeaderId: $stateParams.id
                    }).success(function (result) {
                        if (result == false) {
                            myDiagram.model = new go.GraphLinksModel([
                                                { key: "G1", isGroup: true, pos: "0 0", size: $rootScope.linesize },                                           
                            ]);
                            // this sample does not make use of any links
                        }
                        else {
                            layoutheaderService.getDetailByDividingPlanHeaderId({
                                dividingPlanHeaderId: $stateParams.id
                            }).success(function (result) {
                                vm.jsonLayoutString = result;

                                myDiagram.model = go.Model.fromJson(vm.jsonLayoutString.layoutJson);

                            });

                        }
                    });

              
                        vm.back = function () {
                            $state.go('dividingplan');
                        };
           
                        category1 = $(go.Palette, "Category 1", {
                            nodeTemplate: myDiagram.nodeTemplate,
                            groupTemplate: myDiagram.groupTemplate,
                            layout: $(go.GridLayout),
                        });
                        category2 = $(go.Palette, "Category 2", {
                            nodeTemplate: myDiagram.nodeTemplate,
                            groupTemplate: myDiagram.groupTemplate,
                            layout: $(go.GridLayout),
                        });
                        category3 = $(go.Palette, "Category 3", {
                            nodeTemplate: myDiagram.nodeTemplate,
                            groupTemplate: myDiagram.groupTemplate,
                            layout: $(go.GridLayout),
                        });
                        category4 = $(go.Palette, "Category 4", {
                            nodeTemplate: myDiagram.nodeTemplate,
                            groupTemplate: myDiagram.groupTemplate,
                            layout: $(go.GridLayout),
                        });
                        category5= $(go.Palette, "Category 5", {
                            nodeTemplate: myDiagram.nodeTemplate,
                            groupTemplate: myDiagram.groupTemplate,
                            layout: $(go.GridLayout),
                        });
                        category6 = $(go.Palette, "Category 6", {
                            nodeTemplate: myDiagram.nodeTemplate,
                            groupTemplate: myDiagram.groupTemplate,
                            layout: $(go.GridLayout),
                        });

                    angular.forEach(vm.categories, function (value1, key1) {
                      
                        vm.item = [];
                    elementService.getDetailByCategory({ category: value1 }).success(function (result) {
                        vm.item = result.items;

                        var items = [];

                        angular.forEach(vm.item, function (value, key) {
                            var arrayitem = {};
                            arrayitem.key = value.name;
                            arrayitem.size = value.length + " " + value.width;
                            arrayitem.source = value.path;
                            items.push(arrayitem);
                        });
                        if (value1 == "Category 1") {
                            category1.model = new go.GraphLinksModel(items);
                        }
                        else if (value1 == "Category 2") {
                            category2.model = new go.GraphLinksModel(items);
                        }
                        else if (value1 == "Category 3") {
                            category3.model = new go.GraphLinksModel(items);
                        }
                        else if (value1 == "Category 4") {
                            category4.model = new go.GraphLinksModel(items);
                        }
                        else if (value1 == "Category 5") {
                            category5.model = new go.GraphLinksModel(items);
                        }
                        else if (value1 == "Category 6") {
                            category6.model = new go.GraphLinksModel(items);
                        }
                    });

                    });

             
                    jQuery("#accordion").accordion({

                        activate: function (event, ui) {
                            category1.requestUpdate();
                            category2.requestUpdate();
                            category3.requestUpdate();
                            category4.requestUpdate();
                            category5.requestUpdate();
                            category6.requestUpdate();
                        }
                    });


                    //////////////////////////////

                    // when the document is modified, add a "*" to the title and enable the "Save" button
                    myDiagram.addDiagramListener("Modified", function (e) {
                        var button = document.getElementById("SaveButton");
                        if (button) button.disabled = !myDiagram.isModified;
                        var idx = document.title.indexOf("*");
                        if (myDiagram.isModified) {
                            if (idx < 0) document.title += "*";
                        } else {
                            if (idx >= 0) document.title = document.title.substr(0, idx);
                        }
                    });
                    
                    // This is the template for a label node on a link: just an Ellipse.
                    // This node supports user-drawn links to and from the label node.
                    myDiagram.nodeTemplateMap.add("LinkLabel",
                      $("Node",
                        {
                            selectable: false, avoidable: false,
                            layerName: "Foreground"
                        },  // always have link label nodes in front of Links
                        $("Shape", "Ellipse",
                          {
                              width: 5, height: 5, stroke: null,
                              portId: "", fromLinkable: true, toLinkable: true, cursor: "pointer"
                          })
                      ));
                    // the regular link template, a straight blue arrow
                    myDiagram.linkTemplate =
                      $("Link",
                        { relinkableFrom: true, relinkableTo: true, toShortLength: 2, routing: go.Link.AvoidsNodes, reshapable: true },
                        $("Shape", { stroke: "#2E68CC", strokeWidth: 3 }),
                        $("Shape", { fill: "#2E68CC", stroke: null, toArrow: "Standard" })
                      );
                    // This template shows links connecting with label nodes as green and arrow-less.
                    myDiagram.linkTemplateMap.add("linkToLink",
                      $("Link",
                        { relinkableFrom: true, relinkableTo: true },
                        $("Shape", { stroke: "#2D9945", strokeWidth: 4 })
                      ));
                    // GraphLinksModel support for link label nodes requires specifying two properties.
                    myDiagram.model =
                      $(go.GraphLinksModel,
                        { linkLabelKeysProperty: "labelKeys" });
                    // Whenever a new Link is drawng by the LinkingTool, it also adds a node data object
                    // that acts as the label node for the link, to allow links to be drawn to/from the link.
                    myDiagram.toolManager.linkingTool.archetypeLabelNodeData =
                      { category: "LinkLabel" };
                    // this DiagramEvent handler is called during the linking or relinking transactions
                    function maybeChangeLinkCategory(e) {
                        var link = e.subject;
                        var linktolink = (link.fromNode.isLinkLabel || link.toNode.isLinkLabel);
                        e.diagram.model.setCategoryForLinkData(link.data, (linktolink ? "linkToLink" : ""));
                    }
                    /////////////////

                }

                $scope.saveToJason = function () {
                 
                    var modelAsText = myDiagram.model.toJson();

                    layoutheaderService.headerIdCheck({dividingPlanHeaderId : $stateParams.id})
                      .success(function (result) {
                          if(result == false)
                          {
                          vm.layoutheader = {};
                          vm.layoutheader.dividingPlanHeaderId = $stateParams.id;
                          vm.layoutheader.layoutJson = modelAsText;
                          vm.layoutheader.remark = "";

                          layoutheaderService.create(vm.layoutheader)
                            .success(function () {
                                abp.notify.success(App.localize('SavedSuccessfully'));

                            });

                          }

                          else {
                              layoutheaderService.getDetailByDividingPlanHeaderId({
                                  dividingPlanHeaderId: $stateParams.id
                              }).success(function (result1) {
                                  vm.layoutheaderbyid = result1;

                                  vm.layoutheader1 = {};
                                  vm.layoutheader1.id = vm.layoutheaderbyid.id;
                                  vm.layoutheader1.dividingPlanHeaderId = $stateParams.id;
                                  vm.layoutheader1.layoutJson = modelAsText;
                                  vm.layoutheader1.remark = vm.layoutheaderbyid.remark;


                                  layoutheaderService.update(vm.layoutheader1)
                           .success(function () {
                               abp.notify.success(App.localize('SavedSuccessfully'));

                           });


                              });
                          }


                          });                                    
                        };

            
                $scope.deleteJason = function () {

                    var modelAsText = myDiagram.model.toJson();

                    layoutheaderService.headerIdCheck({ dividingPlanHeaderId: $stateParams.id })
                      .success(function (result) {
                          if (result == false) {

                              myDiagram.model = new go.GraphLinksModel([
                                              { key: "G1", isGroup: true, pos: "0 0", size: $rootScope.linesize },
                              ]);


                                    abp.notify.success(App.localize('DeletedSuccessfully'));
                          }

                          else {
                              layoutheaderService.getDetailByDividingPlanHeaderId({
                                  dividingPlanHeaderId: $stateParams.id
                              }).success(function (result1) {
                                  vm.layoutheaderbyid = result1;
                                                                
                              abp.message.confirm(App.localize('AreYouSureToDeleteLayout'),
                              function (isConfirmed) {
                             if (isConfirmed) {
                              layoutheaderService.delete({ id: vm.layoutheaderbyid.id }).success(function () {
                                  abp.notify.success(App.localize('SuccessfullyDeleted'));
                                
                                  myDiagram.model = new go.GraphLinksModel([
                                               { key: "G1", isGroup: true, pos: "0 0", size: $rootScope.linesize },
                                  ]);

                              });
                          }
                      });
                              });
                          }

                      });
                };



        }
    ]);
})();