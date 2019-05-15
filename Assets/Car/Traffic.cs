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
        public List<GameObject> cars = new List<GameObject>();

        void Start()
        {
            StartCoroutine(spawnCars());
        }

        IEnumerator spawnCars()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnFrequency / 10f);
                var car = Instantiate(car_prefab, transform.position.Clone(), Quaternion.identity);
                cars.Add(car);
            }
        }

        void Update()
        {
            foreach (GameObject car in cars)
            {
                if (!car || !car.active || car == null || !car.transform)
                {
                    cars.Remove(car);
                    Destroy(car);
                    break;
                }

                if (car && !car.GetComponent<Car>().IsGrounded) break;

                var newpos = car.transform.position.Clone();
                newpos += car.transform.TransformDirection(Vector3.forward * velocity);
                if (Vector3.Distance(newpos, endRoad) < 15)
                {
                    cars.Remove(car);
                    Destroy(car);
                    break;
                }
                car.GetComponent<Rigidbody>().MovePosition(newpos);
            }
        }
    }
}
