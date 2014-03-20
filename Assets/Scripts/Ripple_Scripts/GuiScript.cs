using UnityEngine;
using System.Collections;

public class GuiScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}
	
	// Called once per frame
	void OnGUI()
	{
		// Create a box
//		GUI.Box(new Rect(20, 20, 160, 175), "Ripple");
		GUI.Box(new Rect(20, 20, 200, 175), "GALACTICOD");
		
		// Create health label
//		GUI.Label(new Rect(35, 40, 200, 100), "Ripple - New Media Team Project 2014");
//		
		// location
		GUI.Label(new Rect(35, 60, 150, 100), "Location: 1 - start");
//		Debug.Log (Galacticod.location);
//		
//		// # barrels lit
//		GUI.Label(new Rect(35, 80, 150, 100), "# of Barrels lit: " + GameScript.NUM_OF_BARRELS);
//		
//		// # of SF killed
//		GUI.Label(new Rect(35, 100, 150, 100), "# of Strange Folk destroyed: " + GameScript.NUM_OF_FOLK);
//		
//		// to INFORM the user
//		GUI.Label(new Rect(35, 140, 200, 100), text);
		
//		// footer
//		GUI.Label(new Rect(35, 150, 200, 100), "Ripple");
		GUI.Label(new Rect(35, 170, 200, 100), "New Media Team Project 2014");
	}
}