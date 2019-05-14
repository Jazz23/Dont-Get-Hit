using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Car
{
    class Car : MonoBehaviour
    {
        public bool IsGrounded
        {
            get
            {
                return Physics.Raycast(GetComponent<Collider>().bounds.center, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.1f);
            }
            private set { }
        }
    }
}
