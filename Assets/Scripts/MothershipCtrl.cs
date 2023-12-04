using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipCtrl : MonoBehaviour
{
    [SerializeField]private GameManager _manager;
    [SerializeField]private PlayerCtrl _player;
    [SerializeField]private Animator _mothershipAnim;
    [SerializeField]private Animator _powerupAnim;
    
    void Start()
    {
        _mothershipAnim = GetComponent<Animator>();
        _manager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _powerupAnim.gameObject.SetActive(false);
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Player"))
        {
            _mothershipAnim.SetBool("Entered",true);
            _manager.currentGameState = GameManager.GameState.Mothership;
        }
        else if(other.CompareTag("mothership"))
        {
            _powerupAnim.gameObject.SetActive(true);
            _powerupAnim.speed = 1.0f;
            _player.ChangePlayer("powerup");
            StartCoroutine(PoweringWait(2.2f));
            //trigger powerup SFX
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //_mothershipAnim.SetBool("Entered",true);
        }
    }

    IEnumerator PoweringWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _mothershipAnim.SetBool("Armed",true);
        _powerupAnim.gameObject.SetActive(false);
        _player.ChangePlayer("gameplay");
        _manager.currentGameState = GameManager.GameState.Gameplay;
        _manager.UpdateStates();
    }

}
