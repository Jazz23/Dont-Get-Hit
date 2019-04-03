using UnityEngine;
using System.Collections;
using System.Linq;
using Assets.Binaries;

// basic WASD-style movement control
// commented out line demonstrates that transform.Translate instead of charController.Move doesn't have collision detection

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class movement : MonoBehaviour
{
    public float max_velocity = 6.0f;
    public float min_velocity = -1f;
    public float acceleration = 1f;
    public float velocity = 0f;
    public float gravity = -9.8f;
    public float friction = 0.3f;
    public float turn_speed = 2f;
    public float stamina = 100f;
    public float leanSpeed = 1f;
    public Transform wheel;

    private CharacterController _charController;
    private BasePlayer _basePlayer;
    private Transform _leanObj;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
        wheel = GetComponentsInChildren<Transform>().FirstOrDefault(x => x.name == "Circle_004");
        _basePlayer = gameObject.GetComponent<BasePlayer>();
        if (!_basePlayer)//error handling needed
            return;

        foreach (Transform child in transform)
            if (child.tag == "LeanBase")
            {
                _leanObj = child;
                break;
            }
        if (!_leanObj)//error handling needed
            return;
    }

    binaries.aActions HandleLeaning(out float leanx)
    {
        binaries.aActions status = binaries.aActions.NULLACTION;
        // _basePlayer.LeanFloat +=
        if (Input.GetKey(KeyCode.Q))
        {
            status = binaries.aActions.LEANLEFT;
            leanx = leanSpeed;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            status = binaries.aActions.LEANRIGHT;
            leanx = leanSpeed;
        }
        else //check if we are close to 0 so there is no jittering
        {
            status = binaries.aActions.NULLACTION;
            leanx = -((Mathf.Abs(_basePlayer.LeanAngle) / _basePlayer.LeanAngle) * leanSpeed);
        }
        return status;
    }

    void Update()
    {
        float leanX = 0.0f;
        _basePlayer.PlayerActions |= HandleLeaning(out leanX);
        transform.RotateAround(_leanObj.position, Vector3.forward, leanX);


        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        velocity = Mathf.Clamp(deltaZ * acceleration + velocity, min_velocity, max_velocity);
        velocity = Mathf.Abs(velocity) <= friction ? 0 : velocity - Mathf.Sign(velocity) * friction;

        Vector3 movement = new Vector3(0, 0, velocity);
        movement = Vector3.ClampMagnitude(movement, max_velocity);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);

        float newmax = (max_velocity / 2f + max_velocity);
        float _turnspd = (newmax - velocity) / newmax;

        transform.RotateAround(wheel.position, Vector3.up, deltaX * _turnspd/*turn_speed / (Mathf.Abs(velocity)/  + 1)*/);
    }
}
