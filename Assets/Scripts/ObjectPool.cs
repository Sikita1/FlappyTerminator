using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<T> _pool = new List<T>();

    public void Initialize(T prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            var spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    public bool TryGetObject(out T result)
    {
        result = _pool.FirstOrDefault(unit => unit.gameObject.activeSelf == false);

        return result != null;
    }

    public void Reset(T prefab)
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            prefab = _pool[i];
            prefab.transform.position = Vector2.zero;
            prefab.gameObject.SetActive(false);
        }
    }
}
