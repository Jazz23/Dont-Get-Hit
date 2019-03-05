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
    public float speed = 0f;
    public float gravity = -9.8f;
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
        float deltaX = Input.GetAxis("Horizontal") * max_speed;
        float deltaZ = Input.GetAxis("Vertical") * max_speed;
        Vector3 movement = new Vector3(0, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, max_speed);

        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);

        transform.RotateAround(wheel.position, Vector3.up, deltaX * max_speed);
    }
}
