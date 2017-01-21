using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseObject : MonoBehaviour {

	public GameObject wave;
	public int pulse;
	public float time;

	void PulseWave(){
		for (int i = 0; i < pulse; i++) {
			Instantiate (wave, gameObject.transform.position, Quaternion.identity);
		}
	}

	void Start() {
		InvokeRepeating("PulseWave", 0, 2.0f);
	}
}
