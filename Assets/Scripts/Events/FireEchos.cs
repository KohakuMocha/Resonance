using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEchos : MonoBehaviour {

    public GameObject echo_1;
    public GameObject echo_2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameObject clone = (GameObject)Instantiate(Resources.Load("Prefabs/Delayed Echo"), echo_1.transform.position, Quaternion.identity);
            GameObject clone2 = (GameObject)Instantiate(Resources.Load("Prefabs/Delayed Echo"), echo_2.transform.position, Quaternion.identity);
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
