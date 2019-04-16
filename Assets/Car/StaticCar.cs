using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using static Assets.Binaries.Binaries;

namespace Assets.Car
{
    public class StaticCar : MonoBehaviour
    {

        public float threshold = 3f;
        public bool door = Open;
        BasePlayer player;

        void Start()
        {
            player = transform.position.GetClosestPlayer();
            if (!player) player.static_cars.Add(this);
        }

        void Update()
        {
            if (Vector3.Distance(transform.position, player.transform.position) < threshold)
            {
                openDoor();
            }
        }

        void openDoor()
        {
            //Todo
        }
    }
}
