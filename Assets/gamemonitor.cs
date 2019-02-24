using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//a script called once per frame in one place...
public class gamemonitor : MonoBehaviour
{
	void Start()
    {
        Assets.GameSettings.i_tickcount = 0;
	}

	void Update()
    {
        Assets.GameSettings.i_tickcount++;
    }
}
