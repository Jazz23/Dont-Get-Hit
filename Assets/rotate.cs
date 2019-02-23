using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    public float speed = 1;
	void Start()
    {
		
	}
	
	void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.World);
    }
}
