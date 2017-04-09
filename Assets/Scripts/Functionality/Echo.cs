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
    // Velocity:
    public float velocity = 3.0f;
    private float waveSize;
    private bool deflect;
    private List<GameObject> Echoes = new List<GameObject>();
    GameObject newWave;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            return;
        }
        if (!deflect)
        {
            switch (collision.gameObject.tag)
            {
                case "Top0":
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z + 90);
                    break;
                case "Top1":
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z + 180);
                    break;
                case "Top2":
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z - 90);
                    break;
                case "Bot0":
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z + 90);
                    break;
                case "Bot1":
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z + 180);
                    break;
                case "Bot2":
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z - 90);
                    break;
                case "Left0":
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z + 90);
                    break;
                case "Left1":
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z + 180);
                    break;
                case "Left2":
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z - 90);
                    break;
                case "Right0":
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z + 90);
                    break;
                case "Right1":
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z + 180);
                    break;
                case "Right2":
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z - 90);
                    break;
            }
            deflect = true;
        }
        
        else {
            //Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    IEnumerator EchoWave(float time)
    {
        Vector3 previous = transform.position;
        yield return new WaitForSeconds(time);
        newWave = Instantiate(gameObject, previous, Quaternion.identity);
        newWave.transform.localScale = new Vector3(0.17f, 0.1f, 0);
        newWave.transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation, 20 * Time.deltaTime);
        Echoes.Add(newWave);
        newWave.GetComponent<Echo>().source = false;
    }

    IEnumerator EchoEcho(float time)
    {
        yield return new WaitForSeconds(time);
        // Fading awave.
        Color color = GetComponent<SpriteRenderer>().color;
        //color.a -= 0.01f;
        GetComponent<SpriteRenderer>().color = color;
    }

    void Start()
    {
        // Fading awave.
        Color color = GetComponent<SpriteRenderer>().color;
        color.a = 0.5f;
        GetComponent<SpriteRenderer>().color = color;
        deflect = false;
        if (source)
        {
            float time = 0.2f;
            for (int i = 0; i < trail; i++)
            {
                StartCoroutine(EchoWave(time));
                time += 0.2f;
            }
        }
    }

    void Update()
    {
        if (!source)
        {
            transform.Translate(new Vector3(0, 1) * Time.deltaTime * velocity);
        }
        Color color = GetComponent<SpriteRenderer>().color;
        if (color.a < 0)
        {
            Destroy(gameObject);
        }
        StartCoroutine(EchoEcho(1.0f));
        for (int i = 0; i < Echoes.Count; i++)
        {
            if (Echoes[i])
            {
                Echoes[i].transform.Translate(new Vector3(0, 1) * Time.deltaTime * velocity);
            }
        }
        if (transform.localScale.y > 0.001f)
        {
            waveSize = transform.localScale.y - magnitude;
        }
        if (transform.localScale.x < 2)
        {
            transform.localScale = new Vector3(transform.localScale.x + frequency, waveSize, 0);
        }
    }
}