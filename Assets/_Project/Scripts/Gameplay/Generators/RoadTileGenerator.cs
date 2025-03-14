using System.Collections.Generic;
using UnityEngine;

public class RoadTileGenerator : MonoBehaviour
{
    private ForwardMovement _player;

    private float _tileLenght;

    private float _spawnDistance;

    [SerializeField]
    private List<Transform> _currentTiles;

    [SerializeField, Range(1, 5)]
    private int _startTilesCount = 3;

    [SerializeField]
    private List<Transform> _roadTiles = new List<Transform>();

    private void Start()
    {
        _player = FindObjectOfType<ForwardMovement>();

        _tileLenght = _roadTiles[0].transform.localScale.z;

        for (int i = 0; i < _startTilesCount; i++)
        {
            SpawnTile(new Vector3(0, 0, -_tileLenght * (_startTilesCount - i) * 10));
        }

        SpawnTile(new Vector3(0, 0, 0));
    }

    private void Update()
    {
        if (_player.transform.position.z > _spawnDistance)
        {
            _spawnDistance += _tileLenght * 10;
            SpawnTile(new Vector3(0, 0, _spawnDistance));
            DeleteTile();
        }
    }

    private void SpawnTile(Vector3 _spawnPosition)
    {
        Transform _roadTile = Instantiate(_roadTiles[0], _spawnPosition, Quaternion.identity);
        _currentTiles.Add(_roadTile);
    }

    private void DeleteTile()
    {
        Destroy(_currentTiles[0].gameObject);
        _currentTiles.RemoveAt(0);
    }
}