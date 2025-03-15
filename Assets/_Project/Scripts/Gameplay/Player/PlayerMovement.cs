using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private float _distanceSinceLastIncrease = 0f, _horizontalMovement, _currentSpeed;

    [Header("Movement")]
    [SerializeField] 
    private float _initialSpeed = 10f;

    [SerializeField] 
    private float _maxSpeed = 30f;

    [SerializeField] 
    private float _accelerationRate = 0.5f;

    [SerializeField] 
    private float _distancePerAcceleration = 100f;

    [SerializeField] 
    private float _horizontalSpeed = 10f;

    [SerializeField] 
    private float _horizontalDampening = 0.5f;

    [Header("Limitations")]
    [SerializeField] 
    private float _maxVelocity = 50f;

    [Header("Tilt")]
    [SerializeField] 
    private Transform _body;

    [SerializeField] 
    private float _tiltAmount = 10f;

    [SerializeField] 
    private float _tiltSpeed = 5f;

    private Quaternion _targetRotation;

    private void Start()
    {
        _distanceSinceLastIncrease = transform.position.z;
        _rigidbody = GetComponent<Rigidbody>();
        _currentSpeed = _initialSpeed;

        _rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        _horizontalMovement = InputManager._instance._inputActions.Player.Movement.ReadValue<Vector2>().x;
        _targetRotation = Quaternion.Euler(0, 0, -_horizontalMovement * _tiltAmount);
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(transform.forward * _currentSpeed, ForceMode.Acceleration);

        SpeedControl();
        HorizontalMovement();

        Tilt();

        LimitVelocity();
    }

    private void SpeedControl()
    {
        float _distanceTraveled = transform.position.z - _distanceSinceLastIncrease;

        if (_distanceTraveled >= _distancePerAcceleration)
        {
            _distanceSinceLastIncrease = transform.position.z;
            float increment = _accelerationRate * Time.fixedDeltaTime;
            _currentSpeed = Mathf.Clamp(_currentSpeed + increment, _initialSpeed, _maxSpeed);
        }
    }

    private void HorizontalMovement()
    {
        Vector3 horizontalForce = transform.right * _horizontalMovement * _horizontalSpeed;
        _rigidbody.AddForce(horizontalForce, ForceMode.Acceleration);

        Vector3 horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0;
        horizontalVelocity.z = 0;
        horizontalVelocity = Vector3.Lerp(horizontalVelocity, Vector3.zero, _horizontalDampening * Time.fixedDeltaTime);

        _rigidbody.velocity = new Vector3(horizontalVelocity.x, _rigidbody.velocity.y, _rigidbody.velocity.z);
    }


    private void Tilt()
    {
        _body.rotation = Quaternion.RotateTowards(_body.rotation, _targetRotation, _tiltSpeed * Time.deltaTime);
    }

    private void LimitVelocity()
    {
        if (_rigidbody.velocity.magnitude > _maxVelocity)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxVelocity;
        }
    }
}