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

	public void Toggle (bool value) {
		if (value) {
			door.Open();
		} else {
			door.Close();
		}
	}
}
