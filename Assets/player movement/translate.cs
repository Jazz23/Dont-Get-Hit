using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class translate : MonoBehaviour
{

    public float fl_translateSpeed = 1.5F;
    public float fl_translateAcceleration = 0F;
    bool b_lastInput = false;

	void Start()
    {
		
	}
    
	void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (b_lastInput)
                fl_translateAcceleration = 0F;
            else if (fl_translateAcceleration < 1f)
                fl_translateAcceleration += 0.1F;
            b_lastInput = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (!b_lastInput)
                fl_translateAcceleration = 0F;
            else if (fl_translateAcceleration < 1f)
                fl_translateAcceleration += 0.1F;
            b_lastInput = true;
        }
        else
            if (fl_translateAcceleration > 0f)
                fl_translateAcceleration -= 0.05F;


        if (b_lastInput)
            transform.Translate(Vector3.right * fl_translateSpeed * fl_translateAcceleration);
        else
            transform.Translate(Vector3.left * fl_translateSpeed * fl_translateAcceleration);

        transform.Translate(Vector3.forward * BasePlayer.fl_velocity);
    }
}
