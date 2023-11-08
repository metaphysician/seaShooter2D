using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class UI_Manager : MonoBehaviour
{
   [SerializeField] TMP_Text _scoreUI;
   [SerializeField] SpriteRenderer[] playerLifeIcons;
   [SerializeField] TMP_Text _gameOver;
   


    // Start is called before the first frame update
    void Start()
    {
        _gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScoreText(string newScore)
    {
        _scoreUI.text = newScore;
    }

    public void UpdatePlayerLives(int lifeIcon)
    {
        playerLifeIcons[lifeIcon].enabled = false;
    }

    public void GameOver()
    {
        _gameOver.gameObject.SetActive(true);
        GameManager manager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if(manager != null)
            manager.GameOver_Restart();
    }
}
