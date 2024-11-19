using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : Spawner<Enemy>
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Transform _shootingPosition;

    [SerializeField] private GameObject _up;
    [SerializeField] private GameObject _down;

    private Coroutine _coroutine;

    private WaitForSeconds _wait;
    private float _delay = 1f;

    private List<Enemy> _activeEnemys = new List<Enemy>();

    private bool _isWork = true;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    protected override void Start()
    {
        base.Start();
    }

    public void StartSpawn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CreateObject());
    }

    public void ZeroOut()
    {
        Reset();

        foreach (var enemy in _activeEnemys)
            enemy.Died -= OnDied;
    }

    private IEnumerator CreateObject()
    {
        while (_isWork)
        {
            yield return _wait;

            if (TryGetObject(out Enemy enemy))
                SetObject(enemy);
        }
    }

    private void SetObject(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = GetRandomPosition();
        enemy.SetAttackPosition(_shootingPosition);
        enemy.Died += OnDied;
        _activeEnemys.Add(enemy);
    }

    private void OnDied(Enemy enemy)
    {
        _scoreCounter.Add();
        enemy.Died -= OnDied;
        _activeEnemys.Remove(enemy);
    }

    private Vector2 GetRandomPosition()
    {
        float randomPositionY = Random.Range(_down.transform.position.y, _up.transform.position.y);

        return new Vector2(_down.transform.position.x, randomPositionY);
    }
}
