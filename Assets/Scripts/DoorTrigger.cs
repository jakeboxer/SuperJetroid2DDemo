using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {
	public Door door;
	public bool ignoreTrigger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D target) {
		if (ignoreTrigger) { return; }

		if (target.gameObject.tag == "Player") {
			door.Open();
		}
	}
	
	void OnTriggerExit2D (Collider2D target) {
		if (ignoreTrigger) { return; }

		if (target.gameObject.tag == "Player") {
			door.Close();
		}
	}

	void OnDrawGizmos () {
		Gizmos.color = ignoreTrigger ? Color.gray : Color.green;

		var collider = GetComponent<BoxCollider2D>();
		var colliderPosition = collider.transform.position;
		var newPosition = new Vector2(colliderPosition.x + collider.center.x, colliderPosition.y + collider.center.y);
		Gizmos.DrawWireCube(newPosition, new Vector2(collider.size.x, collider.size.y));
	}

	public void Toggle (bool value) {
		if (value) {
			door.Open();
		} else {
			door.Close();
		}
	}
}
