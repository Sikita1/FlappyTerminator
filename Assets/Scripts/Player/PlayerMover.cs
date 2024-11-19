using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;

    [SerializeField] private InputService _inputService;

    private Vector2 _startPosition;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void OnEnable()
    {
        _inputService.Jump += OnJump;
    }

    private void OnDestroy()
    {
        _inputService.Jump -= OnJump;
    }

    public void Reset()
    {
        transform.position = _startPosition;
        _rigidbody2D.velocity = Vector2.zero;
    }

    private void OnJump() =>
        _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
}
