using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charControl : MonoBehaviour
{
    public float jumpForce;
    bool ground;
    float inputX;
    float inputY;
    public float direction = 1;
    Rigidbody2D rb;
    public bool convCar;
    public Collider2D nrmlCol, carCol;

    public GameObject ballet;
    public Transform firePoint;
    public float bullSpeed;

    public Camera cam;

    public float speed;
    public float robotSpeed=300f;
    public float maxCarSpeed = 600f;  
    public float accelerationTime = 2f; 
    public float smallBrakeTime=2f;
    public float bigBrakeTime=2f;
    float brakeTime;


    void Start()
    {
        speed = robotSpeed;
        rb = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;

        if (Input.GetKeyDown(KeyCode.W) && ground && !convCar)
        {
            ground = false;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        rb.velocity = new Vector2(inputX, rb.velocity.y);

        if (inputX < 0)
        {
            direction = -1;
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("move", true);
        }else if(inputX > 0)
        {
            direction = 1;
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("move", true);
        }
        else
            GetComponent<Animator>().SetBool("move", false);

        brakeTime = (speed > 450) ? bigBrakeTime : smallBrakeTime;

        if (!convCar && Input.GetKeyDown(KeyCode.Space))
        {
            fire();
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            carStop();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            convCar = !convCar;
            GetComponent<Animator>().SetBool("car", convCar);
        }

        if (convCar)
        {
            carCol.enabled = true;
            nrmlCol.enabled = false;

            if (inputX != 0)
            {
                speed = Mathf.Lerp(speed, maxCarSpeed, Time.deltaTime / accelerationTime);
            }
            else if (!Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow))
            {
                carStop();
            }
            else speed = robotSpeed;

            GetComponent<Animator>().SetInteger("speed", Mathf.FloorToInt(speed));
        }
        else
        {
            carCol.enabled = false;
            nrmlCol.enabled = true;
            speed = robotSpeed;
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            ground = true;
        }
    }

    public void fire()
    {
        Instantiate(ballet, firePoint.position, firePoint.rotation);
    }

    public void carStop()
    {
        speed = Mathf.Lerp(speed, 0f, brakeTime);
        rb.AddForce(new Vector2(speed, 0f), ForceMode2D.Impulse);
    }

    public void activeControlScrpit()
    {
        this.enabled = true;
    }
}
