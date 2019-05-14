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

            Debug.Log("Here1");
            GameObject.Find("Game Monitor").GetComponent<gamemonitor>().GoToCourt(GetComponent<movement>().velocity, collision.gameObject.name.Contains("Car"));

            GetComponent<BasePlayer>().Dead = true;
            gameObject.AddComponent<Rigidbody>();
            float[] range = new float[2] { 500f, 1000f };
            Vector3 randomForce = new Vector3(UnityEngine.Random.Range(range[0], range[1]), UnityEngine.Random.Range(range[0], range[1]), UnityEngine.Random.Range(range[0], range[1]));
            GetComponent<Rigidbody>().AddForce(randomForce);
        }
    }
}
