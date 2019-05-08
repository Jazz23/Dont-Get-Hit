using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.player_movement
{
    [RequireComponent(typeof(CharacterController))]
    class collide : MonoBehaviour
    {
        void OnControllerColliderHit(ControllerColliderHit collision)
        {
            if (collision.gameObject.tag == "NoCollide") return;
            if (collision.gameObject.name.ToUpper().Contains("CURB") || collision.gameObject.name.ToUpper().Contains("ROAD")) return;

            GetComponent<BasePlayer>().dead = true;
            gameObject.AddComponent<Rigidbody>();
            float[] range = new float[2] { 500f, 1000f };
            Vector3 randomForce = new Vector3(UnityEngine.Random.Range(range[0], range[1]), UnityEngine.Random.Range(range[0], range[1]), UnityEngine.Random.Range(range[0], range[1]));
            GetComponent<Rigidbody>().AddForce(randomForce);
        }
    }
}
