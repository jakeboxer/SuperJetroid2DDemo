using UnityEngine;
using System.Collections;

public class DisplayRestartText : MonoBehaviour {
	private Texture2D texture;

	// Use this for initialization
	void Start () {
		texture = Resources.Load<Texture2D>("restart-text");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		var x = (Screen.width - texture.width) / 2;
		var y = Screen.height - 50;

		if (Time.time % 2 > 1) {
			GUI.DrawTexture(new Rect(x, y, texture.width, texture.height), texture);
		}
	}
}
