using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    public Vector3 Viewangles
    {
        get { return new Vector3(lookaround.fl_pitch, lookaround.fl_yaw); }
        set { lookaround.fl_pitch = value.x; lookaround.fl_yaw = value.y; }
    }

    public int Health;
    public movement movement;
    public lookaround lookaround;


    void Start()
    {
        movement = GetComponent<movement>();
        lookaround = GetComponent<lookaround>();
	}
	
	void Update()
    {
		
	}
}
