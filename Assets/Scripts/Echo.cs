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
	// Magnitude: Determines the range of the wave.
	public float magnitude;
	// Trail: Determines the number of trails left behind.
	public int trail;
	// Source: Choose if the wave is main source.
	public bool source;
	private float wave = 1.0f;
	private float waveSize;

	void OnTriggerEnter2D(Collider2D collision){
		// Do Stuff here on enter.
		Debug.Log("Object response");
	}
		
	IEnumerator EchoWave(float time){
		yield return new WaitForSeconds (time);

		Vector3 deceleration = new Vector3 (0, 1, 0);
		Vector3 decrease = new Vector3 (1, 0, 0);
		GameObject newWave = Instantiate (gameObject, transform.position - deceleration, Quaternion.identity);
		newWave.GetComponent<Echo>().source = false;
		newWave.transform.transform.localScale = newWave.transform.transform.localScale - decrease;
		decrease.x += 1;
		deceleration.y += 1;
	}

	void Start(){
		if (source) {
			float time = 0.1f;
			for (int i = 0; i < trail; i++) {
				time += 0.2f;
				StartCoroutine (EchoWave (time));
			}
		}
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
