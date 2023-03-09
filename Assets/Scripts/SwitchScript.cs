# region 'Using' information
using UnityEngine;
using System.Collections;
#endregion

// Using this tutorial: https://youtu.be/jWPkVxz79CI

public class SwitchScript : MonoBehaviour 
{
	public DoorTrigger[] doorTrig;
	Animator anim; // plays the animation of the button being up or down
	public bool sticks; // if triggered, the button only needs to be pressed once & will 'stick' down
	private AudioSource pressSound;

	void Start () 
    { 
		anim = GetComponent<Animator> ();
		pressSound = GetComponent<AudioSource>();
	}
	
	void OnTriggerStay2D() // when player stands on button
	{
		anim.SetBool ("goDown", true); // plays button's 'pressed' animation

		foreach (DoorTrigger trigger in doorTrig) { trigger.Toggle(true); } // disables collision when on button
	}

	void OnTriggerExit2D() // when player gets off button
	{
		if(sticks) { return; }	// if it's a button that doesn't need to be constantly stood on, rest of code is ignored

		anim.SetBool ("goDown", false); // plays button's 'idle' animation

		foreach (DoorTrigger trigger in doorTrig) { trigger.Toggle(false); } // re-enables collisions after getting off the button
	}

	void OnDrawGizmos() // shows how the buttons / doors link up if there's multiple
	{
		Gizmos.color = Color.cyan;

		foreach (DoorTrigger trigger in doorTrig) 
        { Gizmos.DrawLine(transform.position,trigger.transform.position); }
	}
}