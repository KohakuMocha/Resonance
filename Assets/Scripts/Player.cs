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

        UpdateMouse();

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

    void UpdateMouse()
    {
        Vector3 mouse_position = Input.mousePosition;
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = mouse_position - pos;
        float angle = Mathf.Atan2(dir.y, dir.x);
        //float angleDeg = Mathf.Atan2(mouse_position.y - transform.position.y, mouse_position.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
