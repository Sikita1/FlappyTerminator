public class PlayerBullet : Bullet
{
    protected override void CollisionDetected(IInteractible interacteble)
    {
        base.CollisionDetected(interacteble);

        if (interacteble is Enemy)
            gameObject.SetActive(false);
    }
}
