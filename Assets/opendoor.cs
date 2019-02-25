using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Binaries;

//FOR USE ON STATIONARY OBJECTS ONLY! THIS WILL NOT WORK ON A MOVING CAR/OBJECT
//Also change the x to y if you have the door going in the other way.

public class opendoor : MonoBehaviour
{
    public float fl_openSpeed = 10F;
    public float fl_open_angle;
    public bool b_open = false;
    public float fl_totalRotation = 0F;
    public Vector3 v_rotate_point;
    public float fl_original_angle;

    void Start()
    {
        fl_original_angle = transform.rotation.eulerAngles.y;
    }

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            b_open = !b_open;
        
        if (b_open && transform.rotation.eulerAngles.y != fl_open_angle)
            transform.RotateAround(v_rotate_point, Vector3.up, Time.deltaTime * fl_openSpeed);
        else if (!b_open && transform.rotation.eulerAngles.y != fl_original_angle)
            transform.RotateAround(v_rotate_point, Vector3.up, Time.deltaTime * -fl_openSpeed);
    }
}
