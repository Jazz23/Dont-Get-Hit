using UnityEngine;
using System.Collections;
using System.Linq;

// basic WASD-style movement control
// commented out line demonstrates that transform.Translate instead of charController.Move doesn't have collision detection

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class movement : MonoBehaviour
{
    public float max_speed = 6.0f;
    public float acceleration = 1f;
    public float velocity = 0f;
    public float gravity = -9.8f;
    public float friction = 0.3f;
    public float turn_speed = 0.2f;
    public Transform wheel;

    private CharacterController _charController;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
        wheel = GetComponentsInChildren<Transform>().FirstOrDefault(x => x.name == "Circle_004");
    }

    void Update()
    {
        //transform.RotateAround(wheel.transform.position, Vector3.up, speed / 3);
        //transform.Rotate(Vector3.up, speed / 3, Space.Self);
        //transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        velocity = Mathf.Clamp(deltaZ * acceleration + velocity, -1, max_speed);
        velocity = Mathf.Abs(velocity) <= friction ? 0 : velocity - Mathf.Sign(velocity) * friction;

        Vector3 movement = new Vector3(0, 0, velocity);
        movement = Vector3.ClampMagnitude(movement, max_speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);

        transform.RotateAround(wheel.position, Vector3.up, deltaX * turn_speed * (Mathf.Abs(velocity) + 1));
    }
}
