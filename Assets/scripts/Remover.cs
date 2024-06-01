using System.Collections;
using UnityEngine;

public class Remover : MonoBehaviour
{
    [SerializeField] public Pool Pool;

    private int _minLiveTime = 2;
    private int _maxLiveTime = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out Platform platform))
        {
            StartCoroutine(Remove());
        }
    }

    private IEnumerator Remove()
    {
        int liveTime = Random.Range(_minLiveTime, _maxLiveTime);
        yield return new WaitForSeconds(liveTime);
        Pool.PutObjectBack(gameObject);
        Pool.GetObject();
    }
}
