using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLit : MonoBehaviour
{

    public bool ItIsLit;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == ("echo"))
        {
            ItIsLit = true;
            transform.parent.GetComponent<IfAllLit>().CheckToggles();
        }
    }
}

