using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{

    public int speed;
    public Vector3 savePosition;
    public GameObject echo;
    private float velocity = 3.0f;
    private Vector3 MousePos;
    private List<GameObject> Echoes = new List<GameObject>();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        UpdateMouse();

        // EKKO
        if (Input.GetButtonDown("Space"))
        {
            // Create new wave.
            GameObject wave = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
            // Get player face rotation and set to object.
            wave.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, gameObject.transform.rotation.z), 20 * Time.deltaTime);
            Echoes.Add(wave);
        }
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

        for (int i = 0; i < Echoes.Count; i++)
        {
			if (Echoes[i]) {
				GameObject Echoo = Echoes [i];
				Echoo.transform.Translate (new Vector3 (0, 1) * Time.deltaTime * velocity);
			}
        }
    }

    void UpdateMouse()
    {
        MousePos = Input.mousePosition;
        MousePos.z = 10;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);
        float mouse_angle = Mathf.Atan2(MousePos.x - transform.position.x, MousePos.y - transform.position.y) * Mathf.Rad2Deg;
        float player_angle = transform.rotation.eulerAngles.z;

        if (mouse_angle < 0)
            mouse_angle *= -1;
        else
            mouse_angle = 360 - mouse_angle;
        float angle_difference = mouse_angle - player_angle;

        if ((Mathf.Abs(angle_difference) > 1) || (player_angle > 359 && mouse_angle < 1))
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, mouse_angle), 20 * Time.deltaTime);

    }
}
