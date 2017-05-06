
(function() {
  var moduleName = 'angularUtils.directives.itrack';
    var DEFAULT_ID = '__default';
	
	 angular.module(moduleName, [])
         .directive('iboxTools', iboxTools)
         .directive('icheck', icheck)
		 .directive('routeLoadingIndicator', routeLoadingIndicator)

         .directive('sideNavigation', sideNavigation)

         .directive('gojsinit', gojsinit)

		 
   
 
        .directive('iboxToolsFullScreen', iboxToolsFullScreen)
       
	   
	   
	   /**
 * iboxTools - Directive for iBox tools elements in right corner of ibox
 */
function iboxTools($timeout) {
    return {
        restrict: 'A',
        scope: true,
        
        controller: function ($scope, $element) {
            // Function for collapse ibox
            $scope.showhide = function () {
                var ibox = $element.closest('div.ibox');
                var icon = $element.find('i:first');
                var content = ibox.find('div.ibox-content');
                content.slideToggle(200);
                // Toggle icon from up to down
                icon.toggleClass('fa-chevron-up').toggleClass('fa-chevron-down');
                ibox.toggleClass('').toggleClass('border-bottom');
                $timeout(function () {
                    ibox.resize();
                    ibox.find('[id^=map-]').resize();
                }, 50);
            };
                // Function for close ibox
                $scope.closebox = function () {
                    var ibox = $element.closest('div.ibox');
                    ibox.remove();
                }
        }
    };
}



function icheck($timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, $attrs, ngModel) {
            return $timeout(function () {
                var value;
                value = $attrs['value'];

                $scope.$watch($attrs['ngModel'], function (newValue) {
                    $(element).iCheck('update');
                })

                return $(element).iCheck({
                    checkboxClass: 'icheckbox_square-green',
                    radioClass: 'iradio_square-green'

                }).on('ifChanged', function (event) {
                    if ($(element).attr('type') === 'checkbox' && $attrs['ngModel']) {
                        $scope.$apply(function () {
                            return ngModel.$setViewValue(event.target.checked);
                        });
                    }
                    if ($(element).attr('type') === 'radio' && $attrs['ngModel']) {
                        return $scope.$apply(function () {
                            return ngModel.$setViewValue(value);
                        });
                    }
                });
            });
        }
    };
}


