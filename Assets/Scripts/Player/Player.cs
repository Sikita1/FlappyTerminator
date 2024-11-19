using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour, IInteractible
{
    [SerializeField] private ScoreCounter _scoreCounter;

    private PlayerMover _playerMover;
    private PlayerCollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _handler = GetComponent<PlayerCollisionHandler>(); 
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    public void Reset() => 
        _playerMover.Reset();

    private void ProcessCollision(IInteractible interactible)
    {
        if (interactible is Earth || interactible is EnemyBullet)
        {
            GameOver?.Invoke();
            _scoreCounter.Reset();
        }
    }
}
