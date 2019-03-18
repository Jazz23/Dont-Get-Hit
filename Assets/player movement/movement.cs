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
    public float turn_speed = 0.2f;
    public float stamina = 100f;
    public float endurance = 100f;
    public float regeneration = 1f;
    public float power = 1f;
    public bool can_use_stamina = true;
    public float stretch = 10f;

    public float testy = 0;

    bool using_stamina
    {
        get { return Input.GetKey(KeyCode.LeftShift); }
    }
    public Transform wheel;

    private CharacterController _charController;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
        wheel = GetComponentsInChildren<Transform>().FirstOrDefault(x => x.name == "Circle_004");
    }

    void Update()
    {
        testy = (velocity + 0.001f).Logistic(acceleration, stretch) / 10f;
        handle_Stamina();

        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        velocity = deltaZ == 0 ? Mathf.Abs(velocity) <= friction ? 0 : velocity - Mathf.Sign(velocity) * friction : velocity;
        velocity = Mathf.Clamp(deltaZ * (velocity + 0.001f).Logistic(acceleration, stretch) / 10f + velocity, min_velocity, max_velocity);
        velocity += can_use_stamina.ToInt() * using_stamina.ToInt() * power * (velocity != 0).ToInt();

        Vector3 movement = new Vector3(0, 0, velocity);
        movement = Vector3.ClampMagnitude(movement, max_velocity);
        velocity = movement.magnitude;
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);

        transform.RotateAround(wheel.position, Vector3.up, deltaX * turn_speed * (Mathf.Abs(velocity) + 1));
    }

    void handle_Stamina()
    {
        if (stamina <= 0f) can_use_stamina = false;
        else if (stamina >= 20f) can_use_stamina = true;

        stamina = Mathf.Clamp(stamina + (using_stamina ? -1 / endurance : regeneration) * Time.deltaTime * 100f, 0, 100);
    }
}
