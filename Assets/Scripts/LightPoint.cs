using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPoint : MonoBehaviour {

    [SerializeField]
    private bool isActive = true; //either on or off 
    [SerializeField]
    private float activeTime; //amount of time that it's at its brigthest
    [SerializeField]
    private float intensity; //amount of time that it's at its brigthest    
    [SerializeField]
    private float lightChangeIntensity; //amount of time that it's at its brigthest
    [SerializeField]
    private float lightChangeDelay; //amount of time that it's at its brigthest
    [SerializeField]
    private float z_axis; //how far the light should be. used for bigger objects.
    [SerializeField]
    private float boundingBox; //how big the bounding box for the light collider to be. 

    IEnumerator startLight(float bBox, float intensity, float lightChangeIntensity, float lightChangeDelay, float activeTime)
    {
        //Activate light brightening 
        while (isActive)
        {
            //slowly increase intensity
            if (GetComponent<Light>().intensity > intensity) isActive = false;
            else
            {
                GetComponent<Light>().intensity += (lightChangeIntensity * Time.deltaTime);


            }
            //slowly increase collision box
            if (GetComponent<BoxCollider2D>().transform.localScale != new Vector3(bBox, bBox, 0))
            {
                Vector3 scale = GetComponent<BoxCollider2D>().transform.localScale + new Vector3(0.002f, 0.002f, 0);
                GetComponent<BoxCollider2D>().transform.localScale = scale;
            }
            yield return new WaitForSeconds(lightChangeDelay);
        }
        isActive = true;

        //light will stay brighest for activeTime seconds
        yield return new WaitForSeconds(activeTime);

        //Activate light dimming
        while (isActive)
        {
            if (GetComponent<Light>().intensity == 0) isActive = false;
            else GetComponent<Light>().intensity -= (lightChangeIntensity * Time.deltaTime);
            //slowly decrease collion box
            if (GetComponent<BoxCollider2D>().transform.localScale != new Vector3(1, 1, 0))
            {
                Vector3 scale = GetComponent<BoxCollider2D>().transform.localScale - new Vector3(0.002f, 0.002f, 0);
                GetComponent<BoxCollider2D>().transform.localScale = scale;
            }
            yield return new WaitForSeconds(lightChangeDelay);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.tag.Equals("objectLight")) StartCoroutine(startLight(0.7f, .1f, 3));
        StartCoroutine(startLight(boundingBox, intensity, lightChangeIntensity, lightChangeDelay, activeTime));
    }

    // Use this for initialization
    void Start () {
        //StartCoroutine(startLight(1f, 0.01f, 3));
        transform.position = new Vector3(transform.position.x, transform.position.y, z_axis);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
