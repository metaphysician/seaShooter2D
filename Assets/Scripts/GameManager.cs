using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false;
    [SerializeField] private Animator _mothershipAnim;
    public enum GameState{Menu,Intro,Gameplay,Interlude,Victory,Defeat}
    
    public GameState currentGameState;

    // Start is called before the first frame update
    void Start()
    {
        currentGameState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isGameOver)
        {
            if(Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene("game");
        }
    }

    public void ShipControl(string state)
    {
        switch(state)
        {
            case "enter":
            _mothershipAnim.StartPlayback();
            break;
            case "descend":
            _mothershipAnim.SetBool("Entered",true);
            break;
            case "exit":
            _mothershipAnim.SetBool("Armed",true);
            break;
        }
    }

    public void GameOver_Restart()
    {
        _isGameOver = true;
    }

}
