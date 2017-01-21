using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoReflection : MonoBehaviour {

    public Echo prefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Needs to check tag to see if it was an echo that hit
        print("reflect");
        Echo reflect = Instantiate(prefab, transform.position, Quaternion.identity);
        //Currently reflects 180, need to implement proper physics reflecting
        reflect.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
    }
}
