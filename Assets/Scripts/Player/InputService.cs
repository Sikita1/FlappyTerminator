using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    private const KeyCode KeySpace = KeyCode.Space;
    private const KeyCode KeyAttack = KeyCode.Q;

    public event Action Jump;
    public event Action Attack;

    private void Update()
    {
        Bounce();
        Assault();
    }

    private void Bounce()
    {
        if(Input.GetKeyDown(KeySpace))
            Jump?.Invoke();
    }

    private void Assault()
    {
        if (Input.GetKeyDown(KeyAttack))
            Attack?.Invoke();
    }
}
