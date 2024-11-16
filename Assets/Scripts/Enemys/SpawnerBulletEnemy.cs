using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class SpawnerBulletEnemy : Spawner<Bullet>
{
    private Coroutine _coroutine;

    private Enemy _enemy;

    private WaitForSeconds _wait;
    private float _delay = 2f;

    private bool _isWork = true;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
        _enemy = GetComponent<Enemy>();
    }

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable()
    {
        _enemy.CameIntoAttackPosition += OnCameIntoAttackPosition;
    }

    private void OnDisable()
    {
        Reset();
        _enemy.CameIntoAttackPosition -= OnCameIntoAttackPosition;
    }

    public void OnCameIntoAttackPosition()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        if(_enemy.CanAttack)
            _coroutine = StartCoroutine(CreateObject());
    }

    private IEnumerator CreateObject()
    {
        while (_isWork)
        {
            if (TryGetObject(out Bullet bullet))
                SetBullet(bullet);

            yield return _wait;
        }
    }

    private void SetBullet(Bullet bullet)
    {
        bullet.gameObject.transform.position = transform.position;
        bullet.gameObject.SetActive(true);
    }
}
