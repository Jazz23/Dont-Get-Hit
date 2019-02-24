using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gothirdperson : MonoBehaviour
{
    bool b_pressed = false;
    bool b_position = false;
    public float fl_distance = 40f;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && !b_pressed)
        {
            if (!b_position)
            {
                transform.Translate(Vector3.forward * -fl_distance);
                // transform.Translate(Vector3.up * fl_distance);
                b_position = true;
            }
            else
            {
                transform.Translate(Vector3.forward * fl_distance);
                // transform.Translate(Vector3.up * -fl_distance);
                b_position = false;
            }
        }
        else if (Input.GetKeyUp(KeyCode.H) && b_pressed)
            b_pressed = false;
    }
}
