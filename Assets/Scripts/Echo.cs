using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : MonoBehaviour {
	// Speed: Determines the traveling time of the wave.
	public float speed;
	// Strength: Determines the life time of the wave.
	public float strength;
	// Frequency: Determines the width of the wave.
	public float frequency;
	// Magnitude Determines the range of the wave.
	public float magnitude;
	private float wave = 1.0f;
	private float waveSize;

	void OnTriggerEnter2D(Collider2D collision){
		// Do Stuff here on enter.
		Debug.Log("Object response");
	}

	void Update () {
		if (wave < strength) {
			// Feed player position at x.
			transform.position = new Vector3 (transform.position.x, transform.position.y + (1.0f * speed), 0);
			if (transform.localScale.y > 0) {
				waveSize = transform.localScale.y - magnitude;
			}
			transform.localScale = new Vector3 (transform.localScale.x + frequency, waveSize, 0);
			wave = wave + (1.0f * speed);
		} 
		else {
			Destroy (gameObject);
		}
	}
}
