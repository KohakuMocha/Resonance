using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoReflection : MonoBehaviour {

    Vector3 colliderVector;
    Vector3 normal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collider)
    {
        // Needs to check tag to see if it was an echo that hit
        print("reflect");
        colliderVector = collider.transform.forward;
        normal = collider.contacts[0].normal;
        collider.transform.Rotate(0f,0f,angleInBetween(normal, colliderVector), Space.Self);
    }

    float angleInBetween(Vector3 a, Vector3 b)
    {
        return (a.x * b.x + a.y * b.y + a.z * b.z) / (a.magnitude * b.magnitude);
    }
}
