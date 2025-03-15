using System.Collections.Generic;
using UnityEngine;

public class RoadTileGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    private float _tileLenght;

    private float _spawnDistance;

    [SerializeField]
    private int _spawnTileCount = 1;

    [SerializeField]
    private List<Transform> _currentTiles;

    [SerializeField, Range(1, 5)]
    private int _startTilesCount = 3;

    [SerializeField, Range(0, 1)]
    private int _spawnDirection = 0;

    [SerializeField]
    private List<Transform> _roadTiles = new List<Transform>();

    private void Start()
    {
        _tileLenght = _roadTiles[0].transform.localScale.z * 10;

        for (int i = 0; i < _startTilesCount; i++)
        {
            int _spawnIndex = _spawnDirection == 0 ? (_startTilesCount - i) : i;

            SpawnTile(new Vector3(0, 0, _tileLenght * _spawnDirection * _spawnIndex));

            if (_spawnDirection == 1 && i < _startTilesCount - 1)
                _spawnDistance += _tileLenght;
        }

        if (_spawnDirection == 0)
            SpawnTile(new Vector3(0, 0, 0));
    }

    private void Update()
    {
        if (_player.transform.position.z > _spawnDistance - _tileLenght * (_spawnTileCount - 1))
        {
            for (int i = 0; i < _spawnTileCount; i ++)
            {
                _spawnDistance += _tileLenght;
                SpawnTile(new Vector3(0, 0, _spawnDistance));
            }

            if (_spawnDirection == 0)
                DeleteTile(0);
        }

        if (_player.transform.position.z - _currentTiles[0].position.z >= 100 && _spawnDirection == 1)
            DeleteTile(0);
    }

    private void SpawnTile(Vector3 _spawnPosition)
    {
        Transform _roadTile = Instantiate(_roadTiles[0], _spawnPosition, Quaternion.identity);
        _currentTiles.Add(_roadTile);
    }

    private void DeleteTile(int _deletedTileIndex)
    {
        Destroy(_currentTiles[_deletedTileIndex].gameObject);
        _currentTiles.RemoveAt(_deletedTileIndex);
    }
}