using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool _isEnemySpore = false;
    private float _direction = 1.0f;
    private float _velocity = 12.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetEnemySpore()
    {
        _isEnemySpore = true;
        _velocity = 6.0f;
        _direction = -1.0f; 
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 6.6f && transform.position.y > -6.6f)
        {
          Vector2 direction = new Vector2(0,_direction);
          transform.Translate(direction * Time.deltaTime * _velocity);
        }
        else
        {
            if(transform.parent != null)
                Destroy(transform.parent.gameObject);
            Destroy(this.gameObject);
        } 
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(_isEnemySpore && other.gameObject.CompareTag("Player"))
        {
            other.transform.GetComponent<PlayerCtrl>().DamagePlayer();
            //ExplodeEnemy();
            Destroy(gameObject);
        }

    }
}
