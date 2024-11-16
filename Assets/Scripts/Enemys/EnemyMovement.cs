using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(EnemyCollisionHandler))]
public class EnemyMovement : MonoBehaviour, IInteractible
{
    [SerializeField] private float _speed;

    private Enemy _enemy;
    private Vector2 _startPosition;

    private EnemyCollisionHandler _handler;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _handler = GetComponent<EnemyCollisionHandler>();
    }

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
                                                 new Vector2(_enemy.AttackPosition.position.x,
                                                 transform.position.y),
                                                 _speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _enemy.Died += OnReset;
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _enemy.Died -= OnReset;
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void OnReset(Enemy enemy) =>
        _enemy.transform.position = _startPosition;

    private void ProcessCollision(IInteractible interactible)
    {
        if(interactible is ShootingPosition)
            _enemy.AuthorizeAttack();
    }
}
