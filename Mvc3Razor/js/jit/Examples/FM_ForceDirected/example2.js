
var labelType, useGradients, nativeTextSupport, animate;
var fd;
function fm_saveTree(str){
	fd.graph.eachNode(function (node) {
		console.log(node.id);
	});
	if ($jit.json)
	{
		console.log(JSON.stringify(fd.toJSON('graph')) );
	}
	else 
	{
		alert('un def Dude!');
	}


}
function fm_removeAdjacence(str)
{
//var items = str.split(/[.,\/ -]/);
var items = str.split(/[\s,]+/)
var sz = "";
//var parts = [];
for (var i = 0, len = items.length; i < len; ++i) 
{
	sz += items[i] + "\n";
	//parts.push(items[i]);
}
//alert(sz);
//alert(items[0] + "\n" + items[1] );
var node = fd.graph.getNode(items[0]);
var zzz = fd.toJSON;
//console.log(JSON.stringify(node) );

	//removeAdjacence(id1, id2);
	//var id1 = "graphnode0";
	//var id2 = "graphnode13";
	//fd.graph.removeAdjacence(id1, id2);
	
	fd.graph.removeAdjacence(items[0], items[1]);

	fd.plot();
	//fd.refresh();	
}
function fm_removeNode(id)
{
	var node = fd.graph.getNode(id);
	//alert(node);
	
	if (node)
	{
		alert(node.id);
		
		fd.graph.removeNode(id);
		fd.plot();
		fd.refresh();	
	}
	else 
	{
		alert('un def Dude!');
	}
}

function fm_print(id)
{
{
fd.graph.eachNode(function (node) {
		console.log(node.id);
    });
}
//	var node = fd.graph.getNode(id);
	//alert(node);
	if ($jit.json)
	{
		//alert(node.id);
		//$jit.json.prune(fd.tree, maxLevel);
		//alert(fd.toJSON);
		//alert(JSON.stringify(fd.toJSON('tree')) );
		
		//      alert(JSON.stringify(fd.graph) );
		console.log(JSON.stringify(fd.toJSON('graph')) );
		//alert(JSON.stringify(fd.toJSON('tree')) );
		
		//alert($jit.Graph.Util.eachAdjacency);

		/*******/
var node = fd.graph.getNode(id);		
/********
$jit.Graph.Util.eachAdjacency(node, function(adj) {  
 //console.log('adj.nodeTo.name');  
 console.log(adj.nodeTo.name);  
});  		
***/
		//.alert(JSON.stringify(fd.toJSON('graph')) );
		//alert(json);
		//console.log(JSON.stringify(json));
		
		//fd.graph.removeNode(id);
		//fd.plot();
		//fd.refresh();	
	}
	else 
	{
		alert('un def Dude!');
	}
}



(function() {
  var ua = navigator.userAgent,
      iStuff = ua.match(/iPhone/i) || ua.match(/iPad/i),
      typeOfCanvas = typeof HTMLCanvasElement,
      nativeCanvasSupport = (typeOfCanvas == 'object' || typeOfCanvas == 'function'),
      textSupport = nativeCanvasSupport 
        && (typeof document.createElement('canvas').getContext('2d').fillText == 'function');
  //I'm setting this based on the fact that ExCanvas provides text support for IE
  //and that as of today iPhone/iPad current text support is lame
  labelType = (!nativeCanvasSupport || (textSupport && !iStuff))? 'Native' : 'HTML';
  nativeTextSupport = labelType == 'Native';
  useGradients = nativeCanvasSupport;
  animate = !(iStuff || !nativeCanvasSupport);
})();

var Log = {
  elem: false,
  write: function(text){
    if (!this.elem) 
      this.elem = document.getElementById('log');
    this.elem.innerHTML = text;
    this.elem.style.left = (500 - this.elem.offsetWidth / 2) + 'px';
  }
};

