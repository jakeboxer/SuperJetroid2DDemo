using UnityEngine;
using System.Collections;

public class Meter : MonoBehaviour {
	public float air = 10f;
	public float maxAir = 10f;
	public float airBurnRate = 1f;

	private Player player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!player) { return; }

		if (air > 0) {
			air -= Time.deltaTime * airBurnRate;
		} else {
			Explode script = player.GetComponent<Explode>();
			script.OnExplode();
		}
	}
}
