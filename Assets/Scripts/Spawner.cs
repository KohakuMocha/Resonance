using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float delay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            transform.Translate(new Vector3(0, 1) * Time.deltaTime * 2);
        }

		
	}
}
