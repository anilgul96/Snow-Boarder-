using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SurfaceEffector : MonoBehaviour
{

    //[SerializeField] float SpeedControl = 0.1f;
    SurfaceEffector2D surfaceEffector2D;

    // Start is called before the first frame update
    void Start()
    {
        surfaceEffector2D = GetComponent<SurfaceEffector2D>();
        surfaceEffector2D.speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Speed();
        RespondToBoost();
    }

    void RespondToBoost()
    {

    }

    /*void Speed()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = surfaceEffector2D.speed + SpeedControl;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed = surfaceEffector2D.speed - SpeedControl;
        }
    }*/
}
