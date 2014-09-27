using UnityEngine;
using System.Collections;

public class SpeedBoost : Boost {
	public float duration = 5f;
	public float factor = 2f;

	private Player player;

	// Use this for initialization
	void Start () {
		player = (GameObject.FindWithTag("Player")).GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnBoost () {
		player.speed *= factor;
		player.maxVelocity *= factor;

		StartCoroutine(EndSpeedBoost());
	}

	private IEnumerator EndSpeedBoost () {
		yield return new WaitForSeconds(duration);

		player.speed /= factor;
		player.maxVelocity /= factor;
	}
}
