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
	public float TURN_SPEED = 3.0f;
		
	//Movment vectors
	public Vector3 position;
	private Vector3 forward;
	private Vector3 up;
	private Vector3 down;
	public float velocity = 0.05f;

	// LEAP vars
	Controller controller;
	public int numHands = 0;
	public string location;
	public int swipeCounter;

	// Rotation shitttt

	
	
	
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
		// just keep swimming
		GoForward(false);


		//Debug.Log ("Position: " + galacticod.transform.position + " | " +
		  //         "Velocity: " + velocity);


		// WASD controls for debugging
		ProccessInput();


		// LEAP detection
		Frame frame = controller.Frame();
		//Debug.Log ("Frame id: "+ frame.Id + "timestamp: "+frame.Timestamp+"Hands: "+frame.Hands.Count+"fingers: "+frame.Fingers.Count+"tools: "+frame.Tools.Count);

		if(frame.Hands.Count == 1){
			Hand hand = frame.Hands[0];
			if (hand.PalmPosition.y < 100) { TurnLeft(); }
			if (hand.PalmPosition.y > 200) { TurnRight(); }
			if (hand.PalmPosition.x > 100) { GoDown(); }
			if (hand.PalmPosition.x < -100) { GoUp(); }
		}

		
		// Get gestures
		GestureList gestures = frame.Gestures ();
		for (int i = 0; i < gestures.Count; i++) {
			Gesture gesture = gestures [i];
			// if (gesture.Type == Gesture.GestureType.TYPESWIPE) {}
			switch (gesture.Type) {
				case Gesture.GestureType.TYPESWIPE:
					SwipeGesture swipe = new SwipeGesture (gesture);
					swipeCounter++;
					GoForward(true);
;//					transform.Translate(forward);
					//				cc.Move(forwardSwim*Time.deltaTime);
					Debug.Log ("Swipe id: " + swipe.Id
					           + ", " + swipe.State
					           + ", position: " + swipe.Position
					           + ", direction: " + swipe.Direction
					           + ", speed: " + swipe.Speed);
					break;
				default:
					Debug.Log ("Unknown gesture type.");
					break;
			}
		}

	}
	
	
	/// <summary>
	/// Checks for user input
	/// </summary>
	private void ProccessInput()
	{
		// keyboard input
		if (Input.GetKey(KeyCode.W)) { GoForward(true); }	// forward
		if (Input.GetKey(KeyCode.D)) { TurnRight(); }	// right
		if (Input.GetKey(KeyCode.A)) { TurnLeft(); }	// left
		if (Input.GetKey ("up")) { GoUp(); }			// up
		if (Input.GetKey ("down")) { GoDown(); }		// down
		
	}


	// Movement Functions
	private void GoForward(bool faster) {
		// adjust fish velocity
		if (faster) velocity+= 0.02f; // for swipes and 'W'
		else velocity -= 0.006f;

		// speed limits
		if (velocity < 0.05f) velocity = 0.05f; // maintain minimum speed
		if (velocity > 1.0f) velocity = 1.0f;	// max speed increase

		transform.Translate (Vector3.forward * velocity);
	}
	private void TurnLeft(){
		transform.Rotate(0,(-TURN_SPEED/2), 0, Space.World);
	}
	private void TurnRight(){
		transform.Rotate(0,(TURN_SPEED/2),0, Space.World);
	}

	private void GoUp() {
		transform.Rotate((-TURN_SPEED/2), 0, 0, Space.Self );
//		transform.Translate(up);
	}
	private void GoDown() {
		transform.Rotate((TURN_SPEED/2), 0, 0, Space.Self );
//		transform.Translate(down);
	}


// Example code for LEAP gestures
//
//	// Get gestures
//	GestureList gestures = frame.Gestures ();
//	for (int i = 0; i < gestures.Count; i++) {
//		Gesture gesture = gestures [i];
//		
//		switch (gesture.Type) {
//			//		    case Gesture.GestureType.TYPECIRCLE:
//			//		        CircleGesture circle = new CircleGesture (gesture);
//			//
//			//		            // Calculate clock direction using the angle between circle normal and pointable
//			//		        String clockwiseness;
//			//		        if (circle.Pointable.Direction.AngleTo (circle.Normal) <= Math.PI / 4) {
//			//		            //Clockwise if angle is less than 90 degrees
//			//		            clockwiseness = "clockwise";
//			//		        } else {
//			//		            clockwiseness = "counterclockwise";
//			//		        }
//			//
//			//		        float sweptAngle = 0;
//			//
//			//		            // Calculate angle swept since last frame
//			//		        if (circle.State != Gesture.GestureState.STATESTART) {
//			//		            CircleGesture previousUpdate = new CircleGesture (controller.Frame (1).Gesture (circle.Id));
//			//		            sweptAngle = (circle.Progress - previousUpdate.Progress) * 360;
//			//		        }
//			//
//			//		        SafeWriteLine ("Circle id: " + circle.Id
//			//		                       + ", " + circle.State
//			//		                       + ", progress: " + circle.Progress
//			//		                       + ", radius: " + circle.Radius
//			//		                       + ", angle: " + sweptAngle
//			//		                       + ", " + clockwiseness);
//			//		        break;
//		case Gesture.GestureType.TYPESWIPE:
//			SwipeGesture swipe = new SwipeGesture (gesture);
//			swipeCounter++;
//			transform.Translate(forward);
//			//				cc.Move(forwardSwim*Time.deltaTime);
//			Debug.Log ("Swipe id: " + swipe.Id
//			           + ", " + swipe.State
//			           + ", position: " + swipe.Position
//			           + ", direction: " + swipe.Direction
//			           + ", speed: " + swipe.Speed);
//			break;
//			//		    case Gesture.GestureType.TYPEKEYTAP:
//			//		        KeyTapGesture keytap = new KeyTapGesture (gesture);
//			//		        SafeWriteLine ("Tap id: " + keytap.Id
//			//		                       + ", " + keytap.State
//			//		                       + ", position: " + keytap.Position
//			//		                       + ", direction: " + keytap.Direction);
//			//		        break;
//			//		    case Gesture.GestureType.TYPESCREENTAP:
//			//		        ScreenTapGesture screentap = new ScreenTapGesture (gesture);
//			//		        SafeWriteLine ("Tap id: " + screentap.Id
//			//		                       + ", " + screentap.State
//			//		                       + ", position: " + screentap.Position
//			//		                       + ", direction: " + screentap.Direction);
//			//		        break;
//		default:
//			Debug.Log ("Unknown gesture type.");
//			break;
//		}
//	}
	
}