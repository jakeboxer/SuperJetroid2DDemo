using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	private bool destroyDuringUpdate = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (destroyDuringUpdate) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D target) {
		destroyDuringUpdate = true;
	}
}
