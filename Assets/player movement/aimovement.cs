using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimovement : MonoBehaviour
{
    public Vector3 temp_target;

    void Start()
    {
        
	}

	void Update()
    {

        float best_dist = 10000;
        float best_angle = 0;
        RaycastHit data;
        if (Physics.Linecast(transform.position, temp_target)) //something obstructing our view.
        {
            for (int i = 0; i < 360; i += 45)
            {
                Vector3 __direction = new Vector3(0f, i, 0f);
                Debug.DrawRay(transform.position, __direction, Color.red);
                data = GetRayDataW(__direction - transform.position, transform.position);
                if (data.distance < best_dist)
                {
                    best_dist = data.distance;
                    best_angle = i;
                }
            }
        }
        else
        {
            best_angle = (temp_target.y - transform.position.y);
        }

        //move in best angle direction.
    }

    RaycastHit GetRayDataW(Vector3 __direction, Vector3 __start)
    {
        RaycastHit hit;
        if (Physics.Raycast(__start, __direction, out hit))
            return hit;

        return hit;
    }
    RaycastHit GetRayData(Vector3 __start, Vector3 __dest)
    {
        RaycastHit hit;
        if (Physics.Raycast(__start, __dest - __start, out hit))
            return hit;

        return hit;
    }
}
