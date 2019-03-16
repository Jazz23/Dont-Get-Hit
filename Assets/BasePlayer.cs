using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{

    public static int i_health;

    public float MaxVel
    {
        get { return movement.max_velocity; }
        set { movement.max_velocity = value; }
    }

    public float MinVel
    {
        get { return movement.min_velocity; }
        set { movement.min_velocity = value; }
    }

    public float Stamina
    {
        get { return movement.stamina; }
        set { movement.stamina = value; }
    }
    public float Velocity
    {
        get { return movement.velocity; }
        set { movement.velocity = value; }
    }

    public float Acceleration
    {
        get { return movement.acceleration; }
        set { movement.acceleration = value; }
    }

    public float Friction
    {
        get { return movement.friction; }
        set { movement.friction = value; }
    }

    public Vector3 Viewangles
    {
        get { return new Vector3(lookaround.fl_pitch, lookaround.fl_yaw); }
        set { lookaround.fl_pitch = value.x; lookaround.fl_yaw = value.y; }
    }

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
