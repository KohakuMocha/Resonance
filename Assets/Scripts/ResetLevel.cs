using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerReset();
    }
    void triggerReset()
    {
        Application.LoadLevel(0);
        Player.Instance.transform.position = Player.Instance.savePosition;
    }
}
