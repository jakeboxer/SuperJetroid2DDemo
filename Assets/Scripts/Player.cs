using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(3, 5);
	
	// Update is called once per frame
	void Update () {
		var forceX = 0f;
		var forceY = 0f;

		var absVelocityX = Mathf.Abs(rigidbody2D.velocity.x);

		if (Input.GetKey("right")) {
			if (absVelocityX < maxVelocity.x) {
				forceX = speed;
			}
		} else if (Input.GetKey("left")) {
			if (absVelocityX < maxVelocity.x) {
				forceX = -speed;
			}
		}

		rigidbody2D.AddForce(new Vector2(forceX, forceY));
	}
}
