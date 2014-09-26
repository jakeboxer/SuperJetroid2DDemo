using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void OnBoost () {
		Debug.Log("Override Boost.OnBoost() in superclasses.");
	}
}
