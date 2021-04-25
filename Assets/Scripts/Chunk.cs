using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeReference] private List<GameObject> _obstaclePrefabs;

    private SpriteRenderer _renderer;

    public float Height { get
        {
            return _renderer.bounds.extents.y * 2.0f;
        }
    }

    public float Y
    {
        get
        {
            return transform.position.y;
        }
    }

    public void Populate(bool init=false)
    {
        float stop = init ? 10.0f : 2.0f;
        for (float y = 2.0f; y <= Height - stop; y += 2.8f)
        {
            GameObject prefab = _obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Count)];
            GameObject obstacle = Instantiate(prefab, transform);
            float x = Random.Range(-3.0f, 3.0f);
            obstacle.transform.localPosition = new Vector3(x, (y + Random.Range(-0.8f, 0.8f) - (0.5f * Height)) / transform.localScale.y, 0.0f);
        }
    }

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
