using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorDefiner : MonoBehaviour
{
    private bool _isColored = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out Platform platform) && _isColored == false)
        {
            Define();
            _isColored = true;
        }
    }

    private void Define()
    {
        float randomChannelOne = Random.Range(0f, 1f);
        float randomChannelTwo = Random.Range(0f, 1f);
        float randomChannelThree = Random.Range(0f, 1f);

        gameObject.GetComponent<Renderer>().material.color = new Color(randomChannelOne, randomChannelTwo, randomChannelThree);
    }
}
