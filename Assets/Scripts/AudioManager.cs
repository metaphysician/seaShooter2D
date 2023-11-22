using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip _fireGun;
    [SerializeField] AudioClip _enemyExplodes;
    [SerializeField] AudioClip _playerDamage;
    [SerializeField] AudioClip _playerStepR;
    [SerializeField] AudioClip _playerStepL;

    [SerializeField] AudioSource _gunSource;
    [SerializeField] AudioSource _enemyExplosion;
    [SerializeField] AudioSource _playerSFX;
    [SerializeField] AudioSource _footSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGunSound()
    {
        _gunSource.PlayOneShot(_fireGun);
    }

    public void PlayDoubleGunShots()
    {
        StartCoroutine(TwoGunFireSound());
    }

    public void PlayEnemyExplodeSound()
    {
        _enemyExplosion.pitch = Random.Range(0.8f, 1.6f);
        _enemyExplosion.PlayOneShot(_enemyExplodes);
    }

    public void PlayerSFX(string type)
    {
        AudioClip clip = null;
        switch(type)
        {
            case "damage":
            clip = _playerDamage;
            break;
            case "powerup1":
            break;
            case "shield":
            break;
            case "speedUp":
            break;
        }
        _playerSFX.PlayOneShot(clip);
    }

    public void PlayFootSound_L()
    {
        _footSource.PlayOneShot(_playerStepL);
    }
    public void PlayFootSound_R()
    {
        _footSource.PlayOneShot(_playerStepR);
    }


    IEnumerator TwoGunFireSound()
    {
        _gunSource.pitch = 0.8f;
        _gunSource.PlayOneShot(_fireGun);
        yield return new WaitForSeconds(.03f);
        _gunSource.PlayOneShot(_fireGun);
        _gunSource.pitch = 1.0f;

    }
}
