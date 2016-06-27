//--- The gameTimer object
var gameTimer =
{
  time: 0,
  interval: undefined,

  start: function()
  {
    var self = this;
	  this.interval = setInterval(function(){self.tick();}, 1000);
  },
  tick: function()
  {
    this.time--;
  },
  stop: function()
  {
    clearInterval(this.interval);
  },
  reset: function()
  {
    this.time = 0;
  }
};

//--- The smurf object
var smurf =
{
  //The size of each frame on the tile sheet
  //and the tile sheet's number of columns
  IMAGE: "smurf_sprite.png",
  SIZE: 128,
  COLUMNS: 4,
  
  //The numbers of the animation frames and the starting frame
  numberOfFrames: 15,
  currentFrame: 0,
  
  //Properties of the animation frames's x and
  //y positions on the tile sheet.
  //They're 0 when this object first loads
  sourceX: 0,
  sourceY: 0,
  sourceWidth: 128,
  sourceHeight: 128,
  x: 0,
  y: 0,
  width: 128,
  height: 128,
   
  //A property to control the loop  
  forward: true,
  
  //States
  HIDING: 0,
  JUMPING: 1,
  HIT: 2,
  state: this.HIDING,
  
  //Properties needed to help reset the animation
  timeToReset: 9,
  resetCounter: 0,
  
  //A property to store the random time
  waitTime: undefined,
  
  //The smurf's updateAnimation method
  updateAnimation: function()
  {  
    this.sourceX = Math.floor(this.currentFrame % this.COLUMNS) * this.SIZE;
    this.sourceY = Math.floor(this.currentFrame / this.COLUMNS) * this.SIZE;
    this.state = this.JUMPING;
    
    //Change the behaviour of the animation based on the state
    switch(this.state)
    {
      case this.HIDING:
        this.currentFrame = 0;
        this.waitTime--;
        break;
        
      case this.JUMPING:
        //If the last frame has been reached, set forward to false
   	  if(this.currentFrame === this.numberOfFrames)
        {
          this.forward = false;
        }

        //If the first frame has been reached, set forward to true
        if(this.currentFrame === 0 && this.forward === false)
        {
          //Set forward to true, 
          //set the state to HIDING and break the switch statement
          this.forward = true;
          this.state = this.HIDING;
          break;
        }

        //Add 1 to currentFrame if forward is true, subtract 1 if it's false
    	  if(this.forward)
      	{
      	  this.currentFrame++;
      	}
      	else
      	{
      	  this.currentFrame--;
      	}
      	break;
    }
  }
};

//--- The main program

//Load the animation tile sheet
var image = new Image();
image.addEventListener("load", loadHandler, false);
image.src = smurf.IMAGE;

var SIZE = smurf.SIZE * 8;

//Arrays for the smurfs, their canvases  
//and their drawing surfaces
var smurfObjects = [];
var smurfCanvases = [];
var smurfDrawingSurfaces = [];

//An array to store the move
var move = [];

//Create the move.
var move = Object.create(smurf);
move.x = 0;
move.y = 0;
move.y = canvas.height / 2 - move.height / 2;
move.x = canvas.width / 2 - move.width / 2;
move.push(move);

function loadHandler()
{ 
  //Plot the grid of smurfs
  buildMap();
  
  //Start the animation loop
  updateAnimation();
}

function buildMap()
{
     
      //Create a single new smurf object,
      var newsmurfObject = Object.create(smurf);
      smurfObjects.push(newsmurfObject);
      
      //Create a canvas tag for smurf 
      var canvas = document.createElement("canvas");
      canvas.setAttribute("width", SIZE);
      canvas.setAttribute("height", SIZE);
      stage.appendChild(canvas);
  	  canvas.style.top = 0 + "px";
      canvas.style.left = 0 + "px";
      smurfCanvases.push(canvas);
      
      //Create a drawing surface 
      var drawingSurface = canvas.getContext("2d");
      smurfDrawingSurfaces.push(drawingSurface);
}

function updateAnimation()
{ 
  //Call updateAnimation every 40 milliseconds
    setTimeout(updateAnimation, 40);
  
  //Loop through the smurfs in
  //the smurfs array and call the
  //updateAnimation methods
  for(var i = 0; i < smurfObjects.length; i++)
  {
    smurfObjects[i].updateAnimation();
  }
	move.width = move.x++;    
  
    //Stop the smurf at the canvas edges
  if (move.x + move.width > SIZE)
  {
    move.x = SIZE - move.width;
  }
  //Render the animation
  render();
}

function render()
{
  for(var i = 0; i < smurfObjects.length; i++)
  { 
    //Get reference to the smurf and drawing surface
    var smurf = smurfObjects[i];
    var drawingSurface = smurfDrawingSurfaces[i];
      
    //Clear the smurf's canvas
    drawingSurface.clearRect(0, 0, SIZE, SIZE);
    
    //Draw the smurf's animation frame 
    drawingSurface.drawImage
    (
      image, 
	  smurf.sourceX, smurf.sourceY, 128, 128, 
      Math.floor(move.x), 0, 128, 128
    );
  }
}
