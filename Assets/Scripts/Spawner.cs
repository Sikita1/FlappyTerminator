using UnityEngine;

public class Spawner<T> : ObjectPool<T> where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    protected virtual void Start()
    {
        Initialize(_prefab);
    }

    public T GetPrefab() =>
        _prefab;

    public void Reset() =>
        Reset(_prefab);
}
