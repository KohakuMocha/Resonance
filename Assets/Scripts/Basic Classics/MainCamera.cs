using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainCamera : MonoBehaviour {

    public bool final = false;
    public float xBound;
    public float yBound;
    public Image screen;
    float x = 0.0f;
    float y = 0.0f;
    // Use this for initialization
    void Start () {
        screen.canvasRenderer.SetAlpha(0.0f);
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (!final)
        {
            Vector3 new_position = Player.Instance.transform.position;
            new_position.z = transform.position.z;
            transform.position = new_position;

        }
        else
        {
            if(x < 15f)
            {
                transform.position = transform.position + new Vector3(0.05f, 0.05f, -0.01f);
                x += 0.05f;
                y += 0.05f;
                Debug.Log(x);
            }
            else
            {
                StartCoroutine(wait1());

                screen.CrossFadeAlpha(1, 3, false);
            }
            
        }
	}


    IEnumerator wait1()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("MainMenu");
    }
}
