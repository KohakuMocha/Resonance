using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour {
    public float Scale;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 position = collision.transform.position;
            position -= this.transform.position;
            Vector3 offset = new Vector3(0.1f, 0, 0);
            if (Mathf.Abs(position.x) >= Mathf.Abs(position.y))
            {
                if (position.x > 0)
                {
                    //Create Coroutine to slowly transform position to give animation
                    GetComponent<Rigidbody2D>().MovePosition(transform.position - transform.right * .01f);
                }
                else
                {
                    GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.right * .01f);
                }
            }
            else
            {
                if (position.y > 0)
                {
                    GetComponent<Rigidbody2D>().MovePosition(transform.position - transform.up * .01f);
                }
                else
                {
                    GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.up * .01f);
                }
            }
        }
    }

}