function init(){
  // init data
  var json = [
    {
	
      "adjacencies": [
        {
          "nodeTo": "Jake", 
          "nodeFrom": "graphnode0", 
          "data": {}
        }, 
        {
          "nodeTo": "noiseToSelf", 
          "nodeFrom": "graphnode0", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode4", 
          "nodeFrom": "graphnode0", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode10", 
          "nodeFrom": "graphnode0", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode6", 
          "nodeFrom": "graphnode0", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode11", 
          "nodeFrom": "graphnode0", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode12", 
          "nodeFrom": "graphnode0", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode13", 
          "nodeFrom": "graphnode0", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode14", 
          "nodeFrom": "graphnode0", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode15", 
          "nodeFrom": "graphnode0", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode16", 
          "nodeFrom": "graphnode0", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode17", 
          "nodeFrom": "graphnode0", 
          "data": {}
        }
      ], 
      "data": {
        "$color": "#83548B", 
        "$type": "circle"
      }, 
      "id": "graphnode0", 
      "name": "graphnode0"
    }, 
    {
      "adjacencies": [
        {
          "nodeTo": "noiseToSelf", 
          "nodeFrom": "graphnode1", 
          "data": {}
        }, 
        {
          "nodeTo": "Jake", 
          "nodeFrom": "graphnode1", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode4", 
          "nodeFrom": "graphnode1", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode5", 
          "nodeFrom": "graphnode1", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode6", 
          "nodeFrom": "graphnode1", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode10", 
          "nodeFrom": "graphnode1", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode11", 
          "nodeFrom": "graphnode1", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode12", 
          "nodeFrom": "graphnode1", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode13", 
          "nodeFrom": "graphnode1", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode14", 
          "nodeFrom": "graphnode1", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode15", 
          "nodeFrom": "graphnode1", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode16", 
          "nodeFrom": "graphnode1", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode17", 
          "nodeFrom": "graphnode1", 
          "data": {}
        }
      ], 
      "data": {
        "$color": "#83548B", 
        "$type": "star"
      }, 
      "id": "graphnode1", 
      "name": "graphnode1"
    }, 
    {
      "adjacencies": [
        {
          "nodeTo": "Jake", 
          "nodeFrom": "noiseToSelf", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode5", 
          "nodeFrom": "noiseToSelf", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode18", 
          "nodeFrom": "noiseToSelf", 
          "data": {}
        }
      ], 
      "data": {
        "$color": "#EBB056", 
        "$type": "star"
      }, 
      "id": "noiseToSelf", 
      "name": "noiseToSelf"
    }, 
    {
      "adjacencies": [
        {
          "nodeTo": "graphnode5", 
          "nodeFrom": "Jake", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode10", 
          "nodeFrom": "Jake", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode6", 
          "nodeFrom": "Jake", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode11", 
          "nodeFrom": "Jake", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode12", 
          "nodeFrom": "Jake", 
          "data": {}
        }
      ], 
      "data": {
        "$color": "#70A35E", 
        "$type": "triangle"
      }, 
      "id": "Jake", 
      "name": "Jake"
    }, 
    {
      "adjacencies": [], 
      "data": {
        "$color": "#70A35E", 
        "$type": "star"
      }, 
      "id": "graphnode4", 
      "name": "graphnode4"
    }, 
    {
      "data": {
        "$color": "#416D9C", 
        "$type": "star"
      }, 
      "id": "graphnode5", 
      "name": "graphnode5"
    }, 
    {
      "adjacencies": [
        {
          "nodeTo": "graphnode11", 
          "nodeFrom": "graphnode10", 
          "data": {}
        }
      ], 
      "data": {
        "$color": "#83548B", 
        "$type": "triangle"
      }, 
      "id": "graphnode10", 
      "name": "graphnode10"
    }, 
    {
      "adjacencies": [], 
      "data": {
        "$color": "#416D9C", 
        "$type": "triangle"
      }, 
      "id": "graphnode11", 
      "name": "graphnode11"
    }, 
    {
      "adjacencies": [], 
      "data": {
        "$color": "#70A35E", 
        "$type": "square"
      }, 
      "id": "graphnode12", 
      "name": "graphnode12"
    }, 
    {
      "adjacencies": [
        {
          "nodeTo": "graphnode14", 
          "nodeFrom": "graphnode13", 
          "data": {}
        }
      ], 
      "data": {
        "$color": "#416D9C", 
        "$type": "square"
      }, 
      "id": "graphnode13", 
      "name": "graphnode13"
    }, 
    {
      "adjacencies": [], 
      "data": {
        "$color": "#70A35E", 
        "$type": "square"
      }, 
      "id": "graphnode14", 
      "name": "graphnode14"
    }, 
    {
      "adjacencies": [
        {
          "nodeTo": "graphnode16", 
          "nodeFrom": "graphnode15", 
          "data": {}
        }, 
        {
          "nodeTo": "graphnode17", 
          "nodeFrom": "graphnode15", 
          "data": {}
        }
      ], 
      "data": {
        "$color": "#C74243", 
        "$type": "circle"
      }, 
      "id": "graphnode15", 
      "name": "graphnode15"
    }, 
    {
      "adjacencies": [
        {
          "nodeTo": "graphnode17", 
          "nodeFrom": "graphnode16", 
          "data": {}
        }
      ], 
      "data": {
        "$color": "#EBB056", 
        "$type": "circle"
      }, 
      "id": "graphnode16", 
      "name": "graphnode16"
    }, 
    {
      "adjacencies": [], 
      "data": {
        "$color": "#83548B", 
        "$type": "triangle"
      }, 
      "id": "graphnode17", 
      "name": "graphnode17"
    }, 
  ];
  // end
  // init ForceDirected
  // Fm var fd = new $jit.ForceDirected({
  fd = new $jit.ForceDirected({
    //id of the visualization container
    injectInto: 'infovis',
    //Enable zooming and panning
    //with scrolling and DnD
    Navigation: {
      enable: true,
      //Enable panning events only if we're dragging the empty
      //canvas (and not a node).
      panning: 'avoid nodes',
      zooming: 10 //zoom speed. higher is more sensible
    },
    // Change node and edge styles such as
    // color and width.
    // These properties are also set per node
    // with dollar prefixed data-properties in the
    // JSON structure.
    Node: {
      overridable: true,
      dim: 7
    },
    Edge: {
      overridable: true,
      color: '#23A4FF',
      lineWidth: 0.4
    },
    // Add node events
    Events: {
      enable: true,
      type: 'Native',
      //Change cursor style when hovering a node
      onMouseEnter: function() {
        fd.canvas.getElement().style.cursor = 'move';
      },
      onMouseLeave: function() {
        fd.canvas.getElement().style.cursor = '';
      },
      //Update node positions when dragged
      onDragMove: function(node, eventInfo, e) {
        var pos = eventInfo.getPos();
        node.pos.setc(pos.x, pos.y);
        fd.plot();
      },
      //Implement the same handler for touchscreens
      onTouchMove: function(node, eventInfo, e) {
        $jit.util.event.stop(e); //stop default touchmove event
        this.onDragMove(node, eventInfo, e);
      }
    },
    //Number of iterations for the FD algorithm
    iterations: 200,
    //Edge length
    levelDistance: 130,
    // This method is only triggered
    // on label creation and only for DOM labels (not native canvas ones).
    onCreateLabel: function(domElement, node){
      // Create a 'name' and 'close' buttons and add them
      // to the main node label
      var nameContainer = document.createElement('span'),
          closeButton = document.createElement('span'),
          style = nameContainer.style;
      nameContainer.className = 'name';
      nameContainer.innerHTML = node.name;
      closeButton.className = 'close';
      closeButton.innerHTML = 'x';
      domElement.appendChild(nameContainer);
      domElement.appendChild(closeButton);
      style.fontSize = "0.8em";
      style.color = "#ddd";
      //Fade the node and its connections when
      //clicking the close button
      closeButton.onclick = function() {
        node.setData('alpha', 0, 'end');
        node.eachAdjacency(function(adj) {
          adj.setData('alpha', 0, 'end');
        });
        fd.fx.animate({
          modes: ['node-property:alpha',
                  'edge-property:alpha'],
          duration: 500
        });
		
		// a real delete
		{ // fm begin 6/11/12
			//alert('line 551 ' + node.id);
			fd.graph.removeNode(node.id);
		} // fm end 6/11/12

      };
      //Toggle a node selection when clicking
      //its name. This is done by animating some
      //node styles like its dimension and the color
      //and lineWidth of its adjacencies.
      nameContainer.onclick = function() {
	  // fm begin 6/11/12
	  //alert('hi there dir gragph');
	  // fm end 6/11/12
	  
        //set final styles
        fd.graph.eachNode(function(n) {
		//alert('line 449');
          if(n.id != node.id) delete n.selected;
          n.setData('dim', 7, 'end');
          n.eachAdjacency(function(adj) {
            adj.setDataset('end', {
              lineWidth: 0.4,
              color: '#23a4ff'
            });
          });
        });
        if(!node.selected) {
		  //alert('line 578 ' + node.id);
          node.selected = true;
          node.setData('dim', 17, 'end');
          node.eachAdjacency(function(adj) {
            adj.setDataset('end', {
              lineWidth: 3,
              color: '#36acfb'
            });
          });
        } else {
		  //alert('line 588 ' + node.id);
          delete node.selected;
        }
        //trigger animation to final styles
        fd.fx.animate({
          modes: ['node-property:dim',
                  'edge-property:lineWidth:color'],
          duration: 500
        });
        // Build the right column relations list.
        // This is done by traversing the clicked node connections.
        var html = "<h4>" + node.name + "</h4><b> connections:</b><ul><li>",
            list = [];
        node.eachAdjacency(function(adj){
          if(adj.getData('alpha')) list.push(adj.nodeTo.name);
        });
        //append connections information
        $jit.id('inner-details').innerHTML = html + list.join("</li><li>") + "</li></ul>";
      };
    },
    // Change node styles when DOM labels are placed
    // or moved.
    onPlaceLabel: function(domElement, node){
      var style = domElement.style;
      var left = parseInt(style.left);
      var top = parseInt(style.top);
      var w = domElement.offsetWidth;
      style.left = (left - w / 2) + 'px';
      style.top = (top + 10) + 'px';
      style.display = '';
    }
  });
  // load JSON data.
  // begin fm
  //alert('line 514');
  //var pjson = eval('(' + json + ')');
  //var subtree = $jit.json.getSubtree(json, "graphnode0");
  //alert(json);
  //$jit.json.prune(json, 1);  
//alert(json);
//alert(json.toJSONString());
//console.log(json);
//alert(JSON.stringify(json));

//	console.log(JSON.stringify(json));
	
//$jit.json.prune(fd.tree, maxLevel);

//#$jit.json.prune(pjson, 5);
//#json = pjson;
//alert(pjson);

  //alert($jit.util.event.stop);
  //  $jit.prune(json, 6);
  //Log.write('json');
  // end fm
  //fd.loadJSON(json);
  fd.loadJSON(json);
  
  //$jit.json.prune(fd.tree, 3);
  //$jit.json.prune(fd.graph, 2);
  //alert(fd);
  //console.log(JSON.stringify(json));
	console.log(JSON.stringify(fd.tree)); //console.log(JSON.stringify(fd.graph));
	var jnode = $jit.json.getParent(fd.graph, "graphnode10");
	console.log (JSON.stringify(jnode));
	
	var node = fd.graph.getNode("graphnode10");
	//alert("FM  "+node.id);
	//alert(JSON.stringify(node));
	//alert(JSON.stringify(node) );
	
//alert(JSON.stringify(fd.toJSON('tree')) );
var bbb = fd.toJSON('tree');
//alert(bbb);
console.log (JSON.stringify(bbb));
  
  // compute positions incrementally and animate.
  fd.computeIncremental({
    iter: 40,
    property: 'end',
    onStep: function(perc){
      Log.write(perc + '% loaded...');
    },
    onComplete: function(){
      Log.write('done');
      fd.animate({
        modes: ['linear'],
        transition: $jit.Trans.Elastic.easeOut,
        duration: 2500
      });
    }
  });
  // end
}
