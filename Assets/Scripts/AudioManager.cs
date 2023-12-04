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
    [SerializeField] AudioClip _playerShieldLoop;
    [SerializeField] AudioClip _mothershipLoop;
    [SerializeField] AudioClip _mothershipCutscene;
    [SerializeField] AudioClip _pickup2shot;
    [SerializeField] AudioClip _pickupShield;
    [SerializeField] AudioClip _pickupSpeed;
    [SerializeField] AudioClip _gameOver;



    [SerializeField] AudioSource _gunSource;
    [SerializeField] AudioSource _enemyExplosion;
    [SerializeField] AudioSource _playerSFX;
    [SerializeField] AudioSource _playerShieldLoopSFX;
    [SerializeField] AudioSource _footSource;
    [SerializeField] AudioSource _mothershipLoopSource;
    [SerializeField] AudioSource _mothershipCutsceneSource;


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
            case "2shot":
            clip = _pickup2shot;
            break;
            case "shield":
            clip = _pickupShield;
            break;
            case "speedUp":
            clip = _pickupSpeed;
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

    public void PlayPlayerShieldLoop()
    {
        _playerShieldLoopSFX.clip = _playerShieldLoop;
        _playerShieldLoopSFX.Play();
        _playerShieldLoopSFX.loop = true;
    }

    public void PlayGameOver()
    {
        _playerSFX.clip = _gameOver;
        _playerSFX.Play();
    }


    public void PlayMothershipLoop()
    {
        if(!_mothershipLoopSource.isPlaying)
        {
            _mothershipLoopSource.clip = _mothershipLoop;
            _mothershipLoopSource.Play();
            _mothershipLoopSource.loop = true;
        }
    }

    public void PlayMothershipCutscene()
    {
        _mothershipLoopSource.loop = false;
        _mothershipLoopSource.clip = _mothershipCutscene;
        _mothershipLoopSource.Play();
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
