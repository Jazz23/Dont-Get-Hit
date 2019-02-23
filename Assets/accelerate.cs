using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerate : MonoBehaviour
{
    public float fl_maxspeed = 50F;
    public float fl_minspeed = -10F;
    public float fl_acceleration = 5F;
    public float fl_deceleration = 10F;
    public float fl_currentspeed = 0F;


	void Start()
    {
		
	}

	void Update()
    {
		if (Input.GetKey(KeyCode.W))
            fl_currentspeed += fl_acceleration;
        else if (Input.GetKey(KeyCode.S))
            fl_currentspeed -= fl_deceleration;

        Mathf.Clamp(fl_currentspeed, fl_minspeed, fl_maxspeed);
	}
}
