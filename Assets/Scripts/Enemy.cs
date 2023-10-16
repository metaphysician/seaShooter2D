using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
                Debug.Log(newSpawnPoint);
                transform.position = newSpawnPoint;
            }
            else
                Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.GetComponent<PlayerCtrl>().DamagePlayer();
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
