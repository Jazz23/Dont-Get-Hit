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
    public float max_velocity = 1f;
    public float min_velocity = -0.005f;
    public float velocity = 0f;
    public float acceleration = 0.15f;

    public float gravity = -9.8f;
    public float friction = 0.0005f;
    public float break_speed = 0.5f;
    public float turn_speed = 0.2f;

    public float stamina = 100f;
    public float endurance = 100f;
    public float regeneration = 1f;
    public float power = 1f;
    public bool can_use_stamina = true;

    public float leanSpeed = 1f;

    public float testy = 0;

    bool using_stamina
    {
        get { return can_use_stamina && Input.GetKey(KeyCode.LeftShift); }
    }

    bool breaking
    {
        get { return Input.GetKey(KeyCode.Space); }
    }

    public Transform wheel;
    private CharacterController _charController;
    BasePlayer _basePlayer;
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        wheel = GetComponentsInChildren<Transform>().FirstOrDefault(x => x.name == "Circle_004");
        _basePlayer = gameObject.GetComponent<BasePlayer>();
        if (!_basePlayer)//error handling needed
            return;
    }

   
    void Update()
    {
        handle_Stamina();
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        float boost = using_stamina.ToInt() * power * (velocity > 0).ToInt();

        if (deltaZ > 0)
        {
            float c = 0.001f;
            float x = Binaries.LogisticInvs(velocity + c, max_velocity + c, acceleration) + Time.deltaTime * acceleration;
            velocity = Binaries.Logistic(x, max_velocity + c, acceleration);
        }
        else
        {
            float mew = friction + breaking.ToInt() * break_speed;
            velocity = Mathf.Abs(velocity) <= mew ? 0 : velocity - Mathf.Sign(velocity) * mew;
            velocity += deltaZ * 0.005f;
            velocity = Mathf.Clamp(velocity, min_velocity, Mathf.Infinity);
        }

        Vector3 movement = new Vector3(0, 0, velocity);
        movement.y = gravity;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);

        transform.RotateAround(wheel.position, Vector3.up, deltaX * turn_speed * (Mathf.Abs(velocity) + 3));
    }

    void handle_Stamina()
    {
        if (stamina <= 0f) can_use_stamina = false;
        else if (stamina >= 20f) can_use_stamina = true;

        stamina = Mathf.Clamp(stamina + (using_stamina ? -1 / endurance : regeneration) * Time.deltaTime * 100f, 0, 100);
    }
}
