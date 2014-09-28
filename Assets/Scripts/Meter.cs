using UnityEngine;
using System.Collections;

public class Meter : MonoBehaviour {
	public float air = 30f;
	public float maxAir = 30f;
	public float airBurnRate = 1f;
	public Texture2D bgTexture;
	public Texture2D airBarTexture;
	public int iconWidth = 32;
	public Vector2 airOffset = new Vector2(10, 10);

	private Player player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<Player>();
	}

	void OnGUI () {
		float percent;

		if (player) {
			percent = Mathf.Clamp01(air / maxAir);
		} else {
			percent = 0f;
		}

		DrawMeter(airOffset.x, airOffset.y, airBarTexture, bgTexture, percent);
	}

	void DrawMeter (float x, float y, Texture2D foreground, Texture2D background, float percent) {
		var bgWidth = background.width;
		var bgHeight = background.height;

		GUI.DrawTexture(new Rect(x, y, bgWidth, bgHeight), background);

		var fgWidth = ((bgWidth - iconWidth) * percent) + iconWidth;
		GUI.BeginGroup(new Rect(x, y, fgWidth, bgHeight));
		GUI.DrawTexture(new Rect(0, 0, bgWidth, bgHeight), foreground);
		GUI.EndGroup();
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

	public void AddAir(float airAmount) {
		air = Mathf.Min(air + airAmount, maxAir);
	}
}
