using UnityEngine;

public class Bullet : MonoBehaviour, IInteractible
{
    [SerializeField] protected BulletCollisionHandler Handler;

    [SerializeField] private float _speed;
    [SerializeField] private int _direction;

    private void Update()
    {
        Fly();
    }

    private void OnEnable()
    {
        Handler.CollisionDetected += CollisionDetected;
    }

    private void OnDisable()
    {
        Handler.CollisionDetected -= CollisionDetected;
    }

    protected void Fly() =>
        transform.position = new Vector2(transform.position.x + (_speed * _direction) * Time.deltaTime,
                                         transform.position.y);

    protected virtual void CollisionDetected(IInteractible interacteble)
    {
        if (interacteble is ZoneBullet)
        {
            gameObject.SetActive(false);
            Reset();
        }
    }

    private void Reset() =>
        transform.position = Vector2.zero;
}
