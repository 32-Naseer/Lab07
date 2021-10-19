using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gm;
    private Rigidbody rb;
    private Animation thisAnimation;
    public float velocity;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.y < 3.40f)
            {
                rb.velocity = Vector2.up * velocity;
                thisAnimation.Play();
            }
        }
        else if (transform.position.y < -4.45)
        {
            gm.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gm.GameOver();
        }
    }
}

