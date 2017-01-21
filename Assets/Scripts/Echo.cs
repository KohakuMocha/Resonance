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
	// Choose direction:
	public bool up;
	public bool down;
	public bool left;
	public bool right;
	private float wave = 1.0f;
	private float waveSize;

	void OnTriggerEnter2D(Collider2D collision){
		// Do Stuff here on enter.
		Debug.Log("Object response");
		Destroy (gameObject);
	}
		
	IEnumerator EchoWave(float time){
		yield return new WaitForSeconds (time);

		Vector3 decelerationV = new Vector3 (0, 1, 0);
		Vector3 decreaseV = new Vector3 (1, 0, 0);
		Vector3 decelerationH = new Vector3 (1, 0, 0);
		Vector3 decreaseH = new Vector3 (0, 1, 0);
		GameObject newWave;
		if (up || down) {
			newWave = Instantiate (gameObject, transform.position - decelerationV, Quaternion.identity);
			newWave.transform.transform.localScale = newWave.transform.transform.localScale - decreaseV;
		} 
		else {
			newWave = Instantiate (gameObject, transform.position - decelerationH, Quaternion.identity);
			newWave.transform.transform.localScale = newWave.transform.transform.localScale - decreaseH;
		}
		newWave.GetComponent<Echo>().source = false;
		decreaseV.x += 1;
		decreaseH.x += 1;
		decelerationV.y += 1;
		decelerationH.y += 1;
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
			if (up) {
				transform.position = new Vector3 (transform.position.x, transform.position.y + (1.0f * speed), 0);
			} 
			else if (down) {
				transform.position = new Vector3 (transform.position.x, transform.position.y - (1.0f * speed), 0);
			} 
			else if (left) {
				transform.position = new Vector3 (transform.position.x - (1.0f * speed), transform.position.y, 0);
			} 
			else if (right) {
				transform.position = new Vector3 (transform.position.x + (1.0f * speed), transform.position.y, 0);
			}
			if (up || down) {
				if (transform.localScale.y > 0) {
					waveSize = transform.localScale.y - magnitude;
				}
				transform.localScale = new Vector3 (transform.localScale.x + frequency, waveSize, 0);
				wave = wave + (1.0f * speed);
			} 
			else {
				if (transform.localScale.x > 0) {
					waveSize = transform.localScale.x - magnitude;
				}
				transform.localScale = new Vector3 (waveSize, transform.localScale.y + frequency, 0);
				wave = wave + (1.0f * speed);
			}	
		} 
		else {
			Destroy (gameObject);
		}
	}
}
