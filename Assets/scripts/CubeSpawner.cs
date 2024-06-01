using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _amountCubes;
    [SerializeField] private Cube _cube;
    [SerializeField] private PositionManager _positionManager;
    [SerializeField] private Pool _pool;
    [SerializeField] private Remover _remover;

    private void Awake()
    {
        _remover = _cube.GetComponent<Remover>();
    }

    private void Start()
    {
        SpawnCubes();
    }

    private void SpawnCubes()
    {
        if (_cube.TryGetComponent<Remover>(out Remover remover))
        {
           _remover.Pool = _pool;
        }

        for (int i = 0; i < _amountCubes; i++)
        {
            Instantiate(_cube, _positionManager.GetRandomPosition(), Quaternion.identity);
        }
    }
}
