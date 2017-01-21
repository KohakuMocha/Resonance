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

    void OnTriggerEnter2D(Collider2D collision)
    {
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
        if (source)
        {
            float time = 3f;
            for (int i = 0; i < trail; i++)
            {
                time += 0.2f;
                StartCoroutine(EchoWave(time));
            }
        }
    }

    void Update()
    {
        // Fading awave.
        if (transform.localScale.y > 0.5f)
        {
            waveSize = transform.localScale.y - magnitude;
        }
        if (transform.localScale.x < 5)
        {

            transform.localScale = new Vector3(transform.localScale.x + frequency, waveSize, 0);
        }

    }
}
