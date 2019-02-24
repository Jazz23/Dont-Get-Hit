using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Binaries
{
    public static class binaries
    {
        public static Vector3 GetDirection(Quaternion rotation, float fl_translatespeed)
        {
            float angle = rotation.y;
            float x_translate = Mathf.Cos(angle) * fl_translatespeed;
            float z_translate = Mathf.Sin(angle) * fl_translatespeed;
            return new Vector3(x_translate, 0, z_translate);
        }

        public static float ToRadians(this float _float)
        {
            return _float / (180 / Mathf.PI);
        }

        public static float ToDegrees(this float _float)
        {
            return _float * (180 / Mathf.PI);
        }
    }
}
