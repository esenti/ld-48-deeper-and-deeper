using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] private Chunk _chunkPrefab;
    [SerializeField] private TMP_Text _depthText;

    private Queue<Chunk> _chunks = new Queue<Chunk>();
    private float _speed = 3.5f;
    private float _depth = 0.0f;

    void Start()
    {
        var chunk = Instantiate(_chunkPrefab);
        chunk.transform.position = new Vector3(0, -(0.5f * chunk.Height - 5.0f), 0);
        chunk.Populate(true);
        _chunks.Enqueue(chunk);
    }

    void Update()
    {
        _speed += Time.deltaTime * 0.1f;

        foreach (Chunk chunk in _chunks)
        {
            chunk.transform.position += Vector3.up * Time.deltaTime * _speed;
            _depth += Time.deltaTime * _speed * 0.2f;
            _depthText.text = $"{_depth:0.00}m";
        }

        Chunk topChunk = _chunks.Peek();
        if (topChunk.Y > 0.0f && _chunks.Count < 2)
        {
            var chunk = Instantiate(_chunkPrefab);
            chunk.transform.position = new Vector3(0, -(topChunk.Height - topChunk.Y), 0);
            chunk.Populate();
            _chunks.Enqueue(chunk);
        }

        if (topChunk.Y > 32.0f)
        {
            _chunks.Dequeue();
            Destroy(topChunk.gameObject);
        }
    }
}
