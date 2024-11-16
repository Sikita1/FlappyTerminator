public class EnemyBullet : Bullet
{
    protected override void CollisionDetected(IInteractible interacteble)
    {
        base.CollisionDetected(interacteble);

        if (interacteble is Player)
            gameObject.SetActive(false);
    }
}
