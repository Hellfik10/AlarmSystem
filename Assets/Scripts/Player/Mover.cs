using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(InputHandler))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10;
    [SerializeField] private float _rotateSpeed = 90;

    private InputHandler _inputHandler;

    private void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
    }

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float rotation = _inputHandler.Horizontal;

        transform.Rotate(rotation * _rotateSpeed * Time.deltaTime * Vector3.up);
    }

    private void Move()
    {
        float direction = _inputHandler.Vertical;
        float distance = direction * _moveSpeed * Time.deltaTime;

        transform.Translate(distance * Vector3.forward);
    }
}