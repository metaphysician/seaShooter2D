using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHandler : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int _powerupID;

    void Update()
    {
        if (transform.position.y > -6.6f)
        {
            transform.Translate(Vector3.down * Time.deltaTime * _speed);
        }
        else
        {
                Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerCtrl player = other.transform.gameObject.GetComponent<PlayerCtrl>();
            if(player != null)
            {
                switch(_powerupID)
                {
                   case 0:
                     player.CollectTripleShot();
                   break;
                   case 1:
                     player.CollectSpeedBoost();
                   break;
                   case 2:
                     player.CollectShield();
                   break;
                }
                Destroy(gameObject);
            }
        }
    }
}