function gojsinit($scope) {

    return {
        restrict: 'E',
        template: '<div></div>',  // just an empty DIV element
    replace: true,
    scope: { model: '=goModel' },
    link: function(scope, element, attrs) {
    var $ = go.GraphObject.make;
    var diagram =  // create a Diagram for the given HTML DIV element
      $(go.Diagram, element[0],
        {
            nodeTemplate: $(go.Node, "Auto",
                            new go.Binding("location", "loc", go.Point.parse).makeTwoWay(go.Point.stringify),
                            $(go.Shape, "RoundedRectangle", new go.Binding("fill", "color"),
                              {
                                  portId: "", cursor: "pointer", strokeWidth: 0,
                                  fromLinkable: true, toLinkable: true,
                                  fromLinkableSelfNode: true, toLinkableSelfNode: true,
                                  fromLinkableDuplicates: true, toLinkableDuplicates: true
                              }),
                            $(go.TextBlock, { margin: 8, editable: true },
                              new go.Binding("text", "name").makeTwoWay())
                          ),
            linkTemplate: $(go.Link,
                            { relinkableFrom: true, relinkableTo: true },
                            $(go.Shape),
                            $(go.Shape, { toArrow: "Standard", stroke: null, strokeWidth: 0 })
                          ),
            initialContentAlignment: go.Spot.Center,
            "ModelChanged": updateAngular,
            "ChangedSelection": updateSelection,
            "undoManager.isEnabled": true
        });

        // whenever a GoJS transaction has finished modifying the model, update all Angular bindings
    function updateAngular(e) {
        if (e.isTransactionFinished) {
            scope.$apply();
        }
    }

        // update the Angular model when the Diagram.selection changes
    function updateSelection(e) {
        diagram.model.selectedNodeData = null;
        var it = diagram.selection.iterator;
        while (it.next()) {
            var selnode = it.value;
            // ignore a selected link or a deleted node
            if (selnode instanceof go.Node && selnode.data !== null) {
                diagram.model.selectedNodeData = selnode.data;
                break;
            }
        }
        scope.$apply();
    }

        // notice when the value of "model" changes: update the Diagram.model
    scope.$watch("model", function(newmodel) {
        var oldmodel = diagram.model;
        if (oldmodel !== newmodel) {
            diagram.removeDiagramListener("ChangedSelection", updateSelection);
            diagram.model = newmodel;
            diagram.addDiagramListener("ChangedSelection", updateSelection);
        }
    });

    scope.$watch("model.selectedNodeData.name", function(newname) {
        if (!diagram.model.selectedNodeData) return;
        // disable recursive updates
        diagram.removeModelChangedListener(updateAngular);
        // change the name
        diagram.startTransaction("change name");
        // the data property has already been modified, so setDataProperty would have no effect
        var node = diagram.findNodeForData(diagram.model.selectedNodeData);
        if (node !== null) node.updateTargetBindings("name");
        diagram.commitTransaction("change name");
        // re-enable normal updates
        diagram.addModelChangedListener(updateAngular);
    });
}
};
}

 function routeLoadingIndicator($rootScope) {
  return {
    restrict: 'E',
    template: "<div ng-show='isRouteLoading' class='loading-indicator'>" +
    "<div class='loading-indicator-body'>" +
   
    "<div class='spinner'><div class='bounce1'></div><div class='bounce2'></div><div class='bounce3'></div></div>" +
    "</div>" +
    "</div>",
    replace: true,
    link: function(scope, elem, attrs) {
      scope.isRouteLoading = false;
 
      $rootScope.$on('$routeChangeStart', function() {
        scope.isRouteLoading = true;
      });
      $rootScope.$on('$routeChangeSuccess', function() {
        scope.isRouteLoading = false;
      });
    }
  };
}

/**
 * sideNavigation - Directive for run metsiMenu on sidebar navigation
 */
function sideNavigation($timeout) {
    return {
        restrict: 'A',
        link: function(scope, element) {
            // Call the metsiMenu plugin and plug it to sidebar navigation
            $timeout(function(){
                element.metisMenu();

            });
        }
    };
};




/**
 * iboxTools with full screen - Directive for iBox tools elements in right corner of ibox with full screen option
 */
function iboxToolsFullScreen($timeout) {
    return {
        restrict: 'A',
        scope: true,
      
        controller: function ($scope, $element) {
            // Function for collapse ibox
            $scope.showhide = function () {
                var ibox = $element.closest('div.ibox');
                var icon = $element.find('i:first');
                var content = ibox.find('div.ibox-content');
                content.slideToggle(200);
                // Toggle icon from up to down
                icon.toggleClass('fa-chevron-up').toggleClass('fa-chevron-down');
                ibox.toggleClass('').toggleClass('border-bottom');
                $timeout(function () {
                    ibox.resize();
                    ibox.find('[id^=map-]').resize();
                }, 50);
            };
            // Function for close ibox
            $scope.closebox = function () {
                var ibox = $element.closest('div.ibox');
                ibox.remove();
            };
            // Function for full screen
            $scope.fullscreen = function () {
                var ibox = $element.closest('div.ibox');
                var button = $element.find('i.fa-expand');
                $('body').toggleClass('fullscreen-ibox-mode');
                button.toggleClass('fa-expand').toggleClass('fa-compress');
                ibox.toggleClass('fullscreen');
                setTimeout(function() {
                    $(window).trigger('resize');
                }, 100);
            }
        }
    };
}

})();