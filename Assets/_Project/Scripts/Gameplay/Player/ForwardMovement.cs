using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5;

    private void Update()
    {
        transform.Translate(transform.forward * _movementSpeed * Time.deltaTime);
    }
}