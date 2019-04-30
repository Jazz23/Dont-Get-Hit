using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;

namespace Assets.Car
{
    class Traffic : MonoBehaviour
    {
        Vector3 startpos;
        public float trans_start = 71.5f;
        public float trans_end = 79.5f;
        public float velocity = 3f;
        void Start()
        {
            startpos = transform.position;
        }

        void Update()
        {

            Vector3 pos = transform.position;
            pos.z += velocity;
            transform.position = pos;

            if (transform.position.z > trans_start)
            {
                //var color = GetComponent<Renderer>().material.color;
                //color.a = alpha(transform.position.z) / 255f;
                //GetComponent<Renderer>().material.color = color;
                Debug.Log(transform.position.z.ToString() + ", " + alpha(transform.position.z));
            }

            if (transform.position.z > trans_end)
            {
                DestroyObject(gameObject);
            }
        }

        float alpha(float x)
        {
            float y = 0;

            y = 255f / (trans_start - trans_end) * (x - trans_start) + 255f;

            return y;
        }
    }
}
