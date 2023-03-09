# region 'Using' information
using UnityEngine;
using System.Collections;
#endregion

// Using this tutorial: https://youtu.be/jWPkVxz79CI

public class DoorScript : MonoBehaviour 
{
	Animator anim;

	void Start () 
    { anim = GetComponent<Animator> (); }

	public void DoorOpens()
	{ 
        anim.SetBool ("Opens", true);
        CollDisable();
    }

	public void DoorCloses()
	{ 
        anim.SetBool ("Opens", false);
        CollEnable();
    }

	void CollEnable()
	{ GetComponent<BoxCollider2D>().enabled = true; }

	void CollDisable()
	{ GetComponent<BoxCollider2D>().enabled = false; }
}