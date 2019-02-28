using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class accelerate : MonoBehaviour
{
    public float fl_maxspeed = 50F;
    public float fl_minspeed = -10F;
    public float fl_acceleration = 0.1F;
    public float fl_deceleration = 0.5F;
    public float fl_velocity = 0F;
    public float fl_stamina = 100F;
    public float fl_friction = 1F;
    bool can_use_stamina = true;
    
	void Start()
    {
		
	}

	void Update()
    {
        bool using_stamina = Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && fl_stamina > 0F && can_use_stamina;
        if (using_stamina)  fl_stamina -= 0.5F;
        else fl_stamina += 0.1F;

        //disable stamina after used to 0 until it gets back to 20%
        if (fl_stamina <= 0F) can_use_stamina = false;
        else if (fl_stamina >= 20F)  can_use_stamina = true;

        if (fl_stamina > 100) fl_stamina = 100;
        else if (fl_stamina < 0) fl_stamina = 0;

        if (Input.GetKey(KeyCode.W))
            fl_velocity += fl_acceleration + (using_stamina ? fl_acceleration/2F : 0);
        else if (Input.GetKey(KeyCode.S))
            fl_velocity = fl_velocity < 0 ? -1 : fl_velocity - fl_deceleration;
        else if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && fl_velocity != 0)
            fl_velocity += Mathf.Clamp(fl_friction * fl_velocity / Mathf.Abs(fl_velocity) * -1 * fl_acceleration, -fl_velocity, fl_velocity);

        //Mathf.Clamp(fl_velocity, fl_minspeed, fl_maxspeed); uhh wtf why doesnt this work?
        if (fl_velocity > fl_maxspeed)  fl_velocity = fl_maxspeed;
        else if (fl_velocity < fl_minspeed)  fl_velocity = fl_minspeed;

        __BasePlayer.fl_velocity = fl_velocity;
        __BasePlayer.fl_stamina = fl_stamina;
        __BasePlayer.b_useStamina = can_use_stamina;
        __BasePlayer.fl_acceleration = fl_acceleration + (using_stamina ? fl_acceleration / 2F : 0);
        __BasePlayer.fl_friction = fl_friction;
    }
}
