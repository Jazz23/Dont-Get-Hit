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


    /*
    TODO: 
	Add leaning which will allow for sharper turns.
	Lean using q and e
    */
    //enumerate player actions. so you dont have to do if (acceleration > 0.f) or stuff.
    //usage if (gameObject.GetComponet<BasePlayer>().Actions & ACCELERATING)

    public Binaries.aActions PlayerActions;

    public void RemoveAction(Binaries.aActions action)
    {
	PlayerActions &= ~action;
    }
    public void AddMultipleActions(params Binaries.aActions[] action)
    {
        for (int i = 0; i < action.Length; i++)
            PlayerActions |= action[i];
    }

    public float LeanAngle;

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
