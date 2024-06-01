using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private PositionManager _positionManager;
    [SerializeField] private ColorDefiner _colorDefiner;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => OnGetAct(obj),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true);
    }

    public void GetObject()
    {
        _pool.Get();
    }

    public void PutObjectBack(Cube cube)
    {
        _pool.Release(cube);
    }

    private void OnGetAct(Cube obj)
    {
        obj.transform.position = _positionManager.GetRandomPosition();

        if (obj.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
        {
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.velocity = Vector3.zero;
            rigidbody.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        obj.gameObject.SetActive(true);
        obj.SetDefaultColor();
    }
}
