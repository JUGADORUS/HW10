using System.Collections;
using UnityEngine;

public class Remover : MonoBehaviour
{
    [SerializeField] private Pool _pool;

    private int _minLiveTime = 2;
    private int _maxLiveTime = 5;
    private Cube _cube;

    private void Awake()
    {
        if(gameObject.TryGetComponent<Cube>(out Cube cube))
        {
            _cube = cube;
        }
    }

    private void OnEnable()
    {
        _cube.TouchedPlatform += RemoveCube;
    }

    private void OnDisable()
    {
        _cube.TouchedPlatform -= RemoveCube;
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    private void RemoveCube()
    {
        StartCoroutine(Remove());
    }

    private IEnumerator Remove()
    {
        int liveTime = Random.Range(_minLiveTime, _maxLiveTime);
        yield return new WaitForSeconds(liveTime);
        _pool.PutObjectBack(_cube);
        _pool.GetObject();
    }
}
