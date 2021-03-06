﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(3, 5);
	public bool standing;
	public float jetSpeed = 15f;
	public float airSpeedMultiplier = 0.3f;
	public AudioClip leftFootSound;
	public AudioClip rightFootSound;
	public AudioClip thudSound;
	public AudioClip rocketSound;

	private Animator animator;
	private PlayerController controller;
	private ParticleSystem childParticleSystem;

	void Start () {
		animator = GetComponent<Animator>();
		controller = GetComponent<PlayerController>();
		childParticleSystem = GetComponentInChildren<ParticleSystem>();
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
			// We're not moving horizontally.
			animator.SetInteger("AnimState", 0);
		} else {
			// We're moving horizontally.
			if (absVelocityX < maxVelocity.x) {
				// We haven't yet reached the horizontal speed limit.
				forceX = speed * controller.moving.x;

				if (!standing) {
					// We're moving horizontally while in the air, slow down.
					forceX *= airSpeedMultiplier;
				}

				// Face in the direction we're moving horizontally.
				transform.localScale = new Vector3(forceX > 0 ? 1 : -1, 1, 1);
			}

			animator.SetInteger("AnimState", 1);
		}

		if (controller.moving.y > 0) { 
			// We're using the jetpack.
			PlayRocketSound();

			if (absVelocityY < maxVelocity.y) {
				forceY = jetSpeed * controller.moving.y;
			}

			animator.SetInteger("AnimState", 2);
		} else if (absVelocityY > 0) {
			// We're not using the jetpack but we are in the air (probably falling).
			animator.SetInteger("AnimState", 3);
		}
		
		rigidbody2D.AddForce(new Vector2(forceX, forceY));
	}

	void OnCollisionEnter2D (Collision2D target) {
		if (!standing) {
			var absVelocityX = Mathf.Abs(rigidbody2D.velocity.x);
			var absVelocityY = Mathf.Abs(rigidbody2D.velocity.y);
			
			if (absVelocityX <= 0.1f || absVelocityY <= 0.1f) {
				if (thudSound) {
					AudioSource.PlayClipAtPoint(thudSound, transform.position);
				}
			}
		}
	}
	
	public void StartSpeedBoost (float factor, float duration) {
		speed *= factor;
		maxVelocity *= factor;
		
		childParticleSystem.Play();

		StartCoroutine(EndSpeedBoost(factor, duration));
	}

	public IEnumerator EndSpeedBoost (float factor, float duration) {
		yield return new WaitForSeconds(Mathf.Max(0f, duration));
		
		speed /= factor;
		maxVelocity /= factor;
		
		childParticleSystem.Stop();
	}

	void PlayLeftFootSound () {
		if (leftFootSound) {
			AudioSource.PlayClipAtPoint(leftFootSound, transform.position);
		}
	}
	
	void PlayRightFootSound () {
		if (rightFootSound) {
			AudioSource.PlayClipAtPoint(rightFootSound, transform.position);
		}
	}
	
	void PlayRocketSound () {
		if (!rocketSound || GameObject.Find("RocketSound")) { return; }

		GameObject rocketSoundGameObj = new GameObject("RocketSound");
		AudioSource aSrc = rocketSoundGameObj.AddComponent<AudioSource>();
		aSrc.clip = rocketSound;
		aSrc.volume = 0.7f;
		aSrc.Play();

		Destroy(rocketSoundGameObj, rocketSound.length);
	}
}
