using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(other.GetComponent<Inventory>().checkItem(Items.Key))
            {
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("WHERE'S MY DAM KEY");
            }
        }
    }
}
