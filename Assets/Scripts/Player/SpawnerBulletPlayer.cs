using UnityEngine;

public class SpawnerBulletPlayer : Spawner<Bullet>
{
    [SerializeField] private Player _player;
    [SerializeField] private InputService _inputService;

    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _inputService.Attack += OnAttack;
    }

    private void OnDisable()
    {
        Reset();
        _inputService.Attack -= OnAttack;
    }

    private void OnAttack()
    {
        if (TryGetObject(out Bullet bullet))
            SetBullet(bullet);
    }

    private void SetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = _player.transform.position;
    }
}
