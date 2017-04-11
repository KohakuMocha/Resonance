using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    [SerializeField]
    private Sprite rockInHoleSprite;
    [SerializeField]
    private GameObject blocker;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "rock")
        {
            GetComponent<SpriteRenderer>().sprite = rockInHoleSprite;
            Destroy(blocker);
            Destroy(other.gameObject);
        }
    }
}
