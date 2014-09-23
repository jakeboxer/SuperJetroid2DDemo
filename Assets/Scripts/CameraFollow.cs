using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public GameObject target;

	private Transform _t;

	void Awake () {
		// 100f represents pixel ratio (all our pixel art is 100px to 1 unit in Unity).
		camera.orthographicSize = ((Screen.height / 2.0f) / 100f);
	}

	// Use this for initialization
	void Start () {
		_t = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(_t.position.x, _t.position.y, transform.position.z);
	}
}
