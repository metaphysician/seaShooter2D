using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHandler : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private int _powerupID;
    [SerializeField] private AudioManager _audioMgr;

    void Start()
    {
      _audioMgr = GameObject.Find("AudioMgr").GetComponent<AudioManager>();

    }
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
                     _audioMgr.PlayerSFX("2shot");
                   break;
                   case 1:
                     player.CollectSpeedBoost();
                     _audioMgr.PlayerSFX("speedUp");
                   break;
                   case 2:
                     player.CollectShield();
                     _audioMgr.PlayerSFX("shield");
                   break;
                }
                Destroy(gameObject);
            }
        }
    }
}
