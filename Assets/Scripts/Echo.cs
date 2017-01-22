using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : MonoBehaviour
{
    // Frequency: Determines the width of the wave.
    public float frequency;
    // Magnitude: Determines the range of the wave.
    public float magnitude;
    // Trail: Determines the number of trails left behind.
    public int trail;
    // Source: Choose if the wave is main source; only main source spawns trailing waves.
    public bool source;

    private float wave = 1.0f;
    private float waveSize;
	private bool deflect;

    void OnTriggerEnter2D(Collider2D collision)
    {
		Debug.Log ("I HIT!");

		if (collision.gameObject.name == "Reflect" && !deflect) {
			gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, gameObject.transform.rotation.z + 180), 20 * Time.deltaTime);
			deflect = true;
		}
		else {
			// Fading awave.
			Color color = GetComponent<SpriteRenderer>().color;
			color.a -= 0.1f;
			GetComponent<SpriteRenderer> ().color = color;
			Destroy (gameObject);
		}
    }

	void OnBecameInvisible() {
		Destroy(gameObject);
	}

    IEnumerator EchoWave(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject newWave = Instantiate(gameObject, transform.position, Quaternion.identity);
        newWave.GetComponent<Echo>().source = false;
    }

    void Start()
    {
		deflect = false;
        if (source == true)
        {
            float time = 1.0f;
            for (int i = 0; i < trail; i++)
            {
				StartCoroutine(EchoWave(time));
				time += 0.5f;
            }
        }
    }

    void Update()
    {

        if (transform.localScale.y > 0.5f)
        {
            waveSize = transform.localScale.y - magnitude;
        }
		if (transform.localScale.x < 5) {
			transform.localScale = new Vector3 (transform.localScale.x + frequency, waveSize, 0);
		} 
		else {
			// Fading awave.
			/*
			Color color = GetComponent<SpriteRenderer> ().color;
			color.a -= 0.1f;
			GetComponent<SpriteRenderer> ().color = color;
			*/
		}
    }
}
