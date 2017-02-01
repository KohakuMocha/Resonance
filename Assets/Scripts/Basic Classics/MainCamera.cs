using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 new_position = Player.Instance.transform.position;
        new_position.z = transform.position.z;
        transform.position = new_position;
        
	}
}
