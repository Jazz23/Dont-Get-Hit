using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Binaries;

public class BasePlayer : MonoBehaviour
{

    public int health
    {
    	get { return health; }
	set { health = value; }
    }
    
    public int TakeDamage(int damage)
    {
    	health-=damage;
	return health;
    }

    //enumerate player actions. so you dont have to do if (acceleration > 0.f) or stuff.
    //usage if (gameObject.GetComponet<BasePlayer>().Actions & ACCELERATING)
    public enum aActions {ACCELERATING, DECELERATING, STOPPED, TURNING, THIRDPERSON }

    public aActions PlayerActions
    {
        get { return PlayerActions; }
        set { PlayerActions |= value; }
    }

    
    public void AddMultipleActions(params aActions[] action)
    {
        for (int i = 0; i < action.Length; i++)
            PlayerActions |= action[i];
    }



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
