using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Leap;

public class GameManager : MonoBehaviour {

	CharacterController cc;
	Controller controller;
	GameObject galacticod;
	public int numHands = 0;
	public float codSpeed = 10f;
	public Vector3 forwardSwim;

	// Use this for initialization
	void Start () {

		controller = new Controller();

		galacticod = GameObject.Find("galacticod");
		cc = galacticod.GetComponent<CharacterController> ();

		forwardSwim = galacticod.transform.forward;
	}

	void Update () {

		Frame frame = controller.Frame();
		Debug.Log ("Frame id: "+ frame.Id + "timestamp: "+frame.Timestamp+"Hands: "+frame.Hands.Count+"fingers: "+frame.Fingers.Count+"tools: "+frame.Tools.Count);

		forwardSwim.Normalize();
		forwardSwim *= codSpeed;

		if(frame.Fingers.Count > 2){
			cc.Move(forwardSwim*Time.deltaTime);
		}

	}

}
