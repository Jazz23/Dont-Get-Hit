using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public static class __BasePlayer
    {

        public static int i_health;
        
        public static float fl_maxVel;
        public static float fl_minVel;
        public static float fl_stamina;
        public static float fl_speed;
        public static float fl_velocity;
        public static float fl_acceleration;
        public static float fl_yaw;
        public static float fl_pitch;
        public static float fl_friction;
        
        public static bool b_useStamina;
    }
    public static class GameSettings
    {
        public static int i_tickcount;
    }
}
