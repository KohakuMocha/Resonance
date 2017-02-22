using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLight : MonoBehaviour {

    public GameObject echo_1;
    public GameObject echo_2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject clone = (GameObject)Instantiate(Resources.Load("Prefabs/Final Echo"), echo_1.transform.position, echo_1.transform.rotation);
            GameObject clone2 = (GameObject)Instantiate(Resources.Load("Prefabs/Final Echo"), echo_2.transform.position, echo_2.transform.rotation);
            Destroy(this.gameObject);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
