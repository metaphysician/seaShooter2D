using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipCtrl : MonoBehaviour
{
    [SerializeField]private GameManager _manager;
    [SerializeField]private Animator _mothershipAnim;
    [SerializeField]private Animator _powerupAnim;
    
    void Start()
    {
        _mothershipAnim = GetComponent<Animator>();
        _manager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    void Update()
    {}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _mothershipAnim.SetBool("Entered",true);
            _manager.currentGameState = GameManager.GameState.Mothership;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _mothershipAnim.SetBool("Entered",true);
        }
    }


}
