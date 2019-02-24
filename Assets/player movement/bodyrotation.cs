using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyrotation : MonoBehaviour
{
    public float fl_bodyRotationAmount = 0.4F;
	void Start()
    {
		
	}
	
	void Update()
    {
        float rotation = Assets.BasePlayer.fl_yaw * fl_bodyRotationAmount;

        transform.rotation = Quaternion.Euler(0f, rotation, 0f);
    }
}
