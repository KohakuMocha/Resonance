using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public int KeyValue;
    public SwitchDoor door;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
            foreach(int x in door.SwitchKeyValues)
        {
            if(x == KeyValue)
            {
                print("bug");
                door.SwitchKeyValues.Remove(x);
                break;
            }
        }
            door.checkOpened();
    }
}
