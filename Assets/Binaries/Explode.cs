using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Binaries;
using UnityEngine;

namespace Assets.Binaries
{
    public static partial class Binaries
    {
        //public static Material mat;
        public static void Explode(this GameObject obj, int severity)
        {
            Material mat = Resources.Load("blood", typeof(Material)) as Material;
            Vector3 pos = obj.transform.position;
            List<GameObject> spheres = new List<GameObject>();

            for (int i = 0; i < severity; i++)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.AddComponent<Rigidbody>();
                sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                sphere.transform.position = pos;
                sphere.GetComponent<Renderer>().material = mat;
                foreach (GameObject sfere in spheres)
                    Physics.IgnoreCollision(sphere.GetComponent<Collider>(), sfere.GetComponent<Collider>());
                foreach (Collider col in obj.GetComponentsInChildren<Collider>())
                    Physics.IgnoreCollision(sphere.GetComponent<Collider>(), col);
                spheres.Add(sphere);

                float[] range = new float[2] { -150f, 150f };
                Vector3 randomForce = new Vector3(UnityEngine.Random.Range(range[0], range[1]), UnityEngine.Random.Range(range[0], range[1]), UnityEngine.Random.Range(range[0], range[1]));
                sphere.GetComponent<Rigidbody>().AddForce(randomForce);
            }
        }
    }
}
