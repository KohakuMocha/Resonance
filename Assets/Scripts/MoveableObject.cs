using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour {
    public float Distance;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 position = collision.transform.position;
            position -= this.transform.position;
            if (Mathf.Abs(position.x) >= Mathf.Abs(position.y))
            {
                if (position.x > 0)
                {
                    //Create Coroutine to slowly transform position to give animation
                    Vector3 EndPosition = transform.position - transform.right * Distance;
                    StartCoroutine(BoulderAnimation(EndPosition));
                }
                else
                {
                    Vector3 EndPosition = transform.position + transform.right * Distance;
                    StartCoroutine(BoulderAnimation(EndPosition));
                }
            }
            else
            {
                if (position.y > 0)
                {
                    Vector3 EndPosition = transform.position - transform.up * Distance;
                    StartCoroutine(BoulderAnimation(EndPosition));
                }
                else
                {
                    Vector3 EndPosition = transform.position - transform.right * Distance;
                    StartCoroutine(BoulderAnimation(EndPosition));
                }

            }
        }
    }
    private IEnumerator BoulderAnimation(Vector3 EndPos)
    {
        Vector3 StartPos = this.transform.position;
        Vector3 Movement = (EndPos - StartPos) * .25f;
        GetComponent<Rigidbody2D>().MovePosition(transform.position + Movement);
        yield return new WaitForSecondsRealtime(.2f);
        GetComponent<Rigidbody2D>().MovePosition(transform.position + Movement);
        yield return new WaitForSecondsRealtime(.2f);
        GetComponent<Rigidbody2D>().MovePosition(transform.position + Movement);
        yield return new WaitForSecondsRealtime(.2f);
        GetComponent<Rigidbody2D>().MovePosition(transform.position + Movement);
        yield return new WaitForSecondsRealtime(.2f);

    }
}

