using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//a script called once per frame in one place...
public class gamemonitor : MonoBehaviour
{
	void Start()
    {

	}

	void Update()
    {
        //Time.frameCount exists, below is pointless
        //Assets.GameSettings.i_tickcount++;
	    Assets.__BasePlayer.fl_speed = Mathf.Abs(Assets.__BasePlayer.fl_velocity);
    }
}
