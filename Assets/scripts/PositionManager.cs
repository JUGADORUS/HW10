using UnityEngine;

public class PositionManager : MonoBehaviour
{
    [SerializeField] private int _minPostionOfPlatform;
    [SerializeField] private int _maxPostionOfPlatform;
    [SerializeField] private int _minHeight;
    [SerializeField] private int _maxHeight;

    public Vector3 GetRandomPosition()
    {
        int positionOfCubeX = Random.Range(_minPostionOfPlatform, _maxPostionOfPlatform);
        int positionOfCubeZ = Random.Range(_minPostionOfPlatform, _maxPostionOfPlatform);
        int positionOfCubeY = Random.Range(_minHeight, _maxHeight);

        return new Vector3(positionOfCubeX, positionOfCubeY, positionOfCubeZ);
    }
}
