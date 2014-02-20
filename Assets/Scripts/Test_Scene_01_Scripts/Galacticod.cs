using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Leap;

/*

this is the main code to control our fish, Galacticod

*/

public class Galacticod : MonoBehaviour {
	
	
	// Galacticod vars (user)
	CharacterController cc;
	GameObject galacticod;
	public float MOVEMENT_SPEED = 0.4f;
	
	
	//Movment vectors
	private Vector3 forward;
	private Vector3 backwards;
	private Vector3 up;
	private Vector3 down;
	//	public Vector3 side;
	public Vector3 position;
	public Vector3 acceleration;
	public Vector3 velocity;
	
	
	// LEAP vars
	Controller controller;
	public int numHands = 0;
	
	public string location;

	public int swipeCounter;
	
	
	
	
	// Use this for initialization
	void Start () 
	{
		// GALACTICOD ENGAGE
		galacticod = GameObject.Find("galacticod");
		cc = galacticod.GetComponent<CharacterController> ();
		
		
		// set up LEAP gestures
		controller = new Controller();
		controller.EnableGesture (Gesture.GestureType.TYPESWIPE);
		controller.Config.SetFloat("Gesture.Swipe.MinVelocity", 5000f);
		controller.Config.SetFloat("Gesture.Swipe.MinLength", 100f);
		controller.Config.Save();
		
		// setup movement vectors
		forward = new Vector3(0, 0, MOVEMENT_SPEED);
		backwards = Vector3.back * MOVEMENT_SPEED;
		up = new Vector3 (0, MOVEMENT_SPEED, 0);
		down = new Vector3 (0, -MOVEMENT_SPEED, 0);

		location = "area1";
		Debug.Log (location);

		swipeCounter = 0;
		Debug.Log (swipeCounter);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// WASD controls for debugging
		ProccessInput();


		
		Frame frame = controller.Frame();
		//Debug.Log ("Frame id: "+ frame.Id + "timestamp: "+frame.Timestamp+"Hands: "+frame.Hands.Count+"fingers: "+frame.Fingers.Count+"tools: "+frame.Tools.Count);
		
		//		forwardSwim.Normalize();
		//		forwardSwim *= codSpeed;
		//
//		if(frame.Fingers.Count > 2){
//			cc.Move(forwardSwim*Time.deltaTime);
//			Debug.Log (frame.Hands [0].PalmPosition);
		if(frame.Hands.Count == 1){
			if (frame.Hands [0].PalmPosition.x < -50) {
				Debug.Log("LEFt");
				transform.Rotate(0,(-MOVEMENT_SPEED/2), 0);
			}
			if (frame.Hands [0].PalmPosition.x > 50) {
				Debug.Log("RIGHT");
				transform.Rotate(0,(MOVEMENT_SPEED/2),0);
			}
		}




		
		// Get gestures
		GestureList gestures = frame.Gestures ();
		for (int i = 0; i < gestures.Count; i++) {
			Gesture gesture = gestures [i];
			
			switch (gesture.Type) {
				//		    case Gesture.GestureType.TYPECIRCLE:
				//		        CircleGesture circle = new CircleGesture (gesture);
				//
				//		            // Calculate clock direction using the angle between circle normal and pointable
				//		        String clockwiseness;
				//		        if (circle.Pointable.Direction.AngleTo (circle.Normal) <= Math.PI / 4) {
				//		            //Clockwise if angle is less than 90 degrees
				//		            clockwiseness = "clockwise";
				//		        } else {
				//		            clockwiseness = "counterclockwise";
				//		        }
				//
				//		        float sweptAngle = 0;
				//
				//		            // Calculate angle swept since last frame
				//		        if (circle.State != Gesture.GestureState.STATESTART) {
				//		            CircleGesture previousUpdate = new CircleGesture (controller.Frame (1).Gesture (circle.Id));
				//		            sweptAngle = (circle.Progress - previousUpdate.Progress) * 360;
				//		        }
				//
				//		        SafeWriteLine ("Circle id: " + circle.Id
				//		                       + ", " + circle.State
				//		                       + ", progress: " + circle.Progress
				//		                       + ", radius: " + circle.Radius
				//		                       + ", angle: " + sweptAngle
				//		                       + ", " + clockwiseness);
				//		        break;
			case Gesture.GestureType.TYPESWIPE:
				SwipeGesture swipe = new SwipeGesture (gesture);
				swipeCounter++;
				transform.Translate(forward);
				//				cc.Move(forwardSwim*Time.deltaTime);
				Debug.Log ("Swipe id: " + swipe.Id
				           + ", " + swipe.State
				           + ", position: " + swipe.Position
				           + ", direction: " + swipe.Direction
				           + ", speed: " + swipe.Speed);
				break;
				//		    case Gesture.GestureType.TYPEKEYTAP:
				//		        KeyTapGesture keytap = new KeyTapGesture (gesture);
				//		        SafeWriteLine ("Tap id: " + keytap.Id
				//		                       + ", " + keytap.State
				//		                       + ", position: " + keytap.Position
				//		                       + ", direction: " + keytap.Direction);
				//		        break;
				//		    case Gesture.GestureType.TYPESCREENTAP:
				//		        ScreenTapGesture screentap = new ScreenTapGesture (gesture);
				//		        SafeWriteLine ("Tap id: " + screentap.Id
				//		                       + ", " + screentap.State
				//		                       + ", position: " + screentap.Position
				//		                       + ", direction: " + screentap.Direction);
				//		        break;
			default:
				Debug.Log ("Unknown gesture type.");
				break;
			}
		}
		
		// log out the stuff
//		Debug.Log ("Gesture count: "+swipeCounter);
		
	}
	
	
	/// <summary>
	/// Checks for user input
	/// </summary>
	private void ProccessInput()
	{
		//forward
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(forward);
		}

		// right
		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(0,(MOVEMENT_SPEED/2),0);
		}
		// left
		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(0,(-MOVEMENT_SPEED/2), 0);
		}


		// up
		if (Input.GetKey ("up"))
		{
			transform.Translate(up);
		}
		// down
		if (Input.GetKey ("down"))
		{
			transform.Translate(down);
		}
		
		
	}
	
	
	
}