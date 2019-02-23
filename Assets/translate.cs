using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translate : MonoBehaviour
{

    public float fl_translatespeed = 0.5F;

	void Start()
    {
		
	}
    
	void Update()
    {
		if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * fl_translatespeed);
        else if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.left * -fl_translatespeed);
	}
}
