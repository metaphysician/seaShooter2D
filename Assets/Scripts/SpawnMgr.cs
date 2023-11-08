using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMgr : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _enemySpawner;
    [SerializeField] private GameObject _3shotPowerup;
    [SerializeField] private GameObject _speedPowerup;
    [SerializeField] private GameObject _shieldPowerup;
    [SerializeField] private bool _stopSpawning = false;
    [SerializeField] private float _spawnRateMin;
    [SerializeField] private float _spawnRateMax;
    [SerializeField]
    private int _countEnemies;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public void StopSpawning()
    {
        _stopSpawning = true;
    }

    void Spawn3shotPowerup()
    {
        Vector3 newSpawnPoint = new Vector3(Random.Range(-9.7f,9.7f),6.6f,0);
        GameObject newPowerup = GameObject.Instantiate(_3shotPowerup,newSpawnPoint,Quaternion.identity);
    }

    void SpawnSpeedPowerup()
    {
        Vector3 newSpawnPoint = new Vector3(Random.Range(-9.7f,9.7f),6.6f,0);
        GameObject newPowerup = GameObject.Instantiate(_speedPowerup,newSpawnPoint,Quaternion.identity);
    }

    void SpawnShieldPowerup()
    {
        Vector3 newSpawnPoint = new Vector3(Random.Range(-9.7f,9.7f),6.6f,0);
        GameObject newPowerup = GameObject.Instantiate(_shieldPowerup,newSpawnPoint,Quaternion.identity);
    }

    IEnumerator SpawnEnemies()
    {
        while(!_stopSpawning)
        {
            float waitTime = Random.Range(_spawnRateMin,_spawnRateMax);
            yield return new WaitForSeconds(waitTime);
            Vector3 newSpawnPoint = new Vector3(Random.Range(-9.7f,9.7f),6.6f,0);
            GameObject newEnemy = GameObject.Instantiate(_enemy,newSpawnPoint,Quaternion.identity);
            newEnemy.transform.parent = _enemySpawner.transform;
            _countEnemies++;
            
            //check how many enemies have been spawned
            if(_countEnemies % 10 == 0)
            Spawn3shotPowerup();

            //check how many enemies have been spawned
            if(_countEnemies % 14 == 0)
            SpawnSpeedPowerup();

            //check how many enemies have been spawned
            if(_countEnemies % 8 == 0)
            SpawnShieldPowerup();
        }
    }

    


}
