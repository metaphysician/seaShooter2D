using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMgr : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _enemySpawner;
    [SerializeField]
    private bool _stopEnemies = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopSpawning()
    {
        _stopEnemies = true;
    }

    IEnumerator SpawnEnemies()
    {
        while(!_stopEnemies)
        {
            float waitTime = Random.Range(4.0f,7.0f);
            yield return new WaitForSeconds(waitTime);
            Vector3 newSpawnPoint = new Vector3(Random.Range(-9.7f,9.7f),6.6f,0);
            GameObject newEnemy = GameObject.Instantiate(_enemy,newSpawnPoint,Quaternion.identity);
            newEnemy.transform.parent = _enemySpawner.transform;
        }
    }
}
