using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseObject : MonoBehaviour {

	public GameObject wave1;
	public GameObject wave2;
	public GameObject wave3;
	public GameObject wave4;
	public int pulse;
	public float time;

	void PulseWave(){
		for (int i = 0; i < pulse; i++) {
			if (wave1) {
				Instantiate (wave1, gameObject.transform.position, Quaternion.identity);
			}
			if (wave2) {
				Instantiate (wave2, gameObject.transform.position, Quaternion.identity);
			}
			if (wave3) {
				Instantiate (wave3, gameObject.transform.position, Quaternion.identity);
			}
			if (wave4) {
				Instantiate (wave4, gameObject.transform.position, Quaternion.identity);
			}
		}
	}

	void Start() {
		InvokeRepeating("PulseWave", 0, 2.0f);
	}
}
