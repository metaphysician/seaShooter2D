using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerCtrl _player;
    [SerializeField] private GameObject _enemyExplodes;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Player2D") != null)
            _player = GameObject.Find("Player2D").GetComponent<PlayerCtrl>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > -6.6f)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 4.0f);
        }
        else
        {
            if(GameObject.Find("Player2D") != null)
            {
                Vector3 newSpawnPoint = new Vector3(Random.Range(-9.7f,9.7f),6.6f,0);
                //Debug.Log(newSpawnPoint);
                transform.position = newSpawnPoint;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.GetComponent<PlayerCtrl>().DamagePlayer();
            ExplodeEnemy();
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("bullet"))
        {
            if(_player != null)
                _player.UpdateScore(10);
            Destroy(other.gameObject);
            ExplodeEnemy();
            Destroy(gameObject);
        }

    }

    void ExplodeEnemy()
    {
        GameObject explosion = GameObject.Instantiate(_enemyExplodes,transform.position,Quaternion.identity);
    }
}
