using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _coin;

    private Transform[] _spawnPoints;
    private int _currentSpawnPoint = 0;

    private void Start()
    {
        _spawnPoints = new Transform[_spawnPoint.childCount];

        for(int i = 0; i < _spawnPoint.childCount; i++)
        {
            _spawnPoints[i] = _spawnPoint.GetChild(i);
        }

        StartCoroutine(CreateCoin());
    }

    private IEnumerator CreateCoin()
    {        
        if(_currentSpawnPoint == _spawnPoint.childCount)
        {
            yield break;
        }

        Instantiate(_coin, _spawnPoints[_currentSpawnPoint]);
        _currentSpawnPoint++;
        Debug.Log(_currentSpawnPoint);

        yield return new WaitForSeconds(2f);
    }
}
