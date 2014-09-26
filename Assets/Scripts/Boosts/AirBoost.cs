using UnityEngine;
using System.Collections;

public class AirBoost : Boost {
	public float airAmount = 4f;
	public Meter airMeter; 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnBoost () {
		airMeter.AddAir(airAmount);
	}
}
