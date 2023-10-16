using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed = 10.0f;
    [SerializeField]
    private GameObject bulletObject;
    [SerializeField]
    private bool canFireBullet = true;
    [SerializeField]
    private int _playerLives;
    [SerializeField]
    private SpawnMgr _spawner;


    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      PlayerMovement();

      FireBullet();

      
    }

    void PlayerMovement()
    {
      //if player x position is within screen bounds
      if(Input.GetKey(KeyCode.D))
      {
        if (transform.position.x < 9.7f)
          transform.Translate(Vector3.right * Time.deltaTime * speed);
      }
      else if(Input.GetKey(KeyCode.A))
      {
        if(transform.position.x > -9.7f)
          transform.Translate(Vector3.left * Time.deltaTime * speed);
      }
      else if(Input.GetKey(KeyCode.W))
      {
        if (transform.position.y < 4.6f)
          transform.Translate(Vector3.up * Time.deltaTime * speed);
      }
      else if(Input.GetKey(KeyCode.S))
      {
        if (transform.position.y > -4.6f)
          transform.Translate(Vector3.down * Time.deltaTime * speed);
      }
    }

    void FireBullet()
    {
      if(Input.GetMouseButtonDown(0) && canFireBullet)
      {
        Debug.Log("Pressed the Mouse L Button");
        //set the vertical offset 
        float Yoffset = transform.position.y + 1.2f;
        //create Vector3 to store the new position
        Vector3 offset = new Vector3(transform.position.x,Yoffset,transform.position.z);
        //use the new Vector3 to spawn the object at the new position
        GameObject.Instantiate(bulletObject,offset,Quaternion.identity);
        canFireBullet = false;
        StartCoroutine(BulletCooldown());
      } 
    }

    public void DamagePlayer()
    {
      if(_playerLives > 0)
        _playerLives --;
      else
      {
        _spawner.StopSpawning();
        Destroy(gameObject);
      }
    }

    IEnumerator BulletCooldown()
    {
      yield return new WaitForSeconds(1.0f);
      canFireBullet = true;
    }


  }
