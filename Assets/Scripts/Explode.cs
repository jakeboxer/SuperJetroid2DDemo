using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
	public BodyPart bodyPart;
	public int totalParts = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D target) {
		if (target.gameObject.tag == "Deadly") {
			OnExplode();
		}
	}
	
	void OnCollisionEnter2D (Collision2D target) {
		if (target.gameObject.tag == "Deadly") {
			OnExplode();
		}
	}

	public void OnExplode () {
		Destroy(gameObject);

		var t = transform;

		for (int i = 0; i < totalParts; i++) {
			t.TransformPoint(0, -100, 0);
			BodyPart clone = Instantiate(bodyPart, t.position, Quaternion.identity) as BodyPart;
			clone.rigidbody2D.AddForce(Vector3.right * Random.Range(-50, 50));
			clone.rigidbody2D.AddForce(Vector3.up * Random.Range(100, 400));
		}

		GameObject clickToContinueObj = new GameObject("ClickToContinue");
		ClickToContinue script = clickToContinueObj.AddComponent<ClickToContinue>();
		script.sceneName = Application.loadedLevelName;
	}
}
