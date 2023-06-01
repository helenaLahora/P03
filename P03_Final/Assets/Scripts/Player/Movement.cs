using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float WalkingSpeed = 2.5f;

    [SerializeField]
    float RunSpeed = 4f;

    [SerializeField]
    private float smoothing_Ground = 0.1f;

    [SerializeField]
    private float smoothing_Air = 0.01f;

    public float _lastVelocity_Y;
    public float _lastVelocity_X;
    public float _lastVelocity_Z;

    public float _jumpspeed;

    public Vector3 velocity = new Vector3(0, 0, 0);

    float Speed = 0;

    [SerializeField]
    InputSystem input;

    [SerializeField]
    public Camera playerCamera;

    [SerializeField]
    Salto saltito;

    PlayAnimation _playAnimation;

    CharacterController _charactercontroler;

    private Quaternion _smoothDampVelocity;

    private void FixedUpdate()
    {
        Move(input.Controles_H, input.Controles_V);
    }

    void Start()
    {
        _charactercontroler = GetComponent<CharacterController>();
        _playAnimation = GetComponent<PlayAnimation>();
    }

    public void Move(float horizontal, float vertical)
    {
        Speed = Run() ? RunSpeed : WalkingSpeed;

        Vector3 localInput = new Vector3(Speed * horizontal, 0, Speed * vertical);

        float targetVelocity_x = localInput.x * Speed;
        float targetVelocity_z = localInput.z * Speed;

        float smoothing = saltito.IsGrounded() ? smoothing_Ground : smoothing_Air;

        velocity.x = Mathf.Lerp(_lastVelocity_X, targetVelocity_x, smoothing);
        velocity.y = saltito.GetVelocity();
        velocity.z = Mathf.Lerp(_lastVelocity_Z, targetVelocity_z, smoothing);

        if (velocity != Vector3.zero)
        {
            _charactercontroler.Move(velocity * Time.deltaTime);
        }

        _lastVelocity_Y = velocity.y;
        _lastVelocity_X = velocity.x;
        _lastVelocity_Z = velocity.z;

        if (localInput != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(localInput);
            transform.rotation = SmoothDampQuaternion(transform.rotation, targetRotation, ref _smoothDampVelocity, smoothing);
        }

        _jumpspeed = Mathf.Sqrt((velocity.x * velocity.x) + (velocity.z * velocity.z));

        _playAnimation.setanimationmove(_jumpspeed);
    }

    private Quaternion SmoothDampQuaternion(Quaternion current, Quaternion target, ref Quaternion currentVelocity, float smoothTime)
    {
        float smoothTimeClamped = Mathf.Max(0.0001f, smoothTime);
        float maxSpeed = Mathf.Infinity;
        float deltaTime = Time.deltaTime;
        Quaternion result = Quaternion.identity;

        result.x = Mathf.SmoothDamp(current.x, target.x, ref currentVelocity.x, smoothTimeClamped, maxSpeed, deltaTime);
        result.y = Mathf.SmoothDamp(current.y, target.y, ref currentVelocity.y, smoothTimeClamped, maxSpeed, deltaTime);
        result.z = Mathf.SmoothDamp(current.z, target.z, ref currentVelocity.z, smoothTimeClamped, maxSpeed, deltaTime);
        result.w = Mathf.SmoothDamp(current.w, target.w, ref currentVelocity.w, smoothTimeClamped, maxSpeed, deltaTime);

        return result.normalized;
    }

    public bool Run()
    {
        return input.Controles_R;
    }
}