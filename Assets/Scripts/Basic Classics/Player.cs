using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public Resonance waves;
    public int speed;
    public Vector3 savePosition;
    private GameObject echo;
    private Transform Aim;
    private float velocity = 3.0f;
    private List<GameObject> Echoes = new List<GameObject>();
    private Animator MyAnimator;
    private bool EchoMode = true;
    public bool isDead;
    private Rigidbody2D RigidBody;

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }

    private void Awake()
    {
        MyAnimator = GetComponent<Animator>();
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

    // Update is called once per frame
    void Update()
    {
        if (EchoMode) UpdateMouse();
        switch (waves) {
            case Resonance.Movement:
                // ECHO
                if (Input.GetButtonDown("Space")) {
                    waves = Resonance.Echoing;
                    break;
                }
                if (Input.GetButton("Up") && Input.GetButton("Left")) {
                    MyAnimator.Play("backDL");
                    MyAnimator.speed = 1;
                    EchoMode = false;
                    RigidBody.MovePosition(transform.position + new Vector3(-1, 1) * speed * Time.deltaTime);
                }
                else if (Input.GetButton("Up") && Input.GetButton("Right")) {
                    MyAnimator.Play("backDR");
                    MyAnimator.speed = 1;
                    EchoMode = false;
                    RigidBody.MovePosition(transform.position + new Vector3(1, 1) * speed * Time.deltaTime);

                }
                else if (Input.GetButton("Down") && Input.GetButton("Left")) {
                    MyAnimator.Play("frontDL");
                    MyAnimator.speed = 1;
                    EchoMode = false;
                    RigidBody.MovePosition(transform.position + new Vector3(-1, -1) * speed * Time.deltaTime);
                }
                else if (Input.GetButton("Down") && Input.GetButton("Right")) {
                    MyAnimator.Play("frontDR");
                    MyAnimator.speed = 1;
                    EchoMode = false;
                    RigidBody.MovePosition(transform.position + new Vector3(1, -1) * speed * Time.deltaTime);
                }
                else if (Input.GetButton("Up")) {
                    MyAnimator.Play("back");
                    MyAnimator.speed = 1;
                    EchoMode = false;
                    RigidBody.MovePosition(transform.position + transform.up * speed * Time.deltaTime);
                }
                else if (Input.GetButton("Down")) {
                    MyAnimator.Play("front");
                    MyAnimator.speed = 1;
                    RigidBody.MovePosition(transform.position + -transform.up * speed * Time.deltaTime);
                    EchoMode = false;
                }
                else if (Input.GetButton("Left")) {
                    MyAnimator.Play("left");
                    MyAnimator.speed = 1;
                    RigidBody.MovePosition(transform.position + -transform.right * speed * Time.deltaTime);
                    EchoMode = false;
                }
                else if (Input.GetButton("Right")) {
                    MyAnimator.Play("right");
                    MyAnimator.speed = 1;
                    RigidBody.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
                    EchoMode = false;
                }
                else
                    MyAnimator.speed = 0;
                break;
            case Resonance.Echoing:
                EchoMode = true;
                // Create new wave.
                GameObject wave = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                // Get player face rotation and set to object.
                // Quaternion.Euler (0, 0, gameObject.transform.rotation.z)
                wave.transform.rotation = Quaternion.Slerp(Aim.rotation, Aim.rotation, 20 * Time.deltaTime);
                Echoes.Add(wave);
                waves = Resonance.Movement;
                StartCoroutine(Wait());
                break;
        }
        for (int i = 0; i < Echoes.Count; i++) {
            if (Echoes[i]) {
                GameObject Echoo = Echoes[i];
                Echoo.transform.Translate(new Vector3(0, 1) * Time.deltaTime * velocity);
            }
        }
    }

    void UpdateMouse()
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
            MyAnimator.Play("backDL");
        else if (mouse_angle > 67 && mouse_angle < 112)
            MyAnimator.Play("left");
        else if (mouse_angle > 112 && mouse_angle < 157)
            MyAnimator.Play("frontDL");
        else if (mouse_angle > 157 && mouse_angle < 202)
            MyAnimator.Play("front");
        else if (mouse_angle > 202 && mouse_angle < 247)
            MyAnimator.Play("frontDR");
        else if (mouse_angle > 247 && mouse_angle < 292)
            MyAnimator.Play("right");
        else
            MyAnimator.Play("backDR");
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
