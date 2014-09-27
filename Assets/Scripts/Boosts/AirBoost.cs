using UnityEngine;
using System.Collections;

public class AirBoost : Boost {
	public float airAmount = 8f;

	private Meter airMeter; 

	// Use this for initialization
	void Start () {
		GameObject airMeterGameObject = GameObject.Find("Meter");

		if (airMeterGameObject) {
			airMeter = airMeterGameObject.GetComponent<Meter>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnBoost () {
		if (!airMeter) { return; }

		airMeter.AddAir(airAmount);
	}
}
