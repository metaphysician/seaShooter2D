using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _uiPauseMenu;
    [SerializeField] private bool _isGameOver = false;
    [SerializeField] private bool _isGamePaused = false;
    [SerializeField] private Animator _mothershipAnim;

    public enum GameState {Menu,Intro,Mothership,LevelUp,Gameplay,Interlude,Victory,Defeat}
    
    public GameState currentGameState;

    // Start is called before the first frame update
    void Start()
    {
        
        currentGameState = GameState.Intro;
        
    }

    public void UpdateStates()
    {
        switch(currentGameState)
        {
            case GameState.Menu:
            //load menu scene?
            break;
            case GameState.Intro:
            //play intro cutscene
            break;
            case GameState.Mothership:
            //play intro cutscene
            break;
            case GameState.LevelUp:
            
            break;
            case GameState.Gameplay:
            //show UI
            //start spawning enemies
            break;
            case GameState.Interlude:
            //stop spawning
            //bring mothership down
            break;
            case GameState.Victory:
            //winning UI
            //game is over
            break;
            case GameState.Defeat:
            //losing UI
            //game is over
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            _uiPauseMenu.SetActive(true);
            _isGamePaused = true;
            PauseGame();
        }
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

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void GameOver_Restart()
    {
        _isGameOver = true;
    }

    public void Continue()
    {
        Debug.Log("Clicked Continue!");
        Time.timeScale = 1.0f;
        _uiPauseMenu.SetActive(false); 
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Menu()
    {
        SceneManager.LoadScene("mainMenu");
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
