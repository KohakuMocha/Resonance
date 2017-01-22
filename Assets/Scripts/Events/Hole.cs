using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    public Sprite rockInHoleSprite;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider2D other)
    {
        if(other.tag == "rock")
        {
            GetComponent<SpriteRenderer>().sprite = rockInHoleSprite;
            Destroy(other.gameObject);
        }
    }
}
