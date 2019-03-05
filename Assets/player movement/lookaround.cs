using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(movement))]
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
    public Vector3 view_angles = new Vector3();
    public Transform parent;

	void Start()
    {
        fl_pitch = 0F;
        fl_yaw = 0F;
        parent = GetComponentsInParent<Transform>().FirstOrDefault(x => x.gameObject.name == "Player");
	}
	
	void Update()
    {
        //its called dx and dy stupid unity

        //dx = Input.GetAxis("Mouse X");
        //dy = -Input.GetAxis("Mouse Y");
        Vector3 parent_angles = parent.rotation.eulerAngles;

        dx = Input.GetAxis("Mouse X");
        dy = -Input.GetAxis("Mouse Y");

        fl_yaw += dx * fl_yaw_sense;
        fl_pitch += dy * fl_pitch_sens;
        fl_yaw = Mathf.Clamp(fl_yaw, fl_min_yaw, fl_max_yaw);
        fl_pitch = Mathf.Clamp(fl_pitch, fl_min_pitch, fl_max_pitch);

        Vector3 rot = new Vector3(fl_pitch, fl_yaw, 0.0f)/* + parent_angles*/;
        transform.rotation = Quaternion.Euler(rot);
    }

}
