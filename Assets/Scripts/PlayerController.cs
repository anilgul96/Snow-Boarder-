using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// 
    /// //////////////////////////////////////////////////////////
    /// 
    [SerializeField] ParticleSystem skatePartical;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 0.05f;
    [SerializeField] float baseSpeed = 0.05f;
    /// 
    /// //////////////////////////////////////////////////////////
    /// 
    SurfaceEffector2D surfaceEffector2D;
    Rigidbody2D rb2d = new Rigidbody2D();

    bool canMove = true;
    /// 
    /// //////////////////////////////////////////////////////////
    /// 
    void Start()
    {
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();

        surfaceEffector2D.speed = 1f;

        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            Rotate();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        //push up, then speed up
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed += boostSpeed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed -= baseSpeed;
        }

    }
    void Rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            rb2d.AddTorque(torqueAmount);

        if (Input.GetKey(KeyCode.RightArrow))
            rb2d.AddTorque(-torqueAmount);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            skatePartical.Play();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            skatePartical.Stop();
        }
    }
}
