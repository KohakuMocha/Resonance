using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour {
    public float Distance;
    public float Speed = 1;
    private bool lerping;
    Vector3 start;
    Vector3 end;
    float lerpdist;
    private float time;
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
                    Vector3 EndPosition = transform.position + transform.up * Distance;
                    StartCoroutine(BoulderAnimation(EndPosition));
                }

            }
        }
    }
    private IEnumerator BoulderAnimation(Vector3 EndPos)
    {
        Vector3 StartPos = this.transform.position;
        start = StartPos;
        end = EndPos;
        Vector3 Movement = (EndPos - StartPos) * .25f;
        yield return new WaitForSecondsRealtime(.2f);
        lerpdist = Vector3.Distance(start, end);
        lerping = true;
        time = Time.time;
    }
    private void Update()
    {
        if (lerping)
        {
            
            transform.position = Vector3.Lerp(start, end, (Speed * (Time.time-time))/ lerpdist);
            if(transform.position == end)
            {
                lerping = false;
            }
        }

    }
}

