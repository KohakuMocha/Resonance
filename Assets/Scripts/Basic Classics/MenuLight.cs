using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLight: MonoBehaviour
{

    [SerializeField]
    private bool isActive = true; //either on or off 
    [SerializeField]
    private float activeTime; //amount of time the light is fully on for
    [SerializeField]
    private float intensity; //the highest intensity a light point can have   
    [SerializeField]
    private float lightChangeIntensity; //the rate of decreasing/increasing intensity
    [SerializeField]
    private float lightChangeDelay; //the wait time until the light increases intensity
    [SerializeField]
    private float boundingBox; //how big the bounding box for the light collider to be. 
    [SerializeField]
    private float waitStartTime;
    [SerializeField]
    private float waitEndTime;

    IEnumerator startLight(float bBox, float intensity, float lightChangeIntensity, float lightChangeDelay, float activeTime)
    {
        yield return new WaitForSeconds(waitStartTime);
        while (isActive)
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
            isActive = true;
            yield return new WaitForSeconds(waitEndTime);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag.Equals("objectLight") || other.tag.Equals("echo"))
        {
            //Debug.Log(other.tag);
            StartCoroutine(startLight(boundingBox, intensity, lightChangeIntensity, lightChangeDelay, activeTime));
        }
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(startLight(boundingBox, intensity, lightChangeIntensity, lightChangeDelay, activeTime));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
