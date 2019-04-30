using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Binaries;

namespace Assets.Car
{
    public class CarYeet : MonoBehaviour
    {
        public bool chasing = false;
        public float chase_speed = 5f;
        public float x_start = 1f;
        public float stop_chasing_dist = 0.0005f;
        public float velocity_after_chase = 5f;

        public BasePlayer player;
        float start;
        float start_point;
        Vector3 passing_point;
        
        void Start()
        {
            player = transform.position.GetClosestPlayer();
            passing_point = GameObject.FindObjectOfType<StaticCar>().transform.position;
            start = Time.time;
            start_point = transform.position.z;
        }

        void Update()
        {
            //TESTTT
            //if (Input.GetKeyDown(KeyCode.B))
            //{
            //    Start();
            //    chasing = !chasing;
            //}



            Vector3 pos = transform.position;
            Vector3 playerpos = player.transform.position;
            if (chasing && (!player || Vector3.Distance(pos, playerpos) < stop_chasing_dist))
            {
                //chasing = false;
                //GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 5f));
                //Debug.Log("passed em");
            }

            if (chasing)
            {
                float target = player.transform.position.z + Mathf.Sign(playerpos.z - passing_point.z) * Vector3.Distance(playerpos, passing_point);
                float x = (Time.time - start + x_start) / (1 / chase_speed);
                float point1 = pos.z;
                //Debug.Log(x.ToString() + ", " + target.ToString() + ", " + pos.z.ToString());
                pos.z = -1 / x + target;
                transform.position = pos;
            }
        }
    }
}