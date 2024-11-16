using UnityEngine;

public class SpawnerBulletPlayer : Spawner<Bullet>
{
    [SerializeField] private Player _player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            CreateObject();
    }

    private void CreateObject()
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
