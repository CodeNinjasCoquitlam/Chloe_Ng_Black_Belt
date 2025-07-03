using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimersCountdown : MonoBehaviour
{
    public Text lapTime;
    public Text startCountdown;
    public Interact inte;
    public static transfer GM;

    public float totalLapTime;
    private Animator anim;
    private Rigidbody rb;
    private Quaternion lastLook;
    public float speed;
    public float totalCountdownTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        anim = GetComponent<Animator>();
        lastLook = transform.rotation;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(horizontal, 0, vertical).normalized;

        if (movementVector.magnitude != 0)
        {
            lastLook = Quaternion.LookRotation(movementVector);

        }
        transform.rotation = lastLook;

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed / 100;
        rb.MovePosition(transform.position + movement);

        anim.SetFloat("horizontalVector", movementVector.magnitude);
        anim.SetFloat("verticalVector", 0);
        anim.SetFloat("Speed", movementVector.magnitude);
    }
    void Update()
    {
        
        lapTime.text = Mathf.Round(totalLapTime).ToString();

        lapTime.text = Mathf.Round(totalLapTime).ToString();

        if (totalCountdownTime > 0)
        {
            totalCountdownTime -= Time.deltaTime;
            startCountdown.text = Mathf.Round(totalCountdownTime).ToString();
            speed = 0;
        }
        if (totalCountdownTime <= 0)
        {
            startCountdown.text = "";
            totalLapTime -= Time.deltaTime;
            lapTime.text = Mathf.Round(totalLapTime).ToString();
            totalLapTime -= Time.deltaTime;
            speed = 20;
        }

        if (totalLapTime < 0)
        {
            lapTime.text = "0";
            transfer.score = inte.total;
            SceneManager.LoadScene(4);
        }
    }
}
