using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player> {

    public int speed;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Up"))
        {
            GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.up * speed * Time.deltaTime);
        }
        else if (Input.GetButton("Down"))
        {
            GetComponent<Rigidbody2D>().MovePosition(transform.position + -transform.up * speed * Time.deltaTime);
        }
        else if (Input.GetButton("Left"))
        {
            GetComponent<Rigidbody2D>().MovePosition(transform.position + -transform.right * speed * Time.deltaTime);
        }
        else if (Input.GetButton("Right"))
        {
            GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.right * speed * Time.deltaTime);
        }
	}
}
