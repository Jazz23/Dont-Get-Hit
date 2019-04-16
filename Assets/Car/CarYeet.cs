using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Binaries;

namespace Assets.Car
{
    public class CarYeet : MonoBehaviour
    {
        BasePlayer player;
        
        void Start()
        {
            player = transform.position.GetClosestPlayer();
        }

        void Update()
        {
            if (!player) return;

            Vector3 pos = transform.position;
            //float player2car = Vector3.Distance(player.transform.position, )
        }
    }
}