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
        public static float NormalizeAngle(float __angle, float __normal_range = 360)
        {
            float ang = Math.Abs(__angle);
            ang %= __normal_range;

            return __angle < 0 ? -ang : ang;
        }

        /// <summary>
        /// This was pasted from the intrenet, this gets us the values in the inspector. Useful for customizing target and starting angles.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static float WrapAngle(this float angle)
        {
            angle %= 360;
            return angle > 180 ? angle - 360 : angle;
        }

        public static float UnwrapAngle(this float angle)
        {
            if (angle >= 0)
                return angle;
            angle = -angle % 360;
            return 360 - angle;
        }

        public static void Explode(this GameObject obj, int severity)
        {
            Vector3 pos = obj.transform.position;
        }

        public static int ToInt(this bool bol)
        {
            return bol ? 1 : 0;
        }

        public static float Logistic(this float flot, float upper, float stretch)
        {
            return upper / (1f + Mathf.Pow((float)Math.E, -flot / stretch));
        }
    }
}
