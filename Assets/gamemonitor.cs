using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//a script called once per frame in one place...
public class gamemonitor : MonoBehaviour
{


	void Start()
    {
        DontDestroyOnLoad(gameObject);
	}

    void OnGUI()
    {
        return;
        //if (Time.frameCount % 2 != 0) return;
        // Percent of screen
        float[] size = new float[4] { 10f, 90f, 20f, 5f };
        float width = Screen.width;
        float height = Screen.height;
        Rect recty = new Rect(size[0] / 100 * width, size[1] / 100 * height, size[2] / 100 * width, size[3] / 100 * height);

        Debug.Log(string.Format("{0}, {1}", width, height));
        Debug.Log(recty);

        GUI.Label(recty, "Nugget");
    }

	void Update()
    {

    }
}
