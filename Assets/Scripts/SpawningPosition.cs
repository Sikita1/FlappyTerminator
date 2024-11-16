using UnityEngine;

public class SpawningPosition : MonoBehaviour
{
    public bool Status { get; private set; }

    public bool Authorize(Enemy enemy)
    {
        enemy.Died += OnEnemyDied;
        return Status = true;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        Prohibit();
    }

    private bool Prohibit() =>
        Status = false;
}
