using System;
using UnityEngine;

[RequireComponent(typeof(EnemyCollisionHandler))]
public class Enemy : MonoBehaviour, IInteractible
{
    private EnemyCollisionHandler _handler;

    public event Action<Enemy> Died;
    public event Action CameIntoAttackPosition;

    public Transform AttackPosition { get; private set; }
    public bool CanAttack { get; private set; } = false;

    private void Awake()
    {
        _handler = GetComponent<EnemyCollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    public Transform SetAttackPosition(Transform position) =>
        AttackPosition = position;

    public void AuthorizeAttack()
    {
        CanAttack = true;
        CameIntoAttackPosition?.Invoke();
    }

    private void Die()
    {
        CanAttack = false;
        Died?.Invoke(this);
        gameObject.SetActive(false);;
    }

    private void ProcessCollision(IInteractible interactible)
    {
        if (interactible is PlayerBullet)
            Die();
    }
}
