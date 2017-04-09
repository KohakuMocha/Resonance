using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLight : MonoBehaviour {

    public GameObject echo_1;
    public GameObject echo_2;
    private GameObject clone;
    private GameObject clone2;
    private MainCamera mc;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            clone = (GameObject)Instantiate(Resources.Load("Prefabs/Final Echo"), echo_1.transform.position, echo_1.transform.rotation);
            clone2 = (GameObject)Instantiate(Resources.Load("Prefabs/Final Echo"), echo_2.transform.position, echo_2.transform.rotation);
            //Destroy(this.gameObject);
            mc.final = true;

        }
    }
    // Use this for initialization
    void Start () {
        mc = GameObject.Find("Main Camera").GetComponent<MainCamera>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
