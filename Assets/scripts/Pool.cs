using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private PositionManager _positionManager;
    [SerializeField] private CubeSpawner _cubeSpawner;

    private ObjectPool<GameObject> _pool;

    public void GetObject()
    {
        _pool.Get();
    }

    public void PutObjectBack(GameObject gameObject)
    {
        _pool.Release(gameObject);
    }

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => obj.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true);
    }

    private void ActionOnGet(GameObject obj)
    {
        obj.transform.position = _positionManager.GetRandomPosition();

        if (obj.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
        {
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.velocity = Vector3.zero;
            rigidbody.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        obj.SetActive(true);
    }
}
