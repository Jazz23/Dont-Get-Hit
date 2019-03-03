using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookaround : MonoBehaviour
{
    public float fl_pitch_sens = 1F;
    public float fl_yaw_sense = 1F;


    public float fl_max_pitch = 89F;
    public float fl_min_pitch = -89F;
    public float fl_pitch = 0F;

    public float fl_max_yaw = 160F;
    public float fl_min_yaw = -160F;
    public float fl_yaw = 0F;

    public float dy = 0F, dx = 0F;

    Quaternion Rotation2Move;

	void Start()
    {
        fl_pitch = 0F;
        fl_yaw = 0F;
	}
	
	void Update()
    {
        //its called dx and dy stupid unity

        dx = Input.GetAxis("Mouse X");
        dy = -Input.GetAxis("Mouse Y");

        fl_yaw += dx * fl_yaw_sense;
        fl_pitch += dy * fl_pitch_sens;
        fl_yaw = Mathf.Clamp(fl_yaw, fl_min_yaw, fl_max_yaw);
        fl_pitch = Mathf.Clamp(fl_pitch, fl_min_pitch, fl_max_pitch);

        transform.rotation = Quaternion.Euler(fl_pitch, fl_yaw, 0.0f);

        Assets.__BasePlayer.fl_pitch = fl_pitch;
        Assets.__BasePlayer.fl_yaw = fl_yaw;
    }

}
