using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private float _distanceSinceLastIncrease = 0;

    [Header("Movement")]
    [SerializeField] 
    private float _initialSpeed = 10f;

    [SerializeField]
    private float _maxSpeed = 30f;

    [SerializeField] 
    private float _accelerationRate = 0.5f;

    [SerializeField] 
    private float _distancePerAcceleration = 100f;

    [Header("Limitations")]
    [SerializeField] 
    private float _maxVelocity = 50f;

    private float _currentSpeed;

    private void Start()
    {
        _distanceSinceLastIncrease = transform.position.z;

        _rigidbody = GetComponent<Rigidbody>();

        _currentSpeed = _initialSpeed;
    }

    private void FixedUpdate()
    {
        SpeedControl();

        _rigidbody.AddForce(transform.forward * _currentSpeed, ForceMode.Acceleration);

        if (_rigidbody.velocity.magnitude > _maxVelocity)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxVelocity;
        }
    }

    private void SpeedControl()
    {
        float _distanceTraveled = transform.position.z - _distanceSinceLastIncrease;

        if (_distanceTraveled >= _distancePerAcceleration / 2)
        {
            _distanceSinceLastIncrease = transform.position.z;

            float increment = _accelerationRate * Time.deltaTime;
            _currentSpeed = Mathf.Clamp(_currentSpeed + increment, _initialSpeed, _maxSpeed);

            Debug.Log("Upgrade Speed. Current Speed: " + _currentSpeed);
        }
    }
}