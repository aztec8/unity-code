﻿using UnityEngine;
using System.Collections;

public class SphereTrigger : MonoBehaviour {

	//*****Objects that will refer to/store instance names of things that have triggers
	SphereTrigger sphereWorldOneObj;

	// Pollution triggers
	SphereTrigger marineDebris;
	SphereTrigger shippingAccidents;
	SphereTrigger oilSpills;
	SphereTrigger algae;

	// Acidification triggers
	SphereTrigger fossilFuels;
	SphereTrigger weakShells;
	SphereTrigger whaleBones;

	// Overfishing triggers
	SphereTrigger bycatch;
	SphereTrigger population;
	SphereTrigger trawling;

	// setting each string manually in the Inspector
	// ... maybe there's a better way to go about it
	public string fact;


	// Use this for initialization
	void Start () {
		Debug.Log("Sphere Trigger Script");
		//*****Getting instance names of sphere objects
		sphereWorldOneObj = GameObject.Find("sphereWorldOne").GetComponent<SphereTrigger>();

		// set polution triggers
		marineDebris = GameObject.Find ("marineDebris_trigger").GetComponent<SphereTrigger> ();
//		shippingAccidents = GameObject.Find ("shippingAccidents_trigger").GetComponent<SphereTrigger> ();
//		oilSpills = GameObject.Find ("oilSpills_trigger").GetComponent<SphereTrigger> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider objectThatWasHit)
	{
		Debug.Log(fact);

		//*****The objectThatWasHit is what triggers the collision, this is the galacticod fish
		//*****"this" tells me what is the thing that has been triggered
		//*****If what has been triggered is equal to a specific sphere object, do w/e
//		Debug.Log("Shit went down. The object that was hit is: " + objectThatWasHit +" What is being hit: " + this);
		if (this == sphereWorldOneObj) 
		{

//			Debug.Log("I'm in Sphere World One "  + this);
			//*****if the audio is not playing and a collion occurs, play the audio
			if(!audio.isPlaying)
			{
				audio.Play();
			}
		}

//		if(this == marineDebris)
//		{
//
//		}

//		if (this == sphereWorldTwoObj) 
//		{
//			Debug.Log("I'm in Sphere World Two "  + this);
//			//GUI.Label(new Rect(35, 60, 150, 100), "Location: 2");
//
//			//*****if the audio is not playing and a collion occurs, play the audio
//			if(!audio.isPlaying)
//			{
//				audio.Play();
//			}
//		}

	}

}
