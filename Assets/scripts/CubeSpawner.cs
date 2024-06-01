using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] public int AmountCubes;
    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] private PositionManager _positionManager;
    [SerializeField] private Pool _pool;

    void Start()
    {
        SpawnCubes();
    }

    private void SpawnCubes()
    {
        if (_objectToSpawn.TryGetComponent<Remover>(out Remover remover))
        {
            _objectToSpawn.GetComponent<Remover>().Pool = _pool;
        }

        for (int i = 0; i < AmountCubes; i++)
        {
            Instantiate(_objectToSpawn, _positionManager.GetRandomPosition(), Quaternion.identity);
        }
    }
}
