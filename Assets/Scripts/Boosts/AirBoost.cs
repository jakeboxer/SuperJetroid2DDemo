using UnityEngine;
using System.Collections;

public class AirBoost : Boost {
	public float airAmount = 8f;

	private Meter airMeter; 

	// Use this for initialization
	void Start () {
		airMeter = GameObject.Find("Meter").GetComponent<Meter>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnBoost () {
		airMeter.AddAir(airAmount);
	}
}
