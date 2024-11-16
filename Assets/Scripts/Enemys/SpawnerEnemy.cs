using System.Collections;
using UnityEngine;

public class SpawnerEnemy : Spawner<Enemy>
{
    [SerializeField] private Transform _shootingPosition;

    [SerializeField] private GameObject _up;
    [SerializeField] private GameObject _down;

    private Coroutine _coroutine;

    private WaitForSeconds _wait;
    private float _delay = 1f;

    private bool _isWork = true;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    protected override void Start()
    {
        base.Start();

        if (_coroutine != null)
            StopCoroutine(_coroutine);
            
        _coroutine = StartCoroutine(CreateObject());
    }

    public void ZeroOut() =>
        Reset();

    private IEnumerator CreateObject()
    {
        while (_isWork)
        {
            if (TryGetObject(out Enemy enemy))
                SetObject(enemy);

            yield return _wait;
        }
    }

    private void SetObject(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = GetRandomPosition();
        enemy.SetAttackPosition(_shootingPosition);
    }

    private Vector2 GetRandomPosition()
    {
        float randomPositionY = Random.Range(_down.transform.position.y, _up.transform.position.y);

        return new Vector2(_down.transform.position.x, randomPositionY);
    }
}
