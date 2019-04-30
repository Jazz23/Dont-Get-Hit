using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Binaries;

namespace Assets.Car
{
    public class StaticCar : MonoBehaviour
    {

        public float threshold = 3f;
        public bool door = Binaries.Binaries.Open;
        BasePlayer player;
        CarYeet moving_car;

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
