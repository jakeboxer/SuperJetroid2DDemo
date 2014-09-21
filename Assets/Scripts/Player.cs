using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(3, 5);
	public bool standing;
	public float jetSpeed = 15f;
	public float airSpeedMultiplier = 0.3f;

	private Animator animator;
	private PlayerController controller;

	void Start () {
		animator = GetComponent<Animator>();
		controller = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		var forceX = 0f;
		var forceY = 0f;
		
		var absVelocityX = Mathf.Abs(rigidbody2D.velocity.x);
		var absVelocityY = Mathf.Abs(rigidbody2D.velocity.y);

		if (absVelocityY < 0.2f) {
			standing = true;
		} else {
			standing = false;
		}

		if (controller.moving.x == 0) {
			animator.SetInteger("AnimState", 0);
		} else {
			if (absVelocityX < maxVelocity.x) {
				forceX = speed * controller.moving.x;

				// Less horizontal force when the player in the air.
				if (!standing) {
					forceX *= airSpeedMultiplier;
				}

				transform.localScale = new Vector3(forceX > 0 ? 1 : -1, 1, 1);
			}

			animator.SetInteger("AnimState", 1);
		}

		if (controller.moving.y > 0) {
			if (absVelocityY < maxVelocity.y) {
				forceY = jetSpeed * controller.moving.y;
			}
		}
		
		rigidbody2D.AddForce(new Vector2(forceX, forceY));
	}
}
