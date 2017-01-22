using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour {

    public List<int> SwitchKeyValues;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void checkOpened()
    {
        if (SwitchKeyValues.Count == 0)
        { 
            Destroy(this.GetComponent<BoxCollider2D>());

        }
    }
}
