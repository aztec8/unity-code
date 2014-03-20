using UnityEngine;
using System.Collections;

public class Clown_Fish_Swim : MonoBehaviour {

	GameObject clownFish;
	CharacterController cc;
	Vector3 velocity, acceleration, direction, friction;
	public float turnSpeed, maxSpeed, VEL, ACC, DRAG;

	// Use this for initialization
	void Start () {

		// Set up reference to clown fish game object and it's
		// character controller (for movement)
		clownFish = GameObject.Find("Clown_Fish_Character");
		cc = clownFish.GetComponent<CharacterController>();

		// Set up movement variables
		turnSpeed = 5.0f;
		maxSpeed = 20.0f;
		VEL = 0.0f;
		ACC = 0.0f;
		DRAG = 0.2f;
	}

	// Update is called once per frame
	void Update () {

		//add to acceleration if forward movement key is being held
		if (Input.GetKey(KeyCode.W))
		{
			ACC += 1.0f;
		}

		//get input from other movement keys
		processInput();

		//update velocity
		VEL += ACC;

		//limit speed
		if(VEL > maxSpeed){
			VEL = maxSpeed;
		}

		//if velocity is greater than 0, apply drag force (decrement velocity),
		//otherwise, set velocity = 0
		if(VEL > 0){
			VEL -= DRAG;
		}
		else{
			VEL = 0;
		}

		Debug.Log("velocity = " + VEL);

		// Move fish by multiplying velocity float by fish's forward facing normalized vector
		cc.Move(transform.forward*VEL * Time.deltaTime);

		//reset acceleration
		ACC = 0.0f;
	
	}


	void processInput(){

		//forward

		
		// right
		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(0,(turnSpeed/2),0,Space.World);
			
		}
		// left
		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(0,(-turnSpeed/2), 0,Space.World);
		}		
		
		// up
		if (Input.GetKey ("up"))
		{
			transform.Rotate(Vector3.left*turnSpeed/2,Space.Self);
		}
		// down
		if (Input.GetKey ("down"))
		{

			transform.Rotate(Vector3.right*turnSpeed/2,Space.Self);
		}
	}
}
