using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Binaries;

namespace Assets.Car
{
    class Car : MonoBehaviour
    {
        public float velocity;
        public Vector3 endRoad;
        public bool IsGrounded
        {
            get
            {
                return Physics.Raycast(GetComponent<Collider>().bounds.center, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.1f);
            }
            private set { }
        }

        void Start()
        {
            transform.LookAt(endRoad);
        }

        void Update()
        {
            if (!IsGrounded || gamemonitor.BP.transform.position.magnitude == 0) return;

            var newpos = transform.position.Clone();
            newpos += transform.TransformDirection(Vector3.forward * velocity) * Time.deltaTime;
            if (Vector3.Distance(newpos, gamemonitor.BP.transform.position) > 200)
            {
                Destroy(gameObject);
            }
            GetComponent<Rigidbody>().MovePosition(newpos);
        }
    }
}
