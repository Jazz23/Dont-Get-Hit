using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FOR USE ON STATIONARY OBJECTS ONLY! THIS WILL NOT WORK ON A MOVING CAR/OBJECT
//Also change the x to y if you have the door going in the other way.

public class opendoor : MonoBehaviour
{
    public float fl_doorDistance = 90F;
    public float fl_openSpeed = 0.1F;
    bool b_shouldOpen = false;
    bool b_position = false;
    float fl_totalRotation = 0F;
    Vector3 v_originalPos;
    void Start()
    {
        v_originalPos = transform.position;
        //change this to y if u rotate the door in the other direction.
        v_originalPos.x += 40;
        //v_originalPos.y += 40;
    }

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            b_shouldOpen = true;
        }

        if (b_shouldOpen && b_position)
        {
            transform.RotateAround(v_originalPos, Vector3.up, Time.deltaTime * fl_openSpeed);
            fl_totalRotation += Time.deltaTime * fl_openSpeed;
        }
        else if (b_shouldOpen && !b_position)
        {
            transform.RotateAround(v_originalPos, Vector3.up, -(Time.deltaTime * fl_openSpeed));
            fl_totalRotation += Time.deltaTime * fl_openSpeed;
        }
        if (fl_totalRotation >= fl_doorDistance)
        {
            b_position = !b_position;
            fl_totalRotation = 0F;
            b_shouldOpen = false;
        }


	}
}
