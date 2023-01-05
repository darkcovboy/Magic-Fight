using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveIndex;
    private int _spawned;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveIndex);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        if (_currentWave.Count <= _spawned)
        {
            if (_waves.Count > _currentWaveIndex + 1)
                AllEnemySpawned?.Invoke();

            _currentWave = null;
        }
    }

    public void NextWave()
    {
        SetWave(++_currentWaveIndex);
        _spawned = 0;
    }

    private void InstantiateEnemy()
    {
        int currentSpawnPoint = Random.Range(0, _spawnPoints.Length);
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoints[currentSpawnPoint].position, _spawnPoints[currentSpawnPoint].rotation).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Diyng += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        StartCoroutine(SpawnEnemies());
        EnemyCountChanged?.Invoke(0, 1);
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Diyng -= OnEnemyDying;
        _player.AddMoney(enemy.Reward);
    }

    private IEnumerator SpawnEnemies()
    {
        while (_spawned < _currentWave.Count)
        {
            InstantiateEnemy();
            _spawned++;
            yield return new WaitForSecondsRealtime(_currentWave.Delay);
        }
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
