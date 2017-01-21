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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Collision");
            Vector2 dir = collision.contacts[0].point - (Vector2)this.transform.position;
            dir = -dir.normalized;
            StartCoroutine(BoulderAnimation(dir * Distance));
            
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
    int[] ScreenToIso(Vector3 Screen)
    {
        int[] coords = new int[2];
        coords[0] = Mathf.FloorToInt(Screen.y / (64) + Screen.x / (64));
        coords[1] = Mathf.FloorToInt(Screen.y / (64) - Screen.x / (64));
        return coords;
    }
}

