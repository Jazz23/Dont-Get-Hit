﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Binaries;
using Assets.Car;

public class BasePlayer : MonoBehaviour
{



    /*
    TODO: 
	Add leaning which will allow for sharper turns.
	Lean using q and e
    */
    //enumerate player actions. so you dont have to do if (acceleration > 0.f) or stuff.
    //usage if (gameObject.GetComponet<BasePlayer>().Actions & ACCELERATING)


    public movement movement;
    public lookaround lookaround;
    public Vector3 lastPos;
    public Binaries.aActions PlayerActions;
    public int health;
    public float LeanAngle;
    public List<StaticCar> static_cars;
    public List<CarYeet> moving_cars;

    public Vector3 Viewangles
    {
        get { return new Vector3(lookaround.fl_pitch, lookaround.fl_yaw); }
        set { lookaround.fl_pitch = value.x; lookaround.fl_yaw = value.y; }
    }



    void Start()
    {
        movement = GetComponent<movement>();
        lookaround = GetComponent<lookaround>();
	}
    void Update()
    {

    }

    public int TakeDamage(int damage)
    {
        health -= damage;
        return health;
    }
    public void AddMultipleActions(params Binaries.aActions[] action)
    {
        for (int i = 0; i < action.Length; i++)
            PlayerActions |= action[i];
    }
    public void RemoveAction(Binaries.aActions action)
    {
        PlayerActions &= ~action;
    }
}
