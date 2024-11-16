using System;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    public event Action<IInteractible> CollisionDetected;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractible interactible))
            CollisionDetected?.Invoke(interactible);
    }
}
