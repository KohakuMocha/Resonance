using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public int speed;
    public float EchoDelayTime = 0.3f;
    public States CurrentState = States.Idle;
    public Vector3 savePosition;
    private GameObject echo;
    private Transform Aim;
    private float velocity = 2.5f;
    private List<GameObject> Echoes = new List<GameObject>();
    private Animator MyAnimator;
    public bool isDead;
    private Rigidbody2D RigidBody;
    private Vector3 MovementDirection;
    private bool CoroutineRunning = false;

    private void Awake()
    {
        MyAnimator = GameObject.GetComponent<Animator>();
        Aim = transform.FindChild("Aim");
        RigidBody = GetComponent<Rigidbody2D>();
        RigidBody.velocity = Vector2.zero;
        RigidBody.angularVelocity = 0;
        SetCheckPoint();
    }

    private void Start()
    {
        echo = ResourceManager.Instance.Prefabs["Echo"];
    }

    void Update()
    {

        RigidBody.velocity = Vector2.zero;
        RigidBody.angularVelocity = 0;

        if (!CoroutineRunning && Input.anyKey) {
            if (Input.GetButton("Up") || Input.GetButton("Down") || Input.GetButton("Left") || Input.GetButton("Right")) {
                CurrentState = States.Movement;
                MyAnimator.speed = 1;
            }
            else if (Input.GetMouseButtonDown(0) || Input.GetButton("Space")) {
                FollowMouse();
                CurrentState = States.Echoing;
                MyAnimator.speed = 0;
            }

            StartCoroutine(GetInput());
        }
        else {
            MyAnimator.speed = 0;
        }
        if (CurrentState == States.Echoing)
            FollowMouse();

        //move echos
        foreach (GameObject Echoo in Echoes) {
            if (Echoo)
                Echoo.transform.Translate(Vector3.up * Time.deltaTime * velocity);
        }
    }

    private IEnumerator GetInput()
    {
        CoroutineRunning = true;
        switch (CurrentState) {
            case States.Movement:
                MyAnimator.speed = 1;
                if (Input.GetButton("Up") && Input.GetButton("Left")) {
                    MyAnimator.Play("backL");
                    MovementDirection = new Vector3(-1, 1);
                }
                else if (Input.GetButton("Up") && Input.GetButton("Right")) {
                    MyAnimator.Play("backR");
                    MovementDirection = new Vector3(1, 1);

                }
                else if (Input.GetButton("Down") && Input.GetButton("Left")) {
                    MyAnimator.Play("frontL");
                    MovementDirection = new Vector3(-1, -1);
                }
                else if (Input.GetButton("Down") && Input.GetButton("Right")) {
                    MyAnimator.Play("frontR");
                    MovementDirection = new Vector3(1, -1);
                }
                else if (Input.GetButton("Up")) {
                    MyAnimator.Play("back");
                    MovementDirection = transform.up;
                }
                else if (Input.GetButton("Down")) {
                    MyAnimator.Play("front");
                    MovementDirection = -transform.up;
                }
                else if (Input.GetButton("Left")) {
                    MyAnimator.Play("left");
                    MovementDirection = -transform.right;
                }
                else if (Input.GetButton("Right")) {
                    MyAnimator.Play("right");
                    MovementDirection = transform.right;
                }
                RigidBody.MovePosition(transform.position + MovementDirection * speed * Time.deltaTime);
                CurrentState = States.Idle;
                break;
            case States.Echoing:
                // Create new wave.
                GameObject wave = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                // Get player face rotation and set to object.
                wave.transform.rotation = Aim.rotation; //Quaternion.Slerp(Aim.rotation, Aim.rotation, 20 * Time.deltaTime);
                Echoes.Add(wave);
                yield return new WaitForSeconds(EchoDelayTime);
                break;
        }
        CoroutineRunning = false;
    }

    void FollowMouse()
    {
        Vector3 MousePos = Input.mousePosition;
        MousePos.z = 10;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);
        float mouse_angle = Mathf.Atan2(MousePos.x - Aim.position.x, MousePos.y - Aim.position.y) * Mathf.Rad2Deg;
        float aim_angle = Aim.rotation.eulerAngles.z;

        if (mouse_angle < 0)
            mouse_angle *= -1;
        else
            mouse_angle = 360 - mouse_angle;
        float angle_difference = mouse_angle - aim_angle;

        if ((Mathf.Abs(angle_difference) > 1) || (aim_angle > 359 && mouse_angle < 1))
            Aim.rotation = Quaternion.Slerp(Aim.rotation, Quaternion.Euler(0, 0, mouse_angle), 20 * Time.deltaTime);

        if (mouse_angle > 337 || mouse_angle < 22)
            MyAnimator.Play("back");
        else if (mouse_angle > 22 && mouse_angle < 67)
            MyAnimator.Play("backL");
        else if (mouse_angle > 67 && mouse_angle < 112)
            MyAnimator.Play("left");
        else if (mouse_angle > 112 && mouse_angle < 157)
            MyAnimator.Play("frontL");
        else if (mouse_angle > 157 && mouse_angle < 202)
            MyAnimator.Play("front");
        else if (mouse_angle > 202 && mouse_angle < 247)
            MyAnimator.Play("frontR");
        else if (mouse_angle > 247 && mouse_angle < 292)
            MyAnimator.Play("right");
        else
            MyAnimator.Play("backR");
        MyAnimator.speed = 0;
    }

    public void SetCheckPoint()
    {
        savePosition = transform.position;
    }

    public void Restart()
    {
        transform.position = savePosition;
    }
}
