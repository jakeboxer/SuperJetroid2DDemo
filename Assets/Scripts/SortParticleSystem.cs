using UnityEngine;
using System.Collections;

public class SortParticleSystem : MonoBehaviour {
	public string layerName = "Particles";

	public void Start () {
		particleSystem.renderer.sortingLayerName = layerName;
	}
}
