using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorDefiner : MonoBehaviour
{
    private Renderer _renderer;
    private Cube _cube;

    private void Awake()
    {
        _renderer = gameObject.GetComponent<Renderer>();

        if (gameObject.TryGetComponent<Cube>(out Cube cube))
        {
            _cube = cube;
        }
    }

    private void OnEnable()
    {
        _cube.TouchedPlatform += Define;
    }

    private void OnDisable()
    {
        _cube.TouchedPlatform -= Define;
    }

    public void SetMaterial(Material material)
    {
        _renderer.material = material;
    }

    private void Define()
    {
        float randomChannelOne = Random.Range(0f, 1f);
        float randomChannelTwo = Random.Range(0f, 1f);
        float randomChannelThree = Random.Range(0f, 1f);

        _renderer.material.color = new Color(randomChannelOne, randomChannelTwo, randomChannelThree);
    }
}
