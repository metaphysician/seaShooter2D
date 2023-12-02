using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    [SerializeField] private GameObject _bulletObject;
    [SerializeField] private GameObject _tripleShotObject;
    [SerializeField] private GameObject _shieldObject;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Animator _L_armAnimator;
    [SerializeField] private Animator _R_armAnimator;
    [SerializeField] private bool _canFireBullet = true;
    [SerializeField] private int _shotsFired = 0;
    [SerializeField] private bool _has3shotPowerup = false;
    [SerializeField] private bool _hasSpeedBoostPowerup = false;
    [SerializeField] private bool _hasShield = false;
    [SerializeField] private UI_Manager _UImanager;
    [SerializeField] private GameObject _playerSpriteObj;
    [SerializeField] private int _playerLives;
    [SerializeField] private GameObject _playerDamage1;
    [SerializeField] private GameObject _playerDamage2;
    [SerializeField] private Sprite _playerSingleGun;
    [SerializeField] private bool _oneLifeLeft=false;
    [SerializeField] private int _playerScore = 0;
    [SerializeField] private SpawnMgr _spawner;
    [SerializeField] private AudioManager _audioMgr;
    [SerializeField] private GameManager _gameMgr;
    

    // Start is called before the first frame update
    
    void Start()
    {
      ChangePlayer("intro");
      _gameMgr.currentGameState = GameManager.GameState.Intro;
      Cursor.lockState = CursorLockMode.Locked;
      _shieldObject.SetActive(false);

      _spawner = GameObject.Find("_SpawnManager").GetComponent<SpawnMgr>();
      _UImanager = GameObject.Find("UIManager").GetComponent<UI_Manager>();
      _audioMgr = GameObject.Find("AudioMgr").GetComponent<AudioManager>();

      if(_spawner == null)
        Debug.Log("No Spawn Mgr Found!");
      if (_UImanager == null)
        Debug.Log("No UI Manager Found!");

    }

    // Update is called once per frame
    void Update()
    {
      PlayerMovement();

      FireBullet();
    }

    void PlayerMovement()
    {
      if(_gameMgr.currentGameState != GameManager.GameState.LevelUp)
      {
        float Xmove = Input.GetAxis("Horizontal");
        float Ymove = Input.GetAxis("Vertical");
        if(Xmove + Ymove != 0)
        {
          _playerAnimator.speed = 1.0f;
        }
        else
        {
          _playerAnimator.speed = 0.0f;
        }

        Vector3 movePos = new Vector3(Xmove,Ymove,0);
        transform.Translate(Time.deltaTime * _speed * movePos);

        if(_gameMgr.currentGameState == GameManager.GameState.Mothership)
        {
          if(transform.position.y >= -0.33f)
          {
            Vector2 lockLocation = new Vector2(0,-0.33f);
            transform.position = lockLocation;
            //ChangePlayer("powerup");
            _gameMgr.currentGameState = GameManager.GameState.LevelUp;
          }
        }

        else
        {
        //clamp player position within screen bounds
        transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -9.7f, 9.7f), Mathf.Clamp(this.transform.position.y, -4.6f, 4.6f), this.transform.position.z);
        }
      }
      
    }
    

    void FireBullet()
    {
      if(_gameMgr.currentGameState == GameManager.GameState.Gameplay)
      {
        if(Input.GetMouseButtonDown(0) && _canFireBullet)
        {

          float Yoffset = transform.position.y;
          float Xoffset = transform.position.x;

          GameObject projectile = _bulletObject;
          
          if(!_has3shotPowerup)
          {
            _shotsFired ++;
            _shotsFired %= 2;
            if(_shotsFired == 0)
            {
              Xoffset = transform.position.x + 1.2f;
              Yoffset = transform.position.y + 1f;
              _R_armAnimator.Play("FireRight",-1,0.0f);
              _audioMgr.PlayGunSound();
            }
            else if(_shotsFired == 1)
            {
              if(!_oneLifeLeft)
              {
                Xoffset = transform.position.x + -0.9f;
                Yoffset = transform.position.y + 1.33f;
                _L_armAnimator.Play("FireLeft",-1,0.0f);
                _audioMgr.PlayGunSound();
              }
              else
              {
                Xoffset = transform.position.x + 1.2f;
                Yoffset = transform.position.y + 1f;
                _R_armAnimator.Play("FireRight",-1,0.0f);
                _audioMgr.PlayGunSound();
              }
            }
          }
          else
          {
            Xoffset = transform.position.x + 1.2f;
            Yoffset = transform.position.y + 1f;
            
            Vector3 offset2 = new Vector3(transform.position.x + -0.9f,transform.position.y + 1.33f,transform.position.z);
            GameObject.Instantiate(projectile,offset2,Quaternion.identity);
            _L_armAnimator.Play("FireLeft",-1,0.0f);
            _R_armAnimator.Play("FireRight",-1,0.0f);
            _audioMgr.PlayDoubleGunShots();
          }
            Vector3 offset = new Vector3(Xoffset,Yoffset,transform.position.z);
            GameObject.Instantiate(projectile,offset,Quaternion.identity);
            

          _canFireBullet = false;
          StartCoroutine(BulletCooldown());
        }
      }
    }

    public void ChangePlayer(string state)
    {
        if(state == "intro")
        {
            //activate intro player
            _playerSpriteObj = transform.Find("capsuleBody-start").gameObject;
            _playerSpriteObj.SetActive(true);
            //deactivate gameplay player
            transform.Find("capsuleBodyMuscle").gameObject.SetActive(false);
            //set animator to intro player   
        }
        else if (state == "powerup")
        {
            _playerSpriteObj.SetActive(false);
        }
        else if (state == "gameplay")
        {
            _playerSpriteObj = transform.Find("capsuleBodyMuscle").gameObject;
            _playerSpriteObj.SetActive(true);
            //deactivate gameplay player
            transform.Find("capsuleBody-start").gameObject.SetActive(false);
            //set animator to intro player
          //activate gameplay player
          //deactivate intro player
          //set animator to gameplay player
        }
        _playerAnimator = _playerSpriteObj.GetComponent<Animator>();
    }

    public void CollectTripleShot()
    {
      _has3shotPowerup = true;
      StartCoroutine(Powerup3shotTimer());
    }

    public void CollectSpeedBoost()
    {
      _hasSpeedBoostPowerup = true;
      _speed = 15.0f;
      StartCoroutine(SpeedBoostTimer());
    }

    public void CollectShield()
    {
      _hasShield = true;
      _shieldObject.SetActive(true);
    }

    public void DamagePlayer()
    {
      if(_hasShield)
      {
        _hasShield = false;
        _shieldObject.SetActive(false);
        return;
      }

      if(_playerLives > 0)
      {

        _playerLives --;
        _UImanager.UpdatePlayerLives(_playerLives);
        _audioMgr.PlayerSFX("damage");
        
        if (_playerLives == 2)
          _playerDamage1.SetActive(true);
        else if (_playerLives == 1)
          _playerDamage2.SetActive(true);
        else if (_playerLives == 0)
        {
          GetComponent<SpriteRenderer>().sprite = _playerSingleGun;
          _oneLifeLeft = true;
        }
      }
      else
      {
        _spawner.StopSpawning();
        _UImanager.GameOver();
        Destroy(gameObject);
      }
    }

    public void UpdateScore(int addedPoints)
    {
      _playerScore += addedPoints;
      string updatedScore = _playerScore.ToString();
      _UImanager.UpdateScoreText(updatedScore);
    }

    IEnumerator BulletCooldown()
    {
      yield return new WaitForSeconds(0.1f);
      _canFireBullet = true;
    }

    IEnumerator Powerup3shotTimer()
    {
      yield return new WaitForSeconds(5.0f);
      _has3shotPowerup = false;
    }

    IEnumerator SpeedBoostTimer()
    {
      yield return new WaitForSeconds(5.0f);
      _hasSpeedBoostPowerup = false;
      _speed = 10.0f;
    }


  }
