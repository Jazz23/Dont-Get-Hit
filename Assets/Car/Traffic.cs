using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;
using Assets.Binaries;

namespace Assets.Car
{
    class Traffic : MonoBehaviour
    {
        public GameObject car_prefab;
        public float velocity = 5f;
        public float spawnFrequency = 1f;
        public Vector3 endRoad;
        public float renderingDistance = 200f;

        void Start()
        {
            InitialSpawn();
            StartCoroutine(spawnCars());
        }

        void InitialSpawn()
        {
            if (!gamemonitor.BP)
            {
                StartCoroutine(delay(0.05f));
                return;
            }
            Vector3 playerpos = gamemonitor.BP.transform.position;

            //if (Vector3.Distance(transform.position, playerpos) > 200f) return;

            float dist_appart = velocity * spawnFrequency / 10f + 7.444f;

            for (float i = 0; i < Vector3.Distance(transform.position, endRoad/*Vector3.LerpUnclamped(transform.position, playerpos, Vector3.Distance(transform.position, playerpos) + 50f)*/); i += dist_appart)
            {
                createCar(Vector3.MoveTowards(transform.position, endRoad, i));
            }
        }

        void createCar(Vector3 pos)
        {
            var car = Instantiate(car_prefab, pos, Quaternion.identity);
            var carr = car.GetComponent<Car>();
            carr.endRoad = endRoad;
            carr.velocity = velocity;
            carr.renderingDistance = renderingDistance;
        }

        IEnumerator delay(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            InitialSpawn();
        }

        IEnumerator spawnCars()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnFrequency);
                createCar(transform.position);
            }
        }
    }
}
