using UnityEngine;
using System.Collections;

public class Real_Swim : MonoBehaviour {
	
	GameObject clownFish;
	//CharacterController cc;
	public Rigidbody body;
	Vector3 velocity, acceleration, direction, friction;
	public float turnSpeed, maxSpeed, maxForce, mass, accelerationMag, frictionMag;
	
	// Use this for initialization
	void Start () {
		
		// Set up reference to clown fish game object and it's
		// rigidbody (for movement)
		clownFish = GameObject.Find("Clown_Fish_Character");
		body = clownFish.GetComponent<Rigidbody>();
		
		// Set up vector movement variables
		velocity = Vector3.zero;
		direction = transform.forward;
		friction = velocity*-1;
		acceleration = Vector3.zero;
		turnSpeed = 5.0f;
		maxSpeed = 20.0f;
		maxForce = 10.0f;
		mass = 10.0f;
		accelerationMag = 10.0f;
		frictionMag = 5.0f;
		
	}
	
	void FixedUpdate(){
		
		//body.AddForce(transform.forward*1000, ForceMode.Force);
		
		//Debug.Log("Fish Velocity: "+body.velocity);

		if (Input.GetKey(KeyCode.W))
		{
			body.AddForce(transform.forward * 1000, ForceMode.Acceleration);
		}
		body.drag = 20;
		
	}
	
	// Update is called once per frame
	void Update () {





		
	}


}
