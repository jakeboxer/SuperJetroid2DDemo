using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour {
	public Sprite[] sprites;
	public string resourceName;
	public int currentSpriteIndex = -1;

	// Use this for initialization
	void Start () {
		if (resourceName != "") {
			sprites = Resources.LoadAll<Sprite>(resourceName);

			if (currentSpriteIndex == -1) {
				currentSpriteIndex = Random.Range(0, sprites.Length);
			} else if (currentSpriteIndex >= sprites.Length) {
				currentSpriteIndex = sprites.Length - 1;
			}

			GetComponent<SpriteRenderer>().sprite = sprites[currentSpriteIndex];
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
