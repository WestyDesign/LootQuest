# region 'Using' information
using UnityEngine;
using System.Collections;
#endregion

// Using this tutorial: https://youtu.be/jWPkVxz79CI

public class DoorTrigger : MonoBehaviour 
{
	public DoorScript door;
	public bool ignoreTrigger;

	void OnTriggerEnter2D(Collider2D other)
    {
		if (ignoreTrigger) return;
		if (other.tag == "Player") {door.DoorOpens (); }
	}

	void OnTriggerExit2D(Collider2D other){

		if (ignoreTrigger) return;

		if (other.tag == "Player") { door.DoorCloses(); }		
	}

	public void Toggle(bool state)
	{
		if (state) { door.DoorOpens (); }
		else { door.DoorCloses (); }
	}

	void OnDrawGizmos()
	{
		if (!ignoreTrigger) 
        {
			BoxCollider2D box = GetComponent<BoxCollider2D>();
			Gizmos.DrawWireCube(transform.position, new Vector2(box.size.x,box.size.y));
		}
	}
}