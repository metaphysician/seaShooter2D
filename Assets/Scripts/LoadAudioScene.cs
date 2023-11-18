using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAudioScene : MonoBehaviour
{
    public string audioSceneName;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!SceneManager.GetSceneByName(audioSceneName).isLoaded)
        {
            SceneManager.LoadScene(audioSceneName, LoadSceneMode.Additive);
            
        }
    }

}
